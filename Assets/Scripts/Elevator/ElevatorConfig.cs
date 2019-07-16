using UnityEngine;

namespace Elevator
{
    [CreateAssetMenu(fileName = "ElevatorConfig", menuName = "Game/Enviroment/Elevator/ElevatorConfig")]
    public class ElevatorConfig : ScriptableObject
    {
        public float distancePerFloor = 10;
        public float movementDuration = 3;
        public float doorsClosingTime = 2;
        public Vector3 movementVector;
        public Vector3 initialPosition;

        public Vector3 GetPositionToMove(int floor)
        {
            return initialPosition + movementVector.normalized * floor * distancePerFloor;
        }
    }
}