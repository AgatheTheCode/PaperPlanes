using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utilities;

namespace PaperPlane
{
    public class PauseHUD : MonoBehaviour
    {
        [SerializeField] private SceneReference mainMenuScene;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button mainMenuButton;

        private void Awake()
        {
            quitButton.onClick.AddListener(Helpers.QuitGame);
            mainMenuButton.onClick.AddListener(() => Loader.Load(mainMenuScene));
            Time.timeScale = 1;
        }
    }
}