using UnityEngine;
using Scripts.PassengerController;

public class FsmStateExitLoader : FsmState
{
    private GameObject _gameObject;

    public FsmStateExitLoader(Fsm fsm, string name, GameObject gameObject, Animator animator) : base(fsm, name, animator)
    {
        _gameObject = gameObject;
    }

    public override void Enter()
    {
        base.Enter();
        // plus or minus cargo
        UnityEngine.Object.Destroy(_gameObject);
    }
}