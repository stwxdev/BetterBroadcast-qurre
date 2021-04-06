namespace BetterBroadcast
{
    public static class Config
    {
        //Player Join Message
        public static bool EnablePlayerJoinMessage = Qurre.Plugin.Config.GetBool("bb_ply_join_msg_on", true);
        public static string PlayerJoinMessageText = Qurre.Plugin.Config.GetString("bb_ply_join_text", "<color=yellow>Welcome to my server!</color>");
        public static int PlayerJoinMessageDuration = Qurre.Plugin.Config.GetInt("bb_ply_join_msg_dur", 10);

        //Start Round Message
        public static bool EnableStartRoundMessage = Qurre.Plugin.Config.GetBool("bb_start_round_msg_on", true);
        public static string StartRoundMessageText = Qurre.Plugin.Config.GetString("bb_start_round_text", "<color=red>Good luck!</color>");
        public static int StartRoundMessageDuration = Qurre.Plugin.Config.GetInt("bb_start_round_msg_dur", 10);

        //End Round Message
        public static bool EnableEndRoundMessage = Qurre.Plugin.Config.GetBool("bb_end_round_msg_on", true);
        public static string EndRoundMessageText = Qurre.Plugin.Config.GetString("bb_end_round_text", "<color=green>Thank you for playing!</color>");
        public static int EndRoundMessageDuration = Qurre.Plugin.Config.GetInt("bb_end_round_msg_dur", 10);

        //Round Message
        public static bool EnableRoundMessage = Qurre.Plugin.Config.GetBool("bb_round_msg_on", true);
        public static string RoundMessageText = Qurre.Plugin.Config.GetString("bb_round_text", "<color=green>DISCORD: discord.gg/</color>");
        public static int RoundMessageDuration = Qurre.Plugin.Config.GetInt("bb_round_dur", 10);
        public static float RoundMessageInterval = Qurre.Plugin.Config.GetFloat("bb_round_msg_interval", 100);
    }
}