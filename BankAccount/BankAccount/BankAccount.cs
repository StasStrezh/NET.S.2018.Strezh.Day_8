using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Class with logic for bank account
    /// </summary>
    public sealed class Account
    {
        /// <summary>
        /// Private fields
        /// </summary>
        private long _accnumber;
        private string _ownername;
        private double _accbalance;
        private string _acclevel;
        private long _accbonus;

        /// <summary>
        /// Property for account number
        /// </summary>
        public long AccountNumber
        {
            get => _accnumber;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Account number can't be empty");
                if (value < 16)
                    throw new ArgumentException("Wrong account number, please try again!");
                _accnumber = value;
            }
        }
        /// <summary>
        /// Property for owner info
        /// </summary>
        public string OwnerName
        {
            get => _ownername;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Account must have owner name!");
                _ownername = value;
            }
        }
        /// <summary>
        /// Property for account balance
        /// </summary>
        public double AccountBalance
        {
            get => _accbalance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance can't be less then zero");
                _accbalance = value;
            }
        }
        /// <summary>
        /// Property for account level
        /// </summary>
        public string AccountLevel
        {
            get => _acclevel;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Bank account must have the level");
                _acclevel = value;
            }
        }
        /// <summary>
        /// Property for bonuses
        /// </summary>
        public long AccountBonus
        {
            get => _accbonus;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Bonuses can't be less then 0");
                _accbonus = value;
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="accountnumber"></param>
        /// <param name="ownername"></param>
        /// <param name="accountbalance"></param>
        /// <param name="accountlevel"></param>
        public Account(long accountnumber, string ownername, double accountbalance, string accountlevel)
        {
            AccountNumber = accountnumber;
            OwnerName = ownername;
            AccountBalance = accountbalance;
            AccountLevel = accountlevel;
        }
        /// <summary>
        /// Method for ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
                $"{AccountNumber} {AccountLevel} - {OwnerName} - {AccountBalance}";

        /// <summary>
        /// Status of account - closed or not
        /// </summary>
        public bool IsClosed { get; private set; }
        public void Close()
        {
            IsClosed = true;
        }

        /// <summary>
        /// Method for debit
        /// </summary>
        /// <param name="amount"></param>
        public void Debit(double amount)
        {
            if (IsClosed)
            {
                throw new InvalidOperationException($"Account is closed. All operations are unavailable.");
            }

            AccountBalance += amount;
            AccountBonus += (long)((DebitBalanceCoeff * AccountBalance) + (DebitValueCoeff * amount));
        }

        /// <summary>
        /// Method for withdrow
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(double amount)
        {
            if (IsClosed)
            {
                throw new InvalidOperationException($"Account is closed. All operations are unavailable.");
            }

            AccountBalance -= amount;
            AccountBonus -= (long)((WithdrawBalanceCoeff * AccountBalance) + (WithdrawValueCoeff * amount));
        }

        /// <summary>
        /// Coefficients
        /// </summary>
        public int DebitBalanceCoeff => 1;
        public int DebitValueCoeff => 3;
        public int WithdrawBalanceCoeff => 1;
        public int WithdrawValueCoeff => 1;
    }
}
