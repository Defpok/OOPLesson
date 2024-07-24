using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GemeProjeckLessonsWarning.Program;

namespace GemeProjeckLessonsWarning
{
    internal class Unit
    {
        public int Damage;
        public int MaxHealth;
        public int CurrentHealth;
        public bool IsAlive = true;
        public int ShieldCount = 0;
        public bool LastDamageFromWeapon = false;


        public List<string> AbilityDescriptions = new();


        Dictionary<AttackType, List<float>> DamageHistory = new(); 


        public Unit(int damage, int maxHealth)
        {
            Damage = damage;
            MaxHealth = maxHealth;

            CurrentHealth = maxHealth;

            DamageHistory[AttackType.Demage] = new List<float>();
            DamageHistory[AttackType.Self] = new List<float>();
            DamageHistory[AttackType.Heal] = new List<float>();
        }

        public void TakeDamage(int damage, Unit origin, bool isWeaponDamage = false)
        {
            LastDamageFromWeapon = isWeaponDamage;
            bool isHeal = damage < 0;
            AttackType attackType = AttackType.Demage;
            if(isHeal)
                attackType = AttackType.Heal;
            else if(origin == this)
                attackType = AttackType.Self;
            if(InShield() && !isHeal)
            {
                ShieldCount--;
                DamageHistory[attackType].Add(0);
                return;
            }

            CurrentHealth -= damage;

            DamageHistory[attackType].Add(damage);
            
            if (CurrentHealth <= 0)
            {
                isHeal = false;
                return;
            }
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;

        }
        public string GetAbilityDescription(int abilityNumber)
        {
            return AbilityDescriptions[abilityNumber];
        }

        public int GetAbilityCount()
        {
            return AbilityDescriptions.Count;
        }

        public bool InShield()
        {
            return ShieldCount > 0;
        }



    }

}
