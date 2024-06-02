using UnityEngine;

namespace PaperPlane
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] public int maxHealth;
        public int health;

        protected void Awake() => health = maxHealth;

        public void SetMaxHealth(int value) => maxHealth = health;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        public float GetHealthNormalized() =>health / (float)maxHealth;

        protected abstract void Die();
    }
}