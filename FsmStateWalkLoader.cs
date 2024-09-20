using UnityEngine;
using UnityEngine.AI;
using Scripts.PassengerController;

public class FsmStateWalkLoader : FsmState
{
    protected readonly NavMeshAgent Agent;
    protected readonly Vector3 Destination;
    protected readonly float Speed;
    protected readonly string StateToChange;

    public FsmStateWalkLoader(Fsm fsm, string name, NavMeshAgent agent, Vector3 destination, float speed, string stateToChange, Animator animator) : base(fsm, name, animator)
    {
        Speed = speed;
        Destination = destination;
        Agent = agent;
        StateToChange = stateToChange;
    }

    public FsmStateWalkLoader(Fsm fsm, string name, NavMeshAgent agent, Transform destination, float speed, string stateToChange, Animator animator) : base(fsm, name, animator)
    {
        Speed = speed;
        Destination = destination.position;
        Agent = agent;
        StateToChange = stateToChange;
    }

    public override void Enter()
    {
        base.Enter();
        Agent.speed = Speed;
        Debug.Log("Enter");

        Agent.SetDestination(Destination);
    }

    public override void Exit()
    {
        Animator.SetBool("isCarrying", true);
    }

    public override void Update()
    {

        if (Vector3.Distance(Agent.transform.position, Destination) <= 1f)
        {
            Fsm.SetState(StateToChange);
        }
        Debug.Log("Dest: " + Destination);
        Debug.Log("Agent dest: " + Agent.destination);
    }
}
