namespace csharp
{
    public class Sulfuras : BaseItem
    {
        public Sulfuras(int sellIn) : base()
        {
            this.Name = "Sulfuras, Hand of Ragnaros";
            this.SellIn = sellIn;
            this.Quality = 80;
        }

        public override void UpdateQuality()
        {
            // no-op
        }
    }
}
