namespace Utilities
{
    public static class Helpers
    {
        //pour pouvoir quitter le jeu dans l'éditeur
        public static void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}