using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


[Serializable]
public class Ticket
{
    public string Punkt { get; set; }
    public string Nomer { get; set; }
    public string Fio { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public Ticket() { }

    public Ticket(string punkt, string nomer, string fio, DateTime date)
    {
        Punkt = punkt;
        Nomer = nomer;
        Fio = fio;
        Date = date;
    }
    // Предопределение
    public override string ToString()
    {
        return $"Пасажир: {Fio}, Пункт призначення: {Punkt}, Номер рейсу: {Nomer}, Дата відльоту: {Date.ToShortDateString()}";
    }


}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        Ticket[] ticketsArray = new Ticket[]
        {
            new Ticket("Київ-Львів", "123", "Іванов Іван", new DateTime(2024, 9, 17)),
            new Ticket("Львів-Київ", "123", "Петров Петро", new DateTime(2024, 9, 18)),
            new Ticket("Одеса-Кременчук", "59", "Сидоренко Андрій", new DateTime(2024, 9, 20)),
            new Ticket("Харків-Одесса", "59", "Коваленко Марія", new DateTime(2024, 9, 21))
        };


        string json = JsonSerializer.Serialize(ticketsArray);
        File.WriteAllText("ticket.json", json);

        Ticket[] ticketsJson = JsonSerializer.Deserialize<Ticket[]>(File.ReadAllText("ticket.json"));

        // DisplayTickets(ticketsJson);


        string xml = "ticket.xml";
        SerializeXml(ticketsArray, xml);


        Ticket[] ticketsXml = DeserializeXml(xml);

        // DisplayTickets(ticketsXml);

        SerializeBinary(ticketsArray, "ticket.bin");
        Ticket[] ticketsBinary = DeserializeBinary("ticket.bin");




        Console.WriteLine("Введите номер рейса:");
        string Nomer = Console.ReadLine();

        Console.WriteLine("Введите начальную дату (yyyy-mm-dd):");
        DateTime startDate;
        while (!DateTime.TryParse(Console.ReadLine(), out startDate))
        {
            Console.WriteLine("Неправильный формат даты. Попробуйте ещё раз (yyyy-mm-dd):");
        }

        Console.WriteLine("Введите конечную дату (yyyy-mm-dd):");
        DateTime endDate;
        while (!DateTime.TryParse(Console.ReadLine(), out endDate))
        {
            Console.WriteLine("Неправильный формат даты. Попробуйте ещё раз (yyyy-mm-dd):");
        }


        foreach (var ticket in ticketsJson)
        {
            if (ticket.Nomer == Nomer && ticket.Date >= startDate && ticket.Date <= endDate)
            {
                Console.WriteLine(ticket);
            }
        }

        Console.ReadLine();
    }

    public static void SerializeJson(Ticket[] tickets, string file)
    {
        string jsonString = JsonSerializer.Serialize(tickets, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, jsonString);
    }


    public static Ticket[] DeserializeJson(string file)
    {
        string jsonString = File.ReadAllText(file);
        return JsonSerializer.Deserialize<Ticket[]>(jsonString);
    }

    public static void SerializeXml(Ticket[] tickets, string file)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ticket[]));
        using (FileStream fs = new FileStream(file, FileMode.Create))
        {
            xmlSerializer.Serialize(fs, tickets);
        }
    }

    public static Ticket[] DeserializeXml(string file)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ticket[]));
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
            return (Ticket[])xmlSerializer.Deserialize(fs);
        }
    }

    public static void SerializeBinary(Ticket[] tickets, string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(file, FileMode.Create))
        {
            formatter.Serialize(fs, tickets);
        }
    }

    public static Ticket[] DeserializeBinary(string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
            return (Ticket[])formatter.Deserialize(fs);
        }
    }





    // DisplayTickets Бесполезно практически
    //public static void DisplayTickets(Ticket[] tickets)
    //{
    //    foreach (var ticket in tickets)
    //    {
    //Console.WriteLine(ticket);
    //}
    //}
}