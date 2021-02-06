using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float timeBetweenEnemies;

    private BoxShapedRandomSpawner boxShapedRandomSpawner;

    private void Awake()
    {
        boxShapedRandomSpawner = GetComponentInChildren<BoxShapedRandomSpawner>();
    }
    private void Start()
    {       
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = boxShapedRandomSpawner.Spawn(enemyPrefabs[random]);
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

}
