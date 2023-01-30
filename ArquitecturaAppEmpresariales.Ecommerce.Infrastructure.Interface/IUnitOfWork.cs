namespace ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
