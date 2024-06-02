using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utilities;

namespace PaperPlane
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Item[] itemPrefabs;
        [SerializeField] private float spawnRate = 5.0f;
        [SerializeField] private float spawnRadius = 5.0f;

        private void Start() => Timing.RunCoroutine(SpawnItems());
        
        //fait spawner des items à intervalle régulier 
        private IEnumerator<float> SpawnItems()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(spawnRate);
                var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = (transform.position + Random.insideUnitSphere.With(z:0) * spawnRadius);
            }
        }
    }
}