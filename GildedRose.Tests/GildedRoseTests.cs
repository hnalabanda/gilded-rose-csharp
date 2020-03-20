using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Test]
        public void RegularItemsDecreaseTheirSellInValueByOneEachDay()
        {
            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.SellIn.Should().Be(4);
        }

        [Test]
        public void SulfurasNeverDecreaseTheirSellInValue()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.SellIn.Should().Be(5);
        }

        [Test]
        public void RegularItemsDecreaseInQualityByOneEachDay()
        {
            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(9);
        }
        
        [Test]
        public void RegularItemsDoNotDecreaseTheirValueBelowZero()
        {
            var item = new Item { Name = "Test Item", Quality = 0, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(0);
        }
        
        [Test]
        public void AgedBrieIncreasesInQualityByOneEachDay()
        {
            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(11);
        }
        
        [Test]
        public void AgedBrieCannotIncreaseInValueAbove50()
        {
            var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(50);
        }

        [Test]
        public void BackstagePassesIncreaseInValueEachDayByOneLongBeforeTheEvent()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 11};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(11);
        }
        
        [Test]
        public void BackstagePassesIncreaseInValueEachDayByTwoCloserToTheEvent()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 6};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(12);
        }
        
        [Test]
        public void BackstagePassesIncreaseInValueEachDayByThreeJustBeforeTheEvent()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(13);
        }
        
        [Test]
        public void TheQualityOfSulfurasNeverChanges()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(80);
        }

        [Test]
        public void RegularItemsDecreaseInQualityFasterIfOutOfDate()
        {
            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 0};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(8);
        }
        
        [Test]
        public void AgedBrieIncreasesInQualityFasterIfOutOfDate()
        {
            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 0};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(12);
        }
        
        [Test]
        public void BackstagePassesHaveZeroValueIfOutOfDate()
        {
            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 0};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(12);
        }
    }
}