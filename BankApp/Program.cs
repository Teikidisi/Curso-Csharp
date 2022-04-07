using BankApp;

var account = new Account("Rodrigo", 1000, 0);
Console.WriteLine($"Se creó cuenta con número {account.Number} con un saldo de {account.Balance} por el usuario {account.Owner}");
var giftAccount = new CuentaCredito("Jorge", 1500, 500);
var giftAccount2 = new CuentaInteres("Jorge", 1500);
Console.WriteLine($"Se creó cuenta con número {giftAccount.Number} con un saldo de {giftAccount.Balance} por el usuario {giftAccount.Owner}");

giftAccount.Deposit(2000, DateTime.Now.AddDays(-4), "Feliz Cumpleaños");
giftAccount.Withdrawal(500, DateTime.Now.AddDays(-2), "Chicles");
giftAccount.Withdrawal(4000, DateTime.Now, "Pago de gas");
giftAccount.Withdrawal(300, DateTime.Now, "comprar bonice");
giftAccount.FinMes();
giftAccount2.Deposit(2000, DateTime.Now.AddDays(-4), "Feliz Cumpleaños");
giftAccount2.Withdrawal(500, DateTime.Now.AddDays(-2), "Chicles");
//giftAccount2.Withdrawal(4000, DateTime.Now, "Pago de gas");
giftAccount2.Withdrawal(300, DateTime.Now, "comprar bonice");
giftAccount2.FinMes();
Console.WriteLine(giftAccount.GetAccountHistory());
Console.WriteLine("-------------------------------------");
Console.WriteLine(giftAccount2.GetAccountHistory());