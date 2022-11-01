using System;
using System.Collections.Generic;

namespace MAX_Part2
{
    class Program
    {
        const String str = "Hello dear ##NAME##,\n" +
            "You are invited to a job interview for ##JOB##\n" +
            "on: ##DATE##.\n" +
            "Good Luck!\n";

        static void Main(string[] args)
        {
            //Console.WriteLine(str);

            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("NAME", "Yitzhak"));
            list.Add(new KeyValuePair<string, string>("JOB", "Developer"));
            list.Add(new KeyValuePair<string, string>("DATE", "02/11/2022"));

            Console.WriteLine(ShowFinalString(str, list));
        }

        static private String ShowFinalString(String str, List<KeyValuePair<string, string>> list)
        {
            String result = "";
            Boolean matchFlag = false;
            int amount = 0;

            if (str == null || list == null)
            {
                return "You must enter a params in Main";
            }

            string[] splittedList = str.Split("##");

            if (splittedList.Length < 3)
            {
                return "Params are missing";
            }

            foreach (string s in splittedList)
            {
                matchFlag = false;

                foreach (KeyValuePair<string, string> kvp in list)
                {
                    if (s.Equals(kvp.Key))
                    {
                        matchFlag = true;
                        amount++;
                        result += kvp.Value;
                    }
                }

                if (!matchFlag)
                {
                    result += s;
                }
            }

            if (amount != list.Count)
                return "Not the same params count for String and List.";

            return result;
        }
    }
}
