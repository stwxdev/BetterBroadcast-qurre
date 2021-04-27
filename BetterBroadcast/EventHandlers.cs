using Qurre.API;
using Qurre.API.Events;
using MEC;
using System.Collections.Generic;

namespace BetterBroadcast
{
    public class EventHandlers
    {
        bool BroadcastNow;
        public void RoundEnd(RoundEndEvent ev)
        {
            Timing.KillCoroutines("MessageLoop");
            if (Config.EnableEndRoundMessage)
            {
                if (Config.EndRoundMessageText != string.Empty && Config.EndRoundMessageDuration > 0)
                {
                    Map.Broadcast(Config.EndRoundMessageText, (ushort)Config.EndRoundMessageDuration, true);
                    BroadcastNow = true;
                    float delay = Config.EndRoundMessageDuration;
                    Timing.CallDelayed(delay, delegate ()
                    {
                        BroadcastNow = false;
                    });
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
                    BroadcastNow = true;
                    float delay = Config.StartRoundMessageDuration;
                    Timing.CallDelayed(delay, delegate ()
                    {
                        BroadcastNow = false;
                    });
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
                    string message = Config.PlayerJoinMessageText.Replace("%player%", $"{ev.Player.Nickname}");
                    ev.Player.Broadcast((ushort)Config.PlayerJoinMessageDuration, message, true);
                }
            }
        }

        public void Dies(DiesEvent ev)
        {
            if (Config.EnablePlayerDieMessage)
            {
                if (Config.PlayerDieText != string.Empty && Config.PlayerDieMessageDuration > 0)
                {
                    ev.Allowed = true;
                    if (ev.Killer != ev.Target) 
                    { 
                        string message = Config.PlayerDieText.Replace("%killer%", $"{ev.Killer.Nickname}");
                        ev.Target.Broadcast((ushort)Config.PlayerDieMessageDuration, message, true);
                    }
                    else
                    {
                        ev.Target.Broadcast((ushort)Config.PlayerDieMessageDuration, "<color=red>$UICIDE BOY</color>", true);
                    }
                }
            }
        }

        IEnumerator<float>RoundMessage()
        {
            for(;;)
            {
                yield return Timing.WaitForSeconds(Config.RoundMessageInterval);
                if (!BroadcastNow)
                {
                    Map.Broadcast(Config.RoundMessageText, (ushort)Config.RoundMessageDuration, true);
                }
            }  
        }
    }
}
