using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Dapper.TableValuedParameter.Extensions;

using Microsoft.SqlServer.Server;

namespace Dapper.TableValuedParameter
{
    internal class GenericTableValuedParameter : IEnumerable<SqlDataRecord>
    {
        private readonly string _parameterName;
        private readonly IEnumerable<object> _tableValuedList;
        private readonly TypeSqlDbTypeMap _typeSqlDbTypeMap;

        public GenericTableValuedParameter(
            string parameterName,
            IEnumerable<object> tableValuedList,
            TypeSqlDbTypeMap typeSqlDbTypeMap)
        {
            _parameterName = parameterName;
            _tableValuedList = tableValuedList;
            _typeSqlDbTypeMap = typeSqlDbTypeMap;
        }

        public IEnumerator<SqlDataRecord> GetEnumerator()
        {
            Type type = _tableValuedList.GetType().GetGenericArguments().Single();

            ITypeMappingAdapter typeMappingHandler;
            if (type.IsValueType())
            {
                typeMappingHandler = new ValueTypeMappingAdapter();
            }
            else
            {
                typeMappingHandler = new ReferenceTypeMappingAdapter();
            }

            return typeMappingHandler.Map(type, _tableValuedList, _typeSqlDbTypeMap, _parameterName);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
