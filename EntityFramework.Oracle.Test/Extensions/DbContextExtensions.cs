using System;
using System.Data.Entity;
using Oracle.ManagedDataAccess.Client;

namespace EntityFramework.Oracle.Test.Extensions
{
    public static class DbContextExtensions
    {
        public static OracleConnection TryGetOracleConnection(this DbContext db)
        {
            OracleConnection connection = null;

            try
            {
                connection = (OracleConnection) db.Database.Connection;
            }
            catch (Exception)
            {
                // ignored
            }

            return connection;
        }
    }
}
