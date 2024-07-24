using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemeProjeckLessonsWarning
{
    internal class Program
    {

        public enum AttackType
        {
            Demage,
            Self,
            Heal
        }

        static void Main(string[] args)
        {
            string name;
            float maxPlayerHealth = 1000f;
            float maxEnemyHealth = 2000f;

            float currentPlayerHelth = maxPlayerHealth;
            float currentEnemyHelth = maxEnemyHealth;

            float playerDemage = 50f;
            float enemyDemage = 50f;

            float fireBallDemage = 200f;
            float enemyHealDemage = 100f;

            string input;

            int commandCout = 3;
            int enemySecondAbilityModgier = 3;

            Random random = new Random();

            Dictionary<AttackType, List<float>> demagesToPlayer = new Dictionary<AttackType, List<float>>();
            Dictionary<AttackType, List<float>> demagesToEnemy = new Dictionary<AttackType, List<float>>();

            demagesToPlayer[AttackType.Demage] = new List<float>();
            demagesToPlayer[AttackType.Self] = new List<float>();
            demagesToPlayer[AttackType.Heal] = new List<float>();

            demagesToEnemy[AttackType.Demage] = new List<float>();
            demagesToEnemy[AttackType.Self] = new List<float>();
            demagesToEnemy[AttackType.Heal] = new List<float>();


            Console.Write("Напишите ваше имя");
            name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Привет! {name}\n");

            while (currentPlayerHelth > 0 && currentEnemyHelth > 0)
            {
                Console.WriteLine($"Ваше здоровье: {currentPlayerHelth}");
                Console.WriteLine($"Здоровье врага: {currentEnemyHelth}");

                Console.WriteLine($"{name}! Выберите действие:\n" +
                    $"1 - ударить оружием (урона{playerDemage})\n" +
                    $"2 - Щит: следующая атака врага не наносит урона\n" +
                    $"3 - Огенный шар: наносит урон в размере {fireBallDemage}\n");
                input = Console.ReadLine();
                bool playerShield = false;
                bool playerDemageWithWeapon = false;

                switch (input)
                {
                    case "1":
                        playerDemageWithWeapon = true;
                        currentEnemyHelth -= playerDemage;
                        demagesToEnemy[AttackType.Demage].Add(playerDemage);
                        break;
                    case "2":
                        playerShield = true;
                        break;
                    case "3":
                        currentEnemyHelth -= fireBallDemage;
                        demagesToEnemy[AttackType.Demage].Add(fireBallDemage);
                        break;
                    default:
                        Console.WriteLine("Вы ввели не правильную команду!");
                        break;
                }

                int enemyCommand = random.Next(0, commandCout + 1);

                switch (enemyCommand)
                {
                    case 1:
                        if (!playerShield)
                        {

                            currentPlayerHelth -= enemyDemage;
                            demagesToPlayer[AttackType.Demage].Add(enemyDemage);
                        }
                        break;
                    case 2:
                        if (!playerShield)
                        {
                            currentPlayerHelth -= enemyDemage;
                            currentPlayerHelth -= enemyDemage * enemySecondAbilityModgier;

                            Console.WriteLine($"Противник нанес себе {enemyDemage} урона");

                            demagesToPlayer[AttackType.Self].Add(enemyDemage);

                            demagesToPlayer[AttackType.Demage].Add(enemyDemage * enemySecondAbilityModgier);
                        }
                        break;
                    case 3:
                        if (playerDemageWithWeapon)
                        {
                            currentEnemyHelth -= enemyHealDemage;
                            demagesToPlayer[AttackType.Self].Add(enemyHealDemage);
                        }
                        else
                        {
                            currentEnemyHelth += enemyHealDemage;
                            demagesToPlayer[AttackType.Heal].Add(enemyHealDemage);
                            if (currentEnemyHelth > maxEnemyHealth)
                                currentEnemyHelth = maxEnemyHealth;
                        }
                        break;

                }
                WriteDamagesFromTo(demagesToEnemy, name, "Enemy");
                WriteDamagesFromTo(demagesToPlayer, "Enemy", name);
                EndTurn();


            }

            void EndTurn()
            {
                Console.WriteLine("\nНажмите для продолжения");
                Console.ReadKey();
                Console.Clear();
            }

            




        }
    }
}
