using UnityEngine;

namespace AutomaticDoors.AnimationTriggers
{
    public class DoorsAnimatorTrigger : StateMachineBehaviour
    {
        protected AutomaticDoors doors;
        
        protected AutomaticDoors TryGetDoors(Animator animator)
        {
            if (doors == null)
                doors = animator.GetComponent<AutomaticDoors>();

            return doors;
        }
    }
}