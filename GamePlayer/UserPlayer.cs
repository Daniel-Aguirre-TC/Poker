using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class UserPlayer : GamePlayer
    {
        /// <summary>
        /// Total number of User Players created to use the application.
        /// </summary>
        static int PlayerCount = 0;
        static int NameMaxLength { get; set; } = 15;

        /// <summary>
        /// Increase player count by one and then AssignName() followed by ArrivalMessage() displaying.
        /// </summary>
        public UserPlayer()
        {
            PlayerCount++;
            AssignName();
            
        }

        #region Player Creation Input and Messages

        /// <summary>
        /// Assign Name and then display ArrivalMessage()
        /// </summary>
        public override void AssignName()
        {
            Name = InputController.GetStringResponse(new string[] {
            $"Player {PlayerCount} please enter your name.", "",
            $"Please keep your name below {NameMaxLength} characters long.", "",
            "Name: ",
            }, true, NameMaxLength);
            PlayerCreatedMessage();

        }
 
        /// <summary>
        /// Message to be displayed after player puts in their name.
        /// </summary>
        public override void PlayerCreatedMessage()
        {
            ConsoleController.PrintCenteredVerticalHorizontal(new string[] {
            $"Nice to meet you, {Name}!", "",
            "I hope you're ready to play some cards!", "",
            "Press any key to continue."
            }, true, true);
        }

        #endregion





    }
}
