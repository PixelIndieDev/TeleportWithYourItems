using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace TeleportWithYourItems.Patches
{
    [HarmonyPatch(typeof(ShipTeleporter))]
    internal class TeleporterPatch
    {
        [HarmonyPatch("beamUpPlayer", MethodType.Enumerator)]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.Last)]
        static void BeamUpPrefix(ShipTeleporter __instance)
        {
            PlayerControllerB player = StartOfRound.Instance.mapScreen.targetedPlayer;
            if (player != null) TeleporterHelper.AddPlayerToMap(player.playerClientId, false);
        }

        [HarmonyPatch("TeleportPlayerOutWithInverseTeleporter")]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.Last)]
        static void InversePrefix(int playerObj, Vector3 teleportPos)
        {
            PlayerControllerB player = StartOfRound.Instance.allPlayerScripts[playerObj];
            if (player != null) TeleporterHelper.AddPlayerToMap(player.playerClientId, true);
        }

        [HarmonyPatch("TeleportPlayerOutWithInverseTeleporter")]
        [HarmonyPostfix]
        [HarmonyPriority(Priority.Last)]
        static void InversePostfix(int playerObj, Vector3 teleportPos)
        {
            PlayerControllerB player = StartOfRound.Instance.allPlayerScripts[playerObj];
            if (player != null) TeleporterHelper.RemovePlayerFromMap(player.playerClientId);
        }
    }
}

