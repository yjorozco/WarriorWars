using System;
using WarriorWars.Enum;
using WarriorWars.Equipment;
using System.Threading;

namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;

        private readonly Faction faction;
        private int health;
        private String name;
        private bool isAlive;

        public bool IsAlive { get {
            return isAlive;
        }}

        private Weapon weapon;
        private Armor armor;


        public Warrior(string name, Faction faction){
            this.name = name;
            this.faction = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor =  new Armor(faction);
                    health =  GOOD_GUY_STARTING_HEALTH;                    
                    break;
                case Faction.BadGuy:    
                    weapon = new Weapon(faction);
                    armor =  new Armor(faction);
                    health =  BAD_GUY_STARTING_HEALTH;                    
                    break;
                default:
                    break;
            }

        }


        public void Attack(Warrior enemy){
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health -=  damage;

            AttackResult(enemy, damage);
            //Thread.Sleep(200);
        }

        public void AttackResult(Warrior enemy, int damage){
            if(enemy.health <= 0){
                enemy.isAlive = false;
                Tools.ColorfulWriteLine($"{enemy.name} is Dead!", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is victorous!", ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, remaning health is {enemy.health}");
            }
        }

    }
}