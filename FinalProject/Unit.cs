using static System.Runtime.InteropServices.JavaScript.JSType;

public class Unit
{
    //Fields
    public int currentHP;
    public int maxHP;
    public int Dorllars;
    public string name;
    public float evasion;
    public int AmountOfPotions;

    //properties
    public bool isDead { get { return currentHP == 0; } }

    public int CurrentHp //Method To validate the hp doesnt go bellow 0
    {
        get { return currentHP; }

        set
        {
            currentHP = value;

            if (currentHP <= 0)
            {
                currentHP = 0;
            }
        }

    }
    // Properties
    public Vector Cords { get; set; }
    public MapObjects objectUnderUnit { get; set; }
    public MapObjects ObjectOfUnit { get; set; }
    public Weapon WeaponOnUnit { get; set; }
    public Shield ShieldOnUnit { get; set; }

    //Constructor
    public Unit(Vector cords)
    {
        Cords = cords;
    }


    //Methods

    public void UpdateCurrentVector(Vector cords, MapObjects objectStandingOn)
    {
        Cords += cords;
        objectUnderUnit = objectStandingOn;
    }

    public void HealingPotion(Unit player, DataLogs<string> logUse)
    {
        if (AmountOfPotions > 0)
        {


            if (player.CurrentHp != player.maxHP)
            {
                player.CurrentHp += 20;

                if (player.CurrentHp >= player.maxHP)
                {
                    player.CurrentHp = player.maxHP;
                }
                string logofHeal = ("You Used An Healing Potion healing for 20hp                           ");
                logUse.AddItem(logofHeal);
                AmountOfPotions--;

            }
            if (AmountOfPotions < 0) AmountOfPotions = 0;
        }
        else
        {
            string NoPotions = "You have no Potions In your Inventory                          ";
            logUse.AddItem(NoPotions);
        }
    }
    public void TakeDmg(int dmg, DataLogs<string> dmgEvasionLog)
    {

        if (evasion >= Evasion())
        {
            string evasionLog = ("* Evasion!                                            ");
            dmgEvasionLog.AddItem(evasionLog);
            return;
        }

        dmg -= ShieldOnUnit.shieldValue;
        if (dmg <= 0) return;
        CurrentHp -= dmg;
        string dmgLog = ($"* {dmg} is being dealt                                ");
        dmgEvasionLog.AddItem(dmgLog);


    }
    public void DealDmg(Unit enemy, DataLogs<string> log)
    {

        enemy.TakeDmg(WeaponOnUnit.Attack(), log);
    }

    public static void CombatMechanics(Map map, Enemy enemy, Player player, bool isInitiateCombat, DataLogs<string> log)
    {
        if (isInitiateCombat)
        {
            if (enemy == null) return;
            player.DealDmg(enemy, log);
            enemy.DealDmg(player, log);
            if (enemy.isDead)
            {
                map.MapObjects[enemy.Cords.Y][enemy.Cords.X] = new(UsableObjects.Abyss, enemy.Cords, map.level);//Deletes the enemy
                string logOfCombat = ($"* Enemy is Killed                                       ");
                log.AddItem(logOfCombat);
                map.enemies.Remove(enemy);
                enemy = null;
            }
            if (player.isDead)
            {
                return;
            }

        }
    }
    public static void WalkOnTrap(Map map, Trap trap, Player player, bool isPlayerOnTrap, DataLogs<string> log)
    {
        int randDmg = Random.Shared.Next(1, 8);
        if (isPlayerOnTrap)
        {
            if (trap == null) return;
            trap.TrapDealDmg(player, randDmg, log);
            player.objectUnderUnit = new(UsableObjects.ShownTrap, trap.TrapCords, map.level);
        }
    }
    public static void WalkOnTreasure(Map map, TreasureChest Chest, Player player, bool isPlayerOnChest, DataLogs<string> log, int lvl)
    {
        if (isPlayerOnChest)
        {
            if (Chest == null) return;
            Chest.OpenATreasureChest(player, lvl);
            player.objectUnderUnit = new(UsableObjects.Abyss, Chest.TreasureVector, map.level);
            Chest = null;
        }
    }

    private Double Evasion()
    {
        Random rand = new Random();
        return rand.NextDouble();

    }
}
