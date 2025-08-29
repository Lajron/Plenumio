using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Repositories {
    public class TagRepository(ApplicationDbContext db)
        : BaseRepository<Tag>(db), ITagRepository {


        public async Task<ICollection<PostTag>> ResolveTagsAsync(Dictionary<string, string> tags) {
            if (tags.Count == 0) return [];

            HashSet<string> tagNames = tags.Keys.ToHashSet();

            Dictionary<string, Tag> existingTags = await _dbSet
                .Where(tag => tagNames.Contains(tag.Name))
                .ToDictionaryAsync(tag => tag.Name, tag => tag);

            IEnumerable<Tag> newTags = tags
                .Where(tag => !existingTags.ContainsKey(tag.Key))
                .Select(tag => new Tag {
                    Name = tag.Key,
                    DisplayedName = tag.Value,
                });

            List<PostTag> allTags = newTags.Concat(existingTags.Values)
                .Select(tag => new PostTag { Tag = tag })
                .ToList();

            return allTags;
        }
    }
}
