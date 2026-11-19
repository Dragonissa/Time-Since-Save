using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace TimeSinceSave
{
    [HarmonyPatch(typeof(Dialog_FileList), nameof(Dialog_FileList.DoWindowContents))]
    public static class Dialog_FileList_DoWindowContents_Patch
    {
        static bool Prepare()
        {
            return Prefs.DisableTinyText;
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4 &&
                    instruction.operand is float f &&
                    Mathf.Approximately(f, 94f))
                {
                    instruction.operand = 120f;
                }

                yield return instruction;
            }
        }
    }
}
