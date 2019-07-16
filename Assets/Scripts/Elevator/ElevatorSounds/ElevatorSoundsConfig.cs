using UnityEngine;

namespace Elevator
{
    [CreateAssetMenu(fileName = "ElevatorSoundsConfig", menuName = "Game/Enviroment/Elevator/ElevatorSoundsConfig")]
    public class ElevatorSoundsConfig : ScriptableObject
    {
        public AudioClip elevatorMovingMusic;
        public AudioClip elevatorMovingFinishedSound;
    }
}