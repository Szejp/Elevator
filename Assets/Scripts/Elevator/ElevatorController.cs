using System;
using System.Collections;
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

        bool CanMoveCheck => doors.IsClosed && !isMoving && transform.position != positionToMove;

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

            positionToMove = config.GetPositionToMove(floor);

            if (CanMoveCheck)
            {
                StopMoving();
                var tween = transform.DOMove(config.GetPositionToMove(floor),
                    config.movementDuration);
                tween.onComplete += FinishMovement;
                isMoving = true;
                doors.CanOpen = false;
                OnMovementStarted?.Invoke();
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