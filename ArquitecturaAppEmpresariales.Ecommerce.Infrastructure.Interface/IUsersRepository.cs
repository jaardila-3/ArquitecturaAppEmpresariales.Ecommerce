using ArquitecturaAppEmpresariales.Ecommerce.Domain.Entity;

namespace ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
