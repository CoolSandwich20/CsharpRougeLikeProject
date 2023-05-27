

using static EnemyTypes;
public class Enemy : Unit
    {
    public Enemy(Vector Coords,MapObjects objectStandingOn,int Level) : base(Coords) 
    {
        Cords= Coords;
        objectUnderUnit = new MapObjects(UsableObjects.Abyss,Cords,Level);
        ObjectOfUnit = objectStandingOn; 
        maxHP = 10 + Level;
        currentHP = maxHP;
        evasion = 0.10f;
        WeaponOnUnit = Weapon.WeaponList[Level -1];
        ShieldOnUnit = Shield.ShieldList[Level -1];
        
    }
   

    public Unit Enemy_Unit;
    public string enemyName;
    private EnemyTypes _enemyTypes;
    public static void MoveEnemies(Map map)
    {
        foreach (Enemy enemy in map.enemies)
        {
            if (enemy == null) continue;
            if(enemy.CurrentHp == 0) continue;
            if (Math.Abs(map.player.Cords.Y - enemy.Cords.Y) > 5 || Math.Abs(map.player.Cords.X - enemy.Cords.X) > 5) continue;
            if (map.player.Cords.Y > enemy.Cords.Y)
            {
                Collision.MoveUnit(map, new(Directon.Down), enemy,null);

            }
            else if (map.player.Cords.Y < enemy.Cords.Y)
            {
                Collision.MoveUnit(map, new(Directon.Up), enemy,null);
            }
            else
            {
                if (map.player.Cords.X > enemy.Cords.X)
                {
                    Collision.MoveUnit(map, new(Directon.Right), enemy, null);
                }
                else
                {
                    Collision.MoveUnit(map, new(Directon.Left), enemy, null);
                }
            }
        }
    }
        
}
public enum EnemyTypes
{
    Orc = 1,
    Goblin = 2,
    troll = 3,
    Skeleton = 4,
    demon = 5
}


