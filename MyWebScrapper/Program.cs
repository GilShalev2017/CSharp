// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;

Console.WriteLine("Hello, World!");

HtmlWeb web = new HtmlWeb();

HtmlDocument document = web.Load("http://www.c-sharpcorner.com");

//Console.WriteLine(document.ParsedText);

HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();

foreach (HtmlNode item in nodes)
{
    Console.WriteLine(item.InnerHtml);
}

Console.ReadLine();