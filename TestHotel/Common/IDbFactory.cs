namespace TestHotel.Common
{
        public interface IDbFactory : IDisposable
        {
            RepositoryContext Init();
        }
    

}
