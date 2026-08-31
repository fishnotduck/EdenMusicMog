using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EdenMusicMog
{
    public class ButtSystem : ModSystem
    {
        public const int TrackDurationTicks = 73 * 60;

        public const int FadeBufferTicks = 480;

        public static int Timer;
        private static int buttSlot = -1;

        public static int ButtSlot =>
            buttSlot != -1 ? buttSlot : (buttSlot = MusicSystem.GetMusic("boschsbuttsong"));

        public static bool Active => Timer > 0;
        public static bool Playing => Timer > FadeBufferTicks;

        public static HashSet<string> DefeatedFlags = new();

        public static void TriggerIfFirstTime(string key)
        {
            if (!MusicConfig.Instance.WhoppaButtMode)
                return;

            if (DefeatedFlags.Contains(key) || string.IsNullOrEmpty(key))
                return;

            DefeatedFlags.Add(key);
            Timer = TrackDurationTicks;
            TerryMusicSystem.nowPlayingString = "Congratulations!";
        }

        public override void PostUpdateEverything()
        {
            if (Timer > 0)
                Timer--;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["EdenMusicMog_VictoryFlags"] = DefeatedFlags.ToList();
        }

        public override void LoadWorldData(TagCompound tag)
        {
            DefeatedFlags = tag.ContainsKey("EdenMusicMog_VictoryFlags")
                ? new HashSet<string>(tag.GetList<string>("EdenMusicMog_VictoryFlags"))
                : new HashSet<string>();
        }

        public override void ClearWorld()
        {
            DefeatedFlags.Clear();
            Timer = 0;
        }
    }
}