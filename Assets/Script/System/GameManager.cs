using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager Instance;
    public EnemyData currentEnemy;  // stores which enemy was touched
    public string currentEnemyGuid;  // stores the unique ID of the specific enemy instance
    public List<string> defeatedEnemies = new List<string>();  // simpan nama enemy yang sudah dikalahkan
    public Vector3 playerLastPosition;
    public bool checkIntro = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // survives scene change
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
