using UnityEngine;

namespace AutomaticDoors.AnimationTriggers
{
    public class DoorsCloseAnimatorTrigger : DoorsAnimatorTrigger
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            doors = TryGetDoors(animator);
            doors.OnDoorsClosedCallback?.Invoke();
            Debug.Log("[DoorsClosedAnimatorTrigger] doors closed trigger: " + doors.OnDoorsClosedCallback);
            doors.OnDoorsClosedCallback = null;
        }
    }
}