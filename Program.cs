﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

Console.WriteLine("Welcome to the Calculator");
repeat1:
Console.WriteLine("Please choose:\n\t\t1 ========> Geometry Guru\n\t\t2 ========> Simple Calculator\n");
Console.Write("Number:");
int check1 = Convert.ToInt32(Console.ReadLine());
if(check1 < 1 || check1 > 2)
{
    Console.Write("Please enter number only 1 or 2\n");
    goto repeat1;
}

if(check1 == 1)
{
        repeat2:
        Console.WriteLine("Welcome Geometry Guru Calculator\nPlease choose operators:\n\t1 ======> Circle area\n\t2 ======> Rectangle");
        Console.WriteLine("Enter number of 1 or 2");
        int check2 = Convert.ToInt32(Console.ReadLine());
        if(check2 < 1 || check2 > 2){
            Console.WriteLine(check2);
            Console.WriteLine("Please enter number only 1 or 2");
            goto repeat2;
        }
        switch(check2){
            case 1 : MethodByCircleArea();
                break;
            case 2 : MethodByRectangle();
                break;
            default:Console.WriteLine("Thank you");
            break;
        }
        Console.WriteLine("Do you want to do it again?\n[y/n]");
        string txt1 = Console.ReadLine();
        txt1 = txt1.ToLower();
        if(txt1 == "y")
        {
            goto repeat1;
        }
}
else
{
    repeat3:
    Console.WriteLine("Welcome Simple Calculator\nEnter number and operators\nFormat to =>\t [number and operators and number]");
    string input = Console.ReadLine();
    string pattern = @"^\s*(\d+)\s*([+\-*/])\s*(\d+)\s*$";
    Regex regex = new Regex(pattern);
    Match match = regex.Match(input);

    if(match.Success){
    double firstNumber = Convert.ToDouble(match.Groups[1].Value);
    double secondNumber = Convert.ToDouble(match.Groups[3].Value);  
            
            foreach (var operationChar in input)
            {   
                if (operationChar == '-')  
                {  
                    Console.WriteLine($"Result:{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");  
                }  
                else if (operationChar == '+')  
                {  
                    Console.WriteLine($"Result:{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");  
                }  
                else if (operationChar == '*')  
                {  
                    Console.WriteLine($"Result:{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");  
                }  
                else if (operationChar == '/')  
                {  
                    if(secondNumber != 0)
                    {
                        Console.WriteLine($"Result:{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");  
                    }
                    else
                    {
                        Console.WriteLine("Cannot be divided by ZERO!!!!");
                    }
                }                 
            }
    }  
    else{
        Console.WriteLine("Error: Input does not match the required format.");
        goto repeat3;
    }
        Console.WriteLine("Do you want to do it again?\n[y/n]");
        string txt1 = Console.ReadLine();
        txt1 = txt1.ToLower();
        if(txt1 == "y")
        {
            goto repeat1;
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
    Console.Write("Enter Lenght: ");
    int lenght = Convert.ToInt16(Console.ReadLine());
    
    Console.WriteLine($"For the are rectangle : {width*lenght}\nFor the perimter of rectangle : {2 * (width+lenght)}");
}
