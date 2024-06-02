using UnityEngine;

namespace PaperPlane
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "PaperPlane/WeaponStrategy/SingleShotWeapon", order = 0)]
    public class SingleShot : WeaponStrategy
    {
        private GameObject _player;
        private Camera _cam;
        private GameObject _turret;

        // Call this method whenever the ScriptableObject is enabled
        private void OnEnable()
        {
            _player = GameObject.FindWithTag("Player");
            _cam = Camera.main;
        }

        public override void Fire(Transform firePoint, LayerMask layer, bool isTurret)
        {
            if (!_cam)
            {
                _cam = Camera.main;
            }

            if (!_player) return;
            //prise en charge de la tourelle
            if (isTurret)
            {
                var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
                var position = _player.transform.position;
                var angle = Mathf.Atan2(mousePos.y - position.y,
                    x: mousePos.x - position.x) * Mathf.Rad2Deg;
                //calculate the position of the mouse relative to the player
                if (mousePos.y - _player.transform.position.y <= 0)
                {
                    angle = angle - 90f;
                    firePoint.rotation = Quaternion.Euler(0, 0, angle);
                }
            }

            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);

            Destroy(projectile, projectileLife);
        }
    }
}