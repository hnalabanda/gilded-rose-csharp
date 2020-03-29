using System.Collections.Generic;
using FluentAssertions;
using GildedRose;
using NUnit.Framework;

namespace TestProject1
{
    public class GoldenMasterTest
    {
       
        [Test]
        public void MatchesAfter10Days()
        {
            var items = new List<Item>

            {

                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},

                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},

                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},

                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},

                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},

                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},

                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},

                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},

                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}

            };

            var _gildedRose=new GildedRose.GildedRose(items);
            for (var i = 0; i < 10; i++)

            {

                _gildedRose.UpdateQuality();
              
            }
            items[0].Should().BeEquivalentTo(new Item { Name = "+5 Dexterity Vest", Quality = 10, SellIn = 0 });

            items[1].Should().BeEquivalentTo(new Item { Name = "Aged Brie", Quality = 18, SellIn = -8 });

            items[2].Should().BeEquivalentTo(new Item { Name = "Elixir of the Mongoose", Quality = 0, SellIn = -5 });

            items[3].Should().BeEquivalentTo(new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 });

            items[4].Should().BeEquivalentTo(new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = -1 });

            items[5].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 35, SellIn = 5 });

            items[6].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 50, SellIn = 0 });

            items[7].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 0, SellIn = -5 });

            items[8].Should().BeEquivalentTo(new Item { Name = "Conjured Mana Cake", Quality = 0, SellIn = -7 });
        }
    }
}