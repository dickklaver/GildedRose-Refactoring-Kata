using System.Collections.Generic;
using System.Linq;

namespace csharp
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
            var baseItems = Items.Cast<BaseItem>();
            foreach (var item in baseItems)
            {
                item.UpdateQuality();
            }
        }
    }
}
