class ProductListManager
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("   PRODUCT LIST MANAGER LEVEL 1");
        Console.WriteLine("-------------------------------------");

        Console.WriteLine("Enter product names.");
        Console.WriteLine("Type 'exit' to finish.");
        List<string> products = new List<string>();
        String input;
        Console.Write("Product:");


        while (true)
        {
            if ((input = Console.ReadLine()) != null)
            {
                input = input.Trim().ToLower();
            }
            else
            {
                input = "";
            }

            if (input.IsWhiteSpace())
            {
                Console.WriteLine("Whitespace is not allowed.");
            }
            else if(input == "exit")
            {
                break;
            }
            else
            {
                products.Add(input.ToLower().Trim());
            }
            Console.Write("Product:");

        }

        products.Sort();
        Console.WriteLine("\n\nSorted product list:\n\n");
        foreach (string product in products)
        {
            Console.WriteLine("- " + product);
        }

    }
}