using UnityEngine;

namespace PaperPlane
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "PaperPlane/Enemy Type")]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}