using ArquitecturaAppEmpresariales.Ecommerce.Domain.Entity;
using ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Common;
using Dapper;
using System.Data;

namespace ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
