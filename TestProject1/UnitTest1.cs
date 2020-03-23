using System;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        private GildedRose.GildedRose _gildedRose;
        private IList<Item> Items;
        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        public void QualityOfItemIsNeverNegative()
        {
            Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            _gildedRose=new GildedRose.GildedRose(Items);
            _gildedRose.UpdateQuality();
            /*_gildedRose.UpdateQuality();
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Quality.Should().BePositive();
            }

            Assert.Pass();*/
            Items[0].Quality.Should().Be(19);
            Items[1].Quality.Should().Be(1);
            Items[2].Quality.Should().Be(6);
            Items[3].Quality.Should().Be(80);
            Items[4].Quality.Should().Be(80);
            Items[5].Quality.Should().Be(21);
           Items[6].Quality.Should().Be(50);
           Items[7].Quality.Should().Be(50);
            Items[8].Quality.Should().Be(5);
          //  Items[9].Quality.Should().Be(6);
        }
        /*[Test]
        public void QualityDegradesTwiceOnceSellDatePassed()
        {
            _gildedRose.UpdateQuality();
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Quality.Should().BePositive();
            }

            Assert.Pass();
        }*/
    }
}