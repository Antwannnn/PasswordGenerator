using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Password
    {

        private readonly static char[] lowerCaseLetters =
            {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k' , 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z'};

        private readonly static char[] symbols =
            {'~', '`', '!', '@', '#', '$', '%', '^',
            '&', '*', '(', ')', '_', '-', '+', '=',
            '{', '[', '}', ']', '|', '\\', ':', ';',
            '"', '\'', '<', '>', '.', '?', '/'};

        private readonly string password;
        private bool _containsSymbols;

        // Getters and setter for _containsSymbols field
        public bool ContainsSymbols
        {
            get { return _containsSymbols; }

            set { _containsSymbols =  value; }
        }

        // Password generating method 
        public string generate(int length)
        {
            if(length <= 0)
            {
                return "Please enter a valid length for a password";
            }
            // password string local variable
            string password = "";
            // Random object
            Random randGen = new Random();
            // Index picking in the char array
            int index;
            // Random number btw 0-5 deciding whether the next char's gonna be a symbol or not
            int appendSymbol;
            // The char to append to the password
            char toAppend;
            for(int i = 0; i < length; i++)
            {
                // Checking if the _containsSymbols field is true or not
                if (_containsSymbols && i > 0)
                    appendSymbol = randGen.Next(0, 5);
                // If not, the appendSymbol variable will always be greater than 1
                else
                    appendSymbol = 3;

                // If the generated number is ge to 1 then the next char will be a letter
                if(appendSymbol >= 1)
                {
                    index = randGen.Next(0, lowerCaseLetters.Length - 1);
                    toAppend = lowerCaseLetters[index];
                    if (!password.Equals(""))
                    {
                        while (toAppend.Equals(password.ToCharArray()[password.ToCharArray().Length - 1]))
                        {
                            toAppend = lowerCaseLetters[randGen.Next(0, lowerCaseLetters.Length - 1)];
                        }
                    }
                    password += toAppend;
                }
                // Otherwise it'll append a symbol
                else
                {
                    index = randGen.Next(0, symbols.Length - 1);
                    toAppend = symbols[index];
                    password += toAppend;
                }

            }
            return password;
        }

    }
}
