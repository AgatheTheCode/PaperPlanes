using System;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.Serialization;

namespace PaperPlane
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SceneReference mainMenuScene;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private GameObject pauseMenu;

        public static GameManager Instance { get; set; }
        private int _score;

        private float _restartTimer = 3f;
        public Player player;
        private static bool _isPaused;

        private bool IsGameOver() => player != null && player.GetHealthNormalized() <= 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }

            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
        }

        private void Update()
        {
            if (IsGameOver())
            {
                _restartTimer -= Time.deltaTime;

                if (!gameOverUI.activeSelf)
                {
                    gameOverUI.SetActive(true);
                }

                if (_restartTimer <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
            {
                _isPaused = true;
                if (!pauseMenu.activeSelf)
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
            {
                _isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void AddScore(int score) => _score += score;
        public int GetScore() => _score;
    }
}