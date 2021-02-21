
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;



public class Scrap
{
   
    public static void Main(string[] args)
    {
      

    }

}
public class Currency
{

    public string price { get; set; }
    public string growth { get; set; }
    public string name { get; set; }
    static string url = "https://goldprice.org/cryptocurrency-price";
    static Scraper scrapingBrowser = new Scraper();
    
    public Currency() { }
    public Currency(Currency currency)
    {

        this.price = currency.price;
        this.growth = currency.growth;
    }
    public static Currency[] GetCurr()
    {
        HtmlNode htmlNode = scrapingBrowser.ParseHtmlNode(scrapingBrowser.CallUrl(url));
        Currency[] curr = new Currency[78];
        Currency[] currs = new Currency[15];
        HtmlNodeCollection trNodes = htmlNode.SelectSingleNode("//div[@class='view-content']").SelectSingleNode("//table[@class='views-table cols-8 table table-striped table-hover table-condensed table-0']").SelectNodes("//tr");
        //var pricepath = "//td[@class='views-field views-field-field-crypto-price views-align-right']";
        //var growthpath = "//td[@class='views-field views-field-field-crypto-price-change-pc-24h views-align-right']";
        for (int i = 1; i < trNodes.Count; i++)
        {
           
            curr[i - 1] = new Currency();
            curr[i - 1].name = trNodes[i].ChildNodes[3].InnerText.Trim().Replace("\n", "").Replace("&nbsp;", "");
            curr[i - 1].price = trNodes[i].ChildNodes[7].InnerText.Trim().Replace("\n", "");
            curr[i - 1].growth = trNodes[i].ChildNodes[13].InnerText.Trim().Replace("\n", "");
            if (curr[i - 1].name == "Bitcoin")
            {
                currs[0] = curr[i - 1];
            }
            else if (curr[i - 1].name == "Ethereum")
            {
                currs[1] = curr[i - 1];
            }
            else if (curr[i - 1].name == "Tether")
            {
                currs[2] = curr[i - 1];
            }
            else if (curr[i - 1].name == "XRP")
            {
                currs[3] = curr[i - 1];
            }
            else if (curr[i - 1].name == "Cardano")
            {
                currs[4] = curr[i - 1];
            }
            else if (curr[i - 1].name == "Litecoin")
            {
                currs[5] = curr[i - 1];
            }
        }
        return currs;
    }

    public static Currency GetBitcoin()
    {
        HtmlNode htmlNode = scrapingBrowser.ParseHtmlNode(scrapingBrowser.CallUrl(url));
        var bitcoin = new Currency();
        var pricepath = "//td[@class='views-field views-field-field-crypto-price views-align-right']";
        var growthpath = "//td[@class='views-field views-field-field-crypto-price-change-pc-24h views-align-right']";
        bitcoin.price = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(pricepath).InnerText.Trim().Replace("/n", " ");
        bitcoin.growth = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(growthpath).InnerText.Trim().Replace("/n", " ");
        return bitcoin;
    }
    public static Currency GetEther()
    {
        HtmlNode htmlNode = scrapingBrowser.ParseHtmlNode(scrapingBrowser.CallUrl(url));
        var bitcoin = new Currency();
        var pricepath = "//td[@class='views-field views-field-field-crypto-price views-align-right']";
        var growthpath = "//td[@class='views-field views-field-field-crypto-price-change-pc-24h views-align-right']";
        bitcoin.price = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(pricepath).InnerText.Trim().Replace("/n", " ");
        bitcoin.growth = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(growthpath).InnerText.Trim().Replace("/n", " ");
        return bitcoin;
    }

}
