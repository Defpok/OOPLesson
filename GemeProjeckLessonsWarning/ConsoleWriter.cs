using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GemeProjeckLessonsWarning.Program;

namespace GemeProjeckLessonsWarning
{
    internal class ConsoleWriter
    {
        void DemageMessage(string demager, string defender, float damage)
        {
            Console.WriteLine($"Игрок {demager} наносит игроку {defender} урон в размере {damage} едениц");

        }
        void HealMessage(string healer, float healValue)
        {
            Console.WriteLine($"Игрок {healer} востановил себе {healValue} здоровья");
        }
        void WriteDamgeWithType(AttackType attackType, string damagerName, string defenderName, List<float> demages)
        {
            foreach (var demage in demages)
            {
                switch (attackType)
                {
                    case AttackType.Demage:
                        DemageMessage(damagerName, defenderName, demage);
                        break;
                    case AttackType.Self:
                        DemageMessage(defenderName, defenderName, demage);
                        break;
                    case AttackType.Heal:
                        HealMessage(damagerName, demage);
                        break;
                    default:
                        break;
                }
            }
            demages.Clear();
        }
        public void WriteDamagesFromTo(Dictionary<AttackType, List<float>> damages, string damagerName, string defenderName)
        {
            foreach (var demage in damages)
            {
                WriteDamgeWithType(demage.Key, damagerName, defenderName, demage.Value);

            }
        }
        public void WriteUnitHealth(string owner, Unit unit)
        {
            Console.WriteLine($"{owner}: {unit.CurrentHealth}");
        }

        public void WriteAllAbilities(string message, Unit unit)
        {
            Console.WriteLine($"{message}");
            for (int i = 0; i < unit.GetAbilityCount(); i++)
            {
                Console.WriteLine($"{i + 1}. {unit.GetAbilityDescription(i)}");
            }
            Console.WriteLine();
        }
         
    }
}
