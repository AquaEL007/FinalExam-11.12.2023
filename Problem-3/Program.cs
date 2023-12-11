using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public Person(string name, int health, int energy)
    {
        Name = name;
        Health = health;
        Energy = energy;
    }

    public string Name { get; set; }

    public int Health { get; set; }

    public int Energy { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Health} - {Energy}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Person> warriors = new Dictionary<string, Person>();

        string commands;
        while ((commands = Console.ReadLine()) != "Results")
        {
            string[] arguments = commands.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string command = arguments[0];
            string name = arguments[1];

            switch (command)
            {
                case "Add":
                    int health = int.Parse(arguments[2]);
                    int energy = int.Parse(arguments[3]);
                    if (!warriors.ContainsKey(name))
                    {
                        warriors.Add(name, new Person(name, health, energy));
                    }
                    else
                    {
                        warriors[name].Health += health;
                    }
                    break;
                case "Attack":
                    string attackerName = name;
                    string defenderName = arguments[2];
                    int damage = int.Parse(arguments[3]);

                    if (warriors.ContainsKey(attackerName) && warriors.ContainsKey(defenderName))
                    {
                        Person attacker = warriors[attackerName];
                        Person defender = warriors[defenderName];
                        defender.Health -= damage;
                        if (defender.Health <= 0)
                        {
                            warriors.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }
                        attacker.Energy--;
                        if (attacker.Energy == 0)
                        {
                            warriors.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                    break;
                case "Delete":
                    if (name == "All")
                    {
                        warriors.Clear();
                    }
                    else
                    {
                        warriors.Remove(name);
                    }
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"People count: {warriors.Count}");
        foreach (var item in warriors)
        {
            Console.WriteLine(item.Value);
        }

    }

}
