using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;

//using ApprovalUtilities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class GildedRoseTest
    {
        private IEnumerable<string> names;
        private IEnumerable<int> sellIns;
        private IEnumerable<int> qualities;

        public GildedRoseTest()
        {
            names = new[] { "foo", "bar", "baz" };
            sellIns = Enumerable.Range(-2, 15);
            qualities = Enumerable.Range(-2, 15);
        }
        [Test]
        public void foo()
        {
            CombinationApprovals.VerifyAllCombinations(TestFoo, names, sellIns, qualities);
        }

        [Test]
        public void brie()
        {
            CombinationApprovals.VerifyAllCombinations(TestBrie, sellIns, qualities);
        }

        [Test]
        public void backstage()
        {
            CombinationApprovals.VerifyAllCombinations(TestBackstage, sellIns, qualities);
        }

        [Test]
        public void conjured()
        {
            CombinationApprovals.VerifyAllCombinations(TestConjured, names, sellIns, qualities);
        }

        [Test]
        public void sulfuras()
        {
            CombinationApprovals.VerifyAllCombinations(TestSulfuras, sellIns);
        }

        private string TestFoo(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new GeneralItem(name, sellIn, quality) };
            return TestIt(Items);
        }

        private string TestBrie(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new AgedBrie(sellIn, quality) };
            return TestIt(Items);
        }

        private string TestBackstage(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new BackstagePass(sellIn, quality) };
            return TestIt(Items);
        }

        private string TestConjured(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Conjured(name, sellIn, quality) };
            return TestIt(Items);
        }

        private string TestSulfuras(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Sulfuras(sellIn) };
            return TestIt(Items);
        }

        private static string TestIt(IList<Item> Items)
        {
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items[0].ToString();
        }
    }
}
