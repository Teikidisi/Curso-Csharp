using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class CuentaCredito : Account
    {
        public int creditlimit { get; set; }
        public CuentaCredito(string name, decimal initialBalance, int creditLimit) : base(name, initialBalance, -creditLimit)
        {
            creditlimit = creditLimit;

        }

        public override void FinMes()
        {
            decimal balance = GetTransactionListBalance(TransactionList);
            if (balance < creditlimit)
            {
                decimal balanceInteres = (creditlimit - balance) * 0.07m;
                Console.WriteLine("interes " + balanceInteres+" se creo con balance de "+(balance-creditlimit));
                balance = balance - balanceInteres;
                Console.WriteLine("Balance "+balance);
                Withdrawal(balanceInteres, DateTime.Now, "Quitar credito de fin de mes");
            }
        }
        public override void Withdrawal(decimal amount, DateTime date, string description)
        {
            if (amount < 0)
                Console.WriteLine("El retiro debe ser mayor a 0.");

            var withdrawal = new Transaction(-amount, date, description);
            TransactionList.Add(withdrawal);
        }

    }
}
