using UnityEngine;

namespace PaperPlane
{
    public class EnemyWeapon : Weapon
    {
        private float _fireTimer;

        private void Update()
        {
            _fireTimer += Time.deltaTime;
            if (!(_fireTimer > weaponStrategy.FireRate)) return;
            foreach (var t in firePoint)
            {
                weaponStrategy.Fire(t, layer, false);
            }

            _fireTimer = 0f;
        }
    }
}