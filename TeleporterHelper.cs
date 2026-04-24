using System.Collections.Generic;

namespace TeleportWithYourItems
{
    internal static class TeleporterHelper
    {
        private static readonly Dictionary<ulong, bool> PlayersBeingTeleported = new Dictionary<ulong, bool>();

        public static void RemovePlayerFromMap(ulong playerId)
        {
           PlayersBeingTeleported.Remove(playerId);
        }

        public static void AddPlayerToMap(ulong playerId, bool value)
        {
            if (PlayersBeingTeleported.ContainsKey(playerId))
            {
                PlayersBeingTeleported[playerId] = value;
            } else
            {
                PlayersBeingTeleported.Add(playerId, value);
            }
        }

        public static bool IsPlayerInTeleporter(ulong playerId, out bool isInverseTeleporter)
        {
            return PlayersBeingTeleported.TryGetValue(playerId, out isInverseTeleporter);
        }
    }
}
