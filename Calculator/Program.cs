using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            bool shouldRun = true;
            Calculator calc = new Calculator();

            //Run the program until told to stop
            while (shouldRun)
            {
                //Print options
                Console.WriteLine();
                Console.WriteLine("What type equation do you want to use? \n" +
                                  "1. Addition \n" +
                                  "2. Subtraction \n" +
                                  "3. Multiplication \n" +
                                  "4. Division \n" +
                                  "0. None, close application \n");
                
                //Take input and deterimine action
                string userInputStr = Console.ReadLine();
                int userInput = -1;
                if (!Int32 .TryParse(userInputStr, out userInput)) 
                {
                    userInput = -1;
                }
                switch (userInput)
                {
                    case 0:
                        {   //Exit application
                            shouldRun = false;
                            break;
                        }
                    case 1:
                        {   //Addition
                            float sum = calc.Addition();
                            Console.WriteLine($"The sum of your entered numbers is {sum}");
                            break;
                        }
                    case 2:
                        {   //Subtraction
                            float difference = calc.Subtraction();
                            Console.WriteLine($"The difference of your entered numbers is {difference}");
                            break;
                        }
                    case 3:
                        {   //Multiplication
                            float factor = calc.Multiplication();
                            Console.WriteLine($"The factor of your entered numbers is {factor}");
                            break;
                        }
                    case 4:
                        {   //Division
                            float quotient = calc.Division();
                            Console.WriteLine($"The quotient of your entered numbers is {quotient}");
                            break;
                        }
                    default:
                        {   //Unaccounted for situation
                            Console.WriteLine("Input not recognized, please try again!");
                            break;
                        }
                }

            }
            
            Console.WriteLine("\n End of program reached, press any key to clsoe application.");
            //Console.ReadKey();
        }
    }
}
