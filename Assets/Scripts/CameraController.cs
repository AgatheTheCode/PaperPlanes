using UnityEngine;

namespace PaperPlane
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed = 1.5f;
        
        private void Start()=> transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        private void LateUpdate()
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}