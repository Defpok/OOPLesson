using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemeProjeckLessonsWarning
{
    internal class Input
    {
        public Random Random;

        public Input() 
        { 
            Random = new Random();
        }

        public int GetPlayerCommandNumber()
        {
            Console.Write("Введите номер: ");
            int commandNumber;
            string input = Console.ReadLine();
            while(!int.TryParse(input, out commandNumber))
            {
                Console.WriteLine("Команда не распознана. Попробуйте снова");
                input = Console.ReadLine();
            }
            return commandNumber;
        }

        public int GetAiCommandNumber(int maxNumbers)
        {
            int randomCommand = Random.Next(0, maxNumbers + 1); 
            return randomCommand;
        }

    }
}
