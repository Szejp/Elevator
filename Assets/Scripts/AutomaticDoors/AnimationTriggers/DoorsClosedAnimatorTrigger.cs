using UnityEngine;
using UnityEngine.Animations;

namespace AutomaticDoors.AnimationTriggers
{
    public class DoorsClosedAnimatorTrigger : DoorsAnimatorTrigger
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            doors = TryGetDoors(animator);
            doors.IsClosed = false;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex,
            AnimatorControllerPlayable controller)
        {
            doors = TryGetDoors(animator);
            doors.IsClosed = true;
        }
    }
}