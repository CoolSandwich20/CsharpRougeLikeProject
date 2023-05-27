using System;
using static ShieldType;
public class Shield
{
    public string ShieldName;
    public int shieldValue;
    public static Shield[] ShieldList = { new(roundShield), new(kiteShield), new(heaterShield), new(bucklerShield), new(scutumShield), new(MagenDavid), new(FullPlate), new(AntiWarShield), new(VendorsChoice), new(MagicalShield) };
    public ShieldType playerShieldTypes;
    public int Dorllars;
    public Shield(ShieldType type)
    {
        switch (type)
        {
            case roundShield:
                ShieldName = "Round Shield";
                shieldValue = 3;
                Dorllars = 8;
                break;
            case kiteShield:
                ShieldName = "Kite Shield";
                shieldValue = 5;
                Dorllars = 10;
                break;
            case heaterShield:
                ShieldName = "Heater Shield";
                shieldValue = 6;
                Dorllars = 14;
                break;
            case scutumShield:
                ShieldName = "Scutum Shield";
                shieldValue = 7;
                Dorllars = 15;
                break;
            case bucklerShield:
                ShieldName = "Buckler Shield";
                shieldValue = 4;
                Dorllars = 3;
                break;
            case MagenDavid:
                ShieldName = "Magen David";
                shieldValue = 8;
                Dorllars = 20;
                break;
            case FullPlate:
                ShieldName = "Plate Armor";
                shieldValue = 9;
                Dorllars = 25;
                break;
            case AntiWarShield:
                ShieldName = "Obsidian Shield";
                shieldValue = 10;
                Dorllars = 35;
                break;
            case VendorsChoice:
                shieldValue = 11;
                ShieldName = "The Vendor´s Choice!";
                Dorllars = 40;
                break;
            case MagicalShield:
                shieldValue = 12;
                ShieldName = "Magical Shield";
                Dorllars = 50;
                break;

        }
    }

}

public enum ShieldType
{
    roundShield,
    kiteShield,
    heaterShield,
    scutumShield,
    bucklerShield,
    MagenDavid,
    FullPlate,
    AntiWarShield,
    VendorsChoice,
    MagicalShield


}