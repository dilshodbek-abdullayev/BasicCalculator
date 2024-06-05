using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Calculator");

        bool repeatMainMenu = true;

        while (repeatMainMenu)
        {
            int check1 = 0;

            while (true)
            {
                Console.WriteLine("Please choose:\n\t\t1 ========> Geometry Guru\n\t\t2 ========> Simple Calculator\n");
                Console.Write("Number:");
                if (int.TryParse(Console.ReadLine(), out check1) && (check1 == 1 || check1 == 2))
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter number only 1 or 2\n");
                }
            }

            if (check1 == 1)
            {
                bool repeatGeometry = true;
                while (repeatGeometry)
                {
                    int check2 = 0;

                    while (true)
                    {
                        Console.WriteLine("Welcome Geometry Guru Calculator\nPlease choose operators:\n\t1 ======> Circle area\n\t2 ======> Rectangle");
                        Console.WriteLine("Enter number of 1 or 2");

                        if (int.TryParse(Console.ReadLine(), out check2) && (check2 == 1 || check2 == 2))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter number only 1 or 2");
                        }
                    }

                    switch (check2)
                    {
                        case 1:
                            MethodByCircleArea();
                            break;
                        case 2:
                            MethodByRectangle();
                            break;
                    }

                    Console.WriteLine("Do you want to do it again?\n[y/n]");
                    string txt1 = Console.ReadLine().ToLower();

                    if (txt1 != "y")
                    {
                        repeatGeometry = false;
                    }
                }
            }
            else
            {
                bool repeatCalculator = true;

                while (repeatCalculator)
                {
                    Console.WriteLine("Welcome Simple Calculator\nEnter number and operators\nFormat to =>\t [number and operators and number]");
                    string input = Console.ReadLine();
                    string pattern = @"^\s*(\d+)\s*([+\-*/])\s*(\d+)\s*$";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(input);

                    if (match.Success)
                    {
                        double firstNumber = Convert.ToDouble(match.Groups[1].Value);
                        double secondNumber = Convert.ToDouble(match.Groups[3].Value);
                        char operation = match.Groups[2].Value[0];

                        switch (operation)
                        {
                            case '-':
                                Console.WriteLine($"Result: {firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                                break;
                            case '+':
                                Console.WriteLine($"Result: {firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                                break;
                            case '*':
                                Console.WriteLine($"Result: {firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                                break;
                            case '/':
                                if (secondNumber != 0)
                                {
                                    Console.WriteLine($"Result: {firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                                }
                                else
                                {
                                    Console.WriteLine("Cannot be divided by ZERO!!!!");
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Input does not match the required format.");
                        continue;
                    }

                    Console.WriteLine("Do you want to do it again?\n[y/n]");
                    string txt1 = Console.ReadLine().ToLower();

                    if (txt1 != "y")
                    {
                        repeatCalculator = false;
                    }
                }
            }

            Console.WriteLine("Do you want to go back to the main menu?\n[y/n]");
            string repeatMain = Console.ReadLine().ToLower();

            if (repeatMain != "y")
            {
                repeatMainMenu = false;
            }
        }
    }

    static void MethodByCircleArea()
    {
        const double PI = 3.14;
        Console.Write("Enter radius circle : ");
        int radius = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Circle surface: {PI * Math.Pow(radius, 2)}");
    }

    static void MethodByRectangle()
    {
        Console.Write("Enter Width: ");
        int width = Convert.ToInt16(Console.ReadLine());
        Console.Write("Enter Length: ");
        int length = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine($"For the area of rectangle : {width * length}\nFor the perimeter of rectangle : {2 * (width + length)}");
    }
}
