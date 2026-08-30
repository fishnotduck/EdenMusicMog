using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace EdenMusicMog
{
    public class MusicSystem : ModSystem
    {
        public static int GetMusic(string name) => MusicLoader.GetMusicSlot(EdenMusicMog.Instance, $"Music/{name}");

        private const BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public override void Load()
        {
            MonoModHooks.Add(Update, Update_Detour);
        }

        public static int OverrideMusicID(int i)
        {

            if (Main.gameMenu)
                return i;

            Player player = Main.LocalPlayer;

            if (NPC.LunarApocalypseIsUp)
            {
                int old2 = i;
                i = GetMusic("lookmaiflynow");
                TerryMusicSystem.nowPlayingString = "Hylics 2 - Look Ma, I Fly Now!";
                if (i >= Main.musicFade.Length)
                    return old2;
                return i;
            }

            int old = i;
            var config = MusicConfig.Instance;
            switch (i)
            {
                case MusicID.TownDay:
                    i = GetMusic("tosya");
                    TerryMusicSystem.nowPlayingString = "Z.A.T.O. - Tosya";
                    break;

                case MusicID.TownNight:
                    i = GetMusic("mesmermaladyandmirphie");
                    TerryMusicSystem.nowPlayingString = "Mesmalie - Mesmer, Malady & Mirphie";
                    break;

                case MusicID.OverworldDay:
                    i = GetMusic("thewoodsbehindherhouse");
                    TerryMusicSystem.nowPlayingString = "Mesmalie - The Woods behind her house";
                    break;

                case MusicID.Night:
                    i = GetMusic("thegloominsidethewoodsbehindherhouse");
                    TerryMusicSystem.nowPlayingString = "Mesmalie - The Gloom inside the Woods behind her House";
                    break;

                case MusicID.WindyDay:
                    if (player.townNPCs > 2f)
                        goto case MusicID.TownDay;
                    if (player.ZoneHallow)
                        goto case MusicID.TheHallow;
                    else 
                        goto case MusicID.OverworldDay;
                    break;

                case MusicID.Underground:
                case MusicID.AltUnderground:
                    if (player.ZoneRockLayerHeight)
                    {
                        i = GetMusic("adastra");
                        TerryMusicSystem.nowPlayingString = "Void Stranger - ...ad astra";
                        break;
                    }
                    else
                    {
                        i = GetMusic("voidsymphony");
                        TerryMusicSystem.nowPlayingString = "Void Stranger - Void Symphony";
                        break;
                    }

                case MusicID.Desert:
                    i = GetMusic("lookingforthebossreprise");
                    TerryMusicSystem.nowPlayingString = "ENA: Dream BBQ - Looking for the Boss (Reprise)";
                    break;

                case MusicID.UndergroundDesert:
                    i = GetMusic("mainmenutheme");
                    TerryMusicSystem.nowPlayingString = "ENA: Dream BBQ - Main Menu Theme";
                    break;

                case MusicID.Snow:
                    if (Main.raining)
                    {
                        i = GetMusic("mnsttr");
                        TerryMusicSystem.nowPlayingString = "nonomino - MnSttR";
                        break;
                    }
                    else
                    {
                        i = GetMusic("moonsetter");
                        TerryMusicSystem.nowPlayingString = "Homestuck - Moonsetter";
                        break;
                    }

                case MusicID.Ice:
                    i = GetMusic("moonslammer");
                    TerryMusicSystem.nowPlayingString = "Spoofymaru - Moonslammer";
                    break;

                case MusicID.Jungle:
                case MusicID.JungleNight:
                    i = GetMusic("crystalguitarthemums");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Crystalguitarthemums";
                    break;

                case MusicID.JungleUnderground:
                    i = GetMusic("crystalanthemums");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Crystalanthemums";
                    break;

                case MusicID.TheHallow:
                case MusicID.UndergroundHallow:
                    i = GetMusic("jokziozo");
                    TerryMusicSystem.nowPlayingString = "corru.observer - JOKZI OZO";
                    break;

                case MusicID.Corruption:
                    i = GetMusic("safesurface");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Safe Surface";
                    break;

                case MusicID.UndergroundCorruption:
                    i = GetMusic("ambition");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Ambition";
                    break;

                case MusicID.Crimson:
                    i = GetMusic("outsideinterference");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Outside Interference";
                    break;

                case MusicID.UndergroundCrimson:
                    i = GetMusic("innerworld");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Inner World";
                    break;

                case MusicID.Ocean:
                case MusicID.OceanNight:
                    i = GetMusic("thehub");
                    TerryMusicSystem.nowPlayingString = "corru.observer - The Hub";
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    i = GetMusic("breakingfree");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Breaking Free";
                    break;

                case MusicID.Hell:
                    i = GetMusic("crematorium");
                    TerryMusicSystem.nowPlayingString = "White Knuckle - Crematorium";
                    break;

                case MusicID.Mushrooms:
                    i = GetMusic("ratcastle");
                    TerryMusicSystem.nowPlayingString = "glass beach - (rat castle)";
                    break;

                case MusicID.Dungeon:
                    i = GetMusic("unreasonablebehaviour");
                    TerryMusicSystem.nowPlayingString = "OFF - Unreasonable Behaviour";
                    break;

                case MusicID.Temple:
                    i = GetMusic("crystamanthequins");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Crystamanthequins";
                    break;

                case MusicID.Rain:
                case MusicID.MorningRain:
                    i = GetMusic("rainanddust");
                    TerryMusicSystem.nowPlayingString = "Star Fetchers - Rain and Dust";
                    break;

                case MusicID.Monsoon:
                    i = GetMusic("raindrops");
                    TerryMusicSystem.nowPlayingString = "Set Yourself on Fire - Raindrops";
                    break;

                case MusicID.Graveyard:
                    i = GetMusic("mistofadifferentdimension");
                    TerryMusicSystem.nowPlayingString = "Serial Experiments Lain - Mist of a Different Dimension";
                    break;

                case MusicID.Eerie:
                    if (player.ZoneMeteor)
                    {
                        i = GetMusic("ruins");
                        TerryMusicSystem.nowPlayingString = "Hylics - Ruins";
                        break;
                    }
                    else
                    {
                        i = GetMusic("peppersteak");
                        TerryMusicSystem.nowPlayingString = "OFF - Pepper Steak";
                        break;
                    }

                case MusicID.Sandstorm:
                    i = GetMusic("pulsebeat");
                    TerryMusicSystem.nowPlayingString = "Serial Experiments Lain - Pulse Beat";
                    break;

                case MusicID.Shimmer:
                    i = GetMusic("tightrope");
                    TerryMusicSystem.nowPlayingString = "Z.A.T.O. - Tightrope";
                    break;

                case MusicID.GoblinInvasion:
                    i = GetMusic("skaianskirmish");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Skaian Skirmish";
                    break;

                case MusicID.SlimeRain:
                    i = GetMusic("primarycolours");
                    TerryMusicSystem.nowPlayingString = "Brutal Orchestra - Primary Colours";
                    break;

                case MusicID.Boss1:
                    i = GetMusic("wriggleandwrithe");
                    TerryMusicSystem.nowPlayingString = "Brutal Orchestra - Wriggle and Writhe";
                    break;

                case MusicID.Boss2:
                    i = GetMusic("ruinousintnt");
                    TerryMusicSystem.nowPlayingString = "corru.observer - RUINOUS INTNT";
                    break;

                case MusicID.Boss3:
                    if (Main.invasionType == InvasionID.SnowLegion)
                        goto case MusicID.FrostMoon;
                    i = GetMusic("impact");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Impact";
                    break;

                case MusicID.Boss4:
                    i = GetMusic("incubusrising");
                    TerryMusicSystem.nowPlayingString = "Brutal Orchestra - Incubus Rising";
                    break;

                case MusicID.Boss5:
                    i = GetMusic("sweetparalysis");
                    TerryMusicSystem.nowPlayingString = "OMORI - Sweet Paralysis";
                    break;

                case MusicID.Deerclops:
                    i = GetMusic("threestormsabovethemountainofsteam");
                    TerryMusicSystem.nowPlayingString = "Brutal Orchestra - Three Storms Above the Mountain of Steam";
                    break;

                case MusicID.QueenSlime:
                    i = GetMusic("bigbadbooty");
                    TerryMusicSystem.nowPlayingString = "Outcore - Big Bad Booty";
                    break;

                case MusicID.Plantera:
                    i = GetMusic("feistyflowers");
                    TerryMusicSystem.nowPlayingString = "Everhood - Feisty Flowers";
                    break;

                case MusicID.EmpressOfLight:
                    i = GetMusic("teeheetime");
                    TerryMusicSystem.nowPlayingString = "OMORI - Tee-hee Time";
                    break;

                case MusicID.DukeFishron:
                    i = GetMusic("skybluedays");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - S** **** ****";
                    break;

                case MusicID.LunarBoss:
                    i = GetMusic("fancymeatcomputer");
                    TerryMusicSystem.nowPlayingString = "Hylics 2 - Fancy Meat Computer";
                    break;

                case MusicID.PirateInvasion:
                    i = GetMusic("whatifwe");
                    TerryMusicSystem.nowPlayingString = "Star Fetchers - What if we";
                    break;

                case MusicID.Eclipse:
                    i = GetMusic("afinalduel");
                    TerryMusicSystem.nowPlayingString = "Inscryption - A Final Duel";
                    break;

                case MusicID.PumpkinMoon:
                    i = GetMusic("akubattletheme");
                    TerryMusicSystem.nowPlayingString = "The Battle Cats - Aku Battle Theme";
                    break;

                case MusicID.FrostMoon:
                    i = GetMusic("merrycd");
                    TerryMusicSystem.nowPlayingString = "OMORI - MERRY CD";
                    break;

                case MusicID.OldOnesArmy:
                    i = GetMusic("battletheme1");
                    TerryMusicSystem.nowPlayingString = "The Battle Cats - Battle Theme #1";
                    break;

                case MusicID.MartianMadness:
                    i = GetMusic("intothefuturetheme1");
                    TerryMusicSystem.nowPlayingString = "The Battle Cats - Into the Future Theme #1";
                    break;

                case MusicID.Title:
                case MusicID.MenuMusic:
                case MusicID.Credits:
                    i = GetMusic("systemendless");
                    TerryMusicSystem.nowPlayingString = "ZeroRanger - System Endless";
                    break;
            }

            if (EdenMusicMog.Instance.moddedMusicDict.ContainsKey(i))
            {
                var tuple = EdenMusicMog.Instance.moddedMusicDict[i];
                //Main.NewText($"get! {i} {tuple.ToString()}");
                i = GetMusic(tuple.Item1);
                TerryMusicSystem.nowPlayingString = tuple.Item2;
            }
            // Special-case combined Champions music slot
            // Detect active champion NPCs directly
            // and map to the matching internal music slot.
            if (MusicUtils.Souls != null && EdenMusicMog.Instance.ChampionsSlot != 0 && i == EdenMusicMog.Instance.ChampionsSlot)
            {
                i = GetMusic("workingmanstheme");
                if (MusicUtils.FindClosestSoulsBoss("TimberChampion") != null || MusicUtils.FindClosestSoulsBoss("TimberChampionHead") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("TerraChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("NatureChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("LifeChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("ShadowChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("EarthChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("SpiritChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("WillChampion") != null)
                {
                    i = GetMusic("workingmanstheme");
                }
                else if (MusicUtils.FindClosestSoulsBoss("CosmosChampion") != null)
                {
                    i = GetMusic("despair");
                }
            }
            if (i >= Main.musicFade.Length)
                return old;
            return i;
        }

        private static readonly MethodInfo Update = typeof(LegacyAudioSystem).GetMethod("Update", UniversalBindingFlags);
        public delegate void Orig_Update(LegacyAudioSystem self);
        internal static void Update_Detour(Orig_Update orig, LegacyAudioSystem self)
        {
            Main.newMusic = OverrideMusicID(Main.newMusic);
            orig(self);
        }
    }
}
