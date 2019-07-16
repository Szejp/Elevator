using System;
using System.Linq;
using Helpers;
using Player.Interaction.Interfaces;
using UnityEngine;

namespace Player.Interaction
{
    public class PlayerInteraction : MonoBehaviour
    {
        readonly Vector3 screenPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        [SerializeField] Camera camera;
        [SerializeField] PlayerInteractionConfig config;

        RaycastHit[] castResult;
        Ray ray;
        bool isInteractionAvailable;

        public static event Action<bool> OnInteractionStatusChanged;

        public bool IsInteractionAvailable
        {
            get { return isInteractionAvailable; }
            private set
            {
                if (value != isInteractionAvailable)
                    OnInteractionStatusChanged?.Invoke(value);

                isInteractionAvailable = value;
            }
        }

        public Camera Camera
        {
            get
            {
                if (camera != null)
                    return camera;

                return Camera.main;
            }
        }

        void Update()
        {
            ray = Camera.ScreenPointToRay(screenPoint);
            castResult = Physics.RaycastAll(ray, config.maxDistance, 1 << Layers.INTERACTABLE_LAYER_ID);

            if (castResult != null && castResult.Any())
            {
                IsInteractionAvailable = true;
                Debug.Log("[PlayerInteraction] cast result: " + castResult);

                if (Input.GetKey(PlayerKeys.InteractionKeyCode))
                    foreach (var r in castResult)
                        r.collider.GetComponent<IInteractable>()?.Interact();
            }
            else
                IsInteractionAvailable = false;
        }
    }
}