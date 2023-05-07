using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MyWebCrawller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HtmlWeb web = new HtmlWeb();

            HtmlDocument document = web.Load("http://www.c-sharpcorner.com");

            //HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();

            //foreach (HtmlNode item in nodes)
            //{
            //    Console.WriteLine(item.InnerHtml);
            //}

            HtmlNodeCollection nodes2 = document.DocumentNode.SelectNodes("//a");
         
            foreach (HtmlNode node in nodes2)
            {
                Console.WriteLine(node.InnerHtml);

                string linkText = node.InnerText;

                string linkUrl = node.GetAttributeValue("href", "");

                File.WriteAllText("output.txt", linkText + " " + linkUrl);
            }
        }
    }
}
