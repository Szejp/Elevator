using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Elevator
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] ElevatorConfig config;
        [SerializeField] AutomaticDoors.AutomaticDoors doors;

        Vector3 initialPosition;
        bool isMoving;

        bool CanMoveElevator => doors.IsClosed && !isMoving;

        public void TryMove(int floor)
        {
            StartCoroutine(TryMoveCoroutine(floor));
        }

        IEnumerator TryMoveCoroutine(int floor)
        {
            doors.CanOpen = false;

            if (!doors.IsClosed)
            {
                doors.TryClose();
                yield return new WaitForSeconds(config.doorsClosingTime);
            }

            if (CanMoveElevator)
            {
                StopMoving();
                var tween = transform.DOMove(initialPosition + config.GetMovementVector(floor),
                    config.movementDuration);
                tween.onComplete += FinishMovement;
                isMoving = true;
            }
            else
                doors.CanOpen = true;
        }

        void StopMoving()
        {
            transform.DOKill();
            Reset();
        }

        void FinishMovement()
        {
            Reset();
            doors.TryOpen();
        }

        void Reset()
        {
            isMoving = false;
            doors.CanOpen = true;
        }

        void Awake()
        {
            initialPosition = transform.position;
        }

#if UNITY_EDITOR
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                TryMove(0);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                TryMove(1);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                TryMove(2);
        }
#endif
    }
}