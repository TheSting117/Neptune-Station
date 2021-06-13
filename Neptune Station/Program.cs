using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Neptune_Station
{
    public class neptuneStation
    {
        public class Flags 
        {
            //Encounter Flags
            bool combatEncounterFlag = false;
            bool mechEncounterFlag = false;
            bool hackEncounterFlag = false;
            bool lootingFlag = false;

            //Player Flags
            bool playerStunnedFlag = false;
            bool Strength10 = false;
            bool Stealth10 = false;
            bool Intel10 = false;
            bool Speed10 = false;

            //Moster Flags
            bool monsterStunnedFlag = false;
           
        }
        public class Monster
        {
            public string Name { get; set; }
            //Defensive Stats
            public int Health { get; set; }
            public double Resistance { get; set; }
            public double Evasion { get; set; }
            public double Accuracy { get; set; }
            //Offensive Stats
            public int Damage { get; set; }
            public double stunChance { get; set; }
            //Misc Stats
            public bool isStunnable { get; set; }

            public static Monster[] monsterArray = new Monster[3];

            public Monster(string name, int health, double resistance, double evasion, double accuracy, int damage, double stunchance, bool isstunnable)
            {
                Name = name;
                Health = health;
                Resistance = resistance;
                Evasion = evasion;
                Accuracy = accuracy;
                Damage = damage;
                stunChance = stunchance;
                isStunnable = isstunnable;

            }
        }
        static void monsterGeneration()
        {

            //Monster <monster> = new Monster(Name, Health, Resistance, Evasion, Accuracy, Damage, Stun Chance, Is Stunnable);
            Monster xeno_9 = new Monster("Xeno-9", 500, 0.5, 0.5, 0.9, 25, 0.4, false);
            Monster cyborg_guard = new Monster("Cyborg Guard", 100, 0.2, 0.2, 0.5, 10, 0.2, true);
            Monster roach = new Monster("Irradiated Roach", 25, 0.01, 0.01, 0.2, 5, 0, true);
            Monster.monsterArray[0] = xeno_9;
            Monster.monsterArray[1] = cyborg_guard;
            Monster.monsterArray[2] = roach;
            Console.WriteLine(Monster.monsterArray[2].Name + " approaches! Its health is currently " + Monster.monsterArray[2].Health);
        }
        public class Player
        {
            //Combat related stats
            int Health = 100;
            int punchDamage = 10;
            double stunChance = 0;
            double Resistance = 0.1;
            double Evasion = 0.1;
            double Accuracy = 0.5;
            //Player Attributes
            int Strength = 1;
            int Stealth = 1;
            int Intelligence = 1;
            int Speed = 1;
            int Exp = 0;
            double expGainMult = 1.0;
            //Puzzle Attributes
            int clueCount = 1;

        }
        public class Item
        {
            public static int weaponCount = 3;
            public static int armourCount = 3;
            public static int bagCount = 3;
            public static int mechToolCount = 3;
            public static int hackToolCount = 3;
            public static int medToolCount = 3;
            public static int ammoCount = 3;

            public static Item[] weaponArray = new Item[weaponCount];
            public static Item[] armourArray = new Item[armourCount];
            public static Item[] bagArray = new Item[bagCount];
            public static Item[] mechToolArray = new Item[mechToolCount];
            public static Item[] hackToolArray = new Item[hackToolCount];
            public static Item[] medToolArray = new Item[medToolCount];
            public static Item[] ammoArray = new Item[weaponCount];
            public string itemName { get; set; }
            public string itemType { get; set; }
            public static string[] itemTypes = { "Ammuntion", "Ranged Weapon", "Melee Weapon", "Armour", "Bag", "Mechanical Tool", "Hacking Tool", "Medical Tool" };
            public string[] itemRarities = { "Common", "Uncommon", "Rare", "Legendary", "Story Item" };
            public double spawnChance { get; set; }
            public string itemRarity { get; set; }
            //public static string imgID { get; set; }
            public int maxStackSize { get; set; }
        }
        public class Armour : Item
        {
            public int healthInc { get; set; }
            public double resistInc { get; set; }
            public Armour(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, int healthinc, double resistinc)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                healthInc = healthinc;
                resistInc = resistinc;
            }
        }
        public class Bag : Item
        {
            public int inventoryInc { get; set; }
            public Bag(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, int inventoryinc)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                inventoryInc = inventoryinc;
            }
        }
        public class mechTool: Item
        {
            public int mechClueCountInc { get; set; }
            public mechTool(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, int mechcluecountinc)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                mechClueCountInc = mechcluecountinc;
            }
        }
        public class hackTool : Item
        {
            public int hackClueCountInc { get; set; }
            public bool isAdvanced { get; set; }
            public hackTool(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, int hackcluecountinc, bool isadvanced)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                hackClueCountInc = hackcluecountinc;
                isAdvanced = isadvanced;
            }
        }
        public class medTool : Item
        {
            public int healthHealed { get; set; }
            public double resistInc { get; set; }
            public medTool(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, int healthhealed, double resistinc)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                healthHealed = healthhealed;
                resistInc = resistinc;
            }
        }
        public class combatItem : Item
        {
            public int weaponDamage { get; set; }
            public double weaponAccuracy { get; set; }


        }
        public class rangedWeapon : combatItem
        {
            public string ammunitionType { get; set; }
            public rangedWeapon(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, string ammo, int damage, double accuracy)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                ammunitionType = ammo;
                weaponDamage = damage;
                weaponAccuracy = accuracy;

            }
        }
        public class meleeWeapon : combatItem
        {
            public double weaponStunChance { get; set; }
            public meleeWeapon(string name, int typeid, double spawnchance, int rarityid, int maxstacksize, int damage, double accuracy, double stunchance)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
                weaponDamage = damage;
                weaponAccuracy = accuracy;
                weaponStunChance = stunchance;
            }
        }
        public class Ammo : Item
        {
            public Ammo(string name, int typeid, double spawnchance, int rarityid, int maxstacksize)
            {
                itemName = name;
                itemType = itemTypes[typeid];
                spawnChance = spawnchance;
                itemRarity = itemRarities[rarityid];
                maxStackSize = maxstacksize;
            }
        }
        static void ItemGenerator()
        {
            
            //rangedWeapon <weapon> = new rangedWeapon (Name, TypeID, SpawnChance, RarityID, MaxStackSize, Ammo, Damage, Accuracy)
            rangedWeapon M8A1_Rifle = new rangedWeapon("M8A1 Assault Rifle", 1, 0.2, 0, 1, "5.56mm", 20, 0.4);
            Item.weaponArray[0] = M8A1_Rifle;
            //meleeWeapon <weapon> = new meleeWeapon(Name, TypeID, SpawnChance, RarityID, MaxStackSize, Damage, Accuracy, StunChance)
            meleeWeapon Stun_Knife = new meleeWeapon("Stun Knife", 2, 0.2, 0, 1, 10, 0.6, 0.1);
            Item.weaponArray[1] = Stun_Knife;
            //Armour <armour> = new Armour(Name, TypeID, SpawnChance, RarityID, MaxStackSize, HealthInc, ResistInc)

            //Bag <bag> = new Bag(Name, TypeID, SpawnChance, RarityID, MaxStackSize, InventoryInc)

            //mechTool <tool> = new mechTool(Name, TypeID, SpawnChance, RarityID, MaxStackSize, MechClueCountInc)

            //hackTool <tool> = new mechTool(Name, TypeID, SpawnChance, RarityID, MaxStackSize, HackClueCountInc, IsAdvanced)

            //medTool <tool> = new medTool(Name, TypeID, SpawnChance, RarityID, MaxStackSize, HealthHealed, ResistInc)

            //Ammo <ammo> = new Ammo(Name, TypeID, SpawnChance, RarityID, MaxStackSize)


        }
        public class Room
        {
            public static int roomCount = 10;
            public string roomType { get; set; }
            public string roomName { get; set; }
            public bool monsterSpawn { get; set; }
            public bool roomEntered { get; set; }
            public static Room[] roomArray = new Room[roomCount];
            public static string[] roomTypeArray = { "Start Room", "Lab", "Armoury", "Control Room" };
            public Room(int roomtypeid, string roomname, bool monsterspawn, bool roomentered)
            {
                roomType = roomTypeArray[roomtypeid];
                roomName = roomname;
                monsterSpawn = monsterspawn;
                roomEntered = roomentered;
            }
        }
        static void roomGenerator()
        {
            //Room <room> = new Room(RoomTypeID, RoomName, MonsterSpawn, RoomEntered)
            Room startRoom = new Room(0,"Cryo Room", false, false); 
            Room Lab01 = new Room(1, "Lab 01", false, false);
            Room Lab02 = new Room(1, "Lab 02", false, false);
            Room Lab03 = new Room(1, "Lab 03", true, false);
            Room Lab04 = new Room(1, "Lab 04", true, false);
            Room Armoury01 = new Room(2, "Armoury 01", false, false);
            Room Armoury02 = new Room(2, "Armoury 02", true, false);
            Room Armoury03 = new Room(2, "Armoury 03", false, false);
            Room controlRoom01 = new Room(3, "Control Room Alpha", true, false);
            Room controlRoom02 = new Room(3, "Control Room Gamma", true, false);
        }
        public class Container
        {
            public static int containerCount = 4;
            public static string[] containerTypes = { "Desk", "Locker", "Weapon Locker", "Box" };
            public string containerType { get; set; }
            public string containerName { get; set; }
            public int maxItemSpawn { get; set; }
            public int maxItemCount { get; set; }
            public string itemSpawn { get; set; }
            public string spawnLocation { get; set; }
            public Item[] storedItems { get; set; }
            public static Container[] containerArray = new Container[containerCount];
            public Container(string containername,int containertypeid, int maxitemspawn, int maxitemcount, int itemspawnid, int spawnlocationid)
            {
                containerName = containername;
                containerType = containerTypes[containertypeid];
                maxItemSpawn = maxitemspawn;
                maxItemCount = maxitemcount;
                itemSpawn = Item.itemTypes[itemspawnid];
                spawnLocation = Room.roomTypeArray[spawnlocationid];
                for (int i = 0; i <= maxItemSpawn; i++)
                {
                    Random rnd = new Random();
                    int temp = rnd.Next(0, 2);
                    if (itemSpawn == Item.itemTypes[0])
                    {
                        storedItems[i] = Item.ammoArray[temp];
                    }
                    else if (itemSpawn == Item.itemTypes[1])
                    {
                        storedItems[i] = Item.weaponArray[temp];
                    }
                    else if (itemSpawn == Item.itemTypes[2])
                    {
                        storedItems[i] = Item.weaponArray[temp + 3];
                    }
                    else if (itemSpawn == Item.itemTypes[3])
                    {
                        storedItems[i] = Item.armourArray[temp];
                    }
                    else if (itemSpawn == Item.itemTypes[4])
                    {
                        storedItems[i] = Item.bagArray[temp];
                    }
                    else if (itemSpawn == Item.itemTypes[5])
                    {
                        storedItems[i] = Item.mechToolArray[temp];
                    }
                    else if (itemSpawn == Item.itemTypes[6])
                    {
                        storedItems[i] = Item.hackToolArray[temp];
                    }
                    else if (itemSpawn == Item.itemTypes[7])
                    {
                        storedItems[i] = Item.medToolArray[temp];
                    }
                }  
            }
        }

        static void containerGenerator()
        {
            //Container <container> = new Container(ContainerName, ContainerTypeID, MaxItemSpawn, MaxItemCount, ItemSpawnID, SpawnLocationID)
            Container desk_starter = new Container("Starter Desk", 0, 2, 5, 5, 0);
            Container desk_lab = new Container("Desk", 0, 2, 5, 7, 1);
            Container desk_control = new Container("Control Desk", 0, 2, 5, 6, 3);
            Container locker_armoury = new Container("Armoury Locker", 1, 3, 5, 0, 2);
            Container locker_lab = new Container("Lab Locker", 1, 3, 5, 3, 1);
            Container locker_control = new Container("Control Locker", 1, 3, 5, 4, 3);
            Container weapon_locker_armoury = new Container("Armoury Weapon Locker", 2, 1, 3, 1, 2);
            Container weapon_locker_control = new Container("Armoury Weapon Locker", 2, 1, 3, 2, 3);
            Container box_starter = new Container("Starter Box", 3, 1, 5, 4, 0);
        }
       
        public class playerInventory
        {
            Item[][] storedItems = { null, null, null, null, null, null, null, null, null, null };
            combatItem[] equippedWeapons = { null, null};
            Bag equippedBag;
            Armour equippedArmour;
        }
        static void Introduction()
        {

        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
