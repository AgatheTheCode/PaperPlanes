using UnityEngine;
using Utilities;

namespace PaperPlane
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponStrategy weaponStrategy;
        [SerializeField] protected Transform[] firePoint; 
        [SerializeField, Layer] protected int layer;
        [SerializeField] protected internal bool isTurret;

        
        private void OnValidate() => layer = gameObject.layer;
        
        private void Start() => weaponStrategy.Initialize();

        public void SetWeaponStrategy(WeaponStrategy strategy)
        {
            weaponStrategy = strategy;
            weaponStrategy.Initialize();
        }
    }
}