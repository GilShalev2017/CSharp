using System;
using System.Collections.Generic;
using System.Linq;

namespace General
{
    internal class KomodorProgram
    {
        /*
        static void Main(string[] args)
        {
            var input = new string[] { "9000 app.komodor.com", "100 komodor.com", "100 google.com" };
            //var input = new string[] { "100 www.ynet.co.il" };

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach(var pair in input)
            {
                var splits = pair.Split(" ");
                var num = Convert.ToInt32(splits[0]);
                var domain = splits[1];
                var subdomains = domain.Split(".");

                var currentSubdomain = "";
             
                for (int i=(subdomains.Length-1);i>=0; i--)
                {
                    if(string.IsNullOrEmpty(currentSubdomain))
                    {
                        currentSubdomain = subdomains[i];
                    }
                    else
                    {
                        currentSubdomain = subdomains[i] + "." + currentSubdomain;
                    }

                    if (dic.ContainsKey(currentSubdomain))
                    {
                        dic[currentSubdomain] += num;
                    }
                    else
                    {
                        dic.Add(currentSubdomain, num);
                    }
                   
                }
            }

            string output = "[";
            foreach(var key in dic.Keys.Reverse())
            {
                output += dic[key] + " " + key  + ",";
            }
            output+= "]";
            Console.WriteLine(output);
        }
        */
    }
}
