using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using LethalConfig;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using TeleportWithYourItems.Patches;

namespace TeleportWithYourItems
{
    [BepInPlugin(ModInfo.modGUID, ModInfo.modName, ModInfo.modVersion)]
    [BepInDependency("ainavt.lc.lethalconfig")]
    public class TeleportPatchBase : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(ModInfo.modGUID);
        public static TeleportPatchBase instance;

        internal ConfigEntry<bool> ConfigEntry_CancelOnTeleport; //teleporter to ship
        internal ConfigEntry<bool> ConfigEntry_CancelOnInverseTeleport; //teleporter to facility

        internal static ManualLogSource logSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(ModInfo.modGUID);

            ConfigEntry_CancelOnTeleport = Config.Bind("General", "Keep items when being teleported back to the ship", true, "When enabled, the normal teleporter won't make you drop your items when being teleported back to the ship.");
            var checkbox01 = new BoolCheckBoxConfigItem(ConfigEntry_CancelOnTeleport, new BoolCheckBoxOptions
            {
                RequiresRestart = false
            });
            LethalConfigManager.AddConfigItem(checkbox01);

            ConfigEntry_CancelOnInverseTeleport = Config.Bind("General", "Keep items when being teleported into the facility", true, "When enabled, the inverse teleporter won't make you drop your items when being teleported into the facility.");
            var checkbox02 = new BoolCheckBoxConfigItem(ConfigEntry_CancelOnInverseTeleport, new BoolCheckBoxOptions
            {
                RequiresRestart = false
            });
            LethalConfigManager.AddConfigItem(checkbox02);

            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(TeleporterPatch));
            harmony.PatchAll(typeof(NetworkPatch));

            logSource.LogInfo(ModInfo.modName + " (version - " + ModInfo.modVersion + ")" + ": patches applied successfully");
        }
    }
}
