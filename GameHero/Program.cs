using GameHero.Managers;
using GameHero.Models;

Console.WriteLine("Hello, World!");
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
        case "attack":
            hero.Attack();
            break;
    }
    //Console.Clear();
    
}
while (line != "exit");
Console.WriteLine("Выход, спасибо за игру!");
Thread.Sleep(1000);
