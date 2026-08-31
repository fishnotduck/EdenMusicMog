using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EdenMusicMog
{
    public class VictoryThemeGlobalNPC : GlobalNPC
    {
        private static readonly Dictionary<int, string> VanillaBossKeys = new()
        {
            [NPCID.KingSlime] = "KingSlime",
            [NPCID.EyeofCthulhu] = "EyeOfCthulhu",
            [NPCID.EaterofWorldsHead] = "EaterOfWorlds",
            [NPCID.BrainofCthulhu] = "BrainOfCthulhu",
            [NPCID.QueenBee] = "QueenBee",
            [NPCID.SkeletronHead] = "Skeletron",
            [NPCID.Deerclops] = "Deerclops",
            [NPCID.WallofFlesh] = "WallOfFlesh",
            [NPCID.BloodNautilus] = "Dreadnautilus",
            [NPCID.QueenSlimeBoss] = "QueenSlime",
            [NPCID.SkeletronPrime] = "SkeletronPrime",
            [NPCID.Retinazer] = "Twins",
            [NPCID.Spazmatism] = "Twins",
            [NPCID.TheDestroyer] = "Destroyer",
            [NPCID.Plantera] = "Plantera",
            [NPCID.Golem] = "Golem",
            [NPCID.DD2Betsy] = "OldOnesArmy",
            [NPCID.DukeFishron] = "DukeFishron",
            [NPCID.HallowBoss] = "EmpressOfLight",
            [NPCID.CultistBoss] = "LunaticCultist",
            [NPCID.MoonLordCore] = "MoonLord",
        };

        private static Dictionary<int, string> soulsBossKeys;
        private static bool soulsBuilt;

        private static void BuildSoulsKeysIfNeeded()
        {
            if (soulsBuilt) return;
            soulsBuilt = true;
            soulsBossKeys = new Dictionary<int, string>();

            if (MusicUtils.Souls == null)
                return;

            void TryAdd(string npcName, string key)
            {
                try
                {
                    if (MusicUtils.Souls.TryFind<ModNPC>(npcName, out var modNpc))
                        soulsBossKeys[modNpc.Type] = key;
                }
                catch { /* name not present in this souls version, skip */ }
            }

            TryAdd("DeviBoss", "Deviantt");
            TryAdd("BanishedBaron", "BanishedBaron");
            TryAdd("CursedCoffin", "CursedCoffin");
            TryAdd("TrojanSquirrel", "TrojanSquirrel");
            TryAdd("AbomBoss", "Abominationn");
            TryAdd("MutantBoss", "Mutant");
            TryAdd("CosmosChampion", "Eridanus");
            TryAdd("Lifelight", "Lifelight");
            TryAdd("LifeChallenger", "Lifelight");

            TryAdd("TimberChampion", "TimberChampion");
            TryAdd("TimberChampionHead", "TimberChampion");
            TryAdd("TerraChampion", "TerraChampion");
            TryAdd("NatureChampion", "NatureChampion");
            TryAdd("LifeChampion", "LifeChampion");
            TryAdd("ShadowChampion", "ShadowChampion");
            TryAdd("EarthChampion", "EarthChampion");
            TryAdd("SpiritChampion", "SpiritChampion");
            TryAdd("WillChampion", "WillChampion");
        }

        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.MoonLordCore)
                return;

            if (VanillaBossKeys.TryGetValue(npc.type, out string vanillaKey))
            {
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    bool retiGone = MusicUtils.FindClosestBoss(NPCID.Retinazer) == null;
                    bool spazGone = MusicUtils.FindClosestBoss(NPCID.Spazmatism) == null;
                    if (!(retiGone && spazGone))
                        return;
                }

                ButtSystem.TriggerIfFirstTime(vanillaKey);
                return;
            }

            BuildSoulsKeysIfNeeded();
            if (soulsBossKeys != null && soulsBossKeys.TryGetValue(npc.type, out string soulsKey))
            {
                ButtSystem.TriggerIfFirstTime(soulsKey);
            }
        }
    }
}