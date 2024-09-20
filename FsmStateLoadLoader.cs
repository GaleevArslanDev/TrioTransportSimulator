using Scripts.PassengerController;
using System.Collections;
using UnityEngine;
using System;

public class FsmStateLoadLoader : FsmState
{
    private LoaderController _loaderController;
    public FsmStateLoadLoader(Fsm fsm, string name, Animator animator) : base(fsm, name, animator) { }

    public override void Enter()
    {
        base.Enter();
        Animator.SetBool("isCarrying", true);
        var timer = new System.Threading.Timer(ChangeState, null, TimeSpan.FromSeconds(1), TimeSpan.Zero);
    }

    private void ChangeState(object state)
    {
        Fsm.SetState("WalkBack");
    }
}