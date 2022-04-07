using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class GiftCardAccount : Account
    {
        public int minimumBalance { get; set; }

        public GiftCardAccount(string name, decimal initialBalance, int minimumBalance) : base(name, initialBalance, minimumBalance  )
        {
            //minimumBalance = 0;

        }

        public void PrintHistory()
        {
            foreach (var item in TransactionList)
            {
                Console.WriteLine($"En la fecha {item.Date} se hizo la transaccion \"{item.Description}\" por una cantidad de ${item.Amount}");
                Console.WriteLine(minimumBalance);
            }
        }

        
    }
}
