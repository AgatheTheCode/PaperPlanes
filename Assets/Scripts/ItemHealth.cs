using UnityEngine;

namespace PaperPlane
{
    public class Health : Item
    {
        //quand le joueur entre en collision avec l'objet il regagne de la vie
        private void OnTriggerEnter(Collider col)
        {
            col.GetComponent<Player>().AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}