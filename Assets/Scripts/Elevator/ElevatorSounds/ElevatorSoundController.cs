using UnityEngine;

namespace Elevator.ElevatorSounds
{
    public class ElevatorSoundController : MonoBehaviour
    {
        [SerializeField] ElevatorSoundsConfig config;
        [SerializeField] ElevatorController elevator;
        [SerializeField] AudioSource audioSource;

        void Awake()
        {
            elevator.OnMovementFinished += OnMovementFinishedHandler;
            elevator.OnMovementStarted += OnMovementStartedHandler;
        }

        void OnDestroy()
        {
            elevator.OnMovementFinished -= OnMovementFinishedHandler;
            elevator.OnMovementStarted -= OnMovementStartedHandler;
        }

        void OnMovementFinishedHandler()
        {
            audioSource.Stop();
            audioSource.PlayOneShot(config.elevatorMovingFinishedSound);
        }

        void OnMovementStartedHandler()
        {
            audioSource.clip = config.elevatorMovingMusic;
            audioSource.Play();
        }
    }
}