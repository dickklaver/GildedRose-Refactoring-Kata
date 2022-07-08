using ApprovalTests.Combinations;
using ApprovalTests.Reporters;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    [UseReporter(typeof(WinMergeReporter))]
    public class GildedRoseTest
    {
        private IEnumerable<string> names;
        private IEnumerable<int> sellIns;
        private IEnumerable<int> qualities;

        public GildedRoseTest()
        {
            names = new[] { "foo", "bar", "baz" };
            sellIns = Enumerable.Range(-2, 15);
            qualities = Enumerable.Range(-2, 60);
        }

        [Test]
        public void TestGeneralItems()
        {
            CombinationApprovals.VerifyAllCombinations(HandleFoo, names, sellIns, qualities);
        }

        [Test]
        public void TestAgedBrie()
        {
            CombinationApprovals.VerifyAllCombinations(HandleAgedBrie, sellIns, qualities);
        }

        [Test]
        public void TestBackstagePasses()
        {
            CombinationApprovals.VerifyAllCombinations(HandleBackstagePasses, sellIns, qualities);
        }

        [Test]
        public void TestConjuredItems()
        {
            CombinationApprovals.VerifyAllCombinations(HandleConjured, names, sellIns, qualities);
        }

        [Test]
        public void TestSulfuras()
        {
            CombinationApprovals.VerifyAllCombinations(HandleSulfuras, sellIns);
        }

        private string HandleFoo(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new GeneralItem(name, sellIn, quality) };
            return UpdateTheQuality(Items);
        }

        private string HandleAgedBrie(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new AgedBrie(sellIn, quality) };
            return UpdateTheQuality(Items);
        }

        private string HandleBackstagePasses(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new BackstagePass(sellIn, quality) };
            return UpdateTheQuality(Items);
        }

        private string HandleConjured(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Conjured(name, sellIn, quality) };
            return UpdateTheQuality(Items);
        }

        private string HandleSulfuras(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Sulfuras(sellIn) };
            return UpdateTheQuality(Items);
        }

        private static string UpdateTheQuality(IList<Item> Items)
        {
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items[0].ToString();
        }
    }
}
