using ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface;

namespace ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get; }
        public IUsersRepository Users { get; }

        public UnitOfWork(ICustomerRepository customers, IUsersRepository users)
        {
            Customers = customers;
            Users = users;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
