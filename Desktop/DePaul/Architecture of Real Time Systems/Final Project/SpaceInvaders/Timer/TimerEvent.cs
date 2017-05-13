using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimerEvent : MLink
    {
        public Command cCommand;
        public TimerEvent.TimerEventName cTimerEventName;
        public float cTriggerTime;
        public float cDeltaTime;

        public enum TimerEventName
        {
            SpriteAnimation,
            DeathAnimation,
            ShipRemove,
            ActivateGameEnd,
            ActivateUFO,
            UFOPlaySound,
            Uninitialized
        }

        public TimerEvent() : base()
        {
            this.cTimerEventName = TimerEvent.TimerEventName.Uninitialized;
            this.cCommand = null;
            this.cTriggerTime = 0.0f;
            this.cDeltaTime = 0.0f;
        }
        public void washTimeEvent()
        {
            this.cTimerEventName = TimerEvent.TimerEventName.Uninitialized;
            this.cCommand = null;
            this.cTriggerTime = 0.0f;
            this.cDeltaTime = 0.0f;
        }

        public void setAll(TimerEvent.TimerEventName mEventName, Command mCommand,float mDeltaTime)
        {
            this.cTimerEventName = mEventName;
            this.cCommand = mCommand;
            this.cDeltaTime = mDeltaTime;

            this.cTriggerTime = TimerManager.GetCurrTime() + mDeltaTime;
        }
        public void process()
        {           
            Debug.Assert(this.cCommand != null);
            this.cCommand.execute(cDeltaTime);
        }

        public void printStats()
        {
            Debug.WriteLine("------------------Timer Event---------------");
            Debug.WriteLine("Timer Event Name : " + cTimerEventName);
            Debug.WriteLine("Timer Trigger Time : "+cTriggerTime);
            Debug.WriteLine("Timer Delta Time : " + cDeltaTime);


        }

        protected override void nodeStatistics()
        {
            Debug.WriteLine("------------------Timer Event---------------");
            //  Debug.WriteLine("Command Name : " + cCommand.GetType());
            Debug.WriteLine("Timer Event Name : " + cTimerEventName);
            Debug.WriteLine("Timer Trigger Time : " + cTriggerTime);
            Debug.WriteLine("Timer Delta Time : " + cDeltaTime);

        }
    }
}
