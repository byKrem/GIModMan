using System;
using System.Linq;
using System.Collections.Generic;

namespace GIModMan.Extensions
{
    internal static class TypeExtension
    {
        internal static IEnumerable<string> GetCustomAttributesNames(this Type type)
        {
            var customAttributes = type.GetProperties().Select(x => x.CustomAttributes).Where(x => x.Any()).ToList();

            foreach(var customAttribute in customAttributes)
            {
                yield return customAttribute.Select(x => x.ConstructorArguments[0].Value).First().ToString();
            }
        }
    }
}
