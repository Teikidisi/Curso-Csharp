using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal Balance { get
            {
                decimal balance = 0;
                foreach(var transaction in TransactionList)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        public List<Transaction> TransactionList = new List<Transaction>();

        private readonly decimal _minimumBalance; //como es privada no hace falta agregar getset porque nadie la puede acceder
        //readonly no se puede modificar el valor una vez declarado
        private static int accountNumberSeed = 1234567890; //el static es para que nuevas cuentas puedan accesar el seed actual e iterarlo (ser un seed diferente a cada cuenta)

        public Account(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public Account(string name, decimal initialBalance, decimal minimumBalance)
        {
            Owner = name;
            _minimumBalance = minimumBalance;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            if (initialBalance > 0)
            {
                Deposit(initialBalance, DateTime.Now, "Balance inicial");
            }
        }

        public void Deposit(decimal amount, DateTime date, string description)
        {
            if (amount < 0)
                Console.WriteLine("El depósito debe ser mayor a 0.");

            var deposit = new Transaction(amount, date, description);
            TransactionList.Add(deposit);
        }

        public virtual void Withdrawal(decimal amount, DateTime date, string description)
        {
            if (amount < 0)
                Console.WriteLine("El retiro debe ser mayor a 0.");

            var transaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance); //regresa clase Transaction
            var withdrawal = new Transaction(-amount, date, description);
            TransactionList.Add(withdrawal);
        }

        protected virtual Transaction CheckWithdrawalLimit(bool isOverCharge)
        {
            if (isOverCharge)
            {
                throw new InvalidOperationException("No tienes fondos suficientes."); //si no hay fondos tira error y se cierra la app
            }
            else
            {
                return default; //regresa el valor default de la variable (valor general que se usa al no declarar valor a una variable)
            }
        }

        public static decimal GetTransactionListBalance( List<Transaction> TransactionList)
        {
            decimal balance = 0;
            foreach (var item in TransactionList)
            {
                balance += item.Amount;
            }
            return balance;
        }

        public string GetAccountHistory()
        {
            decimal balance = 0;
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tBalance\tDescription\t");
            foreach (var item in TransactionList)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Description}");
            }
            return report.ToString();
        }

        public virtual void FinMes()
        {

        }
    }
}
