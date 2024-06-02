using UnityEngine;
using UnityEngine.Splines;

namespace PaperPlane
{
    public class EnemyFactory
    {
        public static GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
        {
            var builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSplines(spline)
                .SetSpeed(enemyType.speed);
            
            return builder.Build();
        }
    }
}