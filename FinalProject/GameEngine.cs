

using System.Reflection;
using System.Reflection.Metadata;

public class GameEngine
{

    public bool isGameOver = false;
    public int CurrentLevel { get; set; }
    Map MapStarter;
    Player player;
    public DataLogs<string> dataLogs;

    public GameEngine()
    {
        CurrentLevel = 1;
        player = new(new Vector(0, 0), new MapObjects(UsableObjects.player, new Vector(0, 0), CurrentLevel), CurrentLevel);
        dataLogs = new DataLogs<string>();
    }
    public void GameLoop()
    {
        RunMenu();
        while (!isGameOverMethod(player))
        {

            Hud();
            startlevel();
            dataLogs.printDataLog();




        }
        if (isGameOverMethod(player))
        {

            Console.Clear();
            Console.WriteLine("Game Over You Died");
            Console.WriteLine("Press any key to Go back to the Main Menu");
            Console.ReadLine();
            isGameOver = false;
            player = new(new Vector(0, 0), new MapObjects(UsableObjects.player, new Vector(0, 0), CurrentLevel), CurrentLevel);
            CurrentLevel = 1;
            GameLoop();



        }

    }
    public void startlevel()
    {
        Console.SetWindowSize(100, 28);
        Console.SetCursorPosition(0, 2);
        MapStarter.MapRender();
        KeyConfigure.KeyAction(MapStarter, MapStarter.player, dataLogs, player.AmountOfPotions);
        Enemy.MoveEnemies(MapStarter);

        if (player.objectUnderUnit.type == UsableObjects.Exit)
        {
            FinishLevel();

        }
        if (player.objectUnderUnit.type == UsableObjects.DorVendorE)
        {
            FinishLevel();
        }

    }
    public void FinishLevel()
    {
        if (CurrentLevel == 10)
        {
            VictoryMethod();
        }

        CurrentLevel++;
        Console.Clear();
        MapStarter = new(CurrentLevel, player);
        dataLogs.Clear();
        startlevel();

    }

    private void VictoryMethod()
    {
        Console.Clear();
        string endingPicture = @"          __________-------____                 
          \------____-------___--__---------__--___-------____------/
           \//////// / / / / / \   _-------_   / \ \ \ \ \ \\\\\\\\/
             \////-/-/------/_/_| /___   ___\ |_\_\------\-\-\\\\/
               --//// / /  /  //|| (O)\ /(O) ||\\  \  \ \ \\\\--
                    ---__/  // /| \_  /V\  _/ |\ \\  \__---
                         -//  / /\_ ------- _/\ \  \\-
                           \_/_/ /\---------/\ \_\_/
                               ----\   |   /----
                                    | -|- |
                                   /   |   \
                                   ---- \___|";
        Console.WriteLine(endingPicture);
        Console.WriteLine("Youve Won! Congratz!!!!");
        Console.ReadLine();
        isGameOver = false;
        player = new(new Vector(0, 0), new MapObjects(UsableObjects.player, new Vector(0, 0), CurrentLevel), CurrentLevel);
        CurrentLevel = 1;
        GameLoop();

    }


    public bool isGameOverMethod(Player player)
    {
        if (player.isDead)
        {
            return isGameOver = true;
        }
        return isGameOver;
    }
    //Hud:
    public void Hud()
    {
        Console.SetCursorPosition(0, 20);
        Console.WriteLine("Thy Name is: " + player.name);
        Console.WriteLine($"HP: {player.CurrentHp} / {player.maxHP}");
        Console.WriteLine("Dorllars: " + player.Dorllars);
        Console.WriteLine("Thy Steel: " + player.WeaponOnUnit.weaponName);
        Console.WriteLine("Thy Shield: " + player.ShieldOnUnit.ShieldName);
        Console.WriteLine("(Press 1 To Use)Healing Potions On Player: " + player.AmountOfPotions);



    }



    //Menu Methods:
    public void RunMenu()
    {
        Console.SetWindowSize(240, 40);

        string prompt = @"
   ▄████████         ▄████████  ▄█     ▄████████     ███             ▄████████ ███    █▄   ▄█        ▄█             ▄██████▄     ▄████████      ████████▄   ▄██████▄     ▄████████  ▄█        ▄█          ▄████████    ▄████████    ▄████████ 
  ███    ███        ███    ███ ███    ███    ███ ▀█████████▄        ███    ███ ███    ███ ███       ███            ███    ███   ███    ███      ███   ▀███ ███    ███   ███    ███ ███       ███         ███    ███   ███    ███   ███    ███ 
  ███    ███        ███    █▀  ███▌   ███    █▀     ▀███▀▀██        ███    █▀  ███    ███ ███       ███            ███    ███   ███    █▀       ███    ███ ███    ███   ███    ███ ███       ███         ███    ███   ███    ███   ███    █▀  
  ███    ███       ▄███▄▄▄     ███▌   ███            ███   ▀       ▄███▄▄▄     ███    ███ ███       ███            ███    ███  ▄███▄▄▄          ███    ███ ███    ███  ▄███▄▄▄▄██▀ ███       ███         ███    ███  ▄███▄▄▄▄██▀   ███        
▀███████████      ▀▀███▀▀▀     ███▌ ▀███████████     ███          ▀▀███▀▀▀     ███    ███ ███       ███            ███    ███ ▀▀███▀▀▀          ███    ███ ███    ███ ▀▀███▀▀▀▀▀   ███       ███       ▀███████████ ▀▀███▀▀▀▀▀   ▀███████████ 
  ███    ███        ███        ███           ███     ███            ███        ███    ███ ███       ███            ███    ███   ███             ███    ███ ███    ███ ▀███████████ ███       ███         ███    ███ ▀███████████          ███ 
  ███    ███        ███        ███     ▄█    ███     ███            ███        ███    ███ ███▌    ▄ ███▌    ▄      ███    ███   ███             ███   ▄███ ███    ███   ███    ███ ███▌    ▄ ███▌    ▄   ███    ███   ███    ███    ▄█    ███ 
  ███    █▀         ███        █▀    ▄████████▀     ▄████▀          ███        ████████▀  █████▄▄██ █████▄▄██       ▀██████▀    ███             ████████▀   ▀██████▀    ███    ███ █████▄▄██ █████▄▄██   ███    █▀    ███    ███  ▄████████▀  
                                                                                          ▀         ▀                                                                   ███    ███ ▀         ▀                        ███    ███              
                                                                                                   Use The Arrows To Move Through the menu";
        string[] Options = { "Start", "Credits", "Exit" };
        MenuEngine MainMenu = new(Options, prompt);
        int SelectedIndex = MainMenu.Start();
        Console.Clear();
        switch (SelectedIndex)
        {
            case 0:
                Start();

                break;
            case 1:
                Credits();
                break;
            case 2:
                Exit();
                break;

        }
    }
    private void Start()
    {
        Console.WriteLine("What is Your name Warrior?");
        string name = Console.ReadLine();
        player.name = name;
        Console.Clear();
        Console.WriteLine("Use the arrow keys to move, Enemies are red, Exit is the X, Treasure chests are $, You will meet the vendor in some levels his Symbol is D");
        Console.Read();
        Console.Clear();
        MapStarter = new(CurrentLevel, player);
        startlevel();

    }
    private void Credits()
    {
        Console.SetWindowSize(80, 15);
        Console.Clear();
        Console.WriteLine(@"
  ▄▄▄▄▄ ████▄    ▄   ██     ▄▄▄▄▀ ▄  █ ██      ▄       ███   █    ██     ▄   
▄▀  █   █   █     █  █ █ ▀▀▀ █   █   █ █ █      █      █  █  █    █ █     █  
    █   █   █ ██   █ █▄▄█    █   ██▀▀█ █▄▄█ ██   █     █ ▀ ▄ █    █▄▄█ █   █ 
 ▄ █    ▀████ █ █  █ █  █   █    █   █ █  █ █ █  █     █  ▄▀ ███▄ █  █ █   █ 
  ▀           █  █ █    █  ▀        █     █ █  █ █     ███       ▀   █ █▄ ▄█ 
              █   ██   █           ▀     █  █   ██                  █   ▀▀▀  
                      ▀                 ▀                          ▀         
                           Thanks For Playing!"

);
        Console.ReadKey(true);
        RunMenu();
    }
    private void Exit()
    {
        Console.SetCursorPosition(20, 0);
        Environment.Exit(0);
    }
}

