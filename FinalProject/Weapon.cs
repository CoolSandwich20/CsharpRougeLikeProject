using static WeaponTypes;
public class Weapon
{
    //fields
    public int Dmg;
    public float HitChance;
    public string weaponName;
    public float Crit;
    public int Dorllars;
    public WeaponTypes UnitWeaponTypes;
    public static Weapon[] WeaponList = { new(sickle),new(sword), new(axe), new(mace), new(longSword), new(battleAxe), new(spear), new(poleAxe), new(katana), new(MagicRevolver) };


    //Constructors
    public Weapon(WeaponTypes wpn)
    {

        switch (wpn)
        {
            case sword:
                weaponName = "sword";
                Dmg = 8;
                HitChance = 90;
                Crit = 10f;
                Dorllars = 15;
                break;
            case axe:
                weaponName = "axe";
                Dmg = 9;
                HitChance = 80;
                Crit = 4f;
                Dorllars = 18;
                break;
            case mace:
                weaponName = "mace";
                Dmg = 10;
                HitChance = 77;
                Crit = 12f;
                Dorllars = 25;
                break;
            case longSword:
                weaponName = "longSword";
                Dmg = 14;
                HitChance = 75;
                Crit = 13f;
                Dorllars = 40;
                break;
            case battleAxe:
                weaponName = "Battle Axe";
                Dmg = 12;
                HitChance = 65;
                Crit = 5f;
                Dorllars = 50;
                break;
            case spear:
                weaponName = "Spear";
                Dmg = 13;
                HitChance = 90;
                Crit = 7f;
                Dorllars = 65;
                break;
            case sickle:
                weaponName = "Sickle";
                Dmg = 6;
                HitChance = 95;
                Crit = 8f;
                Dorllars = 2;
                break;
            case poleAxe:
                weaponName = "Pole Axe";
                Dmg = 15;
                HitChance = 90;
                Crit = 20f;
                Dorllars = 70;
                break;
            case MagicRevolver: 
                weaponName = "The Revolver";
                Dmg = 18;
                HitChance = 75;
                Crit = 15f;
                Dorllars = 80;
                break;
            case katana:
                weaponName = "katana";
                Dmg = 20;
                HitChance = 95;
                Crit = 25f;
                Dorllars = 90;
                break;
        }
        UnitWeaponTypes = wpn;
    }
    public int Attack()
    {
        int TempDmg = Dmg;
        Random rnd = new Random();
        int hitChance = rnd.Next(0, 101);
        int CritChance = rnd.Next(0,101);
        if (HitChance <= hitChance)
        {
            return 0;

        }
        if (Crit >= CritChance)
        {
            TempDmg = Dmg * 2;
            return TempDmg;
        }
        return TempDmg;
    }
}
public enum WeaponTypes
{
    sword = 1,
    axe = 2,
    mace = 3,
    longSword = 7,
    battleAxe = 4,
    spear = 5,
    sickle = 0,
    poleAxe = 6,
    MagicRevolver = 8,
    katana = 9

}


