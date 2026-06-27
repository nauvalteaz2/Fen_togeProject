using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyEncounter : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {

            Collider2D col = GetComponent<Collider2D>();
            if (col != null) col.enabled = false;
        }
        else {

            Collider2D col = GetComponent<Collider2D>();
            col.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("kena");
            enemyData enemy = other.GetComponent<enemyData>();
            WorldEnemyInstance instance = other.GetComponent<WorldEnemyInstance>();
            GameManager.Instance.currentEnemy = enemy.enemyDataHolder;
            GameManager.Instance.currentEnemyGuid = instance.UniqueId;
            GameManager.Instance.playerLastPosition = transform.position;
            SceneManager.LoadScene("BattleScene");
        }
    }
}
