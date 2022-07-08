using System;

namespace csharp
{
    public class BackstagePass : BaseItem
    {
        public BackstagePass(int sellIn, int quality) : base()
        {
            this.Name = "Backstage passes to a TAFKAL80ETC concert";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void UpdateQuality()
        {
            AdjustQualityBy(1);
            if (this.SellIn < 11)
            {
                AdjustQualityBy(1);
            }

            if (this.SellIn < 6)
            {
                AdjustQualityBy(1);
            }

            HandleSellIn();
        }

        private void HandleSellIn()
        {
            AdjustSellInBy(-1);
            HandleIfExpired();
        }

        private void HandleIfExpired()
        {
            if (this.IsExpired)
            {
                this.Quality = 0;
            }
        }
    }
}
