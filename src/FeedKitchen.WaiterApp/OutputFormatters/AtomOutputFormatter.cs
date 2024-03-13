using FeedKitchen.Waiter.Extensions;
using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using System.Xml;

namespace FeedKitchen.Waiter.OutputFormatters
{
    public class Atom1OutputFormatter : BaseOutputFormatter
    {
        public Atom1OutputFormatter()
            : base("application/atom+xml")
        { }

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var menu = context.Object as Menu;

            var response = context.HttpContext.Response;

            using (var xmlWriter = XmlWriter.Create(response.Body))
            {
                var feed = await menu.Serve();
                feed.SaveAsAtom10(xmlWriter);
            }
        }
    }
}
