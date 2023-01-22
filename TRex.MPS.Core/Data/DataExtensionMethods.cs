using Microsoft.Data.SqlClient;

namespace TRex.MPS.Core.Data
{
    public static class DataExtensionMethods
    {
        public static T GetDataReaderValue<T>(SqlDataReader sqlDataReader, string fieldName)
        {
            var value = sqlDataReader[fieldName];

            return (T)value;
        }
    }
}