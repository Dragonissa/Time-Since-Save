using HarmonyLib;
using System;
using Verse;

namespace TimeSinceSave
{
    public class TimeSinceSave : Mod
    {
        public TimeSinceSave(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("dragonissa.TimeSinceSave");
            harmony.PatchAll();
        }
    }
}
