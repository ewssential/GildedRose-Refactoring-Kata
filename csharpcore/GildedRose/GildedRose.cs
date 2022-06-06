using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private static readonly string AgedBrie = "Aged Brie";
        private static readonly string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        private static readonly string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        private static readonly List<string> IncreaseQuality = new List<string>()
            { AgedBrie, BackstagePassesToATafkal80EtcConcert };
        
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var t in Items)
            {
                if (t.Name == SulfurasHandOfRagnaros)
                    continue;
                    
                if (!IncreaseQuality.Contains(t.Name))
                {
                    if (t.Quality > 0)
                    {
                        t.Quality = t.Quality - 1;
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality = t.Quality + 1;

                        if (t.Name == BackstagePassesToATafkal80EtcConcert)
                        {
                            if (t.SellIn < 11)
                            {
                                if (t.Quality < 50)
                                {
                                    t.Quality = t.Quality + 1;
                                }
                            }

                            if (t.SellIn < 6)
                            {
                                if (t.Quality < 50)
                                {
                                    t.Quality = t.Quality + 1;
                                }
                            }
                        }
                    }
                }

                t.SellIn = t.SellIn - 1;

                if (t.SellIn < 0)
                {
                    if (t.Name != AgedBrie)
                    {
                        if (t.Name != BackstagePassesToATafkal80EtcConcert)
                        {
                            if (t.Quality > 0)
                            {
                                t.Quality = t.Quality - 1;
                            }
                        }
                        else
                        {
                            t.Quality = t.Quality - t.Quality;
                        }
                    }
                    else
                    {
                        if (t.Quality < 50)
                        {
                            t.Quality = t.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
