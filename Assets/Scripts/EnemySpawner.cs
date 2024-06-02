using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Splines;

namespace PaperPlane
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyType> enemyTypes;
        [SerializeField] private int maxEnemies = 10;
        [SerializeField] private float spawnRate = 1.5f;

        private List<SplineContainer> _splines;
        private EnemyFactory _enemyFactory;

        private float _score;
        public float spawnTimer;
        public int currentEnemies;

        private void OnValidate()
        {
            //chemin "Spline" pour les ennemis
            _splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Start() => _enemyFactory = new EnemyFactory();

        private void Update()
        {
            _score = GameManager.Instance.GetScore();
            switch (_score)
            {
                case 30:
                    spawnRate = 1.0f;
                    break;
                case 60:
                    spawnRate = 0.5f;
                    maxEnemies = 20;
                    break;
                case 80:
                    spawnRate = 0.3f;
                    maxEnemies = 30;
                    break;
                case 100:
                    maxEnemies = 40;
                    break;
                case 110:
                    spawnRate = 0.2f;
                    maxEnemies = 50;
                    break;
            }

            spawnTimer += Time.deltaTime;
            
            if (spawnTimer > spawnRate && currentEnemies < maxEnemies)
            {
                SpawnEnemy();
                spawnTimer = 0;
            }
        }

        private void SpawnEnemy()
        {
            var enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            var spline = _splines[UnityEngine.Random.Range(0, _splines.Count)];

            EnemyFactory.CreateEnemy(enemyType, spline);
            currentEnemies++;
        }
    }
}