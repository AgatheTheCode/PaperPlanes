using System;

namespace PaperPlane
{
    public class Player : Plane
    {
        protected override void Die()
        {
            //On ne fait rien pour avoir le gameOver
        }
        
        //ajoute de la vie au joueur
        public void AddHealth(int value)
        {
            health += value;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}