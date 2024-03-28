
//string[] heroes = { "Harry Potter", "Luke Skywalker", "Lara Croft", "Scooby-Doo" };

//string[] villains = { "Voldemort", "Darth Vader", "Dracula", "Joker", "Sauron" };

string folderPath = @"C:\data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";
string weaponFile = "weapon.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));

string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));

string[] weapons = File.ReadAllLines(Path.Combine(folderPath, weaponFile));

//string[] weapon = { "M1 Abrams", "Longbow", "Ak-47", "Claymore" };


string hero = GetRandomValue(heroes);
string heroWeapon = GetRandomValue(weapons);
int heroHP = GetcharacterHP(hero);
int heroStrikeStrenght = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");


string villain = GetRandomValue(villains);
string villainWeapon = GetRandomValue(weapons);
int villainHP = GetcharacterHP(villain);
int villainStrikeStrenght = villainHP;  

Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrenght);
    villainHP = villainHP - Hit(hero, heroStrikeStrenght);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");
if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Villain wins!");
}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValue(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];  
    return randomStringFromArray;   
}

static int GetcharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");

    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
    
}