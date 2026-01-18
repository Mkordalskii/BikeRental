namespace BikeRental.Models.Validators
{
    public class BiznesValidator : Validator
    {
        public static string sprawdzVat(int? vat)
        {
            if (vat < 0 || vat > 100)
                return "VAT  powinien  być  z  przedziału  od  0  do  100";
            return null;
        }

    }
}
