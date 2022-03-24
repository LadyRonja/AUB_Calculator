using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    static class Calculator
    {

        public static float Addition(float[] numbers)
        {
            //Sum up all elements
            float sum = 0;
            foreach (float f in numbers)
            {
                sum += f;
            }

            return sum;
        }

        public static float Subtraction(float inputA, float inputB)
        {
            //Subtract the 2nd number from the 1st
            float difference = inputA - inputB;

            return difference;
        }

        public static float Multiplication(float[] numbers)
        { 
            //Sum up all elements
            float factor = 1;
            foreach (float f in numbers)
            {
                factor *= f;
            }

            return factor;
        }

        public static float Division(float inputA, float inputB)
        {
            //Divide the 1st number by the 2nd one
            float quotient =  inputA / inputB;
            return quotient;
        }

    }
}
