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
                Debug.Log("[PlayerInteraction] cast result: " + castResult);

            if (Input.GetKey(PlayerKeys.InteractionKeyCode) && castResult != null)
                foreach (var r in castResult)
                    r.collider.GetComponent<IInteractable>()?.Interact();
        }
    }
}