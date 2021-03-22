using FeedKitchen.MenuWaiter.Extensions;
using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedKitchen.MenuWaiter
{

    public class Rss2OutputFormatter : BaseOutputFormatter
    {
        public Rss2OutputFormatter() : 
            base("application/rss+xml")
        {
        }

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var menu = context.Object as Menu;

            var response = context.HttpContext.Response;

            using (var xmlWriter = XmlWriter.Create(response.Body))
            {
                var feed = menu.Serve();
                feed.SaveAsRss20(xmlWriter);
            }
        }
    }
}
