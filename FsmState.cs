using UnityEngine;

namespace Scripts.PassengerController
{
    public abstract class FsmState
    {
        protected readonly Fsm Fsm;
        protected readonly string Name;
        protected readonly Animator Animator;

        public FsmState(Fsm fsm, string name, Animator animator)
        {
            Fsm = fsm;
            Name = name;
            Animator = animator;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
        
        public string GetName()
        {
            return Name;
        }
    }
}