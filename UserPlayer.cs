using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class UserPlayer : GamePlayer
    {
        static int PlayerCount = 0;

        public UserPlayer()
        {
            PlayerCount++;
            AssignName();
            IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[] {
            $"Nice to meet you, {Name}!", "",
            "I hope you're ready to play some cards!", "",
            "Press any key to continue."
            }, true);
            IWriteToTheConsole.Clear(true);
        }

        public override void AssignName()
        {
            Name = IGetInput.GetStringResponse(new string[] {
            $"Player {PlayerCount} please enter your name.", "",
            "Please keep your name below 15 characters long.", "",
            "Name: ",
            }, true, 15);

        }
    }
}
