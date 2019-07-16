using UnityEngine;

namespace Helpers
 {
     public class TriggersClearer : StateMachineBehaviour
     {
         public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
         {
             animator.ResetTriggers();
         }
 
         public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
         {
             animator.ResetTriggers();
         }
     }
 }