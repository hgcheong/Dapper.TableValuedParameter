using System;
using System.Collections.Generic;

using Microsoft.SqlServer.Server;

namespace Dapper.TableValuedParameter
{
    internal interface ITypeMappingAdapter
    {
        IEnumerator<SqlDataRecord> Map(Type type, IEnumerable<object> tableValuedList, TypeSqlDbTypeMap typeSqlDbTypeMap, string parameterName);
    }
}
