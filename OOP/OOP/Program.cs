using System.Globalization;

namespace OOP;

public sealed class Program
{
    public static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("=== Ввод данных о товаре со скидкой ===");

        Console.Write("Наименование товара: ");
        string name = Console.ReadLine();

        Console.Write("Производитель: ");
        string manufacturer = Console.ReadLine();

        Console.Write("Цена (базовая): ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Дата производства (ГГГГ-ММ-ДД): ");
        DateTime productionDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Срок годности (в днях): ");
        int shelfLifeDays = int.Parse(Console.ReadLine());

        Console.Write("Размер скидки (%): ");
        decimal discountPercentage = decimal.Parse(Console.ReadLine());

        DiscountedProduct promoProduct = new DiscountedProduct(
            name, 
            manufacturer, 
            price, 
            shelfLifeDays, 
            productionDate, 
            discountPercentage
        );

        Console.WriteLine("\n=== Информация о товаре ===");
        Console.WriteLine(promoProduct.ToString());
    }
}

public class Product(string name, string manufacturer, decimal price, int shelfLifeDays, DateTime productionDate)
{
    public string Name { get; set; } = name;
    public string Manufacturer { get; set; } = manufacturer;
    public decimal Price { get; set; } = price;
    public int ShelfLifeDays { get; set; } = shelfLifeDays;
    public DateTime ProductionDate { get; set; } = productionDate;

    public override string ToString()
    {
        return $"Наименование: {Name}\n" +
               $"Производитель: {Manufacturer}\n" +
               $"Базовая цена: {Price:F2} руб.\n" +
               $"Дата производства: {ProductionDate:yyyy-MM-dd}\n" +
               $"Срок годности: {ShelfLifeDays} дней";
    }
}

public sealed class DiscountedProduct(string name, string manufacturer, decimal price, int shelfLifeDays, DateTime productionDate,
    decimal discountPercentage) : Product(name, manufacturer, price, shelfLifeDays, productionDate)
{
    public decimal DiscountPercentage { get; set; } = discountPercentage;

    public decimal DiscountedPrice 
    {
        get => Price * (1 - DiscountPercentage / 100);
    }

    public override string ToString()
    {
        return base.ToString() + $"\n" +
               $"Размер скидки: {DiscountPercentage}%\n" +
               $"Акционная цена: {DiscountedPrice:F2} руб.";
    }
}