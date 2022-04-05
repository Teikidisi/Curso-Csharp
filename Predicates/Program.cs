Predicate<int> predicate = new Predicate<int>(GetPairs);
Predicate<int> predicate2 = new Predicate<int>(GetPrimes);

List<int> list = new List<int>();
list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

List<int> result = list.FindAll(predicate);
List<int> result2 = list.FindAll(predicate2);
foreach(var item in result2)
{
    Console.WriteLine(item);
}


static bool GetPairs(int num)
{
    if (num % 2 == 0) return true;
    else return false;
}

static bool GetPrimes(int num)
{
    //    bool primo = true;
    //for (int i = 0; i <= num; i++)
    //{
    //    if (num % i == 0) return true;
    //    else { return false;}
    //}
    Console.WriteLine("-");
    if (num == 1)
    {
        return true;
    }
    if (num % 2 == 0 && num / 2 ==1)
    {
        return true;
    }
    if (num % 7 == 0 && num / 7 == 1)
    {
        return true;
    }
    if (num % 5 == 0 && num / 5 == 1)
    {
        return true;
    }
    if (num % 3 == 0 && num / 3 == 1)
    {
        return true;
    }
    else { return false; }
}