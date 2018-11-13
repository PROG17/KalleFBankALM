using System.Linq;
using KalleFBankALM.ViewModels;

namespace KalleFBankALM
{
    public interface IBankRepository
    {
        //IQueryable<Account> Accounts { get; }
        IQueryable<Customer> Customers { get; }
        TransferViewModel Transfer(TransferViewModel model);
        Account GetAccountById(string accountNumber);
    }
}
