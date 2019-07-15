using Player.Interaction.Interfaces;
using UnityEngine;

namespace Elevator
{
    public class ElevatorButton : MonoBehaviour, IInteractable
    {
        [SerializeField] ElevatorController elevator;
        [SerializeField] int floor;

        public void Interact()
        {
            elevator.TryMove(floor);
        }

        void Awake()
        {
            if (elevator == null)
                elevator = GetComponentInParent<ElevatorController>();
        }
    }
}