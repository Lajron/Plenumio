using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenumio.Core.Enums;
using Plenumio.Common.StaticData;

namespace Plenumio.Web.Extensions {
    public static class PrivacyTypeExtensions {
        public static string ToDisplayString(this PrivacyType privacyType) {
            return privacyType switch {
                PrivacyType.Public => Text.PrivacyType.Public,
                PrivacyType.Private => Text.PrivacyType.Private,
                PrivacyType.FollowersOnly => Text.PrivacyType.FollowersOnly,
                _ => privacyType.ToString()
            };
        }
    }
}
