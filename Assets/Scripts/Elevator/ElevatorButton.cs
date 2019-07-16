using DG.Tweening;
using Player.Interaction.Interfaces;
using UnityEngine;

namespace Elevator
{
    public class ElevatorButton : MonoBehaviour, IInteractable
    {
        const float BUTTON_SCALE_DURATION = .2f;
        const float BUTTON_SCALE = .3f;

        [SerializeField] ElevatorController elevator;
        [SerializeField] int floor;

        public void Interact()
        {
            transform.DOScaleY(BUTTON_SCALE, BUTTON_SCALE_DURATION).SetEase(Ease.Flash).onComplete += () =>
            {
                transform.DOScaleY(1, 0);
            };
            
            elevator.TryMove(floor);
        }

        void Awake()
        {
            if (elevator == null)
                elevator = GetComponentInParent<ElevatorController>();
        }
    }
}