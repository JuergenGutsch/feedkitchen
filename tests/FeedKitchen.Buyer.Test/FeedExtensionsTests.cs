using Xunit;
using FeedKitchen.Buyer.Extensions;
using CodeHollow.FeedReader;
using System.Collections.Generic;
using System;
using FeedKitchen.Shared.Models;
using System.Linq;
using FluentAssertions;

namespace FeedKitchen.Buyer.Tests;

public class FeedExtensionsTests
{
    [Fact]
    public void Convert_FeedItemToFixing_Test()
    {
        // Arrange
        var feedItem = new FeedItem
        {
            Id = "1",
            Title = "Test Title",
            Link = "http://test.com",
            Author = "Test Author",
            Categories = new List<string> { "Test" },
            PublishingDate = DateTime.Now,
            Content = "Test Content",
            Description = "Test Description"
        };

        var expected = new FixingModel
        {
            Title = feedItem.Title,
            Link = new Uri(feedItem.Link),
            Author = feedItem.Author,
            Categories = feedItem.Categories,
            PublishingDate = feedItem.PublishingDate,
            Content = feedItem.Content,
            Summary = feedItem.Description
        };

        // Act
        var actual = feedItem.Convert(0);

        // Assert
        

        
        actual.Should().BeEquivalentTo(expected);
        actual.Title.Should().Be(expected.Title);
        actual.Link.Should().Be(expected.Link);
        actual.Author.Should().Be(expected.Author);
        actual.Categories.Should().Equal(expected.Categories);
        actual.PublishingDate.Should().Be(expected.PublishingDate);
        actual.Content.Should().Be(expected.Content);
        actual.Summary.Should().Be(expected.Summary);

    }

    [Fact]
    public void Convert_FeedItemsToFixings_Test()
    {
        // Arrange
        var feedItems = new List<FeedItem>
        {
            new FeedItem
            {
                Id = "1",
                Title = "Test Title 1",
                Link = "http://test1.com",
                Author = "Test Author 1",
                Categories = new List<string> { "Test1" },
                PublishingDate = DateTime.Now,
                Content = "Test Content 1",
                Description = "Test Description 1"
            },
            new FeedItem
            {
                Id = "2",
                Title = "Test Title 2",
                Link = "http://test2.com",
                Author = "Test Author 2",
                Categories = new List<string> { "Test2" },
                PublishingDate = DateTime.Now,
                Content = "Test Content 2",
                Description = "Test Description 2"
            }
        };

        var expected = feedItems.Select(item => new FixingModel
        {
            Title = item.Title,
            Link = new Uri(item.Link),
            Author = item.Author,
            Categories = item.Categories,
            PublishingDate = item.PublishingDate,
            Content = item.Content,
            Summary = item.Description
        });

        // Act
        var actual = feedItems.Convert(0);

        // Assert
        actual.Count().Should().Be(expected.Count());
        for (int i = 0; i < expected.Count(); i++)
        {
            actual.ElementAt(i).Title.Should().Be(expected.ElementAt(i).Title);
            actual.ElementAt(i).Link.Should().Be(expected.ElementAt(i).Link);
            actual.ElementAt(i).Author.Should().Be(expected.ElementAt(i).Author);
            actual.ElementAt(i).Categories.Should().Equal(expected.ElementAt(i).Categories);
            actual.ElementAt(i).PublishingDate.Should().Be(expected.ElementAt(i).PublishingDate);
            actual.ElementAt(i).Content.Should().Be(expected.ElementAt(i).Content);
            actual.ElementAt(i).Summary.Should().Be(expected.ElementAt(i).Summary);

        }
    }
}
