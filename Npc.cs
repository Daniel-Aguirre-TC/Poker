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

        #region Constructors

        /// <summary>
        /// Static constructor adds random names that can be assigned to Npc and also adds random Greetings to display when they are instantiated.
        /// </summary>
        static Npc()
        {
            NamePool = new List<string>()
            {
                "Billy Bob", "Fedor Holz", "Patrik Antonius", "Phil Hellmuth"
            };
            UsedNames = new List<string>();


        }
        /// <summary>
        /// Dealer Npc will have Name = "Dealer"
        /// </summary>
        /// <param name="isDealer"></param>
        public Npc(bool isDealer)
        {
            AssignName(isDealer);
        }
        /// <summary>
        /// Default Npc will not be a dealer and will have a randomly selected name.
        /// </summary>
        public Npc()
        {
            AssignName();
        }

        #endregion


        /// <summary>
        /// If true then Name is assigned to Dealer, else will pull a random name. Then display ArrivalMessage()
        /// </summary>
        /// <param name="isNpcDealer"></param>
        public void AssignName(bool isNpcDealer)
        {
            if (isNpcDealer)
            {
                Name = "Dealer";
                PlayerCreatedMessage(isNpcDealer);
            }
            else AssignName();
        }

        /// <summary>
        /// Assign a random name to the Npc.
        /// </summary>
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

        /// <summary>
        /// If is true, display that dealer is preparing the table. Else will display default message for a randomly selected npc name.
        /// </summary>
        /// <param name="isDealer"></param>
        public void PlayerCreatedMessage(bool isDealer)
        {
            if (isDealer)
            {
                var message = isDealer ? "The Dealer is preparing the table." : $"{Name} is approaching the table!";
                IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[] {
                    message, "",
                    $"We now have a total of {TotalPlayerCount} players at the table. "

                }, true);
                IWriteToTheConsole.Clear(true);
            }
            else PlayerCreatedMessage();

        }

        /// <summary>
        /// Display default arrival message for a randomly selected Npc name.
        /// </summary>
        public override void PlayerCreatedMessage()
        {
            IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[] {
                $"{Name} is approaching the table!", "",
                $"We now have a total of {TotalPlayerCount} players at the table. "
            }, true);
            IWriteToTheConsole.Clear(true);
        }
    }
}
