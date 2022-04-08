using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public static class Calculator
    {
        public static float Sum(float inputA, float inputB)
        {
            // Return the sum of two numbers
            float sum = inputA + inputB;

            return sum;
        }

        public static float Sum(float[] numbers)
        {
            // If no numbers are entered, the sum is 0 (Treated as 0 + 0)
            if (numbers.Length == 0) { return 0; }

            // If only one input is entered, the sum  is that number (Treated as no equation)
            if (numbers.Length == 1) { return numbers[0]; }

            // Sum up all elements
            float sum = 0;
            foreach (float f in numbers)
            {
                sum += f;
            }

            return sum;
        }

        public static float Subtract(float inputA, float inputB)
        {
            // Subtract the 2nd number from the 1st
            float difference = inputA - inputB;

            return difference;
        }

        public static float Subtract(float[] numbers)
        {
            // If no numbers are entered, the difference is 0 (Treated as 0 - 0)
            if (numbers.Length == 0) { return 0; }

            // If only one input is entered, the difference is that number (Treated as no equation)
            if(numbers.Length == 1) { return numbers[0]; }


            // Subtract all subsequent values from the first one
            float diff = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                diff -= numbers[i];
            }

            return diff;
        }

        public static float Multiply(float[] numbers)
        {
            // If no numbers are entered, the factor is 0 (Treated as 0 * 0)
            if (numbers.Length == 0) { return 0; }

            // If only one input is entered, the factor is that number (Treated as no equation)
            if (numbers.Length == 1) { return numbers[0]; }

            // Multiply all elements
            float factor = 1;
            foreach (float f in numbers)
            {
                factor *= f;
            }

            return factor;
        }

        public static float Divide(float inputA, float inputB)
        {
            if (inputB == 0)
            {
                return float.PositiveInfinity;
            }

            // Divide the 1st number by the 2nd one
            float quotient = inputA / inputB;

            return quotient;
        }

    }
}
