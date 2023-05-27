

using FinalProject;
using System.Drawing;
using System.Numerics;

public class Collision
{
    public static void MoveUnit(Map map, Vector direction, Unit unit, DataLogs<string> dataLog)
    {


        switch (map.GetObjectFromMap(direction + unit.Cords).type)
        {
            case UsableObjects.HWall:
                break;
            case UsableObjects.VWall:
                break;
            case UsableObjects.player:
                break;
            case UsableObjects.enemy:
                if (unit.ObjectOfUnit.type == UsableObjects.player)
                {
                    Unit.CombatMechanics(map, (Enemy)map.GetObjectFromMap(direction + unit.Cords).unitOnObject, map.player, true, dataLog);
                }
                break;

            case UsableObjects.Exit:
                if (map.enemies.Count == 0)
                {
                    map.MoveTheUnit(unit.Cords, direction, unit);
                }
                else
                {
                    string EndLog = $"You need to kill All Enemies To exit";
                    dataLog.AddItem(EndLog);
                }
                break;
            case UsableObjects.Entry:
                break;
            case UsableObjects.ShownTrap:
                break;
            case UsableObjects.HiddenTrap:
                map.MoveTheUnit(unit.Cords, direction, unit);
                if (unit.ObjectOfUnit.type == UsableObjects.player)
                {
                    Unit.WalkOnTrap(map, unit.objectUnderUnit.trap, map.player, true, dataLog);
                }
                break;
            case UsableObjects.Treasure:
                map.MoveTheUnit(unit.Cords, direction, unit);
                if (unit.ObjectOfUnit.type == UsableObjects.player)
                {
                    Unit.WalkOnTreasure(map, unit.objectUnderUnit.treasure, map.player, true, dataLog, map.level);
                }
                break;
            case UsableObjects.DorVendorE:
                map.MoveTheUnit(unit.Cords, direction, unit);
                if (unit.ObjectOfUnit.type == UsableObjects.player)
                {
                    map.VendorOnMap.ShopMenu(map, map.player);
                }
                break;
            case UsableObjects.Abyss:
                map.MoveTheUnit(unit.Cords, direction, unit);
                break;
        }

    }



}

