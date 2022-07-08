namespace csharp
{
    public class AgedBrie : BaseItem
    {
        public AgedBrie(int sellIn, int quality) : base()
        {
            this.Name = "Aged Brie";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void UpdateQuality()
        {
            AdjustQualityBy(1);
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
                AdjustQualityBy(1);
            }
        }
    }
}
