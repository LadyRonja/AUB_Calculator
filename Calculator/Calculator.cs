using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Calculator
    {

        public float Addition()
        {
            Console.WriteLine("Please enter all numbers you want summerized, seperated by a space \n" +
                                "Decimals use comma (,) and faulty inputs will be ignored \n");

            //Take all user inputs and convert to floats
            string[] inputText = Console.ReadLine().Split();
            float[] input = new float[inputText.Length];
            
            for (int i = 0; i < inputText.Length; i++)
            {
                float.TryParse(inputText[i], out input[i]);
            }

            //Sum up all elements
            float sum = 0;
            foreach (float f in input)
            {
                sum += f;
            }

            //Inform user of executed equation
            string outputText = "";
            for (int i = 0; i < input.Length; i++)
            {
                outputText += input[i];
                if(i != input.Length-1) outputText += " + ";
            }
            Console.WriteLine($"{outputText} = {sum}");

            return sum;
        }

        public float Subtraction()
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


            //Subtract the second number from the first one
            float difference = inputA - inputB;

            //Inform user of executed equation
            Console.WriteLine($"{inputA} - {inputB} = {difference}");
            return difference;
        }

        public float Multiplication()
        {
            Console.WriteLine("Please enter all numbers you want multiplied, seperated by a space \n" +
                                "Decimals use comma (,) and faulty inputs will be ignored \n");

            //Take all user inputs and convert to floats
            string[] inputText = Console.ReadLine().Split();
            float[] input = new float[inputText.Length];

            for (int i = 0; i < inputText.Length; i++)
            {
                float.TryParse(inputText[i], out input[i]);
            }

            //Sum up all elements
            float factor = 1;
            foreach (float f in input)
            {
                factor *= f;
            }

            //Inform user of executed equation
            string outputText = "";
            for (int i = 0; i < input.Length; i++)
            {
                outputText += input[i];
                if (i != input.Length - 1) outputText += " * ";
            }
            Console.WriteLine($"{outputText} = {factor}");

            return factor;
        }

        public float Division()
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


            //Subtract the second number from the first one
            float quotient =  inputA / inputB;

            //Inform user of executed equation
            Console.WriteLine($"{inputA} / {inputB} = {quotient}");

            return quotient;
        }

    }
}
