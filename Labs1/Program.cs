using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

public class Ticket {

    public string Punkt { get; set; }
    public string Nomer { get; set; }

    public string Fio { get; set; }

    public DateTime Date { get; set; }


    public Ticket() { }

    public Ticket(string punkt, string nomer, string fio, DateTime date)
    {
        Punkt = punkt;
        Nomer = nomer;
        Fio = fio;
        Date = date;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Ticket[] ticketsArray = new Ticket[]
        {
            new Ticket("Київ", "AB123", "Іванов Іван", new DateTime(2024, 9, 17)),
            new Ticket("Львів", "AB123", "Петров Петро", new DateTime(2024, 9, 18)),
            new Ticket("Одеса", "CD456", "Сидоренко Олег", new DateTime(2024, 9, 20)),
            new Ticket("Харків", "AB123", "Коваленко Марія", new DateTime(2024, 9, 21))

        };
        Console.WriteLine("Введіть номер рейсу:");
        string Nomer = Console.ReadLine();
        Console.WriteLine("Введіть початкову дату (yyyy-mm-dd):");
        DateTime Date = DateTime.Parse(Console.WriteLine());
        Console.WriteLine("Введіть кінцеву дату (yyyy-mm-dd):");
        DateTime Dates = DateTime.Parse(Console.WriteLine());

        




    }
}