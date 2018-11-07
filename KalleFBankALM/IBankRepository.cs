using System.Linq;

namespace KalleFBankALM
{
    public interface IBankRepository
    {
        //IQueryable<Account> Accounts { get; }
        IQueryable<Customer> Customers { get; }
    }
}
