namespace FurnitureDetails;
public class Furniture
{
    public double Height { get; set; }
    public double Width { get; set; }
    public string Colour { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public virtual void Accept()
    {
        Console.Write("Enter height: ");
        Height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter width: ");
        Width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter color: ");
        Colour = Console.ReadLine();

        Console.Write("Enter quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter price: ");
        Price = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Display()
    {
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Width: {Width}");
        Console.WriteLine($"Color: {Colour}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Price: {Price}");
    }
}

public class BookShelf : Furniture
{
    public int AdditionalNoOfShelfs { get; set; }

    public override void Accept()
    {
        base.Accept();
        Console.Write("Enter the  number of shelfs: ");
        AdditionalNoOfShelfs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Number of shelves: {AdditionalNoOfShelfs}");
    }
}
public class DiningTable : Furniture
{
    public int AdditionalNoOfLegs { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter the number of legs: ");
        AdditionalNoOfLegs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Number of legs: {AdditionalNoOfLegs}");
    }
}
public class Program
{
    public static int AddToStock(Furniture[] stock)
    {
        int count = 0;

        while (count < stock.Length)
        {
            Console.Write("Enter '1' for Bookshelf or '2' for Dining table: ");
            string choice = Console.ReadLine();

            Furniture furniture;

            if (choice == "1")
            {
                furniture = new BookShelf();
            }
            else if (choice == "2")
            {
                furniture = new DiningTable();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }
            furniture.Accept();
            stock[count] = furniture;
            count++;
        }
        return count;
    }
    public static double TotalStockValue(Furniture[] stock)
    {
        double totalValue = 0;

        foreach (Furniture furniture in stock)
        {
            totalValue += furniture.Quantity * furniture.Price;
        }

        return totalValue;
    }

    public static void ShowStockDetails(Furniture[] stock)
    {
        foreach (Furniture furniture in stock)
        {
            furniture.Display();
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the count of selecting furniture:");
        int n = Convert.ToInt32(Console.ReadLine());
        Furniture[] stock = new Furniture[n];

        int count = AddToStock(stock);

        Console.WriteLine($"Total number of furniture selected : {count}");
        Console.WriteLine($"Total stock value : {TotalStockValue(stock)}");

        ShowStockDetails(stock);

        Console.ReadLine();
    }
}