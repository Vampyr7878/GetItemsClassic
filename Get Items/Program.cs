using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Get_Items
{
    class Program
    {
        static RECORDS items;
        static XmlSerializer xml;
        static List<string> reagents = new List<string>
        {
            "Symbol of Divinity",
            "Symbol of Kings",
            "Holy Candle",
            "Light Feather",
            "Sacred Candle",
            "Ankh",
            "Fish Oil",
            "Shiny Fish Scales",
            "Arcane Powder",
            "Rune of Portals",
            "Rune of Teleportation",
            "Demonic Figurine",
            "Infernal Stone",
            "Soul Shard",
            "Ashwood Seed",
            "Hornbeam Seed",
            "Ironwood Seed",
            "Maple Seed",
            "Stranglethorn Seed",
            "Wild Berries",
            "Wild Thornroot"
        };
        static List<string> classes = new List<string>
        {
            "2",
            "2",
            "16",
            "144",
            "16",
            "64",
            "64",
            "64",
            "128",
            "128",
            "128",
            "256",
            "256",
            "256",
            "1024",
            "1024",
            "1024",
            "1024",
            "1024",
            "1024",
            "1024"
        };
        static List<string> mounts = new List<string>
        {
            "Black Battlestrider",
            "Black Qiraji Resonating Crystal",
            "Black Ram",
            "Black Stallion Bridle",
            "Black War Kodo",
            "Black War Ram",
            "Black War Steed Bridle",
            "Blue Mechanostrider",
            "Blue Qiraji Resonating Crystal",
            "Blue Skeletal Horse",
            "Brown Horse Bridle",
            "Brown Kodo",
            "Brown Ram",
            "Brown Skeletal Horse",
            "Charger",
            "Chestnut Mare Bridle",
            "Deathcharger's Reins",
            "Dreadsteed",
            "Felsteed",
            "Frost Ram",
            "Gray Kodo",
            "Gray Ram",
            "Great Brown Kodo",
            "Great Gray Kodo",
            "Great White Kodo",
            "Green Kodo",
            "Green Mechanostrider",
            "Green Qiraji Resonating Crystal",
            "Green Skeletal Warhorse",
            "Horn of the Arctic Wolf",
            "Horn of the Black War Wolf",
            "Horn of the Brown Wolf",
            "Horn of the Dire Wolf",
            "Horn of the Frostwolf Howler",
            "Horn of the Red Wolf",
            "Horn of the Swift Brown Wolf",
            "Horn of the Swift Gray Wolf",
            "Horn of the Swift Timber Wolf",
            "Horn of the Timber Wolf",
            "Icy Blue Mechanostrider Mod A",
            "Palomino Bridle",
            "Pinto Bridle",
            "Purple Skeletal Warhorse",
            "Red Mechanostrider",
            "Red Qiraji Resonating Crystal",
            "Red Skeletal Horse",
            "Red Skeletal Warhorse",
            "Reins of the Black War Tiger",
            "Reins of the Frostsaber",
            "Reins of the Nightsaber",
            "Reins of the Spotted Frostsaber",
            "Reins of the Spotted Nightsaber",
            "Reins of the Striped Frostsaber",
            "Reins of the Striped Nightsaber",
            "Reins of the Swift Frostsaber",
            "Reins of the Swift Mistsaber",
            "Reins of the Swift Stormsaber",
            "Reins of the Winterspring Frostsaber",
            "Stormpike Battle Charger",
            "Swift Blue Raptor",
            "Swift Brown Ram",
            "Swift Brown Steed",
            "Swift Gray Ram",
            "Swift Green Mechanostrider",
            "Swift Olive Raptor",
            "Swift Orange Raptor",
            "Swift Palomino",
            "Swift Razzashi Raptor",
            "Swift White Mechanostrider",
            "Swift White Ram",
            "Swift White Steed",
            "Swift Yellow Mechanostrider",
            "Swift Zulian Tiger",
            "Teal Kodo",
            "Unpainted Mechanostrider",
            "Warhorse",
            "Whistle of the Black War Raptor",
            "Whistle of the Emerald Raptor",
            "Whistle of the Ivory Raptor",
            "Whistle of the Mottled Red Raptor",
            "Whistle of the Turquoise Raptor",
            "Whistle of the Violet Raptor",
            "White Mechanostrider Mod B",
            "White Ram",
            "White Stallion Bridle",
            "Yellow Qiraji Resonating Crystal"
        };
        static List<string> models = new List<string>
        {
            "MechaStrider\\PvPMechaStrider",
            "RidingSilithid\\RidingSilithid",
            "Ram\\RidingRam",
            "RidingHorse\\RidingHorse",
            "Kodobeast\\KodoBeastPvPT2",
            "Ram\\PVPRidingRam",
            "RidingHorse\\RidingHorsePvPT2",
            "MechaStrider\\MechaStrider",
            "RidingSilithid\\RidingSilithid",
            "UndeadHorse\\RidingUndeadHorse",
            "RidingHorse\\RidingHorse",
            "Kodobeast\\RidingKodo",
            "Ram\\RidingRam",
            "UndeadHorse\\RidingUndeadHorse",
            "WarHorse\\PVPWarHorse",
            "RidingHorse\\RidingHorse",
            "MountedDeathKnight\\RidingUndeadWarHorse",
            "Nightmare\\Gorgon101",
            "Nightmare\\Nightmare",
            "Ram\\RidingRam",
            "Kodobeast\\RidingKodo",
            "Ram\\RidingRam",
            "Kodobeast\\KodoBeastPvPT2",
            "Kodobeast\\KodoBeastPvPT2",
            "Kodobeast\\KodoBeastPvPT2",
            "Kodobeast\\RidingKodo",
            "MechaStrider\\MechaStrider",
            "RidingSilithid\\RidingSilithid",
            "MountedDeathKnight\\RidingUndeadWarHorse",
            "DireWolf\\RidingDireWolf",
            "DireWolf\\PvPRidingDireWolf",
            "DireWolf\\RidingDireWolf",
            "DireWolf\\RidingDireWolf",
            "DireWolf\\PvPRidingDireWolf",
            "DireWolf\\RidingDireWolf",
            "DireWolf\\PvPRidingDireWolf",
            "DireWolf\\PvPRidingDireWolf",
            "DireWolf\\PvPRidingDireWolf",
            "DireWolf\\RidingDireWolf",
            "MechaStrider\\MechaStrider",
            "RidingHorse\\RidingHorse",
            "RidingHorse\\RidingHorse",
            "MountedDeathKnight\\RidingUndeadWarHorse",
            "MechaStrider\\MechaStrider",
            "RidingSilithid\\RidingSilithid",
            "UndeadHorse\\RidingUndeadHorse",
            "MountedDeathKnight\\RidingUndeadWarHorse",
            "FrostSabre\\PVPRidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "FrostSabre\\PVPRidingFrostSabre",
            "FrostSabre\\PVPRidingFrostSabre",
            "FrostSabre\\PVPRidingFrostSabre",
            "FrostSabre\\RidingFrostSabre",
            "Ram\\PVPRidingRam",
            "RidingRaptor\\PvPRidingRaptor",
            "Ram\\PVPRidingRam",
            "RidingHorse\\RidingHorsePvPT2",
            "Ram\\PVPRidingRam",
            "MechaStrider\\PvPMechaStrider",
            "RidingRaptor\\PvPRidingRaptor",
            "RidingRaptor\\PvPRidingRaptor",
            "RidingHorse\\RidingHorsePvPT2",
            "RidingRaptor\\PvPRidingRaptor",
            "MechaStrider\\PvPMechaStrider",
            "Ram\\PVPRidingRam",
            "RidingHorse\\RidingHorsePvPT2",
            "MechaStrider\\PvPMechaStrider",
            "FrostSabre\\PVPRidingFrostSabre",
            "Kodobeast\\RidingKodo",
            "MechaStrider\\MechaStrider",
            "WarHorse\\WarHorse",
            "RidingRaptor\\PvPRidingRaptor",
            "RidingRaptor\\RidingRaptor",
            "RidingRaptor\\RidingRaptor",
            "RidingRaptor\\RidingRaptor",
            "RidingRaptor\\RidingRaptor",
            "RidingRaptor\\RidingRaptor",
            "MechaStrider\\MechaStrider",
            "Ram\\RidingRam",
            "RidingHorse\\RidingHorse",
            "RidingSilithid\\RidingSilithid"
        };
        static List<string> textures = new List<string>
        {
            "MechaStrider\\PvPMechaStriderSkin_BlackBlack",
            "RidingSilithid\\RidingSilithidTankSkinArmoredBlack",
            "Ram\\RidingRamSkinBlack",
            "RidingHorse\\RidingHorseSkinBlack",
            "Kodobeast\\PVPKotoBeastSkinBlack",
            "Ram\\PvPRidingRamSkinDarkBlack",
            "RidingHorse\\PvPRidingHorseSkinBlack",
            "MechaStrider\\GnomeMechaStriderSkinBlue",
            "RidingSilithid\\RidingSilithidTankSkinArmoredBlue",
            "UndeadHorse\\UndeadHorseSkinBlue",
            "RidingHorse\\RidingHorseSkinBrown",
            "Kodobeast\\RidingKotoBeastSkinYellow",
            "Ram\\RidingRamSkinBrown",
            "UndeadHorse\\UndeadHorseSkinYellow",
            "WarHorse\\PVPWarHorse",
            "RidingHorse\\RidingHorseSkinChessnut",
            "MountedDeathKnight\\MountedDeathKnightBlack_01",
            "Nightmare\\HorseSkinEvilRed",
            "Nightmare\\HorseSkinEvil2",
            "Ram\\RidingRamSkinBlue",
            "Kodobeast\\RidingKotoBeastSkinDrab",
            "Ram\\RidingRamSkinGrey",
            "Kodobeast\\Tier2KotoBeastSkinNatural",
            "Kodobeast\\Tier2KotoBeastSkinDrab",
            "Kodobeast\\Tier2KotoBeastSkinWhite",
            "Kodobeast\\RidingKotoBeastSkinGreen",
            "MechaStrider\\MechaStriderSkin_GrayGreen",
            "RidingSilithid\\RidingSilithidTankSkinArmoredGreen",
            "MountedDeathKnight\\MountedDeathKnightGreen_01",
            "DireWolf\\RidingDireWolfSkinLightBlue",
            "DireWolf\\PvPRidingDireWolfSkinDarkBlack",
            "DireWolf\\RidingDireWolfSkinDarkBrown",
            "DireWolf\\RidingDireWolfSkinDarkGrey",
            "DireWolf\\PvPRidingDireWolfSkinFrostWolf",
            "DireWolf\\RidingDireWolfSkinReddishBrown",
            "DireWolf\\Tier2RidingDireWolfSkinBrown",
            "DireWolf\\Tier2RidingDireWolfSkinGray",
            "DireWolf\\Tier2RidingDireWolfSkinLightGray",
            "DireWolf\\RidingDireWolfSkinBrown",
            "MechaStrider\\MechaStriderSkin_WhiteBlue",
            "RidingHorse\\RidingHorseSkinPalamino",
            "RidingHorse\\RidingHorseSkinPinto",
            "MountedDeathKnight\\MountedDeathKnightPurple_01",
            "MechaStrider\\GnomeMechaStriderSkinRed",
            "RidingSilithid\\RidingSilithidTankSkinArmoredRed",
            "UndeadHorse\\UndeadHorseSkinRed",
            "MountedDeathKnight\\MountedDeathKnightRed_01",
            "FrostSabre\\PVPRidingTigerSkinBlack",
            "FrostSabre\\RidingTigerSkinNostripeWhite",
            "FrostSabre\\RidingTigerSkinBlack",
            "FrostSabre\\RidingTigerSkinSnow",
            "FrostSabre\\RidingTigerSkinYellow",
            "FrostSabre\\RidingTigerSkinWhite",
            "FrostSabre\\RidingTigerSkinDark",
            "FrostSabre\\PVPRidingTigerSkinWhite",
            "FrostSabre\\PVPRidingTigerSkinGrey",
            "FrostSabre\\PVPRidingTigerSkinBlackSpotted",
            "FrostSabre\\RidingTigerSkinLavender",
            "Ram\\PvPRidingRamSkinStormPike",
            "RidingRaptor\\PvPRidingRaptorSkinAqua",
            "Ram\\PvPRidingRamSkinBrown",
            "RidingHorse\\PvPRidingHorseSkinBrown",
            "Ram\\PvPRidingRamSkinDarkGrey",
            "MechaStrider\\PvPMechaStriderSkin_GreenBlack",
            "RidingRaptor\\PvPRidingRaptorSkinYellow",
            "RidingRaptor\\PvPRidingRaptorSkinOrange",
            "RidingHorse\\PvPRidingHorseSkinBeige",
            "RidingRaptor\\PvPRidingRaptorSkinCrimson",
            "MechaStrider\\PvPMechaStriderSkin_WhiteBlack",
            "Ram\\PvPRidingRamSkinWhite",
            "RidingHorse\\PvPRidingHorseSkinWhite",
            "MechaStrider\\PvPMechaStriderSkin_YellowBlack",
            "FrostSabre\\PVPRidingTigerSkinOrange",
            "Kodobeast\\RidingKotoBeastSkinTeal",
            "MechaStrider\\GnomeMechaStriderSkin",
            "WarHorse\\WarHorse",
            "RidingRaptor\\PvPRidingRaptorSkinDarkBlack",
            "RidingRaptor\\RidingRaptorSkinEmerald",
            "RidingRaptor\\RidingRaptorSkinIvory",
            "RidingRaptor\\RidingRaptorSkinTomato",
            "RidingRaptor\\RidingRaptorSkinTurquoise",
            "RidingRaptor\\RidingRaptorSkinViolet",
            "MechaStrider\\GnomeMechaStriderSkinBlack",
            "Ram\\RidingRamSkinWhite",
            "RidingHorse\\RidingHorseSkinWhite",
            "RidingSilithid\\RidingSilithidTankSkinArmoredYellow"
        };

        static void Main(string[] args)
        {
            xml = new XmlSerializer(typeof(RECORDS));
            using(StreamReader reader = new StreamReader("item_template.xml"))
            {
                items = (RECORDS)xml.Deserialize(reader);
            }
            GetItems(@"Data\NeckItems.xml", 4, 0, 2, "");
            GetItems(@"Data\FingerItems.xml", 4, 0, 11, "");
            GetItems(@"Data\TrinketItems.xml", 4, 0, 12, "");
            GetItems(@"Data\BackItems.xml", 4, 1, 16, "");
            GetItems(@"Data\ClothChestItems.xml", 4, 1, 5, "Cloth");
            GetItems(@"Data\LeatherChestItems.xml", 4, 2, 5, "Leather");
            GetItems(@"Data\MailChestItems.xml", 4, 3, 5, "Mail");
            GetItems(@"Data\PlateChestItems.xml", 4, 4, 5, "Plate");
            GetItems(@"Data\ClothWristItems.xml", 4, 1, 9, "Cloth");
            GetItems(@"Data\LeatherWristItems.xml", 4, 2, 9, "Leather");
            GetItems(@"Data\MailWristItems.xml", 4, 3, 9, "Mail");
            GetItems(@"Data\PlateWristItems.xml", 4, 4, 9, "Plate");
            GetItems(@"Data\ClothHandsItems.xml", 4, 1, 10, "Cloth");
            GetItems(@"Data\LeatherHandsItems.xml", 4, 2, 10, "Leather");
            GetItems(@"Data\MailHandsItems.xml", 4, 3, 10, "Mail");
            GetItems(@"Data\PlateHandsItems.xml", 4, 4, 10, "Plate");
            GetItems(@"Data\ClothWaistItems.xml", 4, 1, 6, "Cloth");
            GetItems(@"Data\LeatherWaistItems.xml", 4, 2, 6, "Leather");
            GetItems(@"Data\MailWaistItems.xml", 4, 3, 6, "Mail");
            GetItems(@"Data\PlateWaistItems.xml", 4, 4, 6, "Plate");
            GetItems(@"Data\ClothLegsItems.xml", 4, 1, 7, "Cloth");
            GetItems(@"Data\LeatherLegsItems.xml", 4, 2, 7, "Leather");
            GetItems(@"Data\MailLegsItems.xml", 4, 3, 7, "Mail");
            GetItems(@"Data\PlateLegsItems.xml", 4, 4, 7, "Plate");
            GetItems(@"Data\ClothFeetItems.xml", 4, 1, 8, "Cloth");
            GetItems(@"Data\LeatherFeetItems.xml", 4, 2, 8, "Leather");
            GetItems(@"Data\MailFeetItems.xml", 4, 3, 8, "Mail");
            GetItems(@"Data\PlateFeetItems.xml", 4, 4, 8, "Plate");
            GetItems(@"Data\ShirtItems.xml", 4, 0, 4, "");
            GetItems(@"Data\TabardItems.xml", 4, 0, 19, "");
            GetItems(@"Data\ClothHeadItems.xml", 4, 1, 1, "Cloth");
            GetItems(@"Data\LeatherHeadItems.xml", 4, 2, 1, "Leather");
            GetItems(@"Data\MailHeadItems.xml", 4, 3, 1, "Mail");
            GetItems(@"Data\PlateHeadItems.xml", 4, 4, 1, "Plate");
            GetItems(@"Data\ClothShoulderItems.xml", 4, 1, 3, "Cloth");
            GetItems(@"Data\LeatherShoulderItems.xml", 4, 2, 3, "Leather");
            GetItems(@"Data\MailShoulderItems.xml", 4, 3, 3, "Mail");
            GetItems(@"Data\PlateShoulderItems.xml", 4, 4, 3, "Plate");
            GetItems(@"Data\DaggerItems.xml", 2, 15, 13, "Dagger");
            GetItems(@"Data\FistWeaponItems.xml", 2, 13, 13, "Fist Weapon");
            GetItems(@"Data\OneHandedAxeItems.xml", 2, 0, 13, "Axe");
            GetItems(@"Data\OneHandedMaceItems.xml", 2, 4, 13, "Mace");
            GetItems(@"Data\OneHandedSwordItems.xml", 2, 7, 13, "Sword");
            GetItems(@"Data\PolearmItems.xml", 2, 6, 17, "Polearm");
            GetItems(@"Data\StaffItems.xml", 2, 10, 17, "Staff");
            GetItems(@"Data\TwoHandedAxeItems.xml", 2, 1, 17, "Axe");
            GetItems(@"Data\TwoHandedMaceItems.xml", 2, 5, 17, "Mace");
            GetItems(@"Data\TwoHandedSwordItems.xml", 2, 8, 17, "Sword");
            GetItems(@"Data\BowItems.xml", 2, 2, 15, "Bow");
            GetItems(@"Data\CrossbowItems.xml", 2, 18, 26, "Crossbow");
            GetItems(@"Data\GunItems.xml", 2, 3, 26, "Gun");
            GetItems(@"Data\ThrownItems.xml", 2, 16, 25, "Thrown");
            GetItems(@"Data\WandItems.xml", 2, 19, 26, "Wand");
            GetItems(@"Data\ShieldItems.xml", 4, 6, 14, "Shield");
            GetItems(@"Data\HeldInOffHandItems.xml", 4, 0, 23, "");
            GetItems(@"Data\IdolItems.xml", 4, 8, 28, "Idol");
            GetItems(@"Data\LibramItems.xml", 4, 7, 28, "Libram");
            GetItems(@"Data\TotemItems.xml", 4, 9, 28, "Totem");
            GetItems(@"Data\ArrowItems.xml", 6, 2, 24, "Arrow");
            GetItems(@"Data\BulletItems.xml", 6, 3, 24, "Bullet");
            GetReagentItems(@"Data\ReagentItems.xml");
            GetBagItems(@"Data\BagItems.xml");
            GetMountItems(@"Data\MountItems.xml");
        }

        static string FormatProgress(int progress)
        {
            if(progress == 100)
            {
                return " 100%";
            }
            if(progress > 9)
            {
                return "  " + progress + "%";
            }
            return "   " + progress + "%";
        }

        static void GetItems(string file, int c, int s, int t, string type)
        {
            using(StreamWriter writer = new StreamWriter(file))
            {
                int i = 0;
                int count = items.RECORD.Length;
                int progress = i * 100 / count;
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<Items>");
                Console.Write(file + FormatProgress(progress));
                foreach(RECORDSRECORD record in items.RECORD)
                {
                    i++;
                    progress = i * 100 / count;
                    Console.CursorLeft -= 5;
                    Console.Write(FormatProgress(progress));
                    if(IsProperItem(record, c, s, t))
                    {
                        GetItem(record, writer, t, type);
                    }
                    if(t == 5)
                    {
                        if(IsProperItem(record, c, s, 20))
                        {
                            GetItem(record, writer, t, type);
                        }
                    }
                    if(t == 13)
                    {
                        if(IsProperItem(record, c, s, 21))
                        {
                            GetItem(record, writer, 21, type);
                        }
                        if(IsProperItem(record, c, s, 22))
                        {
                            GetItem(record, writer, 22, type);
                        }
                    }
                }
                Console.CursorLeft -= 5;
                Console.WriteLine(" Done");
                writer.WriteLine("</Items>");
            }
        }

        static bool IsProperItem(RECORDSRECORD item, int c, int s, int t)
        {
            if(item.@class == c)
            {
                if(item.subclass == s)
                {
                    if(item.InventoryType == t)
                    {
                        return true;
                    }
                }
                else if(c == 4 && s == 1 && item.subclass == 0 && item.InventoryType == t)
                {
                    return true;
                }
            }
            return false;
        }

        static void GetReagentItems(string file)
        {
            using(StreamWriter writer = new StreamWriter(file))
            {
                int i = 0;
                int count = items.RECORD.Length;
                int progress = i * 100 / count;
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<Items>");
                Console.Write(file + FormatProgress(progress));
                foreach(RECORDSRECORD record in items.RECORD)
                {
                    i++;
                    progress = i * 100 / count;
                    Console.CursorLeft -= 5;
                    Console.Write(FormatProgress(progress));
                    if(reagents.Contains(record.name))
                    {
                        record.AllowableClass = classes[GetReagent(record)];
                        GetItem(record, writer, 0, "Reagent");
                    }
                }
                Console.CursorLeft -= 5;
                Console.WriteLine(" Done");
                writer.WriteLine("</Items>");
            }
        }

        static int GetReagent(RECORDSRECORD item)
        {
            for(int i = 0; i < reagents.Count; i++)
            {
                if(reagents[i] == item.name)
                {
                    return i;
                }
            }
            return -1;
        }

        static void GetItem(RECORDSRECORD item, StreamWriter writer, int slot, string type)
        {
            string[] models = GetModels(item.displayid, slot);
            string[] textures = GetTextures(item.displayid);
            string[] geosets = Enumerable.Repeat("00000000", 10).ToArray();
            if(slot == 1)
            {
                geosets = GetHideGeosets(item.displayid);
            }
            writer.WriteLine("\t<Item>");
            writer.WriteLine("\t\t<ID>" + item.entry + "</ID>");
            writer.WriteLine("\t\t<Name>" + item.name + "</Name>");
            writer.WriteLine("\t\t<Type>" + type + "</Type>");
            writer.WriteLine("\t\t<Slot>" + Slot(slot) + "</Slot>");
            writer.WriteLine("\t\t<Sheath>" + item.sheath + "</Sheath>");
            writer.WriteLine("\t\t<Quality>" + item.Quality + "</Quality>");
            writer.WriteLine("\t\t<Icon>" + GetIcon(item.displayid) + "</Icon>");
            writer.WriteLine("\t\t<Male>");
            writer.WriteLine("\t\t\t<Hair>" + geosets[0] + "</Hair>");
            writer.WriteLine("\t\t\t<Beards>" + geosets[1] + "</Beards>");
            writer.WriteLine("\t\t\t<Piercing>" + geosets[2] + "</Piercing>");
            writer.WriteLine("\t\t\t<Other>" + geosets[3] + "</Other>");
            writer.WriteLine("\t\t\t<Ears>" + geosets[4] + "</Ears>");
            writer.WriteLine("\t\t</Male>");
            writer.WriteLine("\t\t<Female>");
            writer.WriteLine("\t\t\t<Hair>" + geosets[5] + "</Hair>");
            writer.WriteLine("\t\t\t<Beards>" + geosets[6] + "</Beards>");
            writer.WriteLine("\t\t\t<Piercing>" + geosets[7] + "</Piercing>");
            writer.WriteLine("\t\t\t<Other>" + geosets[8] + "</Other>");
            writer.WriteLine("\t\t\t<Ears>" + geosets[9] + "</Ears>");
            writer.WriteLine("\t\t</Female>");
            writer.WriteLine("\t\t<Models>");
            writer.WriteLine("\t\t\t<Left>" + models[0] + "</Left>");
            writer.WriteLine("\t\t\t<Right>" + models[1] + "</Right>");
            writer.WriteLine("\t\t\t<Cape>" + models[2] + "</Cape>");
            writer.WriteLine("\t\t\t<Sleeve>" + models[3] + "</Sleeve>");
            writer.WriteLine("\t\t\t<Wrist>" + models[4] + "</Wrist>");
            writer.WriteLine("\t\t\t<Doublet>" + models[5] + "</Doublet>");
            writer.WriteLine("\t\t\t<Skirt>" + models[6] + "</Skirt>");
            writer.WriteLine("\t\t\t<Robe>" + models[7] + "</Robe>");
            writer.WriteLine("\t\t\t<Knees>" + models[8] + "</Knees>");
            writer.WriteLine("\t\t\t<Boots>" + models[9] + "</Boots>");
            writer.WriteLine("\t\t</Models>");
            writer.WriteLine("\t\t<Textures>");
            writer.WriteLine("\t\t\t<Left>" + textures[0] + "</Left>");
            writer.WriteLine("\t\t\t<Right>" + textures[1] + "</Right>");
            writer.WriteLine("\t\t\t<ArmUpper>" + textures[2] + "</ArmUpper>");
            writer.WriteLine("\t\t\t<ArmLower>" + textures[3] + "</ArmLower>");
            writer.WriteLine("\t\t\t<Hand>" + textures[4] + "</Hand>");
            writer.WriteLine("\t\t\t<TorsoUpper>" + textures[5] + "</TorsoUpper>");
            writer.WriteLine("\t\t\t<TorsoLower>" + textures[6] + "</TorsoLower>");
            writer.WriteLine("\t\t\t<LegUpper>" + textures[7] + "</LegUpper>");
            writer.WriteLine("\t\t\t<LegLower>" + textures[8] + "</LegLower>");
            writer.WriteLine("\t\t\t<Foot>" + textures[9] + "</Foot>");
            writer.WriteLine("\t\t</Textures>");
            writer.WriteLine("\t\t<AllowableClass>" + item.AllowableClass + "</AllowableClass>");
            writer.WriteLine("\t\t<AllowableRace>" + item.AllowableRace + "</AllowableRace>");
            writer.WriteLine("\t\t<MaxCount>" + item.maxcount + "</MaxCount>");
            writer.WriteLine("\t</Item>");
        }

        static string Slot(int slot)
        {
            string name = "";
            switch(slot)
            {
                case 1:
                    name = "Head";
                    break;
                case 2:
                    name = "Neck";
                    break;
                case 3:
                    name = "Shoulder";
                    break;
                case 4:
                    name = "Shirt";
                    break;
                case 5:
                case 20:
                    name = "Chest";
                    break;
                case 6:
                    name = "Waist";
                    break;
                case 7:
                    name = "Legs";
                    break;
                case 8:
                    name = "Feet";
                    break;
                case 9:
                    name = "Wrist";
                    break;
                case 10:
                    name = "Hands";
                    break;
                case 11:
                    name = "Finger";
                    break;
                case 12:
                    name = "Trinket";
                    break;
                case 13:
                    name = "One-hand";
                    break;
                case 14:
                case 22:
                    name = "Off Hand";
                    break;
                case 15:
                case 26:
                    name = "Ranged";
                    break;
                case 16:
                    name = "Back";
                    break;
                case 17:
                    name = "Two-hand";
                    break;
                case 19:
                    name = "Tabard";
                    break;
                case 21:
                    name = "Main Hand";
                    break;
                case 23:
                    name = "Held in Off-Hand";
                    break;
                case 24:
                    name = "Projectile";
                    break;
                case 25:
                    name = "Thrown";
                    break;
                case 27:
                    name = "Quiver";
                    break;
                case 28:
                    name = "Relic";
                    break;
            }
            return name;
        }

        static void GetBagItems(string file)
        {
            using(StreamWriter writer = new StreamWriter(file))
            {
                int i = 0;
                int count = items.RECORD.Length;
                int progress = i * 100 / count;
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<Items>");
                Console.Write(file + FormatProgress(progress));
                foreach(RECORDSRECORD record in items.RECORD)
                {
                    i++;
                    progress = i * 100 / count;
                    Console.CursorLeft -= 5;
                    Console.Write(FormatProgress(progress));
                    if(IsBagItem(record))
                    {;
                        GetBagItem(record, writer);
                    }
                }
                Console.CursorLeft -= 5;
                Console.WriteLine(" Done");
                writer.WriteLine("</Items>");
            }
        }

        static bool IsBagItem(RECORDSRECORD item)
        {
            if(item.@class == 1 && (item.subclass == 0 || item.subclass == 1))
            {
                return true;
            }
            if(item.@class == 11 && (item.subclass == 2 || item.subclass == 3))
            {
                return true;
            }
            return false;
        }

        static void GetBagItem(RECORDSRECORD item, StreamWriter writer)
        {
            writer.WriteLine("\t<Item>");
            writer.WriteLine("\t\t<ID>" + item.entry + "</ID>");
            writer.WriteLine("\t\t<Name>" + item.name + "</Name>");
            writer.WriteLine("\t\t<Type>" + Type(item.@class, item.subclass) + "</Type>");
            writer.WriteLine("\t\t<Slot>" + item.ContainerSlots + "</Slot>");
            writer.WriteLine("\t\t<Sheath>" + item.sheath + "</Sheath>");
            writer.WriteLine("\t\t<Quality>" + item.Quality + "</Quality>");
            writer.WriteLine("\t\t<Icon>" + GetIcon(item.displayid) + "</Icon>");
            writer.WriteLine("\t\t<Male>");
            writer.WriteLine("\t\t\t<Hair></Hair>");
            writer.WriteLine("\t\t\t<Beards></Beards>");
            writer.WriteLine("\t\t\t<Piercing></Piercing>");
            writer.WriteLine("\t\t\t<Other></Other>");
            writer.WriteLine("\t\t\t<Ears></Ears>");
            writer.WriteLine("\t\t</Male>");
            writer.WriteLine("\t\t<Female>");
            writer.WriteLine("\t\t\t<Hair></Hair>");
            writer.WriteLine("\t\t\t<Beards></Beards>");
            writer.WriteLine("\t\t\t<Piercing></Piercing>");
            writer.WriteLine("\t\t\t<Other></Other>");
            writer.WriteLine("\t\t\t<Ears></Ears>");
            writer.WriteLine("\t\t</Female>");
            writer.WriteLine("\t\t<Models>");
            writer.WriteLine("\t\t\t<Left></Left>");
            writer.WriteLine("\t\t\t<Right></Right>");
            writer.WriteLine("\t\t\t<Cape></Cape>");
            writer.WriteLine("\t\t\t<Sleeve></Sleeve>");
            writer.WriteLine("\t\t\t<Wrist></Wrist>");
            writer.WriteLine("\t\t\t<Doublet></Doublet>");
            writer.WriteLine("\t\t\t<Skirt></Skirt>");
            writer.WriteLine("\t\t\t<Robe></Robe>");
            writer.WriteLine("\t\t\t<Knees></Knees>");
            writer.WriteLine("\t\t\t<Boots></Boots>");
            writer.WriteLine("\t\t</Models>");
            writer.WriteLine("\t\t<Textures>");
            writer.WriteLine("\t\t\t<Left></Left>");
            writer.WriteLine("\t\t\t<Right></Right>");
            writer.WriteLine("\t\t\t<ArmUpper></ArmUpper>");
            writer.WriteLine("\t\t\t<ArmLower></ArmLower>");
            writer.WriteLine("\t\t\t<Hand></Hand>");
            writer.WriteLine("\t\t\t<TorsoUpper></TorsoUpper>");
            writer.WriteLine("\t\t\t<TorsoLower></TorsoLower>");
            writer.WriteLine("\t\t\t<LegUpper></LegUpper>");
            writer.WriteLine("\t\t\t<LegLower></LegLower>");
            writer.WriteLine("\t\t\t<Foot></Foot>");
            writer.WriteLine("\t\t</Textures>");
            writer.WriteLine("\t\t<AllowableClass>" + item.AllowableClass + "</AllowableClass>");
            writer.WriteLine("\t\t<AllowableRace>" + item.AllowableRace + "</AllowableRace>");
            writer.WriteLine("\t\t<MaxCount>" + item.maxcount + "</MaxCount>");
            writer.WriteLine("\t</Item>");
        }

        static string Type(int c, int s)
        {
            string type = "";
            switch(c)
            {
                case 1:
                    type = s == 0 ? "Bag" : "Soul Bag";
                    break;
                case 11:
                    type = s == 2 ? "Quiver" : "Ammo Pouch";
                    break;
            }
            return type;
        }

        static void GetMountItems(string file)
        {
            using(StreamWriter writer = new StreamWriter(file))
            {
                int i = 0;
                int count = items.RECORD.Length;
                int progress = i * 100 / count;
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<Items>");
                Console.Write(file + FormatProgress(progress));
                foreach(RECORDSRECORD record in items.RECORD)
                {
                    i++;
                    progress = i * 100 / count;
                    Console.CursorLeft -= 5;
                    Console.Write(FormatProgress(progress));
                    if(mounts.Contains(record.name))
                    {
                        GetMountItem(record, writer, mounts.IndexOf(record.name));
                    }
                }
                Console.CursorLeft -= 5;
                Console.WriteLine(" Done");
                writer.WriteLine("</Items>");
            }
        }

        static void GetMountItem(RECORDSRECORD item, StreamWriter writer, int index)
        {
            writer.WriteLine("\t<Item>");
            writer.WriteLine("\t\t<ID>" + item.entry + "</ID>");
            writer.WriteLine("\t\t<Name>" + item.name + "</Name>");
            writer.WriteLine("\t\t<Type>Mount</Type>");
            writer.WriteLine("\t\t<Slot></Slot>");
            writer.WriteLine("\t\t<Sheath>" + item.sheath + "</Sheath>");
            writer.WriteLine("\t\t<Quality>" + item.Quality + "</Quality>");
            writer.WriteLine("\t\t<Icon>" + GetIcon(item.displayid) + "</Icon>");
            writer.WriteLine("\t\t<Male>");
            writer.WriteLine("\t\t\t<Hair></Hair>");
            writer.WriteLine("\t\t\t<Beards></Beards>");
            writer.WriteLine("\t\t\t<Piercing></Piercing>");
            writer.WriteLine("\t\t\t<Other></Other>");
            writer.WriteLine("\t\t\t<Ears></Ears>");
            writer.WriteLine("\t\t</Male>");
            writer.WriteLine("\t\t<Female>");
            writer.WriteLine("\t\t\t<Hair></Hair>");
            writer.WriteLine("\t\t\t<Beards></Beards>");
            writer.WriteLine("\t\t\t<Piercing></Piercing>");
            writer.WriteLine("\t\t\t<Other></Other>");
            writer.WriteLine("\t\t\t<Ears></Ears>");
            writer.WriteLine("\t\t</Female>");
            writer.WriteLine("\t\t<Models>");
            writer.WriteLine("\t\t\t<Left>" + models[index] + "</Left>");
            writer.WriteLine("\t\t\t<Right></Right>");
            writer.WriteLine("\t\t\t<Cape></Cape>");
            writer.WriteLine("\t\t\t<Sleeve></Sleeve>");
            writer.WriteLine("\t\t\t<Wrist></Wrist>");
            writer.WriteLine("\t\t\t<Doublet></Doublet>");
            writer.WriteLine("\t\t\t<Skirt></Skirt>");
            writer.WriteLine("\t\t\t<Robe></Robe>");
            writer.WriteLine("\t\t\t<Knees></Knees>");
            writer.WriteLine("\t\t\t<Boots></Boots>");
            writer.WriteLine("\t\t</Models>");
            writer.WriteLine("\t\t<Textures>");
            writer.WriteLine("\t\t\t<Left>" + textures[index] + "</Left>");
            writer.WriteLine("\t\t\t<Right></Right>");
            writer.WriteLine("\t\t\t<ArmUpper></ArmUpper>");
            writer.WriteLine("\t\t\t<ArmLower></ArmLower>");
            writer.WriteLine("\t\t\t<Hand></Hand>");
            writer.WriteLine("\t\t\t<TorsoUpper></TorsoUpper>");
            writer.WriteLine("\t\t\t<TorsoLower></TorsoLower>");
            writer.WriteLine("\t\t\t<LegUpper></LegUpper>");
            writer.WriteLine("\t\t\t<LegLower></LegLower>");
            writer.WriteLine("\t\t\t<Foot></Foot>");
            writer.WriteLine("\t\t</Textures>");
            writer.WriteLine("\t\t<AllowableClass>" + item.AllowableClass + "</AllowableClass>");
            writer.WriteLine("\t\t<AllowableRace>" + item.AllowableRace + "</AllowableRace>");
            writer.WriteLine("\t\t<MaxCount>" + item.maxcount + "</MaxCount>");
            writer.WriteLine("\t</Item>");
        }

        static string GetIcon(int displayid)
        {
            int records;
            int fields;
            int id;
            int icon = 0;
            string name;
            using(BinaryReader reader = new BinaryReader(File.Open("ItemDisplayInfo.dbc", FileMode.Open)))
            {
                Skip(1, reader);
                records = reader.ReadInt32();
                fields = reader.ReadInt32();
                Skip(2, reader);
                for(int i = 0; i < records; i++)
                {
                    id = reader.ReadInt32();
                    if(id == displayid)
                    {
                        Skip(4, reader);
                        icon = reader.ReadInt32();
                        Skip(fields - 6, reader);
                        continue;
                    }
                    Skip(fields - 1, reader);
                }
                name = FindString(icon, reader);
            }
            return name;
        }

        static string[] GetModels(int displayid, int slot)
        {
            int records;
            int fields;
            int id;
            int left = 0;
            int right = 0;
            int geoset1 = -1;
            int geoset2 = -1;
            int geoset3 = -1;
            string[] models = Enumerable.Repeat("", 10).ToArray();
            using(BinaryReader reader = new BinaryReader(File.Open("ItemDisplayInfo.dbc", FileMode.Open)))
            {
                Skip(1, reader);
                records = reader.ReadInt32();
                fields = reader.ReadInt32();
                Skip(2, reader);
                for(int i = 0; i < records; i++)
                {
                    id = reader.ReadInt32();
                    if(id == displayid)
                    {
                        left = reader.ReadInt32();
                        right = reader.ReadInt32();
                        Skip(3, reader);
                        geoset1 = reader.ReadInt32();
                        geoset2 = reader.ReadInt32();
                        geoset3 = reader.ReadInt32();
                        Skip(fields - 9, reader);
                        continue;
                    }
                    Skip(fields - 1, reader);
                }
                models[0] = FindString(left, reader);
                models[1] = FindString(right, reader);
            }
            switch(slot)
            {
                case 4:
                    models[3] = SleeveGeoset(geoset1);
                    models[5] = DoubletGeoset(geoset2);
                    break;
                case 5:
                case 20:
                    models[3] = SleeveGeoset(geoset1);
                    models[5] = DoubletGeoset(geoset2);
                    models[7] = RobeGeoset(geoset3);
                    break;
                case 7:
                    models[6] = SkirtGeoset(geoset1);
                    models[8] = KneesGeoset(geoset2);
                    models[7] = RobeGeoset(geoset3);
                    break;
                case 8:
                    models[9] = BootsGeoset(geoset1);
                    break;
                case 10:
                    models[4] = WristGeoset(geoset1);
                    break;
                case 16:
                    models[2] = CapeGeoset(geoset1);
                    break;
            }
            return models;
        }

        static string CapeGeoset(int geoset)
        {
            string cape = "";
            switch(geoset)
            {
                case 1:
                    cape = "Cape5";
                    break;
                case 2:
                    cape = "Cape4";
                    break;
                case 3:
                    cape = "Cape3";
                    break;
                case 4:
                    cape = "Cape2";
                    break;
                case 5:
                    cape = "Cape1";
                    break;
            }
            return cape;
        }

        static string SleeveGeoset(int geoset)
        {
            string sleeve = "";
            switch(geoset)
            {
                case 1:
                    sleeve = "Sleeve1";
                    break;
                case 2:
                    sleeve = "Sleeve2";
                    break;
            }
            return sleeve;
        }

        static string WristGeoset(int geoset)
        {
            string wrist = "";
            switch(geoset)
            {
                case 0:
                    wrist = "Wrist1";
                    break;
                case 1:
                    wrist = "Wrist2";
                    break;
                case 2:
                    wrist = "Wrist3";
                    break;
                case 3:
                    wrist = "Wrist5";
                    break;
            }
            return wrist;
        }

        static string DoubletGeoset(int geoset)
        {
            string doublet = "";
            switch(geoset)
            {
                case 1:
                    doublet = "Doublet1";
                    break;
            }
            return doublet;
        }

        static string SkirtGeoset(int geoset)
        {
            string skirt = "";
            switch(geoset)
            {
                case 1:
                    skirt = "Skirt1";
                    break;
            }
            return skirt;
        }

        static string RobeGeoset(int geoset)
        {
            string robe = "";
            switch(geoset)
            {
                case 1:
                    robe = "Robe1";
                    break;
            }
            return robe;
        }

        static string KneesGeoset(int geoset)
        {
            string knees = "";
            switch(geoset)
            {
                case 1:
                    knees = "Knees2";
                    break;
                case 2:
                    knees = "Knees1";
                    break;
            }
            return knees;
        }

        static string BootsGeoset(int geoset)
        {
            string boots = "";
            switch(geoset)
            {
                case 0:
                    boots = "Boots1";
                    break;
                case 1:
                    boots = "Boots2";
                    break;
                case 2:
                    boots = "Boots3";
                    break;
                case 3:
                    boots = "Boots5";
                    break;
            }
            return boots;
        }

        static string[] GetTextures(int displayid)
        {
            int records;
            int fields;
            int id;
            int left = 0;
            int right = 0;
            int armUpper = 0;
            int armLower = 0;
            int hand = 0;
            int torsoUpper = 0;
            int torsoLower = 0;
            int legUpper = 0;
            int legLower = 0;
            int foot = 0;
            string[] textures = Enumerable.Repeat("", 10).ToArray();
            using(BinaryReader reader = new BinaryReader(File.Open("ItemDisplayInfo.dbc", FileMode.Open)))
            {
                Skip(1, reader);
                records = reader.ReadInt32();
                fields = reader.ReadInt32();
                Skip(2, reader);
                for(int i = 0; i < records; i++)
                {
                    id = reader.ReadInt32();
                    if(id == displayid)
                    {
                        Skip(2, reader);
                        left = reader.ReadInt32();
                        right = reader.ReadInt32();
                        Skip(9, reader);
                        armUpper = reader.ReadInt32();
                        armLower = reader.ReadInt32();
                        hand = reader.ReadInt32();
                        torsoUpper = reader.ReadInt32();
                        torsoLower = reader.ReadInt32();
                        legUpper = reader.ReadInt32();
                        legLower = reader.ReadInt32();
                        foot = reader.ReadInt32();
                        Skip(fields - 22, reader);
                        continue;
                    }
                    Skip(fields - 1, reader);
                }
                textures[0] = FindString(left, reader).Replace("_U", "");
                textures[1] = FindString(right, reader).Replace("_U", "");
                textures[2] = FindString(armUpper, reader).Replace("_U", "");
                textures[3] = FindString(armLower, reader).Replace("_U", "");
                textures[4] = FindString(hand, reader).Replace("_U", "");
                textures[5] = FindString(torsoUpper, reader).Replace("_U", "");
                textures[6] = FindString(torsoLower, reader).Replace("_U", "");
                textures[7] = FindString(legUpper, reader).Replace("_U", "");
                textures[8] = FindString(legLower, reader).Replace("_U", "");
                textures[9] = FindString(foot, reader).Replace("_U", "");
            }
            return textures;
        }

        static string[] GetHideGeosets(int displayid)
        {
            int records;
            int fields;
            int id;
            int male = -1;
            int female = -1;
            string[] geosets = new string[10];
            using(BinaryReader reader = new BinaryReader(File.Open("ItemDisplayInfo.dbc", FileMode.Open)))
            {
                Skip(1, reader);
                records = reader.ReadInt32();
                fields = reader.ReadInt32();
                Skip(2, reader);
                for(int i = 0; i < records; i++)
                {
                    id = reader.ReadInt32();
                    if(id == displayid)
                    {
                        Skip(11, reader);
                        male = reader.ReadInt32();
                        female = reader.ReadInt32();
                        break;
                    }
                    Skip(fields - 1, reader);
                }
            }
            string[] m = HelmetGeoset(male);
            string[] f = HelmetGeoset(female);
            for(int i = 0; i < 5; i++)
            {
                geosets[i] = m[i];
                geosets[i + 5] = f[i];
            }
            return geosets;
        }

        static string[] HelmetGeoset(int index)
        {
            int records;
            int fields;
            int id;
            int[] geosets = Enumerable.Repeat(0, 5).ToArray();
            using(BinaryReader reader = new BinaryReader(File.Open("HelmetGeosetVisData.dbc", FileMode.Open)))
            {
                Skip(1, reader);
                records = reader.ReadInt32();
                fields = reader.ReadInt32();
                Skip(2, reader);
                for(int i = 0; i < records; i++)
                {
                    id = reader.ReadInt32();
                    if(id == index)
                    {
                        for(int j = 0; j < 5; j++)
                        {
                            geosets[j] = reader.ReadInt32();
                        }
                    }
                    Skip(fields - 1, reader);
                }
            }
            return Decode(geosets);
        }

        static string[] Decode(int[] geosets)
        {
            string[] decoded = new string[5];
            char[] bits;
            for(int i = 0; i < 5; i++)
            {
                geosets[i] >>= 1;
                bits = Convert.ToString(geosets[i], 2).PadLeft(32, '0').Substring(24).ToCharArray();
                Array.Reverse(bits);
                decoded[i] = new string(bits);
            }
            return decoded;
        }

        static void Skip(int count, BinaryReader reader)
        {
            reader.BaseStream.Position += count * 4;
        }

        static string FindString(int offset, BinaryReader reader)
        {
            string text = "";
            long position = reader.BaseStream.Position;
            reader.BaseStream.Position += offset;
            text += reader.ReadChar();
            while(text.Last() != '\0')
            {
                text += reader.ReadChar();
            }
            reader.BaseStream.Position = position;
            return text.Substring(0, text.Length - 1);
        }
    }
}
