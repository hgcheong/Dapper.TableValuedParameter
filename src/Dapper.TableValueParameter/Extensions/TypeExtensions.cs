using System;
using System.Reflection;

#if !NET461
using System.Linq;
#endif

namespace Dapper.TableValuedParameter.Extensions
{

    public static class TypeExtensions
    {
#if NET461
        public static Assembly Assembly(this Type type)
        {
            return type.Assembly;
        }

        public static bool IsValueType(this Type type)
        {
            return type.IsValueType;
        }
#else

        public static Assembly Assembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        public static bool IsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;

        }
#endif
    }
}