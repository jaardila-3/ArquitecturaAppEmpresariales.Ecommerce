using ArquitecturaAppEmpresariales.Ecommerce.Domain.Entity;

namespace ArquitecturaAppEmpresariales.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
