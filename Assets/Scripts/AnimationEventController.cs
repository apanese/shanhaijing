using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationEventController : StateMachineBehaviour
{
    private void controllfullpath(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.fullPathHash == GameManager.Instance.base_idle)
        {
            Debug.Log("目前hashcode为"+ stateInfo.fullPathHash+"，state是："+"base_idle,");
        }
        else if (stateInfo.fullPathHash == GameManager.Instance.base_sub)
        {
            Debug.Log("目前hashcode为" + stateInfo.fullPathHash + "，state是：" + "base_sub");
        }
        else if (stateInfo.fullPathHash == GameManager.Instance.sub_attack)
        {
            Debug.Log("目前hashcode为" + stateInfo.fullPathHash + "，state是：" + "sub_attack" );
        }
        else
        {
            Debug.Log("目前hashcode为" + stateInfo.fullPathHash + "，state是：" + "all no!" );
        }
    }
    private void controllfullpath(int stateMachinePathHash)
    {
        if (stateMachinePathHash == GameManager.Instance.sub_attack)
        {
            Debug.Log("目前hashcode为" + stateMachinePathHash + "，state是：" + "sub_attack" );
        }
        else if (stateMachinePathHash == GameManager.Instance.base_sub)
        {
            Debug.Log("目前hashcode为" + stateMachinePathHash + "，state是：" + "base_sub" );
        }
        else
        {
            Debug.Log("目前hashcode为" + stateMachinePathHash + "，state是：" + " no" );
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*string animatorname = animator.name;
        string test = "Base Layer.idle";
        int testid = Animator.StringToHash(test);
        int fullPathHashId = stateInfo.fullPathHash;
        AnimatorStateInfo a1 = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo a2 = animator.GetCurrentAnimatorStateInfo(1);
        AnimatorStateInfo a3 = animator.GetCurrentAnimatorStateInfo(2);
        AnimatorStateInfo a4 = animator.GetCurrentAnimatorStateInfo(3);
        int length = animator.layerCount;*/
        HELPER.OutPutFileName();
        //Debug.Log(animator.name + "OnStateEnter,fullPashHash" + stateInfo.fullPathHash);
        controllfullpath(stateInfo);

        // Debug.Log("Animator.StringToHash(animator.name):"+Animator.StringToHash(animator.name));
        //Debug.Log("Animator.StringToHash(stateInfo):" + Animator.StringToHash();

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HELPER.OutPutFileName();
        controllfullpath(stateInfo);
    }
    /*public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HELPER.OutPutFileName();
        controllfullpath(stateInfo);
    }*/
    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        HELPER.OutPutFileName();
        controllfullpath(stateMachinePathHash);

    }
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        HELPER.OutPutFileName();
        controllfullpath(stateMachinePathHash);
    }
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Debug.Log(animator.name + "OnStateMove");
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Debug.Log(animator.name + "OnStateUpdate");
    }
}
