using UnityEngine;

public class BattleSceneEnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform enemySpawnMarker;
    private enemyData spawnedEnemy;
    void Start()
    {
        SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
   
        EnemyData data = GameManager.Instance.currentEnemy;
        GameObject enemyObj = Instantiate(data.EnemyPrefab, enemySpawnMarker.position, Quaternion.identity);
        enemyObj.transform.localScale = new Vector3(-1, 1, 1);
        spawnedEnemy = enemyObj.GetComponent<enemyData>();
        spawnedEnemy.enemyDataHolder = data;

        Debug.Log("Spawned enemy: " + data.enemyName);
    }

}

