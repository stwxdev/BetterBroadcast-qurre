using Qurre.API;
using Qurre.API.Events;
using MEC;
using System.Collections.Generic;

namespace BetterBroadcast
{
    public class EventHandlers
    {
        bool BroadcastNow;
        CoroutineHandle roundMessage = new CoroutineHandle();
        public void RoundEnd()
        {
            if (Config.EnableEndRoundMessage)
            {
                if (Config.EndRoundMessageText != string.Empty && Config.EndRoundMessageDuration > 0)
                {
                    Map.Broadcast(Config.EndRoundMessageText, Config.EndRoundMessageDuration, true);
                    BroadcastNow = true;
                    float delay = Config.EndRoundMessageDuration;
                    Timing.CallDelayed(delay, delegate ()
                    {
                        BroadcastNow = false;
                    });
                }
            }
        }

        public void RoundStart()
        {
            if (Config.EnableStartRoundMessage) 
            {
                if (Config.StartRoundMessageText != string.Empty && Config.StartRoundMessageDuration > 0)
                {
                    Map.Broadcast(Config.StartRoundMessageText, Config.StartRoundMessageDuration, true);
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
                if (Config.RoundMessageText.IsEmpty() && Config.RoundMessageDuration > 0 && Config.RoundMessageInterval > 0)
                {
                    roundMessage = Timing.RunCoroutine(RoundMessage(), "MessageLoop");
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
                    ev.Player.Broadcast(Config.PlayerJoinMessageDuration, message, true);
                }
            }
        }

        public void Dies(DiesEvent ev)
        {
            if (Config.EnablePlayerDieMessage && !Config.PlayerDieText.IsEmpty() && Config.PlayerDieMessageDuration > 0)
            {
                if (ev.Killer != ev.Target) 
                {
                    while(Config.PlayerDieText.Contains("%killer%")) Config.PlayerDieText = Config.PlayerDieText.Replace("%killer%", $"{ev.Killer.Nickname}");
                    ev.Target.Broadcast(Config.PlayerDieMessageDuration, Config.PlayerDieText, true);
                }
                else
                {
                    ev.Target.Broadcast(Config.PlayerDieMessageDuration, "<color=red>$UICIDE BOY</color>", true);
                }
            }
        }

        IEnumerator<float>RoundMessage()
        {
            while (RoundSummary.RoundInProgress())
            {
                yield return Timing.WaitForSeconds(Config.RoundMessageInterval);
                if (!BroadcastNow) Map.Broadcast(Config.RoundMessageText, Config.RoundMessageDuration, true);
            }  
        }
    }
}
