using System;
using System.Collections.Generic;



namespace GildedRose

{

    public class GildedRose

    {

        IList<Item> Items;

        public GildedRose(IList<Item> Items)

        {

            this.Items = Items;

        }



        public void UpdateQuality()

        {
            foreach (var item in Items)
            {
                item.Quality = UpdateItemQuality(item);
                item.SellIn = UpdateItemSellInDate(item);

            }

         

        }

        private int UpdateItemSellInDate(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return item.SellIn;
            }
            else
            {
                return item.SellIn-=1;
            }

          
        }

        private int UpdateItemQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return item.Quality;
            }
            else
            {
                var newQuality=item.Name switch
                {
                    "Aged Brie" => GetAgedBrieQualityUpdates(item),
                    "Backstage passes to a TAFKAL80ETC concert" => GetBackstageQualityUpdates(item),
                    "Conjured Mana Cake" => GetConjuredQualityUpdates(item),
                    _ => GetDefaultQualityUpdates(item)
                };
                return GetQualityChange(newQuality);
            }
           

        }

        private int GetQualityChange(int newQuality)
        {
           
                return Math.Max(0,Math.Min(newQuality,50));
          
         
        }
        private int GetDefaultQualityUpdates(Item item)
        {
          
                var newQuality = item.SellIn <= 0 ? item.Quality -= 2 : item.Quality -= 1;
                return newQuality;
        
         
        }

        private int GetConjuredQualityUpdates(Item item)
        { var i=GetDefaultQualityUpdates(item);
            return GetDefaultQualityUpdates(item);
        }

        private int GetBackstageQualityUpdates(Item item)
        {
            if (item.SellIn <=0)
            {
                return 0;

            }
            if (item.SellIn >= 10 )
            {
                return item.Quality += 1;

            }
         
            return item.SellIn <= 5?item.Quality += 3:item.Quality += 2;
        }

        private int GetAgedBrieQualityUpdates(Item item)
        {
            return item.SellIn<=0?item.Quality += 2:item.Quality += 1;
        }
    }

}