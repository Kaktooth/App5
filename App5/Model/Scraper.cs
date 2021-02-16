using System;
using System.Collections.Generic;
using System.Text;

using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

using System.IO;
using System.Linq;

public sealed class Scraper
{
    public Scraper() { }

    private static async Task<string> CallUrl(string fullUrl)
    {
        HttpClient client = new HttpClient();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        client.DefaultRequestHeaders.Accept.Clear();
        var response = client.GetStringAsync(fullUrl);
        return await response;
    }
    private List<string> ParseHtmlList(string html)
    {
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        var programmerLinks = htmlDoc.DocumentNode.Descendants("li")
                .Where(node => !node.GetAttributeValue("class", "").Contains("tocsection")).ToList();

        List<string> wikiLink = new List<string>();

        foreach (var link in programmerLinks)
        {
            if (link.FirstChild.Attributes.Count > 0)
                wikiLink.Add("https://en.wikipedia.org/" + link.FirstChild.Attributes[0].Value);
        }

        return wikiLink;

    }
    public HtmlNode ParseHtmlNode(string html)
    {
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        return htmlDoc.DocumentNode;
    }
    public string GetHtml(string url)
    {
        
         var response = CallUrl(url).Result;
         return response;
    }


}

