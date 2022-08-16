namespace TestHotel.Common
{

    public class DbFactory : Disposable, IDbFactory
        {

            RepositoryContext dbContext;
            public DbFactory(RepositoryContext db)
            {
                dbContext = db;
            }

        public  void Dispose()
        {
                throw new NotImplementedException();
        }

        public RepositoryContext Init()
            {
                return dbContext;
                //return dbContext ?? (dbContext = new LogicLyncEntities());
            }

            protected override void DisposeCore()
            {
                if (dbContext != null)
                    dbContext.Dispose();
            }
    }


    
}
