using System;
using Helpers;
using UnityEngine;

namespace AutomaticDoors
{
    public class AutomaticDoors : MonoBehaviour
    {
        const string ANIMATOR_OPEN_TRIGGER = "Open";
        const string ANIMATOR_CLOSE_TRIGGER = "Close";
        const string ANIMATOR_IS_BLOCKED_BOOL = "IsBlocked";

        [SerializeField] Animator animator;
        [SerializeField] Trigger trigger;

        Func<bool> OpeningCondition;

        public Action OnDoorsClosedCallback { get; set; }

        public bool CanOpen { get; set; } = true;
        public bool IsClosed { get; set; }

        public bool IsBlocked
        {
            get { return trigger.IsColliderStaying; }
        }

        public bool CanClose
        {
            get
            {
                if (trigger.IsColliderStaying)
                    return false;

                return true;
            }
        }

        public void TryOpen()
        {
            if (CanOpen)
                animator.FireTrigger(ANIMATOR_OPEN_TRIGGER);
        }

        public void TryClose(Action callback)
        {
            if (CanClose)
            {
                animator.FireTrigger(ANIMATOR_CLOSE_TRIGGER);
                OnDoorsClosedCallback += callback;
            }
        }

        void Awake()
        {
            trigger.OnStay += OnStayHandler;
            trigger.OnExit += OnExitHanadler;
            if (animator == null)
                animator = GetComponent<Animator>();
        }

        void OnDestroy()
        {
            trigger.OnStay -= OnStayHandler;
            trigger.OnExit -= OnExitHanadler;
        }

        void OnStayHandler()
        {
            if (CanOpen && (OpeningCondition == null || OpeningCondition.Invoke()))
                animator.FireTrigger(ANIMATOR_OPEN_TRIGGER);

            animator.SetBool(ANIMATOR_IS_BLOCKED_BOOL, true);
        }

        void OnExitHanadler()
        {
            animator.SetBool(ANIMATOR_IS_BLOCKED_BOOL, false);
        }
    }
}