namespace Types_Task2;

class Program
{
    static void Main(string[] args)
    {
        PrintDiamond(7);
    }

    public static void PrintDiamond(int n)
    {
        if (n <= 0 || n % 2 == 0) return;

        int mid = n / 2;

        for (int i = 0; i < n; i++)
        {
            int leftSpaces = Math.Abs(mid - i);
            Console.Write(new string(' ', leftSpaces));

            Console.Write('X');

            if (leftSpaces < mid)
            {
                int internalSpaces = n - 2 * leftSpaces - 2;
                Console.Write(new string(' ', internalSpaces));
                Console.Write('X');
            }

            Console.WriteLine();
        }
    }
}