using ArquitecturaAppEmpresariales.Ecommerce.Domain.Entity;

namespace ArquitecturaAppEmpresariales.Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Métodos Síncronos

        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);

        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
