
public class DorVendor
{
    public Vector VendorCords { get; set; }
    public MapObjects VendorObject { get; set; }
    MenuEngine shopMenu { get; set; }


    public DorVendor(Vector DorCords, MapObjects DorObject)
    {
        VendorCords = DorCords;
        VendorObject = DorObject;
    }
    public void ShopMenu(Map map, Player player)
    {
        Console.Clear();
        string[] optionsForShop = { new("Weapons"), new("Shields"), new($"Healing Potion - Costs 10 Dorllars Per Potion, You have({player.AmountOfPotions})"), new($"Health Buff, You have ({player.maxHP})"), new("Exit - This sends you to the next level!") };
        string prompt = @$"
                _______________________________
               /                               \
_____________ /  Hi Im Dor Vendor!              \
____________ |\  What Do You wish to buy?       /
            || \__  ___________________________/
            ||   / /
           _||__/ /
          (______/
            ||  _
            || [.]
            ||
            ||
            ||    _____
         ___||   /     \/_
        |\__||  //\__(\_\
        || |||  |\ ~~ ~~|
________||_|||  /|_O \O_ \
 \_\ \_\||_|||  \_  (_)  /
\_\_\_\_\_\_||__ \   -  / _____________________
______________ __/\  ~ /\__ _____________
_____________ /  \ \  / /  \ ____________\
             /    \/\/\/    \            |__
            /        .   |   \           \  \
           /   /|    .   |    \         | \__\
              / |        | \   \        | |  |
   You have {player.Dorllars} Dorllars";
        shopMenu = new(optionsForShop, prompt);
        int selectedIndex = shopMenu.Start();
        Console.Clear();
        switch (selectedIndex)
        {
            case 0:
                ChoosingWeapon(player, map);
                break;
            case 1:
                ChoosingShield(player, map);
                break;
            case 2:
                if (player.Dorllars >= 10)
                {
                    player.Dorllars -= 10;
                    player.AmountOfPotions++;
                }
                ShopMenu(map, player);
                break;
            case 3:
                if (player.Dorllars >= 5)
                {
                    player.Dorllars -= 5;
                    player.maxHP += 5;
                    player.CurrentHp += 5;
                }
                ShopMenu(map, player);
                break;

            case 4:
                break;

        }

    }
    public Weapon ChoosingWeapon(Player player, Map map)
    {
        int _page = 1;
        string _previousPage = "Previous Page";
        string _nextPage = "Next Page";
        Weapon result = null;

        while (result == null)
        {
            Console.Clear();
            Console.WriteLine("Use the A and D to move pages and press the number stated to choose which Weapon");
            Console.WriteLine($"Your Dorllars: {player.Dorllars}");
            Console.WriteLine("1. The {0}´s Hit chance is {1}, The {0}`s damage is {2} At the Price of {3}", Weapon.WeaponList[_page - 1].weaponName, Weapon.WeaponList[_page - 1].HitChance, Weapon.WeaponList[_page - 1].Dmg, Weapon.WeaponList[_page - 1].Dorllars);
            Console.WriteLine("2. The {0}´s Hit chance is {1}, The {0}`s damage is {2} At the Price of {3}", Weapon.WeaponList[_page].weaponName, Weapon.WeaponList[_page].HitChance, Weapon.WeaponList[_page].Dmg, Weapon.WeaponList[_page].Dorllars);
            Console.WriteLine("3. The {0}´s Hit chance is {1}, The {0}`s damage is {2} At the Price of {3}", Weapon.WeaponList[_page + 1].weaponName, Weapon.WeaponList[_page + 1].HitChance, Weapon.WeaponList[_page + 1].Dmg, Weapon.WeaponList[_page + 1].Dorllars);
            Console.WriteLine($"D. {_nextPage}");
            Console.WriteLine($"A. {_previousPage} ");
            Console.WriteLine($"X. To Exit back to the menu");
            ConsoleKey keys = Console.ReadKey(true).Key;
            switch (keys)
            {
                case ConsoleKey.D1:
                    if (Weapon.WeaponList[_page - 1].Dorllars <= player.Dorllars)
                    {
                        result = Weapon.WeaponList[_page - 1];
                        player.Dorllars -= Weapon.WeaponList[_page - 1].Dorllars;
                        ShopMenu(map, player);
                        break;
                    }
                    break;
                case ConsoleKey.D2:
                    if (Weapon.WeaponList[_page].Dorllars <= player.Dorllars)
                    {
                        result = Weapon.WeaponList[_page];
                        player.Dorllars -= Weapon.WeaponList[_page].Dorllars;
                        ShopMenu(map, player);
                        break;
                    }
                    break;
                case ConsoleKey.D3:
                    if (Weapon.WeaponList[_page + 1].Dorllars <= player.Dorllars)
                    {
                        result = Weapon.WeaponList[_page + 1];
                        player.Dorllars -= Weapon.WeaponList[_page + 1].Dorllars;
                        ShopMenu(map, player);
                        break;
                    }
                    break;

                case ConsoleKey.D:
                    _page += 3;
                    if (_page > 7)
                    {

                        _page = 1;
                    }
                    break;
                case ConsoleKey.A:
                    _page -= 3;
                    if (_page < 1)
                    {
                        _page = 7;
                    }
                    break;
                case ConsoleKey.X:
                    result = player.WeaponOnUnit;
                    ShopMenu(map, player);
                    break;

            }
        }
        return player.WeaponOnUnit = result;
    }

    public Shield ChoosingShield(Player player, Map map)
    {
        int _page = 1;
        string _previousPage = "Previous Page";
        string _nextPage = "Next Page";
        Shield result = null;

        while (result == null)
        {
            Console.Clear();
            Console.WriteLine("Use the A and D to move pages and press the number stated to choose which Weapon");
            Console.WriteLine($"Your Dorllars: {player.Dorllars}");
            Console.WriteLine("1. The {0}´s Defence Power is {1}, At the Price of {2}", Shield.ShieldList[_page - 1].ShieldName, Shield.ShieldList[_page - 1].shieldValue, Shield.ShieldList[_page - 1].Dorllars);
            Console.WriteLine("2. The {0}´s Defence Power is {1}, At the Price of {2}", Shield.ShieldList[_page].ShieldName, Shield.ShieldList[_page].shieldValue, Shield.ShieldList[_page].Dorllars);
            Console.WriteLine("3. The {0}´s Defence Power is {1}, At the Price of {2}", Shield.ShieldList[_page + 1].ShieldName, Shield.ShieldList[_page + 1].shieldValue, Shield.ShieldList[_page + 1].Dorllars);
            Console.WriteLine($"D. {_nextPage}");
            Console.WriteLine($"A. {_previousPage} ");
            Console.WriteLine("X. To Exit back to the menu");
            ConsoleKey keys = Console.ReadKey(true).Key;
            switch (keys)
            {
                case ConsoleKey.D1:
                    if (Shield.ShieldList[_page - 1].Dorllars <= player.Dorllars)
                    {
                        result = Shield.ShieldList[_page - 1];
                        player.Dorllars -= Shield.ShieldList[_page - 1].Dorllars;
                        ShopMenu(map, player);
                        break;
                    }
                    break;
                case ConsoleKey.D2:
                    if (Shield.ShieldList[_page].Dorllars <= player.Dorllars)
                    {
                        result = Shield.ShieldList[_page];
                        player.Dorllars -= Shield.ShieldList[_page].Dorllars;
                        ShopMenu(map, player);
                        break;
                    }
                    break;
                case ConsoleKey.D3:
                    if (Shield.ShieldList[_page + 1].Dorllars <= player.Dorllars)
                    {
                        result = Shield.ShieldList[_page + 1];
                        player.Dorllars -= Shield.ShieldList[_page + 1].Dorllars;
                        ShopMenu(map, player);
                        break;
                    }
                    break;

                case ConsoleKey.D:
                    _page += 3;
                    if (_page > 7)
                    {

                        _page = 1;
                    }
                    break;
                case ConsoleKey.A:
                    _page -= 3;
                    if (_page < 1)
                    {
                        _page = 7;
                    }
                    break;
                case ConsoleKey.X:
                    result = player.ShieldOnUnit;
                    ShopMenu(map, player);
                    break;

            }
        }
        return player.ShieldOnUnit = result;
    }

}
