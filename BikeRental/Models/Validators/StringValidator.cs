using System;

namespace BikeRental.Models.Validators
{
    public class StringValidator : Validator
    {
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                {
                    return "Rozpocznij  dużą  literą.";
                }
            }
            catch (Exception) { }
            ;
            return null;
        }
    }

}
