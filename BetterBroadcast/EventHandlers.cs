using Qurre.API;
using Qurre.API.Events;
using MEC;
using System.Collections.Generic;

namespace BetterBroadcast
{
    public class EventHandlers
    {
        public void RoundEnd(RoundEndEvent ev)
        {
            Timing.KillCoroutines("MessageLoop");
            if (Config.EnableEndRoundMessage)
            {
                if (Config.EndRoundMessageText != string.Empty && Config.EndRoundMessageDuration > 0)
                {
                    Map.Broadcast(Config.EndRoundMessageText, (ushort)Config.EndRoundMessageDuration, true);
                }
            }
        }
        public void RoundRestart()
        {
            Timing.KillCoroutines("MessageLoop");
        }
        public void RoundStart()
        {
            if (Config.EnableStartRoundMessage) 
            {
                if (Config.StartRoundMessageText != string.Empty && Config.StartRoundMessageDuration > 0)
                {
                    Map.Broadcast(Config.StartRoundMessageText, (ushort)Config.StartRoundMessageDuration, true);
                }
            }
            if (Config.EnableRoundMessage)
            {
                if (Config.RoundMessageText != string.Empty && Config.RoundMessageDuration > 0 && Config.RoundMessageInterval > 0)
                {
                    Timing.RunCoroutine(RoundMessage(), "MessageLoop");
                }
            }
        }
        public void PlayerJoin(JoinEvent ev)
        {
            if (Config.EnablePlayerJoinMessage)
            {
                if (Config.PlayerJoinMessageText != string.Empty && Config.PlayerJoinMessageDuration > 0)
                {
                    ev.Player.Broadcast((ushort)Config.PlayerJoinMessageDuration, Config.PlayerJoinMessageText, true);
                }
            }
        }
        IEnumerator<float>RoundMessage()
        {
            for(;;)
            {
                yield return Timing.WaitForSeconds(Config.RoundMessageInterval);
                Map.Broadcast(Config.RoundMessageText, (ushort)Config.RoundMessageDuration, true);
            }  
        }
    }
}
