using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace PaperPlane
{
    public class EnemyBuilder
    {
        GameObject enemyPrefab;
        GameObject weaponPrefab;
        SplineContainer spline;
        float speed;

        public EnemyBuilder SetBasePrefab(GameObject prefab)
        {
            enemyPrefab = prefab;
            return this;
        }
        
        public EnemyBuilder SetSplines(SplineContainer spline)
        {
            this.spline = spline;
            return this;
        }
        
        public EnemyBuilder SetWeaponPrefab(GameObject weaponPrefab)
        {
            this.weaponPrefab = weaponPrefab;
            return this;
        }
        
        public EnemyBuilder SetSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public GameObject Build()
        {
            var instance = GameObject.Instantiate(enemyPrefab);
            
            var splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;

            instance.transform.position = spline.EvaluatePosition(0f);
            
            
            return instance;

        }
    }
}