using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehav : StateMachineBehaviour {
    private int randm;
    private Transform plyrPost;
    public float speed;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //plyrPost = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randm = Random.Range(0,2);
        if (randm == 0)
        {
            animator.SetTrigger("Idle");
        }
        if (randm == 1)
        {            
            animator.SetTrigger("FowrdAttck");
        }
        if (randm == 2)
        {
            animator.SetTrigger("Jump");
        }

        //Vector2 move = new Vector2(plyrPost.position.x,animator.transform.position.y);
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position,move,speed * Time.deltaTime);
    }

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}
