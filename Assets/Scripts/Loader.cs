using System.Collections.Generic;
using Eflatun.SceneReference;
using MEC;
using UnityEngine.SceneManagement;

namespace PaperPlane
{
    public static class Loader
    {
        private static readonly SceneReference LoadingScene = new(SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/Scenes/Loading.unity"]);
        private static SceneReference _targetScene;
        

        public static void Load(SceneReference scene)
        {
            _targetScene = scene;
            SceneManager.LoadScene(LoadingScene.Name);
            Timing.RunCoroutine(LoadTargetScene());
        }

        private static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(_targetScene.Name);
        }
    }
}