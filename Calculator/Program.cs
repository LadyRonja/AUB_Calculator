using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            bool shouldRun = true;

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
                            HandleAdditionInputs();
                            break;
                        }
                    case 2:
                        {   //Subtraction
                            HandleSubtractionInputs();
                            break;
                        }
                    case 3:
                        {   //Multiplication
                            HandleMultiplicationInputs();
                           // Console.WriteLine($"The factor of your entered numbers is {factor}");
                            break;
                        }
                    case 4:
                        {   //Division
                            HandleDivisonInputs();
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

        private static void HandleAdditionInputs()
        {
            Console.WriteLine("Please enter all numbers you want summerized, seperated by a space \n" +
                               "Decimals use comma (,) and faulty inputs will be ignored \n");         

            //Take all user inputs and convert to floats
            string[] inputText = new string[0];
            float[] input = new float[inputText.Length];

            //Verify that all input is legal
            bool inputVerified = false;
            while (!inputVerified)
            {
                inputText = Console.ReadLine().Split();
                input = new float[inputText.Length];

                bool noErrorsDeteced = true;
                for (int i = 0; i < inputText.Length; i++)
                {
                    if (!float.TryParse(inputText[i], out input[i])) noErrorsDeteced = false;
                }
                if (noErrorsDeteced) inputVerified = true;
            }


            //Inform user of executed equation
            string outputText = "";
            for (int i = 0; i < input.Length; i++)
            {
                outputText += input[i];
                if (i != input.Length - 1) outputText += " + ";
            }
            Console.WriteLine($"{outputText} = {Calculator.Addition(input)}");
        }

        private static void HandleSubtractionInputs()
        {
            Console.WriteLine("Please enter two numbers, seperated by a space, the 2nd number will be subtracted from the first \n" +
                                "Decimals use comma (,) \n");

            float inputA = 0;
            float inputB = 0;

            //Ensure legal inputs;
            bool inputsVerified = false;
            while (!inputsVerified) //Run until inputs are verified
            {
                string[] inputText = Console.ReadLine().Split();
                int verifiedInputs = 0;

                if (inputText.Length != 2)
                {
                    Console.WriteLine("Incorrect amount of inputs, please try again");
                    continue;
                }
                if (float.TryParse(inputText[0], out inputA)) verifiedInputs++;
                if (float.TryParse(inputText[1], out inputB)) verifiedInputs++;

                if (verifiedInputs != 2)
                {
                    Console.WriteLine("Input could not be verified, please try again");
                }
                else
                {
                    inputsVerified = true;
                }
            }


            //Use the calculator to do the equation.
            float difference = Calculator.Subtraction(inputA, inputB);

            //Inform user of executed equation
            Console.WriteLine($"{inputA} - {inputB} = {difference}");
        }

        private static void HandleMultiplicationInputs()
        {
            Console.WriteLine("Please enter all numbers you want multiplied, seperated by a space \n" +
                                "Decimals use comma (,) and faulty inputs will be ignored \n");

            //Take all user inputs and convert to floats
            string[] inputText = new string[0];
            float[] input = new float[inputText.Length];

            //Verify that all input is legal
            bool inputVerified = false;
            while (!inputVerified)
            {
                inputText = Console.ReadLine().Split();
                input = new float[inputText.Length];

                bool noErrorsDeteced = true;
                for (int i = 0; i < inputText.Length; i++)
                {
                    if (!float.TryParse(inputText[i], out input[i])) noErrorsDeteced = false;
                }
                if (noErrorsDeteced) inputVerified = true;
            }

            //Sum up all elements
            float factor = Calculator.Multiplication(input);

            //Inform user of executed equation
            string outputText = "";
            for (int i = 0; i < input.Length; i++)
            {
                outputText += input[i];
                if (i != input.Length - 1) outputText += " * ";
            }
            Console.WriteLine($"{outputText} = {factor}");
        }

        private static void HandleDivisonInputs()
        {
            Console.WriteLine("Please enter two numbers, seperated by a space, the 1st number will be divided by the 2nd \n" +
                                "Decimals use comma (,) \n");

            float inputA = 0;
            float inputB = 0;

            //Ensure legal inputs;
            bool inputsVerified = false;
            while (!inputsVerified) //Run until inputs are verified
            {
                string[] inputText = Console.ReadLine().Split();
                int verifiedInputs = 0;

                if (inputText.Length != 2)
                {
                    Console.WriteLine("Incorrect amount of inputs, please try again");
                    continue;
                }
                if (float.TryParse(inputText[0], out inputA)) verifiedInputs++;
                if (float.TryParse(inputText[1], out inputB)) verifiedInputs++;

                if (inputB == 0)
                {
                    Console.WriteLine("You can't divide by 0, please try again");
                }
                else
                {
                    verifiedInputs++;
                }

                if (verifiedInputs != 3)
                {
                    Console.WriteLine("Input could not be verified, please try again");
                }
                else
                {
                    inputsVerified = true;
                }
            }

            //Get the quotient from the calculator
            float quotient = Calculator.Division(inputA, inputB);

            //Inform user of executed equation
            Console.WriteLine($"{inputA} / {inputB} = {quotient}");
        }

    }
}
