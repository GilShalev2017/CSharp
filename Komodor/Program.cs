using System;
using System.Collections.Generic;

namespace Komodor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var input = new string[] { "9000 app.intel.com", "100 intel.com", "100 google.com" };
            var input = new string[] { "9000 app.komodor.com", "100 komodor.com", "100 google.com" };

            var dic = new Dictionary<string,int>();

            foreach (string pair in input)
            {
                var splits = pair.Split(' ');
                var counter = Convert.ToInt32(splits[0]);
                var domain = splits[1];
                var subdomains = domain.Split(".");

                var currentSubdomain = "";

                for(int i=(subdomains.Length-1); i>=0; i--)
                {
                    if(string.IsNullOrEmpty(currentSubdomain))
                    {
                        currentSubdomain = subdomains[i];
                    }
                    else
                    {
                        currentSubdomain = subdomains[i] + "." + currentSubdomain;
                    }

                    if(!dic.ContainsKey(currentSubdomain))
                    {
                        dic.Add(currentSubdomain, counter);
                    }
                    else
                    {
                        dic[currentSubdomain] += counter;
                    }
                }
            }

            var result = "Output: [";

            foreach (var subdomain in dic.Keys)
            {
                result += String.Format("{0} {1} ", dic[subdomain] ,subdomain);
            }

            result += "]";

            Console.WriteLine(result);
        }
    }
}
