using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class aiAgent : MonoBehaviour
{
    /// <summary>
    /// A.I. bots to help fill out the scene. Cars, other bikes, people.
    /// Give each object a location to head back and forth, or vehicles to go around a block.
    /// </summary>

    [SerializeField]
    private int waitTime = 4;

    public enum State { MoveToPointOne, MoveToPointTwo, MoveToPointThree, MoveToPointFour, TravellingToPointTwo, HangAround };
    public State currentState = State.MoveToPointOne;

    public Transform pointOne,pointTwo, pointThree, pointFour;
    public BoxCollider fieldCollider;
    
    //navemesh component goes on the A.I bot
    //navmesh must also be created
    private NavMeshAgent agent;
    Animator anim;
    //private bool isWalking;
    private bool canHangAround;



    public enum Type { Car, Bike, Person };

    [SerializeField] private int type;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    private void Start()
    {
        //anim = GetComponent<Animator>();
        agent.SetDestination(pointOne.position);
        //isWalking = false;
        //canHangAround = true;
    }

    void Update()
    {
        AiLogic();

    }

    private void AiLogic()
    {
        if (currentState == State.MoveToPointOne)
        {
            //isWalking = true;

            //anim.SetBool("Walking", true);
            // anim.SetBool("Idle", false);

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




        //if (currentState == State.TravellingToPointTwo)
        //{
        //   // isWalking = true;

        //    //anim.SetBool("Walking", true);
        //   // anim.SetBool("Idle", false);

        //    if (!agent.pathPending)
        //    {
        //        //Is the remaining distance very small, implying we've arrived? **Keeping these comments for future reference**
        //        if (agent.remainingDistance <= agent.stoppingDistance)
        //        {
        //            // Check that we have come to a halt or no longer have a path.
        //            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        //            {
        //                anim.SetBool("Walking", false);
        //                anim.SetBool("Idle", true);
        //                currentState = State.HangAround;
                        
        //            }
        //        }
        //    }
        //}

        //if (currentState == State.HangAround && canHangAround == true)
        //{
        //    //isWalking = false;

        //    StartCoroutine(RelaxingInPlace());
        //}
    }

    private void HeadingThere(Transform currentPoint, Transform nextPoint)
    {

        //Debug.Log(Vector3.Distance(transform.position, currentPoint.position));

        if (Vector3.Distance(transform.position, currentPoint.position) < 10)
        {
            //currentState++;
           if (currentState == State.MoveToPointFour)
            {
                currentState = State.MoveToPointOne;
            }
            else
            {
                currentState++;
            }
            //Vector3 targetPosition = RandomPointInBounds(fieldCollider.bounds);
            agent.SetDestination(nextPoint.position);
            //canHangAround = true;
        }
    }

    IEnumerator RelaxingInPlace()
    {
        yield return new WaitForSeconds(waitTime);

        anim.SetBool("Walking", true);
        anim.SetBool("Idle", false);

        StartCoroutine(EnsureAnimatorEngages());

        //currentState = State.MoveToPointOne;
        //agent.SetDestination(pointOne.position);
    }

    IEnumerator EnsureAnimatorEngages()
    {
        yield return new WaitForSeconds(.5f);


        currentState = State.MoveToPointOne;
        agent.SetDestination(pointOne.position);

    }




    Vector3 RandomPointInBounds(Bounds bounds)
    {
        Vector3 randomvector3 = new Vector3
                            (Random.Range(bounds.min.x, bounds.max.x),
                             Random.Range(bounds.min.y, bounds.max.y),
                             Random.Range(bounds.min.z, bounds.max.z));
        return randomvector3;
    }
}
