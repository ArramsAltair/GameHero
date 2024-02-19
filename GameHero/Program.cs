using GameHero.Enums;
using GameHero.Managers;
using GameHero.Models;

Console.WriteLine("Добро пожаловать в игру ГЕРОИ!");
GameManager gameManager = new GameManager();
HeroModel hero = new HeroModel();

string line ="";
string mainMenu =   "Меню \n" +
                "1. Введите 'weapons' для выбора оружия \n" +
                "2. Введите 'attack' для атаки оружием \n" +
                "3. Введите 'exit' для выхода \n";

do
{
    Console.WriteLine(mainMenu);
    line = Console.ReadLine();
    switch (line) 
    {
        case "weapons":
            ChangeWeapon();
            break;
            
        case "attack":
            Attack();
            break;
    }
    //Console.Clear();
    
}
while (line != "exit");



Console.WriteLine("До свидания, спасибо за игру!");
Thread.Sleep(1000);


void Attack() 
{
    hero.Attack();
}
void ChangeWeapon()
{
    string sWeaponChange = "Оружие\n" +
                        "1. Рука 'hand'\n" +
                        "2. Пистолет 'pistol'\n" +
                        "3. Вернуться 'back'\n";
    do
    {
        Console.WriteLine(sWeaponChange);
        Console.WriteLine("Текущее оружие: " + hero.CurrectWeapon + "\n");
        line = Console.ReadLine();
        if (line == "hand")
        {
            hero.ChangeWeapon(WeaponTypes.Hand);
        }
        if (line == "pistol")
        {
            hero.ChangeWeapon(WeaponTypes.Pistol);
        }
    }
    while (line != "back");
    line = "";
}
