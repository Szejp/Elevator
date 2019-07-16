using System;
using UnityEngine;

namespace Helpers
{
    public class Trigger : MonoBehaviour
    {
        public event Action OnStay;
        public event Action OnExit;

        public bool IsColliderStaying { get; private set; }

        void OnTriggerStay(Collider other)
        {
            IsColliderStaying = true;
            OnStay?.Invoke();
            Debug.Log("[Trigger] OnTriggerStay");
        }

        void OnTriggerExit(Collider other)
        {
            IsColliderStaying = false;
            OnExit?.Invoke();
        }
    }
}