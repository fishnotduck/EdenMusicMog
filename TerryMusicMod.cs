using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace EdenMusicMog
{
	public class EdenMusicMog : Mod
	{
		internal static EdenMusicMog Instance;
        public int ChampionsSlot = 0;
		public override void Load()
		{
			Instance = this;
		}
		public override void Unload()
		{
			Instance = null;
		}

		public Dictionary<int, Tuple<string, string>> moddedMusicDict = new Dictionary<int, Tuple<string, string>>();

        void TryMapMusic(int musicId, string newMusicIdPath, string newMusicName)
        {
            if (musicId == 0)
                return;
            moddedMusicDict.Add(musicId, new Tuple<string, string>(newMusicIdPath, newMusicName));
        }

        public override void PostSetupContent()
        {
            if (MusicConfig.Instance.OverrideModdedMusicBoxes && ModLoader.TryGetMod("FargowiltasMusic", out Mod musicMod))
            {
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron"),
                    "skyxxxxdays",
                    "ZeroRanger - Sky XXXX Days"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron2"),
                    "skyxxxxdays",
                    "ZeroRanger - Sky XXXX Days"
                );
                // Store the combined Champions slot for special-casing in the
                // music override logic. Do NOT map it to a single song here;
                // instead `MusicSystem.OverrideMusicID` will inspect which
                // champion is active and choose the correct internal track.
                ChampionsSlot = MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Champions");
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Laevateinn_P1"),
                    "yourcontracthasexpired",
                    "A Hat in Time - Your Contract Has Expired"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Laevateinn_P2"),
                    "yourcontracthasexpired",
                    "A Hat in Time - Your Contract Has Expired"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/LieFlightNoCum"),
                    "waifu4laifu",
                    "Outcore - Waifu 4 Laifu"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/PlatinumStar"),
                    "despair",
                    "ZeroRanger - Despair"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/SteelRed"),
                    "voidthesky",
                    "Void Stranger - Void the Sky"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Strawberry_Sparkly_Sunrise"),
                    "captaintutorial",
                    "Outcore - Captain Tutorial"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Storia"),
                    "voidthesky",
                    "Void Stranger - Void the Sky"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/TrojanSquirrel"),
                    "vampiresinvadingheaven",
                    "Everhood - Vampires Invading Heaven"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/WillChampion"),
                    "workingmanstheme",
                    "Serial Experiments Lain - Working Man's Theme"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/rePrologue"),
                    "voidthesky",
                    "Void Stranger - Void the Sky"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/ShiftingSands"),
                    "freezone",
                    "Serial Experiments Lain - Free Zone"
                );
            }
        }
	}
}