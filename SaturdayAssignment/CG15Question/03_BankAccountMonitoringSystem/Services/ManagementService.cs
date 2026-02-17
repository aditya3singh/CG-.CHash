using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class BankUtility
    {
        private readonly SortedDictionary<decimal, List<Account>> _ledger
            = new SortedDictionary<decimal, List<Account>>();

        public void AddAccount(Account account)
        {
            account.Validate();

            if (_ledger.Values.Any(list => list.Any(a => a.Id == account.Id)))
                throw new CustomBaseException("Account number already exists.");

            if (!_ledger.ContainsKey(account.Balance))
                _ledger[account.Balance] = new List<Account>();

            _ledger[account.Balance].Add(account);
        }

        public void ProcessTransaction(string accountNumber, decimal amount, bool isDeposit)
        {
            Account target = null;
            decimal currentBalance = 0;

            foreach (var entry in _ledger)
            {
                target = entry.Value.FirstOrDefault(a => a.Id == accountNumber);
                if (target != null)
                {
                    currentBalance = entry.Key;
                    break;
                }
            }

            if (target == null) throw new AccountNotFoundException("Account not found.");

            decimal newBalance = isDeposit ? currentBalance + amount : currentBalance - amount;

            if (newBalance < 0) throw new InsufficientFundsException("Transaction denied: Insufficient funds.");

            _ledger[currentBalance].Remove(target);
            if (_ledger[currentBalance].Count == 0) _ledger.Remove(currentBalance);

            target.Balance = newBalance;
            AddAccount(target); 
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _ledger.Values.SelectMany(list => list);
        }
    }
}