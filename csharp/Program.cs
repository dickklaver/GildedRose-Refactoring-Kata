using System;
using System.Collections.Generic;

namespace csharp
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new GeneralItem("+5 Dexterity Vest", 10, 20),
                new AgedBrie(2, 0),
                new GeneralItem("Elixir of the Mongoose", 5, 7),
                new Sulfuras(0),
                new Sulfuras(-1),
                new BackstagePass(15, 20),
                new BackstagePass(10, 49),
                new BackstagePass(5, 49),
                new Conjured("Mana Cake", 3, 6),
                new Conjured("Mana Cake", 3, 7),
                new Conjured("Other Cake", 3, 13),
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
