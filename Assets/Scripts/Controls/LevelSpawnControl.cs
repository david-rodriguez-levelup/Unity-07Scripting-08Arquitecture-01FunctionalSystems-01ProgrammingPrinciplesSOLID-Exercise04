using System.Collections;
using UnityEngine;

public class LevelSpawnControl : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float timeBetweenEnemies;

    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private float timeBetweenPowerUps;

    private LevelUIControl levelUIControl;
    private BoxShapedRandomSpawnAction spawnAction;

    private void Awake()
    {
        levelUIControl = GetComponent<LevelUIControl>();
        spawnAction = GetComponentInChildren<BoxShapedRandomSpawnAction>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = spawnAction.Spawn(enemyPrefabs[random]);
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);

            ScoreEmitAction scoreEmitAction = enemy.GetComponent<ScoreEmitAction>();
            if (scoreEmitAction != null)
            {
                levelUIControl.SubscribeToScoreEmitAction(scoreEmitAction);
            }

            // TODO: Registrarse al evento OnDestroy de cada enemigo!!!


            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            GameObject powerUp = spawnAction.Spawn(powerUpPrefab);
            powerUp.transform.position = new Vector3(powerUp.transform.position.x, powerUp.transform.position.y, 0f);

            yield return new WaitForSeconds(timeBetweenPowerUps);
        }
    }

}
