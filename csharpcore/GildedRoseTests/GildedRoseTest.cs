using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        /*
         *
			# - Once the sell by date has passed, Quality degrades twice as fast
			#- The Quality of an item is never negative
			#- "Aged Brie" actually increases in Quality the older it gets
			#- The Quality of an item is never more than 50
			- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
			- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
			Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
			Quality drops to 0 after the concert
         * 
         */
        
        [Fact]
        public void Quality_of_item_is_never_negative_after_update()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }
        // 
        
        [Fact]
        public void Quality_of_aged_brie_increased_after_update()
        {
	        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
	        var app = new GildedRose(items);
	        app.UpdateQuality();
	        Assert.Equal(1, items[0].Quality);
        }
        
        //- The Quality of an item is never more than 50
        
        [Fact]
        public void Quality_of_aged_brie_increased_not_above_50_after_update()
        {
	        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
	        var app = new GildedRose(items);
	        app.UpdateQuality();
	        Assert.Equal(50, items[0].Quality);
        }
        
        //- Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void Quality_decreased_by_2_after_sell_date_passed()
        {
	        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
	        var app = new GildedRose(items);
	        app.UpdateQuality();
	        Assert.Equal(50, items[0].Quality);
        }
    }
}
