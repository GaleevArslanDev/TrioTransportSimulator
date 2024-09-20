using System.Collections.Generic;
using System;

namespace Scripts.PassengerController
{
    public class Fsm
    {
        private FsmState StateCurrent { get; set; }
        
        private Dictionary<string, FsmState> _states = new Dictionary<string, FsmState>();

        public void AddState(FsmState state)
        {
            _states.Add(state.GetName(), state);
        }

        public void SetState(string name)
        {
            if (StateCurrent != null && StateCurrent.GetName() == name)
            {
                return;
            }

            if (_states.TryGetValue(name, out var newState))
            {
                StateCurrent?.Exit();

                StateCurrent = newState;
                
                StateCurrent.Enter();
            }
        }

        public void Update()
        {
            StateCurrent?.Update();
        }
    }
}