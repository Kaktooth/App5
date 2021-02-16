
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
    static string url = "https://goldprice.org/cryptocurrency-price";
    static Scraper scrapingBrowser = new Scraper();
    
    public Currency() { }
    public Currency(Currency currency)
    {

        this.price = currency.price;
        this.growth = currency.growth;
    }
    public static Currency GetBitcoin()
    {
        HtmlNode htmlNode = scrapingBrowser.ParseHtmlNode(scrapingBrowser.GetHtml(url));
        var bitcoin = new Currency();
        var pricepath = "//td[@class='views-field views-field-field-crypto-price views-align-right']";
        var growthpath = "//td[@class='views-field views-field-field-crypto-price-change-pc-24h views-align-right']";
        bitcoin.price = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(pricepath).InnerText.Trim().Replace("/n", " ");
        bitcoin.growth = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(growthpath).InnerText.Trim().Replace("/n", " ");
        return bitcoin;
    }
    
}
