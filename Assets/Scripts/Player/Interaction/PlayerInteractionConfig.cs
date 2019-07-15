using UnityEngine;

namespace Player.Interaction
{
    [CreateAssetMenu(fileName = "PlayerInteractionConfig", menuName = "Game/Config/PlayerInteractionConfig")]
    public class PlayerInteractionConfig : ScriptableObject
    {
        public float maxDistance = 2f;
    }
}