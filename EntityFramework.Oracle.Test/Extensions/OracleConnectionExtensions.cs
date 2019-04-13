using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EntityFramework.Oracle.Test.Extensions
{
    public static class OracleConnectionExtensions
    {
        public static bool TryOpen(this OracleConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                // ignored
            }

            return connection.State == ConnectionState.Open;
        }
    }
}
