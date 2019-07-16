using UnityEngine;

namespace UI.PlayerInfo
{
    [CreateAssetMenu(fileName = "PlayerInfoConfig",
        menuName = "Game/Config/UI/PlayerInfoConfig")]
    public class PlayerInfoConfig : ScriptableObject
    {
        public string text = "Press {0} to interact";
    }
}