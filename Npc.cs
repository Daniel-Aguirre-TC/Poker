using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Npc : GamePlayer
    {

        static List<string> NamePool { get; set; }
        static List<string> UsedNames { get; set; }
        static Random random = new Random();



        /// <summary>
        /// Static constructor adds random names that can be assigned to Npc and also adds random Greetings to display when they are instantiated.
        /// </summary>
        static Npc()
        {
            NamePool.AddRange(new string[]
            {
                "Billy Bob", "Fedor Holz", "Patrik Antonius", "Phil Hellmuth"
            });


        }

        public Npc()
        {
            AssignName();
            IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[] { 
                $"{Name} is approaching the table!", "",
                $"We now have a total of {TotalPlayerCount} players at the table."
            });

        }

        public override void AssignName()
        {
            do
            {
                var nameSelected = random.Next(0, NamePool.Count - 1);
                Name = NamePool[nameSelected];
            }
            while (UsedNames.Contains(Name));
            UsedNames.Add(Name);
            NamePool.Remove(Name);

        }

    }
}
