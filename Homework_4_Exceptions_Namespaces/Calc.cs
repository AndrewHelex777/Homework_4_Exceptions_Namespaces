namespace Homework_4_Exceptions_Namespaces
{
    internal class Calc
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Numeral system calculator");
                Console.WriteLine("1 - From decimal to binary");
                Console.WriteLine("2 - From binary to decimal");
                Console.WriteLine("3 - From decimal to hexadecimal");
                Console.WriteLine("4 - From hexadecimal to decimal");
                Console.WriteLine("5 - Exit");
                Console.Write(": ");
                try
                {
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        throw new FormatException("Menu choice must be int number.");
                    }
                    if (choice == 1)
                    {
                        Console.Write("Enter a decimal number: ");
                        if (!int.TryParse(Console.ReadLine(), out int num1))
                        {
                            throw new FormatException("Invalid decimal number or number is outside of the int range.");
                        }
                        Console.WriteLine($"Binary number: {num1:B}");
                    }
                    if (choice == 2)
                    {
                        Console.Write("Enter a binary number: ");
                        string num2 = Console.ReadLine();
                        if (num2 == "")
                        {
                            throw new FormatException("Binary number cannot be empty.");
                        }
                        int numD1 = 0;
                        foreach (var c in num2)
                        {
                            if (c != '0' && c != '1') 
                            {
                                throw new FormatException("Binary number can contain only 0 and 1.");
                            }
                            numD1 = numD1 * 2 + (c - '0');
                        }
                        Console.WriteLine($"Decimal: {numD1}");
                    }
                    if (choice == 3)
                    {
                        Console.Write("Enter a decimal number: ");
                        if (!int.TryParse(Console.ReadLine(), out int num3))
                        {
                            throw new FormatException("Invalid decimal number or number is outside of the int range.");
                        }
                        Console.WriteLine($"Hexadecimal number: {num3:X}");
                    }
                    if (choice == 4)
                    {
                        Console.Write("Enter a hexadecimal number: ");
                        string num4 = Console.ReadLine();
                        if (num4 == "")
                        {
                            throw new FormatException("Hexadecimal number cannot be empty.");
                        }
                        Console.WriteLine($"Decimal: {num4:D}");
                    }
                    if (choice == 5)
                    {
                        Console.WriteLine("Exit...");
                        break;
                    }
                    else if (choice < 1 || choice > 5)
                    {
                        throw new ArgumentOutOfRangeException("Choose from 1 to 5");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Input error: {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Overflow error : {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Argument out of range error: {ex.Message}");
                }
            }
        }
    }
}
