
    public class TreasureChest
    {
    public int Dorllars { get; set; }
    public Vector TreasureVector { get; set; }
    public MapObjects TreasureObject { get; set; }


    public TreasureChest(Vector Cords, MapObjects Treasure)
    {
        TreasureVector= Cords;
        TreasureObject= Treasure;
    }

    public int GenerateMoney(int Level)
    {
        int RandomMoney = Random.Shared.Next(5, 25);
        RandomMoney *= Level;
        return Dorllars = RandomMoney;
    }
    public void OpenATreasureChest(Player player,int lvl)
    {
        GenerateMoney(lvl);
        player.Dorllars += Dorllars;
    }
    }

