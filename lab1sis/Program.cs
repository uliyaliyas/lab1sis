using lab1sis;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank(1000, "MyBank", 5);

        bank.Money = 1500;
        bank.Name = "NewBank";
        bank.Percent = 6;

        Console.WriteLine($"Банк 1:{bank.Money},{bank.Name},{bank.Percent}");
    }
}