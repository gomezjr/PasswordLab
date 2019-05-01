using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PasswordLab
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> emails = new List<string>();
            List<string> passwords = new List<string>();


            bool playAgain = true;

            while(playAgain == true)
            {
                Console.WriteLine("Please enter a valid email");
                string email = Console.ReadLine();

                Console.WriteLine("Please enter a valid password");
                string password = Console.ReadLine();

                RegisterUser(email);
                string e;
                ValidatePassword(password, out e);

                Console.WriteLine("Do you want to enter another email and password? Y/N");
                string input = Console.ReadLine().ToLower();
                if(input == "y")
                {
                    playAgain = true;
                }
                if(input == "n")
                {
                    playAgain = false;
                }
            }
           




        }
        public static bool RegisterUser(string e)
        {
            

            //char[] delimters = { '@', '.' };
            //string[] emailArray = email.Split(delimters);

            //emailArray.Contains("M", "A", "W", "Q")

            //if(emailArray[0] == "A", "B", "C"){

            //}

            try
            {
                MailAddress m = new MailAddress(e);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }

        
        
        
            public static bool ValidatePassword(string password, out string ErrorMessage)
            {
                var input = password;
                ErrorMessage = string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new Exception("Password should not be empty");
                }

                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{8,15}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one lower case letter";
                    return false;
                }
                else if (!hasUpperChar.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one upper case letter";
                    return false;
                }
                else if (!hasMiniMaxChars.IsMatch(input))
                {
                    ErrorMessage = "Password should not be less than or greater than 12 characters";
                    return false;
                }
                else if (!hasNumber.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one numeric value";
                    return false;
                }

                else if (!hasSymbols.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one special case characters";
                    return false;
                }
                else
                {
                    return true;
                }
            }


        
    }
}
