namespace BetterBroadcast
{
    public static class Config
    {
        public static bool EnablePlugin = Qurre.Plugin.Config.GetBool("bb_enable", true);
        public static bool EnablePlayerJoinMessage = Qurre.Plugin.Config.GetBool("bb_ply_join_msg_on", true);
        public static string PlayerJoinMessageText = Qurre.Plugin.Config.GetString("bb_ply_join_text", "<color=yellow>Welcome to my server <color=red>%player%</color>!</color>");
        public static ushort PlayerJoinMessageDuration = Qurre.Plugin.Config.GetUShort("bb_ply_join_msg_dur", 10);
        public static bool EnableStartRoundMessage = Qurre.Plugin.Config.GetBool("bb_start_round_msg_on", true);
        public static string StartRoundMessageText = Qurre.Plugin.Config.GetString("bb_start_round_text", "<color=red>Good luck!</color>");
        public static ushort StartRoundMessageDuration = Qurre.Plugin.Config.GetUShort("bb_start_round_msg_dur", 10);
        public static bool EnableEndRoundMessage = Qurre.Plugin.Config.GetBool("bb_end_round_msg_on", true);
        public static string EndRoundMessageText = Qurre.Plugin.Config.GetString("bb_end_round_text", "<color=green>Thank you for playing!</color>");
        public static ushort EndRoundMessageDuration = Qurre.Plugin.Config.GetUShort("bb_end_round_msg_dur", 10);
        public static bool EnableRoundMessage = Qurre.Plugin.Config.GetBool("bb_round_msg_on", true);
        public static string RoundMessageText = Qurre.Plugin.Config.GetString("bb_round_text", "<color=green>DISCORD: discord.gg/</color>");
        public static ushort RoundMessageDuration = Qurre.Plugin.Config.GetUShort("bb_round_dur", 10);
        public static float RoundMessageushorterval = Qurre.Plugin.Config.GetFloat("bb_round_msg_ushorterval", 100);
        public static bool EnablePlayerDieMessage = Qurre.Plugin.Config.GetBool("bb_player_die_msg_on", true);
        public static string PlayerDieText = Qurre.Plugin.Config.GetString("bb_player_die_text", "You were killed by player <color=red>%killer%</color>");
        public static ushort PlayerDieMessageDuration = Qurre.Plugin.Config.GetUShort("bb_player_die_msg_dur", 4);
        public static float RoundMessageInterval = Qurre.Plugin.Config.GetFloat("bb_round_message_interval", 4);
    }
}