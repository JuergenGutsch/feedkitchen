using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedKitchen.MenuWaiter
{

    public class Rss2OutputFormatter : BaseOutputFormatter
    {
        public Rss2OutputFormatter() : base("text/atom")
        {
        }

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var menu = context.Object as Menu;

            var feed = new SyndicationFeed(
                "ASP.NET Hacker",
                "Feed Description",
                new Uri("https://asp.net-hacker.rocks/"),
                "https://asp.net-hacker.rocks/",
                DateTime.Now);

            var formater = feed.GetAtom10Formatter();

            var response = context.HttpContext.Response;

            var xmlWriter = XmlWriter.Create(response.Body);

            feed.SaveAsRss20(xmlWriter);
        }
    }
}
