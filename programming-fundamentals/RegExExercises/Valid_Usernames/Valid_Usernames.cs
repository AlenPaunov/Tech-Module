using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Valid_Usernames
{
    class Valid_Usernames
    {
        static void Main(string[] args)
        {
            string[] userNames = Regex.Split(Console.ReadLine(), @"[ \/\\()]");

            string pattern = @"(^[A-Za-z]{1}[a-zA-Z0-9_]{2,24}$)";

            List<string> validUsers = new List<string>();
            foreach (var user in userNames)
            {
                if (Regex.Match(user,pattern).Success)
                {
                    validUsers.Add(user);
                }
                
            }

            int maxLen = 0;
            int index = 0;

            for (int i = 0; i < validUsers.Count-1; i++)
            {
                int tempLen = validUsers[i].Length + validUsers[i + 1].Length;
                if (tempLen>maxLen)
                {
                    maxLen = tempLen;
                    index = i;
                }
            }

            Console.WriteLine(validUsers[index]+Environment.NewLine + validUsers[index+1]);
        }
    }
}
