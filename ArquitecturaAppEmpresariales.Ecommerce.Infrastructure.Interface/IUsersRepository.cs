using ArquitecturaAppEmpresariales.Ecommerce.Domain.Entity;

namespace ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);
    }
}
