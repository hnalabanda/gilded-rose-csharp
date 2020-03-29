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
        public void SellInDecreasesBy1EachDayForRegularItems()
        {
            var Items=new List<Item>
            { new Item {Name = "Test Item", SellIn = 5, Quality = 10}
            };
            _gildedRose=new GildedRose.GildedRose(Items);
            _gildedRose.UpdateQuality();
            Items[0].SellIn.Should().Be(4);
        }
        
        [Test]
     public void QualityIsNeverNegative()
     {
         var Items = new List<Item>
             {new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}};
         _gildedRose=new GildedRose.GildedRose(Items);
        
         
         for (var i = 0; i < 10; i++)
         {
             _gildedRose.UpdateQuality();
            
         }

         Items[0].Quality.Should().BeGreaterOrEqualTo(0);

     }

     [Test]
     public void SulfurasSellDateNeverDecreases()
     {
         var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 10, SellIn = 5};

         var gildedRose = new GildedRose.GildedRose(new List<Item> { item });
         gildedRose.UpdateQuality();
         item.SellIn.Should().Be(5);
     }
     
     [Test]
     public void QualityDecreasesForRegularItems()
     {
         var item = new Item { Name = "Test Item", Quality = 10, SellIn = 5};
         var gildedRose = new GildedRose.GildedRose(new List<Item> { item });
         gildedRose.UpdateQuality();
         item.Quality.Should().Be(9);
     }
     
        [Test]
        public void QualityDegradesTwiceOnceSellDatePassed()
        {   var item = new Item { Name = "Test Item", Quality = 10, SellIn = 0};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(8);

        }
        
        [Test]
        public void AgedBrieIncreasesInQuality()
        {   var item = new Item { Name = "Aged Brie", Quality = 11, SellIn = 5};
            _gildedRose=new GildedRose.GildedRose(new List<Item> { item });
            _gildedRose.UpdateQuality();
        
            item.Quality.Should().Be(12);
        }
        
        [Test]
        public void QualityNeverMoreThan50()
        {    var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 5};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();
            item.Quality.Should().Be(50);
        }
        
        [Test]
        public void QualityOfSulfurasNeverDecreases()
        {      var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 5};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(80);
        }
        
        [Test]

        public void BackstagePassesIncreaseInValueEachDayByOneLongBeforeTheEvent()

        {

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 11};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(11);

        }

        

        [Test]

        public void BackstagePassesIncreaseInValueEachDayByTwoCloserToTheEvent()

        {

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 6};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(12);

        }
        [Test]

        public void BackstagePassesIncreaseInValueEachDayByThreeJustBeforeTheEvent()

        {

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 5};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(13);

        }
        [Test]

        public void RegularItemsDecreaseInQualityFasterIfOutOfDate()

        {

            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 0};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(8);

        }
        [Test]

        public void AgedBrieIncreasesInQualityFasterIfOutOfDate()

        {

            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 0};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();



            item.Quality.Should().Be(12);

        }
       

        [Test]

        public void BackstagePassesHaveZeroValueIfOutOfDate()

        {

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 0};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(0);

        }

        [Test]

        public void ConjuredItemsDegradeTwiceAsFast()
        {
            var item = new Item { Name = "Conjured Mana Cake", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();
            item.Quality.Should().Be(8);
        }
      
        /*
           [Test]

        public void ConjuredItemsDegradeTwiceAsFast()
        {
            var item = new Item { Name = "Conjured Mana Cake", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();
            item.Quality.Should().Be(8);
        }
         [Test]

        public void OutOfDateConjuredItemsDegradeFourAsFast()

        {

            var item = new Item { Name = "Conjured Mana Cake", Quality = 10, SellIn = 0};

            var gildedRose = new GildedRose.GildedRose(new List<Item> { item });

            

            gildedRose.UpdateQuality();



            item.Quality.Should().Be(6);

        }*/
    }
}