using System;
using DG.Tweening;
using UnityEngine;

namespace Elevator
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] ElevatorConfig config;
        [SerializeField] AutomaticDoors.AutomaticDoors doors;

        bool isMoving;
        Vector3 positionToMove;

        public event Action OnMovementFinished;
        public event Action OnMovementStarted;

        public void TryMove(int floor)
        {
            if (doors.IsBlocked)
                return;

            doors.CanOpen = false;

            if (SameFloorCheck(floor))
            {
                doors.CanOpen = true;
                doors.TryOpen();
                return;
            }

            if (isMoving)
                return;

            if (doors.IsClosed)
                TryMoveElevator(floor);
            else
                doors.TryClose(() => TryMoveElevator(floor));
        }

        bool SameFloorCheck(int floor)
        {
            return transform.position == config.GetPositionToMove(floor);
        }

        void TryMoveElevator(int floor)
        {
            positionToMove = config.GetPositionToMove(floor);
            StopMoving();

            var tween = transform.DOMove(config.GetPositionToMove(floor),
                config.movementDuration);
            tween.onComplete += FinishMovement;
            isMoving = true;
            OnMovementStarted?.Invoke();
            Debug.Log("[ElevatorController] Start moving");
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
            doors.IsClosed = false;
            transform.position = positionToMove;
            OnMovementFinished?.Invoke();
        }

        void Reset()
        {
            isMoving = false;
            doors.CanOpen = true;
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