using System.Text.RegularExpressions;
class ProductListManager
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("   PRODUCT LIST MANAGER LEVEL 3");
        Console.WriteLine("-------------------------------------");

        Console.WriteLine("Enter product names.");
        Console.WriteLine("Type 'exit' to finish.");

        //List of products
        List<string> products = new List<string>();
        //Input variable
        string input;
        //Regex pattern
        string pattern = @"^([a-zA-Z]+)-([0-9]+)$";


        Console.Write("Product:");

        //Main loop to get user input
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
            if (input == "exit")
            {
                break;
            }
            else
            {
                if (ValidateInput(input, pattern))
                {
                    Console.WriteLine("Valid product name.");
                    products.Add(input);
                }
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

    public static bool ValidateInput(string input, string pattern)
    {
        var valid = true;

        //Get match and extract the name and number
        Match m = Regex.Match(input, pattern);
        Console.WriteLine("Name:" + m.Groups[1].Value);
        Console.WriteLine("Number: " +  m.Groups[2].Value);

        if (!m.Success)
        {
            valid = false;
            Console.WriteLine("Invalid product name. Please use the format 'name-number'.");
        }
        else
        {

        }

        if (input.IsWhiteSpace())
        {
            valid = false;
            Console.WriteLine("Input cannot be empty or whitespace.");
        }

        return valid;
    }
}