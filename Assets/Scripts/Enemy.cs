namespace PaperPlane
{
    public class Enemy : Plane
    {
        protected override void Die()
        { 
            GameManager.Instance.AddScore(5);
            Destroy(gameObject);
        }
    }
}