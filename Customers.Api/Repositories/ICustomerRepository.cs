using Customers.Api.Contracts.Data;
using Customers.Api.Domain;

namespace Customers.Api.Repositories;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerDto customer);

    Task<CustomerDto?> GetAsync(Guid id);

    Task<IEnumerable<CustomerDto>> GetAllAsync();

    Task<bool> UpdateAsync(CustomerDto customer, DateTime requestStarted);

    Task<bool> DeleteAsync(Guid id);
    Task<CustomerDto?> GetByEmailAsync(string email);
}
