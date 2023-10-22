using System.Runtime.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace MietHack_10_2023
{
    public static class EnumUtils
    {
        public static T TryGetCustomAttribute<T>(this Enum value)
    where T : Attribute
        {
            var stringValue = value.ToString();

            return
                value
                    .GetType()
                    .GetMember(stringValue)
                    .FirstOrDefault()
                    ?.GetCustomAttribute<T>();
        }

        public static string GetMemberValue(this Enum value) =>
            value.TryGetCustomAttribute<EnumMemberAttribute>()?.Value ?? value.ToString();
    }
}
