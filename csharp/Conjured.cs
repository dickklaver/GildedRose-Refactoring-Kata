namespace csharp
{
    public class Conjured : BaseItem 
    {
        public Conjured(string name, int sellIn, int quality) : base()
        {
            this.Name = "Conjured " + name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void UpdateQuality()
        {
            AdjustQualityBy(-2);
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
                AdjustQualityBy(-2);
            }
        }
    }
}
