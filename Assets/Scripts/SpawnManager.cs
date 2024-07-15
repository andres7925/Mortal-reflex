using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;

    private float maximoZ = 31;
    private float minimoZ = -36;

    private float maximoX = -25;
    private float minimoX = -75;
    public int enemyCount;
    public int WaveNumber = 1;

   

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawmEnemyWave(WaveNumber);
        StartCoroutine(EjecutarIntervalo());
          
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyControl>().Length;
        
        if (enemyCount == 0)
        {
            WaveNumber ++;
            SpawmEnemyWave(WaveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            
        }
    }

    IEnumerator EjecutarIntervalo()
    {
        while (true)
        {
            // Esperar 5 segundos
            yield return new WaitForSeconds(30f);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        
            
        }
    }

    void SpawmEnemyWave(int EnemiesToSpawn)
    {
        for (int i = 0; i < EnemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(minimoX, maximoX);
        float spawnPosZ = Random.Range(minimoZ, maximoZ);
        Vector3 randomPos = new Vector3(spawnPosX, 2.1f, spawnPosZ);

        return randomPos;
    }
}
