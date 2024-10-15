using System;
using Entity;


namespace Exceptions
{
    public static class ExceptionHandler
    {
        public static int GetPositiveInteger(string input)
        {
            try
            {
                int value = int.Parse(input);
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be a positive integer.");
                }
                return value;
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid input. Please enter a valid integer.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
        }

        public static void HandleNullReferenceException(Pet pet)
        {
            try
            {
                if (pet.Name == null || pet.Age == 0 || pet.Breed == null)
                {
                    throw new NullReferenceException("Pet information is missing.");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}