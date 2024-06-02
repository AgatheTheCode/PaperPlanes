using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PaperPlane
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] public float speed = 5f;
        [SerializeField] public float lifeTime = 5f;
        [SerializeField] private GameObject muzzlePrefab;
        [SerializeField] private GameObject hitPrefab;

        Transform _parent;
        private GameObject _player;
        private bool _isTurret;
        private Camera _camera;


        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => _parent = parent;

        private void Start()
        {
            _camera = Camera.main;
            _player = GameObject.FindWithTag("Player");
            if (muzzlePrefab != null)
            {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(_parent);

                DestroyParticleSystem(muzzleVFX);
            }
        }


        private void Update()
        {
            //update isTurret
            if (_player)
            {
                _isTurret = _player.GetComponent<PlayerWeapon>().isTurret;
            }

            // Set parent to null outside of conditional statements
            transform.SetParent(null);
            transform.position += transform.up * (speed * Time.deltaTime);
        }


        private void OnCollisionEnter(Collision col)
        {
            var plane = col.gameObject.GetComponent<Plane>();
            if (plane != null) {
                plane.TakeDamage(10);
            }
            
            Destroy(gameObject);
        }

        private static void DestroyParticleSystem(GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }

            Destroy(vfx, ps.main.duration);
        }
    }
}