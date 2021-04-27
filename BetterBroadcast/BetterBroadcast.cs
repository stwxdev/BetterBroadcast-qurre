using System;
using Qurre.Events;

namespace BetterBroadcast
{
    public class BetterBroadcast : Qurre.Plugin
    {
        public override string Name => "BetterBroadcast";
        public override string Developer => "stwx.";
        public override Version Version => new Version(1, 0, 1);
        public override Version NeededQurreVersion => new Version(1, 2, 12);
        private EventHandlers EventHandlers;
        public override void Enable()
        {
            EventHandlers = new EventHandlers();
            Player.Join += EventHandlers.PlayerJoin;
            Round.Start += EventHandlers.RoundStart;
            Round.Restart += EventHandlers.RoundRestart;
            Round.End += EventHandlers.RoundEnd;
            Player.Dies += EventHandlers.Dies;
        }
        public override void Reload() => Enable();
        public override void Disable()
        {
            Player.Join -= EventHandlers.PlayerJoin;
            Round.Start -= EventHandlers.RoundStart;
            Round.Restart -= EventHandlers.RoundRestart;
            Round.End -= EventHandlers.RoundEnd;
            Player.Dies -= EventHandlers.Dies;
            EventHandlers = null;
        }
    }
}
