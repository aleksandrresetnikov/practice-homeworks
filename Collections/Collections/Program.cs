namespace Collections;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Создание стека с емкостью по умолчанию (4) ===");
        SmartStack<int> stack = new SmartStack<int>();
        
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Push(40);
        
        Console.WriteLine($"Количество: {stack.Count}, Емкость: {stack.Capacity}");

        Console.WriteLine("\n=== Добавление 5-го элемента (Емкость должна удвоиться) ===");
        stack.Push(50);
        Console.WriteLine($"Количество: {stack.Count}, Емкость: {stack.Capacity}");

        Console.WriteLine("\n=== Тест PushRange ===");
        List<int> list = new List<int> { 60, 70, 80 };
        stack.PushRange(list);
        Console.WriteLine($"После PushRange -> Количество: {stack.Count}, Емкость: {stack.Capacity}");

        Console.WriteLine("\n=== Перебор стека (от вершины к основанию) ===");
        foreach (var item in stack) Console.Write($"{item} ");
        Console.WriteLine();

        Console.WriteLine("\n=== Тест индексатора (0 - вершина) ===");
        Console.WriteLine($"Индекс 0 (вершина): {stack[0]}");
        Console.WriteLine($"Индекс 1: {stack[1]}");
        Console.WriteLine($"Индекс 7 (основание): {stack[7]}");

        Console.WriteLine("\n=== Тест метода Contains ===");
        Console.WriteLine($"Содержит 30?: {stack.Contains(30)}");
        Console.WriteLine($"Содержит 100?: {stack.Contains(100)}");

        Console.WriteLine("\n=== Извлечение элементов (Pop) ===");
        Console.WriteLine($"Удален элемент: {stack.Pop()}");
        Console.WriteLine($"Текущая вершина (Peek): {stack.Peek()}");
        Console.WriteLine($"Количество после Pop: {stack.Count}, Емкость: {stack.Capacity}");
    }
}