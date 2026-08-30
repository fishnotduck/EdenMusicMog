using System.ComponentModel;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;

namespace EdenMusicMog
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static MusicConfig Instance => ModContent.GetInstance<MusicConfig>();

        [DefaultValue(NowPlayingID.Notification)]
        [DrawTicks]
        public NowPlayingID NowPlayingEnum;

        [DefaultValue(true)]
        public bool ImmersiveBossSongs;

        [ReloadRequired]
        public bool OverrideModdedMusicBoxes;

        [Header("$Mods.EdenMusicMog.Configs.MusicConfig.Headers.VanillaMusicOverrides")]

        [DefaultValue(true)]
        public bool OverrideKingSlimeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEyeOfCthulhuTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEaterOfWorldsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideBrainOfCthulhuTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideQueenBeeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideSkeletronTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDeerclopsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideWallOfFleshTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDreadnautilusTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideQueenSlimeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideBanishedBaronTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideSkeletronPrimeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideTwinsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDestroyerTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverridePlanteraTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideGolemTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideBetsyTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDukeFishronTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEmpressOfLightTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideLunaticCultistTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideMoonLordTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool ToggleAllVanillaMusicOverrides
        {
            get
            {
                return OverrideKingSlimeTheme &&
                OverrideEyeOfCthulhuTheme &&
                OverrideEaterOfWorldsTheme &&
                OverrideBrainOfCthulhuTheme &&
                OverrideQueenBeeTheme &&
                OverrideSkeletronTheme &&
                OverrideDeerclopsTheme &&
                OverrideWallOfFleshTheme &&
                OverrideDreadnautilusTheme &&
                OverrideQueenSlimeTheme &&
                OverrideSkeletronPrimeTheme &&
                OverrideTwinsTheme &&
                OverrideDestroyerTheme &&
                OverridePlanteraTheme &&
                OverrideGolemTheme &&
                OverrideBetsyTheme &&
                OverrideDukeFishronTheme &&
                OverrideEmpressOfLightTheme &&
                OverrideLunaticCultistTheme &&
                OverrideMoonLordTheme;
            }
            set
            {
                OverrideKingSlimeTheme = value;
                OverrideEyeOfCthulhuTheme = value;
                OverrideEaterOfWorldsTheme = value;
                OverrideBrainOfCthulhuTheme = value;
                OverrideQueenBeeTheme = value;
                OverrideSkeletronTheme = value;
                OverrideDeerclopsTheme = value;
                OverrideWallOfFleshTheme = value;
                OverrideDreadnautilusTheme = value;
                OverrideQueenSlimeTheme = value;
                OverrideSkeletronPrimeTheme = value;
                OverrideTwinsTheme = value;
                OverrideDestroyerTheme = value;
                OverridePlanteraTheme = value;
                OverrideGolemTheme = value;
                OverrideBetsyTheme = value;
                OverrideDukeFishronTheme = value;
                OverrideEmpressOfLightTheme = value;
                OverrideLunaticCultistTheme = value;
                OverrideMoonLordTheme = value;
            }
        }

        [Header("$Mods.EdenMusicMog.Configs.MusicConfig.Headers.SoulsMusicOverrides")]

        [DefaultValue(true)]
        public bool OverrideTrojanSquirrelTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideCursedCoffinTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDevianttTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideLifelightTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideChampionThemes
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEridanusTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideAbominationnTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideMutantTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool ToggleAllSoulsMusicOverrides
        {
            get
            {
                return OverrideTrojanSquirrelTheme &&
                OverrideCursedCoffinTheme &&
                OverrideDevianttTheme &&
                OverrideBanishedBaronTheme &&
                OverrideLifelightTheme &&
                OverrideChampionThemes &&
                OverrideEridanusTheme &&
                OverrideAbominationnTheme &&
                OverrideMutantTheme;
            }
            set
            {
                OverrideTrojanSquirrelTheme = value;
                OverrideCursedCoffinTheme = value;
                OverrideDevianttTheme = value;
                OverrideBanishedBaronTheme = value;
                OverrideLifelightTheme = value;
                OverrideChampionThemes = value;
                OverrideEridanusTheme = value;
                OverrideAbominationnTheme = value;
                OverrideMutantTheme = value;
            }
        }

    }
}
