using Plenumio.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Validation {
    internal static class ValidationExtensions {
        public static T ValidateNotNull<T>(this T obj, string paramName) {
            if (obj == null) throw new ValidationException($"{paramName} - Must not be null.");
            return obj;
        }
        public static T ValidateIsNull<T>(this T obj, string paramName) {
            if (obj != null) throw new ValidationException($"{paramName} - Must be null.");
            return obj;
        }

        public static string ValidateNotEmpty(this string str, string paramName) {
            str = str?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(str)) throw new ValidationException($"{paramName} - Must not be empty.");
            return str;
        }

        public static string ValidateIsEmpty(this string str, string paramName) {
            if (!string.IsNullOrWhiteSpace(str)) throw new ValidationException($"{paramName} - Must be empty.");
            return str;
        }

        public static IEnumerable<T> ValidateNotEmpty<T>(this IEnumerable<T> obj, string paramName) {
            if (obj == null || !obj.Any()) throw new ValidationException($"{paramName} - Must not be empty.");
            return obj;
        }
        public static IEnumerable<T>? ValidateIsEmpty<T>(this IEnumerable<T> obj, string paramName) {
            if (obj != null && obj.Any()) throw new ValidationException($"{paramName} - Must be empty.");
            return obj;
        }

        public static string ValidateMaxLength(this string str, int maxLength, string paramName) {
            if (str.Length > maxLength) throw new ValidationException($"{paramName} - Must not exceed {maxLength} characters.");
            return str;
        }

        public static string ValidateMinLength(this string str, int minLength, string paramName) {
            if (str.Length < minLength) throw new ValidationException($"{paramName} - Must be at least {minLength} characters long.");
            return str;
        }

        public static T IsNotEqualTo<T>(this T obj, T other, string paramName) where T : IEquatable<T> {
            if (obj.Equals(other)) throw new ValidationException($"{paramName} - Must not be equal to {other}.");
            return obj;
        }


    }
}
