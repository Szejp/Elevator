using UnityEngine;

namespace Helpers
{
    public static class AnimatorExtensions
    {
        // GG Unity
        public static void FireTrigger(this Animator animator, string triggerName)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(triggerName))
                return;

            animator.ResetTriggers();
            animator.SetTrigger(triggerName);
        }

        public static void ResetTriggers(this Animator animator)
        {
            foreach (AnimatorControllerParameter p in animator.parameters)
                if (p.type == AnimatorControllerParameterType.Trigger)
                    animator.ResetTrigger(p.name);
        }
    }
}