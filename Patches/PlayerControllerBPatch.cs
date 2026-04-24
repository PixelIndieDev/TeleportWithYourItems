using GameNetcodeStuff;
using HarmonyLib;

namespace TeleportWithYourItems.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("DropAllHeldItemsAndSync")]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.Last)]
        static bool SkipDropAllSync(PlayerControllerB __instance)
        {
            if (__instance != null)
            {
                if (TeleporterHelper.IsPlayerInTeleporter(__instance.playerClientId, out bool isInverse))
                {
                    TeleporterHelper.RemovePlayerFromMap(__instance.playerClientId);
                    if (!isInverse && TeleportPatchBase.instance.ConfigEntry_CancelOnTeleport.Value) return false;
                }
                else
                {
                    TeleporterHelper.RemovePlayerFromMap(__instance.playerClientId);
                }
            }
            return true;
        }

        [HarmonyPatch("DropAllHeldItems")]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.Last)]
        static bool SkipDropAll(PlayerControllerB __instance)
        {
            if (__instance != null)
            {
                if (TeleporterHelper.IsPlayerInTeleporter(__instance.playerClientId, out bool isInverse))
                {
                    TeleporterHelper.RemovePlayerFromMap(__instance.playerClientId);
                    if (isInverse && TeleportPatchBase.instance.ConfigEntry_CancelOnInverseTeleport.Value) return false;
                }
                else
                {
                    TeleporterHelper.RemovePlayerFromMap(__instance.playerClientId);
                }
            }
            return true;
        }
    }
}
