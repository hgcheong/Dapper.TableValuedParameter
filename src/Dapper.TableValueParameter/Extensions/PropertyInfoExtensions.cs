﻿using System;
using System.Linq;
using System.Reflection;

namespace Dapper.TableValuedParameter.Extensions
{
    /// <summary>
    ///     PropertyInfo Extensions
    /// </summary>Dapper.TableValueParameter
    internal static class PropertyInfoExtensions
    {
        public static T GetAttribute<T>(this PropertyInfo property) where T : class
        {
            var attribute = property.GetCustomAttributes(typeof(T), true).SingleOrDefault();

            return Convert.ChangeType(attribute, conversionType: typeof(T)) as T;
        }
    }
}
