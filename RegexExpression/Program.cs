using System.Text.RegularExpressions;

var domain = "https://www.something.com";

DomainValidation(domain);
phoneNumber();
PasswordValidator();

static void DomainValidation(string domain)
{
    Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$");
    Console.WriteLine(regex.IsMatch(domain));
}

static void phoneNumber()
{
    var phoneNumber = "+52 (686) 405 4720";
    Regex regex = new Regex(@"^\+[\d]{2} (\([\d]{3}\)) [\d]{3} [\d]{4}");
    Console.WriteLine(regex.IsMatch(phoneNumber));
}

static void PasswordValidator()
{
    //Debe contener min 8 caracteres
    //Al menos una mayuscula
    //Al menos una minuscula
    //Al menos un caracter especial
    //no debe tener espacios
    var password = "asdfgh3D@jkllE3$";
    Regex regex = new Regex(@"(?=\S*[A-Z])(?=\S*[a-z])(?=\S*[\d])(?=\S*[?!@$])(?=\S+$).{8,}");
    Console.WriteLine(regex.IsMatch(password));
}

