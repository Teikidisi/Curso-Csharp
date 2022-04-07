using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class CuentaInteres : Account
    {
        //cuenta de 5% interes arriba de un balance de 500 pejecoins

        public CuentaInteres(string name, decimal initialBalance) : base(name, initialBalance)
        {

        }

        public override void FinMes()
        {
            decimal balance = GetTransactionListBalance(TransactionList);
            if (balance >= 500)
            {
                decimal balanceGanancia = balance * 0.05m;
                Deposit(balanceGanancia, DateTime.Now, "Has generado interés");
            }
        }
    }
}
