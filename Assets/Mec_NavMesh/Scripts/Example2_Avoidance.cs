using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Example2_Avoidance : MonoBehaviour {

    public Transform spots;
    //link to Animator component
    public Animator animController;

	//used to set anim controller parameters
	public enum MoveState {Idle, Walking}
	public MoveState moveState;

	//link to NavMeshAgent component
	public NavMeshAgent navAgent;

    public float minIdleTime = 2f;
    public float maxIdleTime = 6f;
    List<Vector3> spotsPos;
    float idleTime;

	void Start ()
	{
        spotsPos = new List<Vector3>();
        foreach (Transform tr in spots)
            spotsPos.Add(tr.position);

        getRandomSpot();
    }

    void getRandomSpot()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        var spotPos  = spotsPos[Random.Range(0, spotsPos.Count - 1)];
        navAgent.destination = spotPos;
    }

	void Update ()
	{
		//set animation speed based on navAgent 'Speed' var
		animController.speed = navAgent.speed;

		//character walks if there is a navigation path set, idle all other times
		if (navAgent.hasPath)
        {
            moveState = MoveState.Walking;
        }
        else
        {
            moveState = MoveState.Idle;
            idleTime -= Time.deltaTime;
            if (idleTime < 0)
                getRandomSpot();
        }

		//send move state info to animator controller
		animController.SetInteger("MoveState", (int)moveState);
	}

	void OnAnimatorMove ()
	{
		//only perform if walking
		if (moveState == MoveState.Walking)
		{
			//set the navAgent's velocity to the velocity of the animation clip currently playing
			navAgent.velocity = animController.deltaPosition / Time.deltaTime;

			//smoothly rotate the character in the desired direction of motion
			Quaternion lookRotation = Quaternion.LookRotation(navAgent.desiredVelocity);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, navAgent.angularSpeed * Time.deltaTime);
		}
	}
}


