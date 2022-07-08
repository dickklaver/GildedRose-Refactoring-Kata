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

        public bool IsExpired
        {
            get
            {
                return this.SellIn < 0;
            }
        }

        public abstract void UpdateQuality();

        protected void AdjustQualityBy(int increment)
        {
            this.Quality += increment;
            if (this.Quality < MINIMUM_QUALITY)
            {
                this.Quality = MINIMUM_QUALITY;
            }

            if (this.Quality > MAXIMUM_QUALITY)
            {
                this.Quality = MAXIMUM_QUALITY;
            }
        }

        protected void AdjustSellInBy(int increment)
        {
            this.SellIn += increment;
        }
    }
}
