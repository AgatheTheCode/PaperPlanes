using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace PaperPlane
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private SceneReference startScene;
        [SerializeField] private SceneReference stage2Scene;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button stage2Button;


        public void Awake()
        {
            playButton.onClick.AddListener(() => Loader.Load(startScene));
            quitButton.onClick.AddListener(Helpers
                .QuitGame); //appel de la méthode pour quitter le jeu même en mode éditeur
            stage2Button.onClick.AddListener(() => Loader.Load(stage2Scene));

            Time.timeScale = 1;
        }
    }
}