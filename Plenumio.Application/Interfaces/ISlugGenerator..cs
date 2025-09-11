using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface ISlugGenerator {
        string Create(string s);
        string GenerateTagSlug(string tag);
        string GeneratePostSlug(string content, string? title);
        string GenerateUsername(string username);
    }
}
