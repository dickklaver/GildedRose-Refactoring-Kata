using System;

namespace csharp
{
    public abstract class BaseItem : Item
    {
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
            if (this.Quality < 0)
            {
                this.Quality = 0;
            }

            if (this.Quality > 50)
            {
                this.Quality = 50;
            }
        }

        protected void AdjustSellInBy(int increment)
        {
            this.SellIn += increment;
        }
    }
}
