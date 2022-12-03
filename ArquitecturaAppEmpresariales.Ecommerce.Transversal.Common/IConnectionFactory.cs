using System.Data;

namespace ArquitecturaAppEmpresariales.Ecommerce.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection? GetConnection { get; }
    }
}
