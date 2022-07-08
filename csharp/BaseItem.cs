using System;

namespace csharp
{
    public abstract class BaseItem : Item
    {
        public const int MINIMUM_QUALITY = 0;
        public const int MAXIMUM_QUALITY = 50;

        public BaseItem() : base()
        {
        }

        public bool IsExpired => this.SellIn < 0;

        public abstract void UpdateQuality();

        protected void AdjustQualityBy(int increment)
        {
            this.Quality += increment;
            HandleIfBelowMinimumQuality();
            HandleIfOverMaximumQuality();
        }

        private void HandleIfOverMaximumQuality()
        {
            if (this.Quality > MAXIMUM_QUALITY)
            {
                this.Quality = MAXIMUM_QUALITY;
            }
        }

        private void HandleIfBelowMinimumQuality()
        {
            if (this.Quality < MINIMUM_QUALITY)
            {
                this.Quality = MINIMUM_QUALITY;
            }
        }

        protected void AdjustSellInBy(int increment)
        {
            this.SellIn += increment;
        }
    }
}
