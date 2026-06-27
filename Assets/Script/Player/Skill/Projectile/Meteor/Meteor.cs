using Unity.VisualScripting;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private int damage;
    private Transform target;
    private float speed = 5f;
    [SerializeField] private SkillData playerSkill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        meteorMove();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyData enemy = other.GetComponent<enemyData>();
            if (enemy != null) { 
                enemy.TakeDamage(playerSkill.skillDamage); 
            }
            if (!TurnManager.Instance.CheckBattleEnd()) { 
                TurnManager.Instance.StartEnemyTurn();
            }
            Destroy(gameObject);
        }
    }

    public void meteorMove()
    {
        if (target != null)
        {
         transform.position = Vector2.MoveTowards(
         transform.position,
         target.position,
         speed * Time.deltaTime
            );
        }
        else
        {
            Debug.LogError("Target is NULL!");
            Destroy(gameObject);
        }

    }
}
