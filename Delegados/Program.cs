Main.MainMethod();
Message.Show();
Message2.Show("Another way");

class Main{
    delegate void Delegation();
    delegate void Del2(string message);

    public static void MainMethod()
    {
        Delegation del = new Delegation(Message.Show);
        del();

        Del2 del2 = new Del2(Message2.Show);
        del2("Goodbye World");
    }

}

class Message
{
    public static void Show()
    {
        Console.WriteLine("Hello World");
    }
}

class Message2
{
    public static void Show(string message)
    {
        Console.WriteLine(message);
    }
}