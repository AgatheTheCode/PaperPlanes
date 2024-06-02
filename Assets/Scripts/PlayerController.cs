using System;
using UnityEngine;

namespace PaperPlane
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float smooth = 1f;

        [SerializeField] private float leanAngle = 15f;
        [SerializeField] private float leanSpeed = 5f;

        [SerializeField] private GameObject model;

        [Header("Camera Boundaries")] [SerializeField]
        private Transform cameraFollow;

        [SerializeField] public float xMin = -2.5f;
        [SerializeField] public float xMax = 2.5f;
        [SerializeField] public float yMin = -4.5f;
        [SerializeField] public float yMax = 4.5f;

        private InputReader _input;

        private Vector3 _currentVelocity;
        private Vector3 _targetPosition;

        private void Start()
        {
            _input = GetComponent<InputReader>();
        }

        private void Update()
        {
            _targetPosition += new Vector3(_input.Move.x, _input.Move.y, 0) * (speed * Time.deltaTime);
            var cameraPosition = cameraFollow.position;
            //Position minimum et maximum du joueur par rapport à la camera
            var minPlayerX = cameraPosition.x + xMin;
            var minPlayerY = cameraPosition.y + yMin;
            var maxPlayerX = cameraPosition.x + xMax;
            var maxPlayerY = cameraPosition.y + yMax;

            //clamp the player position
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, minPlayerX, maxPlayerX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, minPlayerY, maxPlayerY);

            //Lerp the player position
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, smooth);

            //Lean Angle of the model
            var targetRotationAngle = _input.Move.x * leanAngle;
            var currentYRotation = transform.localEulerAngles.y;
            
            //new Rotation
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);
            
            //Apply the lean angle
            transform.localEulerAngles = new Vector3(0, newYRotation, 0);
        }
    }
}