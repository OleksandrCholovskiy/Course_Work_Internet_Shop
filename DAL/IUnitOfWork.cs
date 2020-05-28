namespace DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> Products { get; }

        IGenericRepository<Role> Roles { get; }

        IGenericRepository<User> Users { get; }

        void Save();
        void Dispose();
    }
}
