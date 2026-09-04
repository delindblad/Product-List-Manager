using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Json;
class ProductListManager
{
    static string ErrorMessage = "";
    static void Main(string[] args)
        
    {
        //List of products
        List<string> products = null;
        //If there's a saved list, load it
        if (File.Exists("products.json"))
        {
            try
            {
                string jsonString = File.ReadAllText("products.json");
                products = JsonSerializer.Deserialize<List<string>>(jsonString)!;
            }
            catch (Exception ex)
            {
                {
                    //Unexpected problem, exit
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
        //Else create a new list
        else
        {
            products = new List<string>();
        }
         
        Console.Clear();
        /*
         * Main menu loop
         */
        while (true)
        {
            
            Console.WriteLine("=================================");
            Console.WriteLine("   PRODUCT LIST MANAGER LEVEL 4");
            Console.WriteLine("=================================");

            Console.WriteLine("1. Add product");
            Console.WriteLine("2. View products");
            Console.WriteLine("3. Search product");
            Console.WriteLine("4. Delete product");
            Console.WriteLine("5. Statistics");
            Console.WriteLine("6. Save to file");
            Console.WriteLine("7. Exit\n\n");

            Console.Write("Select option:");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.Clear();
                    AddProductsView(products);
                    break;
                case '2':
                    ViewProductsView(products);
                    break;
                case '3':
                    SearchProductsView(products);
                    break;
                case '4':
                    DeleteProductsView(products);
                    break;
                case '5':
                    ShowStatisticsView(products);
                    break;
                case '6':
                    SaveView(products);
                    break;
                case '7':
                    return;

                default:
                    //Console.Clear();
                    break;
            }
        }
        
    }



    /*
     * <summary>Shows the menu that allows the user to add products to the list</summary>
     * <param name="products">The product list</param>
     * 
     */
    public static void AddProductsView(List<string> products)
    {
        //Input variable
        string input;
 
        Console.WriteLine("Enter product names.");
        Console.WriteLine("Type 'exit' to finish.");
        Console.Write("Product:");

        //Main loop to get user input
        while (true)
        {
            //Reset the error message
            ErrorMessage = "";
            if ((input = Console.ReadLine()) != null)
            {
                //Set to lower case and remove whitespace
                input = input.Trim().ToLower();
            }
            else
            {
                input = "";
            }
            if (input == "exit")
            {
                Console.Clear();
                break;
            }
            else
            {   //Validate
                if (ValidateInput(input))
                {
                    //Print warning if the product already exists
                    if (products.Contains(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WARNING: Product already exists.");
                        Console.ResetColor();
                        Console.Beep();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        //Add the product
                        products.Add(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Added '" + input + "'");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else 
                    //It failed to validate, print the error message
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ErrorMessage);
                    Console.ResetColor();
                    Console.Beep();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
             
            
            }
            //Reprint instructions
            Console.WriteLine("Enter product names.");
            Console.WriteLine("Type 'exit' to finish.");
            Console.Write("Product:");

        }

    }
    /*
     * <summary>Lets the user view the contents of the list</summary>
     * <param name="products">The product list</param>
     * 
     */
    public static void ViewProductsView(List<string> products)
    {
        Console.Clear();
        products.Sort();
        Console.WriteLine("\n\nSorted product list:\n\n");
        foreach (string product in products)
        {
            Console.WriteLine("- " + product);
        }

        Console.Write("\n\nPress any key to return to the main menu.");
        Console.ReadKey();
        Console.Clear();
    }

    /*
     * <summary>Menu that lets the user search for products</summary>
     * <param name="products">The product list</param>
     * 
     */public static void SearchProductsView(List<string> products)
    {
        while (true)
        { 
            Console.Clear();
            Console.WriteLine("Type '%' to exit.");
            Console.Write("Search:");
            var query = Console.ReadLine();
            if (query == "%")
            {
                Console.Clear();
                break;
            }
            if (!Regex.IsMatch(query, @"^[a-zA-Z]+$") && !Regex.IsMatch(query, @"^[2-4][0-9][0-9]|500$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Search query must be either a product name or number!");
                Console.ResetColor();
                Console.Beep();
                Thread.Sleep(2000);
                continue;
            }
            var matchFound = false;
            Console.WriteLine("Results:\n");


            foreach (string product in products)
            {
                if (Regex.IsMatch(product, query))
                {
                    matchFound = true;
                    Console.WriteLine(product);
                }
            }
            if (!matchFound)
            {
                Console.WriteLine("No results found!\n\n");
            }
            Console.WriteLine("\nPress any key to search again.");
            Console.ReadKey();
       }
    }

    /*
     * <summary>Shows the menu that lets the user delete products</summary>
     * <param name="products">The product list</param>
     * 
     */
    public static void DeleteProductsView(List<string> products)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter product to be deleted.");
            Console.WriteLine("Type '%' to return to the main menu.");
            Console.Write("Product:");
            var query = Console.ReadLine();
            // '%' is used to exit the menu
            if (query == "%")
            {
                Console.Clear();
                break;

            }
            //Check if it's in the list
            if (products.Contains(query))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //Ask for confirmation
                Console.WriteLine("Are you sure? (y/n)");
                Console.ResetColor();
                if (Console.ReadKey().KeyChar == 'y')
                    //Delete the product
                {
                    products.Remove(query);
                    Console.WriteLine("\nProduct '" + query + "' deleted!");
                    Thread.Sleep(2000);
                }

                
            }
            else
            {
                Console.WriteLine("No such product exists!");
                Console.Beep();
                Thread.Sleep(2000);
            }
        }
    }
    /*
     * <summary>Print statistics</summary>
     * <param name="products">The product list</param>
     * 
     */
    public static void ShowStatisticsView(List<string> products)
    {
        //Create a new list with only the numerical part, use floats to support 'Average()'
        List<float> productNumbers = new List<float>();
        foreach (var product in products)
        {
            var v = Regex.Match(product, @"[2-4][0-9][0-9]|500").Value;
            float productNumber = 0;
            if (float.TryParse(v, out productNumber))
            {
                productNumbers.Add(productNumber);
            }

        }

        Console.Clear();
        try
        {
            //Get the average
            float average =
                (from num in productNumbers
                 select num).Average();
            //Get max number
            float max = (from num in productNumbers
                         select num).Max();

            //Get min number
            float min = (from num in productNumbers
                         select num).Min();

            //Get the count
            int count = (from num in productNumbers
                         select num).Count();

            //Print the results
            Console.WriteLine("- Total Products: " + count.ToString());
            Console.WriteLine("- Lowest Number: " + min.ToString());
            Console.WriteLine("- Highest Number: " + max.ToString());
            Console.WriteLine("- Average Number: " + average.ToString());


        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message.ToString());
          

        }
        finally
        {

            Console.WriteLine("\n\nPress any button to return to main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
    /*
     * <summary>Saves the list</summary>
     * <param name="products">The product list</param>
     * 
     */
    public static void SaveView(List<string> products)
    {
        //Serialize to JSON sting
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(products,options);
        File.WriteAllText("products.json", jsonString);
        Console.Clear();
        Console.WriteLine("Saved products...");
        Thread.Sleep(2000);
        Console.Clear();

    }
    /*
     * <summary>Validates the input</summary>
     * <param name="input">input string</param>
     * <returns>Returns true if successful, otherwise false</returns>
     */
    public static bool ValidateInput(string input)
    {


        //Check if empty
        if (input.IsWhiteSpace())
        {
            ErrorMessage += "ERROR: Input cannot be empty.\n";
            return false;
        }

        //Try to match
        //This regexp should make any use of "int.TryParse()" redundant
        if (!Regex.Match(input, @"^([a-zA-Z]+)-([2-4][0-9][0-9]|500)$").Success)
        {
            //Match and extract groups
            Match m = Regex.Match(input, @"^(.+)-(.+)$");
            if (!m.Success)
            { 
                ErrorMessage += "ERROR: Product must contain a dash (-).\n";
                //Return right away if there's no dash
                return false;
            }
            else
            {
                //Check if the left side contains only characters
                if (!Regex.Match(m.Groups[1].Value, @"^[a-zA-Z]+$").Success)
                    {
                    ErrorMessage += "ERROR: The left side must contain letters only.\n";
                }
                //Check if the right side contains only numbers
                if (!Regex.Match(m.Groups[2].Value, @"^[0-9]+$").Success)
                {
                    ErrorMessage += "ERROR: The right side must contain numbers only.\n";
                }
                //This match might actually be unnecessary, since we are down to the last possible reason for the mismatch
                else if (!Regex.Match(m.Groups[2].Value, @"^[2-4][0-9][0-9]|500$").Success)
                {
                    ErrorMessage += "ERROR: The numeric part must be between 200 and 500.\n";
                }

            }
            return false;
        }

        return true;
    }
}