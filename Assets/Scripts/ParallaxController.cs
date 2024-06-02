using System;
using UnityEngine;

namespace PaperPlane
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform[] backgrounds; // Array of all the backgrounds to be parallaxed

        [SerializeField] private float smoothing = 10f; // How smooth the parallax is going to be. Make sure to set this above 0

        [SerializeField] private float multiplier = 15f; // How much the parallax effect is going to be multiplied by
        

        private Transform _cam;
        private Vector3 _previousCamPos; // The position of the camera in the previous frame

        private void Awake()
        {
            if (Camera.main == null) return;
            _cam = Camera.main.transform;
        }

        private void Start() => _previousCamPos = _cam.position;

        private void Update()
        {
            //Iterate through each background
            for (var i = 0; i < backgrounds.Length; i++)
            {
                // The parallax is the opposite of the camera movement because the previous frame multiplied by the scale
                var parallax = (_previousCamPos.y - _cam.position.y) * (i * multiplier);
                // Set a target y position which is the current position plus the parallax
                var targetY = backgrounds[i].position.y + parallax;
                var backgroundTarget = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);
                backgrounds[i].position =
                    Vector3.Lerp(backgrounds[i].position, backgroundTarget, smoothing * Time.deltaTime);
            }

            _previousCamPos = _cam.position;
        }
    }
}