using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class aiAgent : MonoBehaviour
{
    /// <summary>
    /// A.I. bots to help fill out the scene. Cars, other bikes, people.
    /// Give each object a location to head back and forth, or vehicles to go around a block.
    /// </summary>

    //[SerializeField] private int waitTime = 4;

    public enum State { MoveToPointOne, MoveToPointTwo, MoveToPointThree, MoveToPointFour, TravellingToPointTwo, HangAround };
    public State currentState = State.MoveToPointOne;

    public Transform pointOne,pointTwo, pointThree, pointFour;
    public BoxCollider fieldCollider;
    
    //navemesh component goes on the A.I bot
    private NavMeshAgent agent;
    Animator anim;

    public enum Type { Car, Bike, Person };
    [SerializeField] private int type;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    private void Start()
    {
        agent.SetDestination(pointOne.position);
    }

    void Update()
    {
        AiLogic();
    }

    private void AiLogic()
    {
        if (currentState == State.MoveToPointOne)
        {
            HeadingThere(pointOne, pointTwo);
        }

        if (currentState == State.MoveToPointTwo)
        {
            HeadingThere(pointTwo, pointThree);
        }

        if (currentState == State.MoveToPointThree)
        {
            HeadingThere(pointThree, pointFour);
        }

        if (currentState == State.MoveToPointFour)
        {
            HeadingThere(pointFour, pointOne);
        }
    }

    private void HeadingThere(Transform currentPoint, Transform nextPoint)
    {
        if (Vector3.Distance(transform.position, currentPoint.position) < 10)
        {
           if (currentState == State.MoveToPointFour)
            {
                currentState = State.MoveToPointOne;
            }
            else
            {
                currentState++;
            }
            agent.SetDestination(nextPoint.position);
        }
    }

    IEnumerator EnsureAnimatorEngages()
    {
        yield return new WaitForSeconds(.5f);


        currentState = State.MoveToPointOne;
        agent.SetDestination(pointOne.position);

    }
}
