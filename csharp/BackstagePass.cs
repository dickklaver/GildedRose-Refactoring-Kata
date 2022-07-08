using System;

namespace csharp
{
    public class BackstagePass : BaseItem
    {
        private const int FIRST_THRESHOLD = 11;
        private const int SECOND_THRESHOLD = 6;

        public BackstagePass(int sellIn, int quality) : base()
        {
            this.Name = "Backstage passes to a TAFKAL80ETC concert";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void UpdateQuality()
        {
            AdjustQualityBy(1);
            AdjustQualityIfPastFistThreshold();
            AdjustQualityIfPastSecondThreshold();
            HandleSellIn();
        }

        private void AdjustQualityIfPastSecondThreshold()
        {
            if (this.SellIn < SECOND_THRESHOLD)
            {
                AdjustQualityBy(1);
            }
        }

        private void AdjustQualityIfPastFistThreshold()
        {
            if (this.SellIn < FIRST_THRESHOLD)
            {
                AdjustQualityBy(1);
            }
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
