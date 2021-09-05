using System;

namespace Poker
{
    class Program : IGetInput
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 60);

            GameManager.StartProgram();

        }
    }
}
