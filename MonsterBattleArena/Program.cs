using MonsterBattleArena;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== MONSTER BATTLE ARENA ===");

        // Creating the objects using our blueprint 
        Monster player = new Monster { Name = "Rover", Health = 100, MaxHealth = 100, BaseAttack = 15, IsDefending = false };
        Monster enemy = new Monster { Name = "Sparky", Health = 80, MaxHealth = 80, BaseAttack = 12, IsDefending = false };

        Console.WriteLine("A wild " + enemy.Name + " appears!\n");

        int turnCounter = 1;

        // The game loop: runs as long as both monsters have health greater than 0 
        // The while loop will evaluate the condition of the game logic stopping point. So when do we want the game to start and stop? 
        // while this condition is true, run this code. 
        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine("--- TURN " + turnCounter + " ---");
            Console.WriteLine(player.Name + " (HP: " + player.Health + "/" + player.MaxHealth + ")");
            Console.WriteLine(enemy.Name + " (HP: " + enemy.Health + "/" + enemy.MaxHealth + ")\n");

            // --- Player and Enemy actions will be written here in the next steps ---

            turnCounter++;
            Console.WriteLine("\n-----------------------------------\n");

            // Reset defense status at the start of a new turn 
            player.IsDefending = false;

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Heal");
            Console.WriteLine("Your choice: ");
            string input = Console.ReadLine();
            Console.WriteLine(); 

            // input the gaming logic. the gaming logic at this point in time is not written but you can make an outline and than write what you need here. 
            switch (input)
            {
                case "1":
                    // We will build these action methods in the next steps! 
                    ExecuteAttack(player, enemy);
                    break;
                case "2":
                    player.IsDefending = true;
                    Console.WriteLine(player.Name + "raises a defensive shield!");
                    break;
                case "3":
                    ExecuteHeal(player); 
                    break;
                default:
                    Console.WriteLine("Invalid entry! " + player.Name + " stumbled and missed their turn!");
                    break; 
            }

        }

        if (enemy.Health > 0)
        {
            enemy.IsDefending = false; 

            // Simple AI decision logic: enemy heals if low, otherwise attacks 
            if (enemy.Health < 20 && dice.Next(1, 3) == 1)
            {
                ExecuteHeal(enemy); 
            }
            else
            {
                ExecuteAttack(enemy, player); 
            }
        }
        Console.WriteLine("=== THE BATTLE IS OVER ==="); 
        if (player.Health > 0) 
        {
            Console.WriteLine("Victory! " + player.Name + " defeated " + enemy.Name + "and won the tournament!");
        }
        else
        {
            Console.WriteLine("Defeat! " + player.Name + " fainted. " + enemy.Name + " rules the arena.");
        }
    }

    // now we have to build the logic for the parts of the game. 
    // in a way we created a random dice to use. 
    static Random dice = new Random();

    // notice that the parameters are attacker and defender the attacker can accept arguments of player and enemy. same for defender. 
    static void ExecuteAttack(Monster attacker, Monster defender)
    {
        // Generate a variation of damage from 70% to 120% of base attack
        // i need a way to have some variance with attacks so i need to look in the random module for something that works. 
        int damageVariance = dice.Next(-3, 4); // Picks a number between -3 and 3
        
        int calculatedDamage = attacker.BaseAttack + damageVariance;

        // Check if the target is defending
        if (defender.IsDefending)
        {
            calculatedDamage = calculatedDamage / 2; // Cut damage in half!
            Console.WriteLine(defender.Name + "'s shield blocked some damage!");
        }

        // Apply the damage to the defender's health pool
        defender.Health = defender.Health - calculatedDamage;

        // Safety check: Prevent health from tracking as a negative value
        if (defender.Health < 0) defender.Health = 0;

        Console.WriteLine(attacker.Name + " attacks " + defender.Name + " for " + calculatedDamage + " damage!");
    }

    static void ExecuteHeal(Monster monster)
    {
        int healAmount = dice.Next(10, 21); // Restores between 10 and 20 HP
        monster.Health = monster.Health + healAmount;

        // Do not allow healing past maximum capacity
        if (monster.Health > monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
        }

        Console.WriteLine(monster.Name + " focuses energy and restores " + healAmount + " HP!");
    }


}