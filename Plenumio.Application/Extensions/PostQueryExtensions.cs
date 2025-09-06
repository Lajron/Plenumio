using Azure;
using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Plenumio.Application.Extensions {
    public static class PostQueryExtensions {
        public static IQueryable<Post> ApplyPrivacyFilter(this IQueryable<Post> query, Guid? currentUserId) {
            if (currentUserId is null) {
                return query.Where(p => p.Privacy == PrivacyType.Public);
            }

            return query.Where(p =>
                p.Privacy == PrivacyType.Public ||
                p.ApplicationUserId == currentUserId ||
                (p.Privacy == PrivacyType.Followers &&
                 p.ApplicationUser!.Followers.Any(f => f.FollowerId == currentUserId))
            );
        }

        public static IQueryable<Post> FilterByOwner(this IQueryable<Post> query, Guid? ownerId) {
            return ownerId is null ? query : query.Where(p => p.ApplicationUserId == ownerId);
        }

        public static IQueryable<Post> FilterByOwners(this IQueryable<Post> query, List<Guid> ownerIds) {
            return ownerIds?.Any() == true ? query.Where(p => ownerIds.Contains(p.ApplicationUserId)) : query;
        }

        public static IQueryable<Post> PersonalFeedFilter(this IQueryable<Post> query, Guid currentUserId, List<Guid> followingIds, List<Guid> followedTagIds) {
            // Personal feed = your posts + posts from people you follow
            return query.Where(p =>
                currentUserId == p.ApplicationUserId ||
                followingIds.Contains(p.ApplicationUserId) ||
                p.PostTag.Any(pt => followedTagIds.Contains(pt.TagId))
            );
        }

        public static IQueryable<Post> GlobalFeedFilter(this IQueryable<Post> query) {
            // Global feed = all posts (privacy will be applied separately)
            return query; // No additional filtering needed
        }

        public static IQueryable<Post> ForPersonalFeed(this IQueryable<Post> query, Guid currentUserId, List<Guid> followingIds, List<Guid> followedTagIds) {
            return query
                .PersonalFeedFilter(currentUserId, followingIds, followedTagIds)
                .ApplyPrivacyFilter(currentUserId);
        }

        public static IQueryable<Post> ForGlobalFeed(this IQueryable<Post> query, Guid? currentUserId) {
            return query
                .GlobalFeedFilter()
                .ApplyPrivacyFilter(currentUserId);
        }

        public static IQueryable<Post> ForUserProfile(this IQueryable<Post> query, Guid profileUserId, Guid? viewerUserId) {
            var result = query.FilterByOwner(profileUserId);

            // If viewing someone else's profile, apply privacy
            if (viewerUserId != profileUserId) {
                result = result.ApplyPrivacyFilter(viewerUserId);
            }

            return result;
        }

        public static IQueryable<Post> WhereProfile(this IQueryable<Post> query, Guid? profileId) {
            if (profileId == null)
                return query;
            return query.Where(p => p.ApplicationUserId == profileId);
        }

        public static IQueryable<Post> WhereTag(this IQueryable<Post> query, Tag? tag) {
            if (tag is null)
                return query;

            var tagIds = new List<Guid> { tag.Id };

            if (tag.ParentId is not null) 
                tagIds.Add(tag.ParentId.Value);

            return query.Where(p => p.PostTag.Any(pt => tagIds.Contains(pt.TagId)));

        }
    }
}
