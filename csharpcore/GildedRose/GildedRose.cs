using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        private static readonly List<string> IncreaseQualityItems = new List<string>()
            { AgedBrie, BackstagePassesToATafkal80EtcConcert };

        private static int _maxQuality = 50;

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
                    
                if (IncreaseQualityPossible(t))
                {
                    IncreaseQuality(t);
                }
                else
                {
                    DecrementQuality(t);
                }

                t.SellIn -= 1;

                if (t.SellIn < 0)
                {
                    SellInLessZero(t);
                }
            }
        }

        private static bool IncreaseQualityPossible(Item t)
        {
            return IncreaseQualityItems.Contains(t.Name);
        }

        private static void IncreaseQuality(Item t)
        {
            IncrementQuality(t);
            IncreaseBackstagePasses(t);
        }

        private static void IncreaseBackstagePasses(Item t)
        {
            if (t.Name != BackstagePassesToATafkal80EtcConcert) return;
            switch (t.SellIn)
            {
                case < 6:
                    IncrementQuality(t);
                    IncrementQuality(t);
                    break;
                case  < 11:
                    IncrementQuality(t);
                    break;
            }
        }

        private static void IncrementQuality(Item t)
        {
            t.Quality = t.Quality < _maxQuality ? t.Quality + 1 : _maxQuality;
        }

        private static void SellInLessZero(Item t)
        {
            switch (t.Name)
            {
                case AgedBrie:
                    IncrementQuality(t);
                    break;
                case BackstagePassesToATafkal80EtcConcert:
                    SetQualityToZero(t);
                    break;
                default:
                    DecrementQuality(t);
                    break;
            }
        }

        private static void DecrementQuality(Item t)
        {
            t.Quality = t.Quality > 0 ? t.Quality - 1 : 0;
        }
        
        private static void SetQualityToZero(Item t)
        {
            t.Quality = 0;
        }
    }
}
