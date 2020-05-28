using System;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext _context;

        public IGenericRepository<Product> Products { get; }

        public IGenericRepository<Role> Roles { get; }

        public IGenericRepository<User> Users { get; }

        private bool Disposed;

        public UnitOfWork(DataContext context, IGenericRepository<Product> products, IGenericRepository<Role> roles, IGenericRepository<User> users)
        {
            _context = context;
            Products = products;
            Roles = roles;
            Users = users;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
