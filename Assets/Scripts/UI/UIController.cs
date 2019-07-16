using Player.Interaction;
using UI.PlayerInfo;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] PlayerInfoText playerInfo;

        void Awake()
        {
            PlayerInteraction.OnInteractionStatusChanged += EnableInteractionInfo;
            playerInfo.Hide();
        }

        void OnDestroy()
        {
            PlayerInteraction.OnInteractionStatusChanged -= EnableInteractionInfo;
        }

        void EnableInteractionInfo(bool isEnabled)
        {
            if (isEnabled)
                playerInfo.ShowInteractionText();
            else
                playerInfo.Hide();
        }
    }
}