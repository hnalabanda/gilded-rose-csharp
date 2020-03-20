using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.Quality = GetUpdatedItemQuality(item);
                item.SellIn = GetUpdatedSellInValue(item);
                UpdateOutOfDateItems(item);
            }
        }

        private int GetBackStagePassQualityChange(Item item)
        {
            if (item.SellIn > 10)
            {
                return 1;
            }

            return item.SellIn > 5 ? 2 : 3;
        }

        private int GetChangeInQuality(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => 1,
                "Backstage passes to a TAFKAL80ETC concert" => GetBackStagePassQualityChange(item),
                _ => -1
            };
        }

        private int GetUpdatedItemQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                // Quality of Sulfuras, Hand of Ragnaros should never change.
                return item.Quality;
            }
            
            var changeInQuality = GetChangeInQuality(item);
            return Math.Max(0, Math.Min(50, item.Quality + changeInQuality));
        }


        private int GetUpdatedSellInValue(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return item.SellIn;
            }

            return item.SellIn - 1;
        }

        private void UpdateOutOfDateItems(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}