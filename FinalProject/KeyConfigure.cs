

public class KeyConfigure
{
    public static void KeyAction(Map map, Unit player, DataLogs<string> data,int amount)
    {

        ConsoleKey keys = Console.ReadKey(true).Key;
        switch (keys)
        {
            case ConsoleKey.UpArrow:
                Collision.MoveUnit(map, new(Directon.Up), player, data);
               
                break;
            case ConsoleKey.DownArrow:
                Collision.MoveUnit(map, new(Directon.Down), player, data);
                
                break;
            case ConsoleKey.RightArrow:
                Collision.MoveUnit(map, new(Directon.Right), player, data);
                break;
            case ConsoleKey.LeftArrow:
                Collision.MoveUnit(map, new(Directon.Left), player, data);
                break;
            case ConsoleKey.D1:
                player.HealingPotion(player, data);
                
                break;
            case ConsoleKey.R:
                break;
            case ConsoleKey.E:
                break;

            default:
                KeyAction(map, player, data,amount);
                break;
        }
    }
}

