
public class Trap
{
    public Vector TrapCords { get; set; }
    public MapObjects TrapObject { get; set; }
    public Trap(Vector trapCords, MapObjects trapObject)
    {
        TrapCords = trapCords;
        TrapObject = trapObject;
    }
    public void TrapDealDmg(Player HitPlayer, int dmg, DataLogs<string> trapData)
    {
        HitPlayer.TakeDmg(dmg, trapData);
    }
}

