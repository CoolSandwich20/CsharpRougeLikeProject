using FinalProject;
using System.Drawing;
using System.Reflection.Emit;
using static UsableObjects;

public class Map
{

    //Fields
    public bool isNextLevel = false;
    public MapObjects[][] MapObjects = new MapObjects[18][];
    public Vector spawn;
    public List<Enemy> enemies;
    public Trap trapOnMap;
    public TreasureChest TreasureOnMap;
    public DorVendor VendorOnMap;
    private string[] _importedMap;
    public Player player { get; set; }
    public int level { get; set; }
    public void MoveTheUnit(Vector cord, Vector Change, Unit moveableUnit)
    {
        Vector newCord = cord + Change;
        MapObjects temporary = MapObjects[newCord.Y][newCord.X];
        MapObjects[newCord.Y][newCord.X] = moveableUnit.ObjectOfUnit;
        MapObjects[cord.Y][cord.X] = moveableUnit.objectUnderUnit;
        moveableUnit.UpdateCurrentVector(Change, temporary);
    }
    public MapObjects GetObjectFromMap(Vector cord)
    {
        return MapObjects[cord.Y][cord.X];
    }
    public Map(int Level, Player player)
    {
        level= Level;
        enemies = new(Level);
        this.player = player;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  ____Level {Level}____");
        Console.ResetColor();
        _importedMap = FileReader.Read(Level);
        for (int i = 0; i < _importedMap.Length; i++) //this is the rows
        {
            string collum = _importedMap[i];
            MapObjects[i] = new MapObjects[collum.Length];

            for (int j = 0; j < collum.Length; j++)// this is for the collums
            {

                MapObjects[i][j] = new MapObjects((UsableObjects)collum[j], new(j, i),level);
                if (MapObjects[i][j].type == UsableObjects.Entry)
                {
                    player.UpdateCurrentVector(new Vector(j, i) - player.Cords, MapObjects[i][j]);
                }
                if (MapObjects[i][j].type == UsableObjects.enemy)
                {
                    enemies.Add((Enemy)MapObjects[i][j].unitOnObject);
                }
                if (MapObjects[i][j].type == UsableObjects.HiddenTrap)
                {
                    trapOnMap =  MapObjects[i][j].trap;

                }
                if (MapObjects[i][j].type == UsableObjects.Treasure)
                {
                    TreasureOnMap = MapObjects[i][j].treasure;
                }
                if (MapObjects[i][j].type == UsableObjects.DorVendorE)
                {
                    VendorOnMap = MapObjects[i][j].DorVendorOnMap;
                }
            }


        }

    }
    public void MapRender()
    {

        for (int i = 0; i < MapObjects.Length; i++)
        {
            if (MapObjects[i] == null) continue;
            for (int j = 0; j < MapObjects[i].Length; j++)
            {

                Console.ForegroundColor = MapObjects[i][j].colorOfObject;
                Console.Write(MapObjects[i][j].symbol);
            }
            Console.WriteLine();

        }
    }
}
public class MapObjects
{
    //fields
    public char symbol;
    public UsableObjects type; 
    public Unit unitOnObject;
    public ConsoleColor colorOfObject;
    //Prop
    public DorVendor DorVendorOnMap { get; set; }
    public Trap trap { get; set; }
    public TreasureChest treasure { get; set; }
    public MapObjects(UsableObjects useable, Vector cords,int Level)
    {
        switch (useable)
        {
            case HWall:
                symbol = '═';
                colorOfObject = ConsoleColor.Gray;
                break;
            case VWall:
                symbol = '║';
                colorOfObject = ConsoleColor.Gray;
                break;
            case player:
                symbol = '¢';
                unitOnObject = new Player(cords,this,Level);
                colorOfObject = ConsoleColor.Yellow;
                break;

            case enemy:
                symbol = 'Æ';
                colorOfObject = ConsoleColor.DarkRed;
                unitOnObject = new Enemy(cords,this,Level);
                break;
            case Exit:
                symbol = 'X';
                colorOfObject = ConsoleColor.Red;
                break;
            case Entry:
                symbol = 'E';
                colorOfObject = ConsoleColor.Green;

                break;
            case ShownTrap:
                symbol = 'T';
                colorOfObject = ConsoleColor.Magenta;
                trap = new Trap(cords, this);
                break;
            case HiddenTrap:
                symbol = ' ';
                trap = new Trap(cords,this);
                break;
            case Treasure:
                symbol = '$';
                colorOfObject = ConsoleColor.DarkYellow;
                treasure = new TreasureChest(cords,this);
                break;
            case DorVendorE:
                symbol = 'D';
                colorOfObject = ConsoleColor.Blue;
                DorVendorOnMap = new(cords,this);

                break;
            case Abyss:
                symbol = ' ';
                break;
        }
        type = useable;
    }

}


public enum UsableObjects
{
    HWall = 48, //0
    VWall = 49,// 1
    player = 51, //3
    enemy = 52, //4
    Exit = 57, //9
    Entry = 50, //2
    ShownTrap = 56,// 8
    HiddenTrap = 55,//7
    Treasure = 53, //5
    DorVendorE = 54, //6
    Abyss = 32 //Space


}
