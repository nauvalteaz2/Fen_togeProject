using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            GameObject obj = Instantiate(objectPrefab, point.position, Quaternion.identity);
            obj.name = objectPrefab.name;
            WorldEnemyInstance instance = obj.GetComponent<WorldEnemyInstance>();
            if (instance != null)
                instance.GenerateId();
            if (SceneManager.GetActiveScene().name == "BattleScene")
            {
                PlayerController pc = obj.GetComponent<PlayerController>();
                if (pc != null) pc.enabled = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}


 
