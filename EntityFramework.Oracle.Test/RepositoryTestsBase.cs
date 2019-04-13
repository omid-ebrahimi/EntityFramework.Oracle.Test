using System;
using System.Data.Entity;
using EntityFramework.Oracle.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFramework.Oracle.Test
{
    public abstract class RepositoryTestsBase<TDatabase> where TDatabase : DbContext, new()
    {
        public TDatabase Db { get; set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            Db = new TDatabase();
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            try
            {
                Db.Dispose();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [TestMethod]
        public void CRUD_ConnectionIsOK_Successful()
        {
            // Test db connection
            if (Db.TryGetOracleConnection()?.TryOpen() == false)
                return;

            // C
            var id = Create();

            // R
            Read(id);

            // U
            Update(id);

            // D
            Delete(id);
        }

        protected abstract decimal Create();

        protected abstract void Read(decimal id);

        protected abstract void Update(decimal id);

        protected abstract void Delete(decimal id);
    }
}
