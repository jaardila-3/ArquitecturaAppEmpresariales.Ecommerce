using ArquitecturaAppEmpresariales.Ecommerce.Domain.Entity;
using ArquitecturaAppEmpresariales.Ecommerce.Domain.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface;

namespace ArquitecturaAppEmpresariales.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomerRepository _customersRepository;
        public CustomersDomain(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region Métodos Síncronos

        public bool Insert(Customers customers)
        {
            return _customersRepository.Insert(customers);
        }

        public bool Update(Customers customers)
        {
            return _customersRepository.Update(customers);
        }

        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _customersRepository.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _customersRepository.InsertAsync(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _customersRepository.UpdateAsync(customers);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customersRepository.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        #endregion
    }
}
