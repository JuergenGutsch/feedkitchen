using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Func<T, T> action)
        {
            foreach (var item in enumerable)
            {
                yield return action(item);
            }
        }
    }
}
