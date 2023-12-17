using System;
using System.Collections.Generic;
using week3assignement;

public class Program
{
    public static void Main()
    {
        List<Room> rooms = new List<Room>()
        {
            new Room() { Monster = new Monster() { Name = "Silent Stalker", Health = 100 } },
            new Room() { Monster = new Monster() { Name = "Venomspike", Health = 100 } },
            new Room() { Monster = new Monster() { Name = "Soul Devourer", Health = 100 } }
        };
        Player player = new Player() { Health = 100 };

        DoublyLinkedList results = new DoublyLinkedList();

        foreach (var room in rooms)
        {
            Console.WriteLine($"Do you want to enter the room with {room.Monster.Name}? (Y/N)");
            string userInput = Console.ReadLine();

            if (userInput.ToUpper() == "Y")
            {
                Console.WriteLine($"Entering room with {room.Monster.Name}");

                bool isDefending = false;

                while (player.Health > 0 && room.Monster.Health > 0)
                {
                    DisplayBattleStatus(player, room.Monster);

                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Defend");

                    string action = Console.ReadLine();

                    switch (action)
                    {
                        case "1":
                            isDefending = false;
                            PerformAttack(player, room.Monster);
                            break;
                        case "2":
                            isDefending = true;
                            PerformDefend(player);
                            break;
                        default:
                            Console.WriteLine("Invalid action. Please choose again.");
                            break;
                    }

                    if (!isDefending)
                    {
                        PerformMonsterAttack(player, room.Monster);
                    }
                }

                if (player.Health <= 0)
                {
                    results.AddNode($"Player was defeated by {room.Monster.Name}", room.Monster.Health, 0, player.Health);
                    break;
                }
                else
                {
                    results.AddNode($"Player defeated {room.Monster.Name}", room.Monster.Health, 0, player.Health);
                }
            }
        }

        if (player.Health > 0)
        {
            results.AddNode("Player defeated all monsters and won the game!", 0, 0, player.Health);
        }

        results.PrintList();

        // Wait for user input before closing the console window
        Console.ReadLine();
    }

    private static void DisplayBattleStatus(Player player, Monster monster)
    {
        Console.WriteLine($"Player Health: {player.Health}");
        Console.WriteLine($"{monster.Name} Health: {monster.Health}");
    }

    private static void PerformAttack(Player player, Monster monster)
    {
        int damage = 10; // Adjust the damage value as needed
        monster.Health -= damage;
        Console.WriteLine($"You attacked {monster.Name} and dealt {damage} damage!");
    }

    private static void PerformDefend(Player player)
    {
        int defense = 5; // Adjust the defense value as needed
        player.Health = Math.Min(100, player.Health + defense); // Ensure health does not exceed 100
        Console.WriteLine($"You defended and restored {defense} health!");
    }

    private static void PerformMonsterAttack(Player player, Monster monster)
    {
        int damage = 10; // Adjust the damage value as needed
        Console.WriteLine($"{monster.Name} attacked you and dealt {damage} damage!");
        player.Health = Math.Max(0, player.Health - damage); // Ensure health does not go below 0
    }
}
