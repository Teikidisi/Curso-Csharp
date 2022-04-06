Console.WriteLine("Please enter the name of your event: ");
string evento = Console.ReadLine();

Console.WriteLine("How many days before do you want a reminder? Use only the number:");
string reminderDay = Console.ReadLine();

if (Int32.TryParse(reminderDay, out int reminderDays))
{
    Console.WriteLine("Please put the date of the event using dd/mm/yyyy:");
    string eventDate = Console.ReadLine();

    if (DateTime.TryParseExact(eventDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime eventInDate))
    {
        
        Console.WriteLine("What is the current date? dd/mm/yyyy");
        string currentDate = Console.ReadLine();

        if (DateTime.TryParseExact(currentDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime currentInDate))
        {
            if (eventInDate.CompareTo(currentInDate) < 0)
            {
                Console.WriteLine("The event date has already passed.");
            } 
            else if (eventInDate.CompareTo(currentInDate) > 0)
            {
                DateTime reminderDate = eventInDate.AddDays(-Math.Abs(reminderDays));
                Console.WriteLine("A reminder has been set for {0}",reminderDate.ToString());
                await DateCounter.DateToReminder(reminderDate, eventInDate, currentInDate);
                Console.WriteLine("{0} is today! Get there before it starts!", char.ToUpper(evento[0])+evento.Substring(1));
            } 
            else
            {
                Console.WriteLine("The date is today!!");
            }
        }
        else
        {
            Console.WriteLine("The date is not valid");
        }

    }
    else
    {
        Console.WriteLine("The date is not valid");
    }
}
else
{
    Console.WriteLine("The days are not valid");
}


public class DateCounter
{
    public static async Task DateToReminder(DateTime reminderDate, DateTime eventDate, DateTime currentDate)
    {
        double DaysToReminder;
        if(currentDate < reminderDate)
        {
             DaysToReminder = eventDate.Subtract(reminderDate).TotalDays;
        }
        else
        {
            DaysToReminder = eventDate.Subtract(currentDate).TotalDays;
        }
        var DaysToEvent = eventDate.Subtract(currentDate).TotalDays;
        double reminderDays = DaysToReminder;
        while (DaysToEvent > 0 )
        {
            await Task.Delay(500);
            DaysToEvent -= 1;
            currentDate = currentDate.AddDays(1);
            
            if (DaysToEvent <= DaysToReminder)
            {
                Console.WriteLine($"The event is in {reminderDays} days.");
                reminderDays--;
            }
            else
            {
                Console.WriteLine($"\t{currentDate.ToShortDateString()}");
            }
        }
    }
}
