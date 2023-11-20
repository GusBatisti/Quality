using System;

namespace Jogo_poo2
{
    internal class Program
    {
        enum Faction
        {
            GoodGuy,
            BadGuy
        }

        class Weapon
        {
            private int damage { get; set; }
            private int GOOD_GUY_DAMAGE { get; set; }
            private int BAD_GUY_DAMAGE { get; set; }

            public Weapon()
            {
                this.damage = damage;
                this.GOOD_GUY_DAMAGE = 10;
                this.BAD_GUY_DAMAGE = 5;
            }
            public int getGOOD_GUY_DAMAGE(){
              return GOOD_GUY_DAMAGE;
            }
          
            public int getBAD_GUY_DAMAGE(){
              return BAD_GUY_DAMAGE;
            }
        }

        class Armor
        {
            private int armorPoints { get; set; }
            private int GOOD_GUY_ARMOR { get; set; }
            private int BAD_GUY_ARMOR { get; set; }

            public Armor()
            {
                this.armorPoints = armorPoints;
                this.GOOD_GUY_ARMOR = 30;
                this.BAD_GUY_ARMOR = 20;
            }
                public int getArmorPoints(){
                  return armorPoints;
                }
                public void setArmorPoints(int armorPoints){
                  this.armorPoints = armorPoints;
                }
        }

        class Warrior
        {
            private Faction faction { get; set; }
            private Int32 health { get; set; }
            private string name { get; set; }
            private bool isAlive { get; set; }
            private Weapon weapon { get; set; }
            public Armor armor { get; set; }
            private int GOOD_GUY_START_HEALTH { get; set; }
            private int BAD_GUY_START_HEALTH { get; set; }

            public Warrior(Faction faction, int health, string name, bool isAlive, Weapon weapon, Armor armor)
            {
                this.faction = faction;
                this.health = health;
                this.name = name;
                this.isAlive = true;
                this.weapon = weapon;
                this.armor = armor;
                GOOD_GUY_START_HEALTH = 50;
                BAD_GUY_START_HEALTH = 50;
            }

            public string getName(){
              return name;
            }

            public bool getIsAlive(){
              return isAlive;
            }

            public int getHealth(){
              return health;
            }

            public void Attack(Warrior enemy)
            {

                if (faction == Faction.GoodGuy)
                {
                    if (enemy.armor.getArmorPoints() > 0)
                    {
                      int damage = weapon.getGOOD_GUY_DAMAGE();
            enemy.armor.setArmorPoints(enemy.armor.getArmorPoints() - damage);
                    }
                  else if (enemy.armor.getArmorPoints() < 0)
                    {
                        // Aplicar o dano restante à vida se a armadura estiver esgotada.
                        enemy.health += enemy.armor.getArmorPoints();
                        enemy.armor.setArmorPoints(0);
                    }
                }

              if (faction == Faction.BadGuy)
                {
                    if (enemy.armor.getArmorPoints() > 0)
                    {
                      int damage = weapon.getBAD_GUY_DAMAGE();
            enemy.armor.setArmorPoints(enemy.armor.getArmorPoints() - damage);
                    }
                    else if (enemy.armor.getArmorPoints() < 0)
                    {
                        // Aplicar o dano restante à vida se a armadura estiver esgotada.
                        enemy.health += enemy.armor.getArmorPoints();
                        enemy.armor.setArmorPoints(0);
                    }
                }

              if (this.health > 0){
                this.isAlive = true;
              }
              else{
                this.isAlive = false;
              }
              
              
              
            }

        }

public static void Main(string[] args)
        {
            // Crie armas e armaduras para os guerreiros
            Weapon espada = new Weapon();
            Armor armaduraPesada = new Armor();
            Weapon cajado = new Weapon();
            Armor armaduraLeve = new Armor();

            

            // Crie dois guerreiros, um bom e um mau
            Warrior heroi = new Warrior(Faction.GoodGuy, 100, "Herói", true, espada, armaduraPesada);
            Warrior vilao = new Warrior(Faction.BadGuy, 80, "Vilão", true, cajado, armaduraLeve);

            // Simule um combate
            Console.WriteLine($"Começou o combate entre {heroi.getName()} e {vilao.getName()}!");

            while ((heroi.getIsAlive() && vilao.getIsAlive()) == true)
            {
                // Herói ataca o vilão
                heroi.Attack(vilao);

                // Verifica se o vilão está vivo após o ataque
                if (vilao.getIsAlive())
                {
                    // Vilão ataca o herói
                    vilao.Attack(heroi);
                }

                // Exibe o estado atual dos guerreiros
                Console.WriteLine($"{heroi.getName()}: Vida = {heroi.getHealth()}, Pontos de Armadura = {heroi.armor.getArmorPoints()}");
                Console.WriteLine($"{vilao.getName()}: Vida = {vilao.getHealth()}, Pontos de Armadura = {vilao.armor.getArmorPoints()}");
                Console.WriteLine();
              break;
            }

            // Determine o vencedor
            if (heroi.getIsAlive())
            {
                Console.WriteLine($"{heroi.getName()} venceu!");
            }
          else if (vilao.getIsAlive())
            {
                Console.WriteLine($"{vilao.getName()} venceu!");
            }
            else
            {
                Console.WriteLine("O combate terminou em empate.");
            }
        }
    }
}