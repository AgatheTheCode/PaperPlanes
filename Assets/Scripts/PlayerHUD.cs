using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PaperPlane
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Image healthAmount;
        [SerializeField] private Image healthBackground;
        [SerializeField] private TextMeshProUGUI score;

        private void LateUpdate()
        {
            if (GameManager.Instance != null && GameManager.Instance.player != null)
            {
                healthAmount.fillAmount = GameManager.Instance.player.GetHealthNormalized();
                healthBackground.fillAmount = GameManager.Instance.player.GetHealthNormalized();
                score.text = $"Score: {GameManager.Instance.GetScore()}";
            }
            else
            {
                Debug.LogWarning("GameManager or player is null in PlayerHUD.Update()");
            }
        }

    }
}