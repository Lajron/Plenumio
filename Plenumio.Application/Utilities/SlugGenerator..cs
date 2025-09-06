using Azure.Core;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Plenumio.Application.Utilities {
    public static class SlugGenerator {
        public static string Create(string s) {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            // Normalize accents
            s = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in s) {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            s = sb.ToString().Normalize(NormalizationForm.FormC);

            // Lowercase, remove invalid chars, replace spaces
            s = s.ToLowerInvariant();
            s = Regex.Replace(s, @"[^\w\s-]", ""); // Remove punctuation/symbols
            s = Regex.Replace(s, @"\s+", "-");     // Replace spaces with hyphens
            s = Regex.Replace(s, @"-+", "-");      // Collapse multiple hyphens
            return s.Trim('-');                     // Trim leading/trailing hyphens
        }

        public static string GenerateTagSlug(string tag) {
            if (string.IsNullOrWhiteSpace(tag))
                return string.Empty;

            // Special replacements
            tag = tag.Replace("#", "Sharp"); // C# -> CSharp, F# -> FSharp, etc.

            return Create(tag);
        }

        public static string GeneratePostSlug(string content, string? title) {
            string baseSlug;

            if (string.IsNullOrWhiteSpace(title) || title == "" || title.Length < 5) {
                IEnumerable<string> words = content
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Take(5);
                baseSlug = Create(string.Join('-', words));
            } else {
                baseSlug = Create(title);
            }

            string guid = Guid.NewGuid().ToString("N");
            string randomSuffix = guid.Substring(guid.Length - 8); // take last 8 chars
            return $"{baseSlug}-{randomSuffix}";
        }

        public static string GenerateUsername(string username) {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            // Lowercase
            string slug = username.Trim().ToLowerInvariant();

            // Remove invalid characters (letters, digits, underscores, hyphens only)
            slug = Regex.Replace(slug, @"[^a-z0-9_-]", "");

            // Collapse multiple hyphens or underscores
            slug = Regex.Replace(slug, @"[-_]+", m => m.Value[0].ToString());

            // Trim leading/trailing hyphens or underscores
            slug = slug.Trim('-', '_');

            // Ensure minimum length (fallback if slug is empty)
            if (string.IsNullOrEmpty(slug))
                slug = "user" + Guid.NewGuid().ToString("N").Substring(0, 6);

            return slug;
        }
    }
}
