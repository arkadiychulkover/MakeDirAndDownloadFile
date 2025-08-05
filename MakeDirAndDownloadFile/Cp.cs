using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeDirAndDownloadFile
{
    internal class Cp
    {
        public void crypt(string word)
        {
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    char d = (char)(c + 3);
                    if (char.IsUpper(c) && d > 'Z')
                    {
                        d = (char)(d - 26);
                    }
                    else if (char.IsLower(c) && d > 'z')
                    {
                        d = (char)(d - 26);
                    }
                    Console.Write(d);
                }
                else
                {
                    Console.Write(c);
                }
            }
        }
        public string decrypt(string word)
        {
            StringBuilder decryptedWord = new StringBuilder();
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    char d = (char)(c - 3);
                    if (char.IsUpper(c) && d < 'A')
                    {
                        d = (char)(d + 26);
                    }
                    else if (char.IsLower(c) && d < 'a')
                    {
                        d = (char)(d + 26);
                    }
                    decryptedWord.Append(d);
                }
                else
                {
                    decryptedWord.Append(c);
                }
            }
            return decryptedWord.ToString();
        }
    }
}
