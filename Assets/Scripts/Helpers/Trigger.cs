using System;
using UnityEngine;

namespace Helpers
{
    public class Trigger : MonoBehaviour
    {
        public event Action OnStay;

        public bool IsColliderStaying { get; private set; }

        void OnTriggerStay(Collider other)
        {
            OnStay?.Invoke();
            IsColliderStaying = true;
            Debug.Log("[Trigger] OnTriggerStay");
        }

        void OnTriggerExit(Collider other)
        {
            IsColliderStaying = false;
        }
    }
}