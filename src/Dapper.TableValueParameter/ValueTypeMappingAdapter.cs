using System;
using System.Collections.Generic;

using Microsoft.SqlServer.Server;

namespace Dapper.TableValuedParameter
{
    internal class ValueTypeMappingAdapter : ITypeMappingAdapter
    {
        public IEnumerator<SqlDataRecord> Map(Type type, IEnumerable<object> tableValuedList, TypeSqlDbTypeMap typeSqlDbTypeMap, string parameterName = null)
        {
            var metaData = new SqlMetaData[1]
            {
                new SqlMetaData(parameterName, typeSqlDbTypeMap.GetSqlDbType(type))
            };

            foreach (object item in tableValuedList)
            {
                var sqlDataRecord = new SqlDataRecord(metaData);
                try
                {
                    sqlDataRecord.SetValues(item);
                }
                catch (Exception exception)
                {
                    throw new ArgumentException("An error occured while setting SqlDbValues.", exception);
                }

                yield return sqlDataRecord;
            }
        }
    }
}
