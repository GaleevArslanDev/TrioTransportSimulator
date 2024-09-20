using UnityEngine;
using UnityEngine.AI;
using Scripts.PassengerController;
using System.Collections;

public class LoaderController : MonoBehaviour
{
    private Fsm _fsm;
    [SerializeField] private float _walkSpeed = 3.2f;
    [SerializeField] private float _workTime = 3f;
    [SerializeField] private Transform _carPosition;
    [SerializeField] private Transform _doorPosition;
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Start()
    {
        _fsm = new Fsm();

        _agent = gameObject.GetComponent<NavMeshAgent>();

        _animator = gameObject.GetComponent<Animator>();

        _fsm.AddState(new FsmStateWalkLoader(_fsm, "WalkToCar", _agent, _carPosition, _walkSpeed, "Load", _animator));
        _fsm.AddState(new FsmStateLoadLoader(_fsm, "Load", _animator));
        _fsm.AddState(new FsmStateWalkLoader(_fsm, "WalkBack", _agent, _doorPosition, _walkSpeed, "Exit", _animator));
        _fsm.AddState(new FsmStateExitLoader(_fsm, "Exit", gameObject, _animator));

        _fsm.SetState("WalkToCar");
    }

    private void Update()
    {
        _fsm.Update();
    }
}