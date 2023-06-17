using System;

namespace PasswordAssembly
{
    public class Password
    {
        public bool examine(string password)
        {
            bool num = false;
            bool upperLetter = false;
            bool lowerLetter = false;
            foreach(char c in password)
            {
                if(c >= '0' && c <= '9')
                {
                    num = true;
                }
                if (c >= 'A' && c <= 'Z')
                {
                    upperLetter = true;
                }
                if (c >= 'a' && c <= 'z')
                {
                    lowerLetter = true;
                }
            }

            return (num && upperLetter && lowerLetter);

        }

    }
}
