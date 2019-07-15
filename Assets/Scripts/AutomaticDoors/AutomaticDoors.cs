using System;
using Helpers;
using UnityEngine;

namespace AutomaticDoors
{
    public class AutomaticDoors : MonoBehaviour
    {
        const string ANIMATOR_OPEN_TRIGGER = "Open";
        const string ANIMATOR_FORCE_CLOSE_TRIGGER = "Close";
        const string ANIMATOR_CLOSED_STATE_NAME = "Closed";

        [SerializeField] Animator animator;
        [SerializeField] Trigger[] triggers;

        Func<bool> OpeningCondition;

        public bool CanOpen { get; set; } = true;
        public bool IsClosed => animator.GetCurrentAnimatorStateInfo(0).IsName(ANIMATOR_CLOSED_STATE_NAME);

        public bool CanClose
        {
            get
            {
                foreach (var t in triggers)
                    if (t.IsColliderStaying)
                        return false;

                return true;
            }
        }

        public void TryOpen()
        {
            if (CanOpen)
                animator.FireTrigger(ANIMATOR_OPEN_TRIGGER);
        }

        public void TryClose()
        {
            if (CanClose)
                animator.FireTrigger(ANIMATOR_FORCE_CLOSE_TRIGGER);
        }

        void ClearEvents()
        {
            if (triggers != null)
                foreach (var t in triggers)
                    t.OnStay -= OpenDoors;
        }

        void AddEvents()
        {
            foreach (var t in triggers)
                t.OnStay += OpenDoors;
        }

        void Awake()
        {
            AddEvents();

            if (animator == null)
                animator = GetComponent<Animator>();
        }

        void OpenDoors()
        {
            if (CanOpen && (OpeningCondition == null || OpeningCondition.Invoke()))
                animator.FireTrigger(ANIMATOR_OPEN_TRIGGER);
        }
    }
}