﻿using Content.Shared.Roles;
using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
        /// <summary>
        ///     Disables most functionality in the GameTicker.
        /// </summary>
        public static readonly CVarDef<bool>
            GameDummyTicker = CVarDef.Create("game.dummyticker", false, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Controls if the lobby is enabled. If it is not, and there are no available jobs, you may get stuck on a black screen.
        /// </summary>
        public static readonly CVarDef<bool>
            GameLobbyEnabled = CVarDef.Create("game.lobbyenabled", true, CVar.ARCHIVE);

        /// <summary>
        ///     Controls the duration of the lobby timer in seconds. Defaults to 2 minutes and 30 seconds.
        /// </summary>
        public static readonly CVarDef<int>
            GameLobbyDuration = CVarDef.Create("game.lobbyduration", 150, CVar.ARCHIVE);

        /// <summary>
        ///     Controls if players can latejoin at all.
        /// </summary>
        public static readonly CVarDef<bool>
            GameDisallowLateJoins = CVarDef.Create("game.disallowlatejoins", false, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Controls the default game preset.
        /// </summary>
        public static readonly CVarDef<string>
            GameLobbyDefaultPreset = CVarDef.Create("game.defaultpreset", "secret", CVar.ARCHIVE);

        /// <summary>
        ///     Controls if the game can force a different preset if the current preset's criteria are not met.
        /// </summary>
        public static readonly CVarDef<bool>
            GameLobbyFallbackEnabled = CVarDef.Create("game.fallbackenabled", true, CVar.ARCHIVE);

        /// <summary>
        ///     The preset for the game to fall back to if the selected preset could not be used, and fallback is enabled.
        /// </summary>
        public static readonly CVarDef<string>
            GameLobbyFallbackPreset = CVarDef.Create("game.fallbackpreset", "Traitor,Extra", CVar.ARCHIVE); // Sunrise-Edit

        /// <summary>
        ///     Controls if people can win the game in Suspicion or Deathmatch.
        /// </summary>
        public static readonly CVarDef<bool>
            GameLobbyEnableWin = CVarDef.Create("game.enablewin", true, CVar.ARCHIVE);

        /// <summary>
        ///     Controls the maximum number of character slots a player is allowed to have.
        /// </summary>
        public static readonly CVarDef<int>
            GameMaxCharacterSlots = CVarDef.Create("game.maxcharacterslots", 30, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Controls the game map prototype to load. SS14 stores these prototypes in Prototypes/Maps.
        /// </summary>
        public static readonly CVarDef<string>
            GameMap = CVarDef.Create("game.map", string.Empty, CVar.SERVERONLY);

        /// <summary>
        ///     Controls whether to use world persistence or not.
        /// </summary>
        public static readonly CVarDef<bool>
            UsePersistence = CVarDef.Create("game.usepersistence", false, CVar.ARCHIVE);

        /// <summary>
        ///     If world persistence is used, what map prototype should be initially loaded.
        ///     If the save file exists, it replaces MapPath but everything else stays the same (station name and such).
        /// </summary>
        public static readonly CVarDef<string>
            PersistenceMap = CVarDef.Create("game.persistencemap", "Empty", CVar.ARCHIVE);

        /// <summary>
        ///     Prototype to use for map pool.
        /// </summary>
        public static readonly CVarDef<string>
            GameMapPool = CVarDef.Create("game.map_pool", "SunriseMapPool", CVar.SERVERONLY); // Sunrise-Edit

        /// <summary>
        ///     The depth of the queue used to calculate which map is next in rotation.
        ///     This is how long the game "remembers" that some map was put in play. Default is 16 rounds.
        /// </summary>
        public static readonly CVarDef<int>
            GameMapMemoryDepth = CVarDef.Create("game.map_memory_depth", 16, CVar.SERVERONLY);

        /// <summary>
        ///     Is map rotation enabled?
        /// </summary>
        public static readonly CVarDef<bool>
            GameMapRotation = CVarDef.Create("game.map_rotation", true, CVar.SERVERONLY);

        /// <summary>
        ///     If roles should be restricted based on time.
        /// </summary>
        public static readonly CVarDef<bool>
            GameRoleTimers = CVarDef.Create("game.role_timers", false, CVar.SERVER | CVar.REPLICATED); // Sunrise-Edit

        /// <summary>
        ///     Override default role requirements using a <see cref="JobRequirementOverridePrototype"/>
        /// </summary>
        public static readonly CVarDef<string>
            GameRoleTimerOverride = CVarDef.Create("game.role_timer_override", "", CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        ///     If roles should be restricted based on whether or not they are whitelisted.
        /// </summary>
        public static readonly CVarDef<bool>
            GameRoleWhitelist = CVarDef.Create("game.role_whitelist", true, CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        ///     Whether or not disconnecting inside of a cryopod should remove the character or just store them until they reconnect.
        /// </summary>
        public static readonly CVarDef<bool>
            GameCryoSleepRejoining = CVarDef.Create("game.cryo_sleep_rejoining", false, CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        ///     When enabled, guests will be assigned permanent UIDs and will have their preferences stored.
        /// </summary>
        public static readonly CVarDef<bool> GamePersistGuests =
            CVarDef.Create("game.persistguests", true, CVar.ARCHIVE | CVar.SERVERONLY);

        public static readonly CVarDef<bool> GameDiagonalMovement =
            CVarDef.Create("game.diagonalmovement", true, CVar.ARCHIVE);

        public static readonly CVarDef<int> SoftMaxPlayers =
            CVarDef.Create("game.soft_max_players", 30, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     If a player gets denied connection to the server,
        ///     how long they are forced to wait before attempting to reconnect.
        /// </summary>
        public static readonly CVarDef<int> GameServerFullReconnectDelay =
            CVarDef.Create("game.server_full_reconnect_delay", 30, CVar.SERVERONLY);

        /// <summary>
        ///     Whether or not panic bunker is currently enabled.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerEnabled =
            CVarDef.Create("game.panic_bunker.enabled", false, CVar.NOTIFY | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        ///     Whether or not the panic bunker will disable when an admin comes online.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerDisableWithAdmins =
            CVarDef.Create("game.panic_bunker.disable_with_admins", false, CVar.SERVERONLY);

        /// <summary>
        ///     Whether or not the panic bunker will enable when no admins are online.
        ///     This counts everyone with the 'Admin' AdminFlag.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerEnableWithoutAdmins =
            CVarDef.Create("game.panic_bunker.enable_without_admins", false, CVar.SERVERONLY);

        /// <summary>
        ///     Whether or not the panic bunker will count deadminned admins for
        ///     <see cref="PanicBunkerDisableWithAdmins"/> and
        ///     <see cref="PanicBunkerEnableWithoutAdmins"/>
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerCountDeadminnedAdmins =
            CVarDef.Create("game.panic_bunker.count_deadminned_admins", false, CVar.SERVERONLY);

        /// <summary>
        ///     Show reason of disconnect for user or not.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerShowReason =
            CVarDef.Create("game.panic_bunker.show_reason", false, CVar.SERVERONLY);

        /// <summary>
        ///     Minimum age of the account (from server's PoV, so from first-seen date) in minutes.
        /// </summary>
        public static readonly CVarDef<int> PanicBunkerMinAccountAge =
            CVarDef.Create("game.panic_bunker.min_account_age", 1440, CVar.SERVERONLY);

        /// <summary>
        ///     Minimal overall played time.
        /// </summary>
        public static readonly CVarDef<int> PanicBunkerMinOverallMinutes =
            CVarDef.Create("game.panic_bunker.min_overall_minutes", 600, CVar.SERVERONLY);

        /// <summary>
        ///     A custom message that will be used for connections denied to the panic bunker
        ///     If not empty, then will overwrite <see cref="PanicBunkerShowReason"/>
        /// </summary>
        public static readonly CVarDef<string> PanicBunkerCustomReason =
            CVarDef.Create("game.panic_bunker.custom_reason", string.Empty, CVar.SERVERONLY);

        /// <summary>
        ///     Allow bypassing the panic bunker if the user is whitelisted.
        /// </summary>
        public static readonly CVarDef<bool> BypassBunkerWhitelist =
            CVarDef.Create("game.panic_bunker.whitelisted_can_bypass", true, CVar.SERVERONLY);

        /*
         * TODO: Remove baby jail code once a more mature gateway process is established. This code is only being issued as a stopgap to help with potential tiding in the immediate future.
         */

        /// <summary>
        ///     Whether the baby jail is currently enabled.
        /// </summary>
        public static readonly CVarDef<bool> BabyJailEnabled  =
            CVarDef.Create("game.baby_jail.enabled", false, CVar.NOTIFY | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        ///     Show reason of disconnect for user or not.
        /// </summary>
        public static readonly CVarDef<bool> BabyJailShowReason =
            CVarDef.Create("game.baby_jail.show_reason", false, CVar.SERVERONLY);

        /// <summary>
        ///     Maximum age of the account (from server's PoV, so from first-seen date) in minutes that can access baby
        ///     jailed servers.
        /// </summary>
        public static readonly CVarDef<int> BabyJailMaxAccountAge =
            CVarDef.Create("game.baby_jail.max_account_age", 1440, CVar.SERVERONLY);

        /// <summary>
        ///     Maximum overall played time allowed to access baby jailed servers.
        /// </summary>
        public static readonly CVarDef<int> BabyJailMaxOverallMinutes =
            CVarDef.Create("game.baby_jail.max_overall_minutes", 120, CVar.SERVERONLY);

        /// <summary>
        ///     A custom message that will be used for connections denied due to the baby jail.
        ///     If not empty, then will overwrite <see cref="BabyJailShowReason"/>
        /// </summary>
        public static readonly CVarDef<string> BabyJailCustomReason =
            CVarDef.Create("game.baby_jail.custom_reason", string.Empty, CVar.SERVERONLY);

        /// <summary>
        ///     Allow bypassing the baby jail if the user is whitelisted.
        /// </summary>
        public static readonly CVarDef<bool> BypassBabyJailWhitelist =
            CVarDef.Create("game.baby_jail.whitelisted_can_bypass", true, CVar.SERVERONLY);

        /// <summary>
        ///     Make people bonk when trying to climb certain objects like tables.
        /// </summary>
        public static readonly CVarDef<bool> GameTableBonk =
            CVarDef.Create("game.table_bonk", false, CVar.REPLICATED);

        /// <summary>
        ///     Whether or not status icons are rendered for everyone.
        /// </summary>
        public static readonly CVarDef<bool> GlobalStatusIconsEnabled =
            CVarDef.Create("game.global_status_icons_enabled", true, CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        ///     Whether or not status icons are rendered on this specific client.
        /// </summary>
        public static readonly CVarDef<bool> LocalStatusIconsEnabled =
            CVarDef.Create("game.local_status_icons_enabled", true, CVar.CLIENTONLY);

        /// <summary>
        ///     Whether or not coordinates on the Debug overlay should only be available to admins.
        /// </summary>
        public static readonly CVarDef<bool> DebugCoordinatesAdminOnly =
            CVarDef.Create("game.debug_coordinates_admin_only", true, CVar.SERVER | CVar.REPLICATED);

#if EXCEPTION_TOLERANCE
        /// <summary>
        ///     Amount of times round start must fail before the server is shut down.
        ///     Set to 0 or a negative number to disable.
        /// </summary>
        public static readonly CVarDef<int> RoundStartFailShutdownCount =
            CVarDef.Create("game.round_start_fail_shutdown_count", 5, CVar.SERVERONLY | CVar.SERVER);
#endif

        /// <summary>
        ///     Delay between station alert level changes.
        /// </summary>
        public static readonly CVarDef<int> GameAlertLevelChangeDelay =
            CVarDef.Create("game.alert_level_change_delay", 60, CVar.SERVERONLY); // Sunrise-edit

        /// <summary>
        ///     The time in seconds that the server should wait before restarting the round.
        ///     Defaults to 2 minutes.
        /// </summary>
        public static readonly CVarDef<float> RoundRestartTime =
            CVarDef.Create("game.round_restart_time", 120f, CVar.SERVERONLY);

        /// <summary>
        ///     The prototype to use for secret weights.
        /// </summary>
        public static readonly CVarDef<string> SecretWeightPrototype =
            CVarDef.Create("game.secret_weight_prototype", "SunriseSecret", CVar.SERVERONLY); // Sunrise-Edit

        /// <summary>
        ///     The id of the sound collection to randomly choose a sound from and play when the round ends.
        /// </summary>
        public static readonly CVarDef<string> RoundEndSoundCollection =
            CVarDef.Create("game.round_end_sound_collection", "SunriseRoundEnd", CVar.SERVERONLY); // Sunrise-Edit

        /// <summary>
        ///     Whether or not to add every player as a global override to PVS at round end.
        ///     This will allow all players to see their clothing in the round screen player list screen,
        ///     but may cause lag during round end with very high player counts.
        /// </summary>
        public static readonly CVarDef<bool> RoundEndPVSOverrides =
            CVarDef.Create("game.round_end_pvs_overrides", false, CVar.SERVERONLY); // Sunrise-Edit

        /// <summary>
        ///     If true, players can place objects onto tabletop games like chess boards.
        /// </summary>
        /// <remarks>
        ///     This feature is currently highly abusable and can easily be used to crash the server,
        ///     so it's off by default.
        /// </remarks>
        public static readonly CVarDef<bool> GameTabletopPlace =
            CVarDef.Create("game.tabletop_place", false, CVar.SERVERONLY);

        /// <summary>
        ///     If true, contraband severity can be viewed in the examine menu
        /// </summary>
        public static readonly CVarDef<bool> ContrabandExamine =
            CVarDef.Create("game.contraband_examine", false, CVar.SERVER | CVar.REPLICATED); // Sunrise-Edit

        /// <summary>
        ///     Size of the lookup area for adding entities to the context menu
        /// </summary>
        public static readonly CVarDef<float> GameEntityMenuLookup =
            CVarDef.Create("game.entity_menu_lookup", 0.25f, CVar.CLIENTONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Should the clients window show the server hostname in the title?
        /// </summary>
        public static readonly CVarDef<bool> GameHostnameInTitlebar =
            CVarDef.Create("game.hostname_in_titlebar", true, CVar.SERVER | CVar.REPLICATED);

}
