

using System.Reflection.Emit;
using System;
using System.Runtime.CompilerServices;

public class Player : Unit
{
    public Player(Vector coordinations, MapObjects ObjectUnit,int Level ) : base( coordinations )//This works like the Unit Constructor
    {
        Cords = coordinations;
        objectUnderUnit = new MapObjects(UsableObjects.Abyss, Cords,Level);
        ObjectOfUnit = ObjectUnit;
        maxHP = 100;
        currentHP = maxHP;
        evasion = 0.10f;
        WeaponOnUnit = new Weapon(WeaponTypes.sickle);
        this.Dorllars = 0;
        ShieldOnUnit = new Shield(ShieldType.roundShield);
        AmountOfPotions = 2;
        
    }
    
}

