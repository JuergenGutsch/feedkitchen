using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;

namespace FeedKitchen.MenuWaiter
{
    public abstract class BaseOutputFormatter : TextOutputFormatter
    {
        protected BaseOutputFormatter(string contentType)
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(contentType));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(Menu).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
    }
}
