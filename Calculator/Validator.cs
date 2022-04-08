using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public static class Validator
    {
        public static bool ConfirmLegalInputs(string consoleInput, out float[] validatedInput, out List<string> errorMessages)
        {
            // Prephare list of error messages
            errorMessages = new List<string>();

            // Split the user input and prephare an array for the out value
            string[] splitInput = consoleInput.Split();
            float[] output = new float[splitInput.Length];

            // Verify that all input is legal
            bool inputVerified = false;
            bool noErrorsDeteced = true;

            // Ensure each element parses as a float and is not infinite 
            for (int i = 0; i < splitInput.Length; i++)
            {

                if (!float.TryParse(splitInput[i], out output[i])) {
                    noErrorsDeteced = false;
                    errorMessages.Add($"{splitInput[i]} cannot be parsed as a float");
                }                 
                else if (float.IsInfinity(output[i]))
                {
                    noErrorsDeteced = false;
                    errorMessages.Add($"{splitInput[i]} is parsed as infinity or NaN");
                }                   
            }

            if (noErrorsDeteced) inputVerified = true;


            validatedInput = output;
            return inputVerified;
        }

        public static bool ConfirmLegalInputs(string consoleInput, out float[] validatedInput)
        {
            bool inputVerified = ConfirmLegalInputs(consoleInput, out validatedInput, out var errors);


            return inputVerified;
        }

        public static bool ConfirmLegalInputs(string consoleInput, out float[] validatedInput, int minReqElements, out List<string> errorMessages)
        {
            // Prephare list of error messages
            errorMessages = new List<string>();

            // Check if consoleInput contains enough elements
            if (consoleInput.Split().Length < minReqElements)
            {
                errorMessages.Add("Not enough inputs entered");
                validatedInput = new float[0];
                return false;
            }

            // Run the base function and add any additional errors occured there
            bool inputValidated = ConfirmLegalInputs(consoleInput, out validatedInput, out var additionalErrors);        
            errorMessages.AddRange(additionalErrors);
           
            return inputValidated;
        }

        public static bool ConfirmLegalInputs(string consoleInput, out float[] validatedInput, int minReqElements)
        {
            // Run the base function
            return ConfirmLegalInputs(consoleInput, out validatedInput, minReqElements, out var errors);
        }

        public static bool ConfirmLegalDivsionInput(string consoleInput, out float[] validatedInput, out List<string> errorMessages)
        {
            // Prephare outputs
            bool noErrorsFound = true;
            errorMessages = new List<string>();

            // Does the input contain at least 2 legal float inputs?
            if (ConfirmLegalInputs(consoleInput, out validatedInput, 2, out var additionalErrors) == false)
            {
                errorMessages.AddRange(additionalErrors);
                noErrorsFound = false;
            }                      

            // Does the input contain exactly 2 elements?
            if (validatedInput.Length != 2)
            {
                errorMessages.Add("Input must contain exactly 2 inputs");
                noErrorsFound = false;
            }

            // Is the 2nd number 0?
            if (validatedInput.Length >= 2)
            {
                if (validatedInput[1] == 0)
                {
                    errorMessages.Add("You can't divide by 0");
                    noErrorsFound = false;
                }
            }


            return noErrorsFound;
        }

    }
}
