using Helpers;
using TMPro;
using UnityEngine;

namespace UI.PlayerInfo
{
    public class PlayerInfoText : MonoBehaviour
    {
        [SerializeField] PlayerInfoConfig config;
        [SerializeField] TextMeshProUGUI text;

        public void ShowInteractionText()
        {
            text.text = string.Format(config.text, PlayerKeys.InteractionKeyCode.ToString());
            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}