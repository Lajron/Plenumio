using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Repositories {
    public class TagRepository(
            ApplicationDbContext db,
            ISlugGenerator slugGenerator
        ) : BaseRepository<Tag>(db), ITagRepository {

        public async Task<ICollection<PostTag>> ResolveTagsAsync(IEnumerable<string> postTags) {
            if (postTags == null || !postTags.Any())
                return [];

            var incomingTagMap = postTags
                .Select(t => t.TrimStart('#').Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .GroupBy(t => slugGenerator.GenerateTagSlug(t)) 
                .ToDictionary(
                    g => g.Key, 
                    g => g.First(), 
                    StringComparer.OrdinalIgnoreCase
                );

            var incomingSlugs = incomingTagMap.Keys.ToList();

            var existingTags = await _dbSet
                .Where(tag => incomingSlugs.Contains(tag.Name)) 
                .ToDictionaryAsync(tag => tag.Name, tag => tag); 

            var newTagValues = incomingTagMap
                .Where(map => !existingTags.ContainsKey(map.Key))
                .Select(map => new Tag {
                    Name = map.Key, 
                    DisplayedName = map.Value
                })
                .ToList();

            var allResolvedTags = new List<Tag>();
            allResolvedTags.AddRange(existingTags.Values);
            allResolvedTags.AddRange(newTagValues);

            // G. Create the final collection of PostTag objects.
            return allResolvedTags
                .Select(tag => new PostTag { Tag = tag })
                .ToList();
        }
    }
}
