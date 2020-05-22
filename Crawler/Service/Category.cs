using HtmlAgilityPack;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Category : ICategory
    {
        public void Crawler(string htmlStr)
        {
            if (string.IsNullOrEmpty(htmlStr))
            {
                throw new ArgumentNullException();
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlStr);
            HtmlNodeCollection firstHtmls = htmlDocument.DocumentNode.SelectNodes(@"//dl/dt/a");
            foreach (var firstHtml in firstHtmls)
            {
                Console.Write($"{firstHtml.InnerText}:");
                string secondHtmlStr = firstHtml.ParentNode.ParentNode.OuterHtml;//SelectNodes(@"//dd/a");
                HtmlDocument htmlDocumentSecond = new HtmlDocument();
                htmlDocumentSecond.LoadHtml(secondHtmlStr);
                HtmlNodeCollection secondHtmls = htmlDocumentSecond.DocumentNode.SelectNodes(@"//dd/a");
                foreach (var secondHtml in secondHtmls)
                {
                    Console.Write($"{secondHtml.InnerText},");
                }

                //foreach (var secondHtml in secondHtmls)
                //{
                //    Console.Write($"{secondHtml.InnerText}");
                //}
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
        }
    }
}
