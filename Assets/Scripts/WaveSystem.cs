using UnityEngine;
using System.Collections;
public class Waves : MonoBehaviour
{
    public static int EnemiesAlive, Wave;
    public static float HealthMultiplier = 1f, SpeedMultiplier = 1f;
    public GameObject[] enemyPrefabs;
    public Transform[] waypoints;
    public float timeBetweenWaves = 5f;
    public float spawnInterval = 1f;
    public int startEnemies = 5;
    public int extraEnemiesPerWave = 2;
    public float healthIncrease = 0.2f;
    public float speedIncrease = 0.05f;
    public float maxSpeedMultiplier = 3f;

    IEnumerator Start()
    {
        EnemiesAlive = Wave = 0;
        yield return new WaitForSeconds(2f);

        while (true)
        {
            int n = Wave++;  
            HealthMultiplier = 1f + n * healthIncrease;
            SpeedMultiplier = Mathf.Min(1f + n * speedIncrease, maxSpeedMultiplier);
            int count = startEnemies + n * extraEnemiesPerWave;
            EnemiesAlive = count;

            for (int i = 0; i < count; i++)
            {
                var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(prefab, waypoints[0].position, Quaternion.identity).GetComponent<EnemeyMovment>().Init(waypoints);
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitUntil(() => EnemiesAlive <= 0);
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}