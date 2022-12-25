using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateMachineBehaviourBase : StateMachineBehaviour
{
    protected AIController aiController;
    protected SteeringBehaviours steeringBehaviours;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject gameObject = animator.gameObject;
        aiController = gameObject.GetComponent<AIController>();
        steeringBehaviours = gameObject.GetComponent<SteeringBehaviours>();
        steeringBehaviours.SetTarget(aiController.player);
    }
}