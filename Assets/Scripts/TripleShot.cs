using UnityEngine;

namespace PaperPlane
{
    [CreateAssetMenu(fileName = "TripleShot", menuName = "PaperPlane/WeaponStrategy/TripleShotWeapon", order = 0)]
    public class TripleShot : WeaponStrategy
    {
        [SerializeField] private float spread = 20f;
        
        //pas de prise en charge de la tourelle ici, c'était trop déséquilibré mdrrrr

        public override void Fire(Transform firePoint, LayerMask layer, bool isTurret)
        {
            for (var i = 0; i < 3; i++) {
                var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.transform.Rotate(0f, 0f, spread * (i - 1));
                projectile.layer = layer;

                var projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);
                Destroy(projectile, projectileLife);
            }
        }
    }
}