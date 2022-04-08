using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            bool shouldRun = true;

            // Run the program until told to stop
            while (shouldRun)
            {
                // Print options
                Console.WriteLine();
                Console.WriteLine("What type equation do you want to use? \n" +
                                  "1. Addition \n" +
                                  "2. Subtraction \n" +
                                  "3. Multiplication \n" +
                                  "4. Division \n" +
                                  "0. None, close application \n");
                
                // Take input and deterimine action
                string userInputStr = Console.ReadLine();
                int userInput = -1;
                if (!Int32 .TryParse(userInputStr, out userInput)) 
                {
                    userInput = -1;
                }
                switch (userInput)
                {
                    case 0:
                        {   // Exit application
                            shouldRun = false;
                            break;
                        }
                    case 1:
                        {   // Sum
                            AdditionManager();
                            break;
                        }
                    case 2:
                        {   // Subtract
                            SubtractionManager();
                            break;
                        }
                    case 3:
                        {   // Multiplication
                            MultiplicationManager();
                            break;
                        }
                    case 4:
                        {   // Divide
                            DivisionManager();
                            break;
                        }
                    default:
                        {   // Unaccounted for situation
                            Console.WriteLine("Input not recognized, please try again!");
                            break;
                        }
                }

            }

            Console.WriteLine("\n End of program reached");
            //Console.ReadKey();
        }

        private static void AdditionManager()
        {
            Console.WriteLine("Please enter at least two numbers you want summerized, seperated by a space \n" +
                              "Decimals use comma (,) \n");

            float[] numbers;
            int minInputs = 2;

            // Have the user enter inputs until they are validated
            while (Validator.ConfirmLegalInputs(Console.ReadLine(), out numbers, minInputs, out var errors) != true)
            {
                ErrorMessagePrinter(errors);
            }

            float result = Calculator.Sum(numbers);
            EquationPrinter(numbers, result, '+');
        }

        private static void SubtractionManager()
        {
            Console.WriteLine("Please enter at least two numbers, seperated by a space \n" +
                                "All numbers following the first one will be subtracted from the first one \n" +
                                "Decimals use comma (,) \n" + 
                                "At least two inputs are required");

            float[] numbers;
            int minInputs = 2;

            // Have the user enter inputs until they are validated
            while (Validator.ConfirmLegalInputs(Console.ReadLine(), out numbers, minInputs, out var errors) != true)
            {
                ErrorMessagePrinter(errors);
            }

            float result = Calculator.Subtract(numbers);
            EquationPrinter(numbers, result, '-');
        }

        private static void MultiplicationManager()
        {
            Console.WriteLine("Please enter at least two numbers you want multiplied, seperated by a space \n" +
                              "Decimals use comma (,) \n");

            float[] numbers;
            int minInputs = 2;

            // Have the user enter inputs until they are validated
            while (Validator.ConfirmLegalInputs(Console.ReadLine(), out numbers, minInputs, out var errors) != true)
            {
                ErrorMessagePrinter(errors);
            }

            float result = Calculator.Multiply(numbers);
            EquationPrinter(numbers, result, '*');
        }

        private static void DivisionManager()
        {
            Console.WriteLine("Please enter two numbers, seperated by a space, the 1st number will be divided by the 2nd \n" +
                                "Decimals use comma (,) \n");

            float[] numbers;
            // Have the user enter inputs until they are validated
            while (Validator.ConfirmLegalDivsionInput(Console.ReadLine(), out numbers, out var errors) != true)
            {
                ErrorMessagePrinter(errors);
            }

            float result = Calculator.Divide(numbers[0], numbers[1]);
            EquationPrinter(numbers, result, '/');
        }

        private static void EquationPrinter(float[] elements, float result, char equationOperator)
        {
            // Inform user of executed equation
            string outputText = "";
            for (int i = 0; i < elements.Length; i++)
            {
                outputText += $"{elements[i]} ";
                if (i != elements.Length - 1)
                {
                    outputText += $"{equationOperator} ";
                } 
            }

            outputText += $"= {result}";

            Console.WriteLine(outputText);
        }

        private static void ErrorMessagePrinter(List<string> errors)
        {
            // Print each error message on a new line
            for (int i = 0; i < errors.Count; i++)
            {
                Console.WriteLine(errors[i]);
            }
        }
    }
}
