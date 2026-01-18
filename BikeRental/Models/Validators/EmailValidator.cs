using System.Linq;

namespace BikeRental.Models.Validators
{
    public class EmailValidator : Validator
    {
        public static string SprawdzEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return "Email nie może być pusty";
            if (email.Any(char.IsWhiteSpace))
                return "Email nie może zawierać spacji";
            if (email.Count(c => c == '@') > 1)
                return "Email musi zawierać dokładnie jeden znak '@'";
            //Jeśli użytkownik jeszcze nie wpisał @, nie oceniaj reszty "finalnych" reguł
            if (!email.Contains("@"))
                return null; // albo zwróć hint zamiast błędu
            if (email.StartsWith("@") || email.EndsWith("@"))
                return "Email nie może zaczynać się ani kończyć znakiem '@'";
            //Dopóki nie ma kropki po @, też jeszcze nie musi być błędu przy pisaniu
            var at = email.IndexOf('@');
            var dotAfterAt = email.IndexOf('.', at + 1);
            if (dotAfterAt == -1)
                return null; //nadal pisze domenę
            if (dotAfterAt - at < 2)
                return "Między znakiem '@' a kropką musi być co najmniej jeden znak";
            if (email.EndsWith(".") || email.StartsWith("."))
                return "Email nie może zaczynać się ani kończyć kropką";
            if (email.Length < 5)
                return "Email jest za krótki";

            return null;
        }
    }
}
