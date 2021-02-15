using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace App2.Droid.Model
{

    class Currency
    {
        public string price { get; set; }
        public string growth { get; set; }
        static string url = "https://goldprice.org/cryptocurrency-price";
        static ScrapingBrowser scrapingBrowser = new ScrapingBrowser();
      
        public Currency() { }
        public Currency( Currency currency)
        {
            this.price = currency.price;
            this.growth = currency.growth;
        }
        public static Currency GetBitcoin()
        {
            var htmlNode = GetHtml(url);
            var bitcoin = new Currency();
            var pricepath = "//td[@class='views-field views-field-field-crypto-price views-align-right']";
            var growthpath = "//td[@class='views-field views-field-field-crypto-price-change-pc-24h views-align-right']";
            bitcoin.price = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(pricepath).InnerText.Trim().Replace("/n", " ");
            bitcoin.growth = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode(growthpath).InnerText.Trim().Replace("/n", " ");
            return bitcoin;
        }
        static HtmlNode GetHtml(string url)
        {
            WebPage webPage = scrapingBrowser.NavigateToPage(new Uri(url));
            return webPage.Html;
        }
    }
}
