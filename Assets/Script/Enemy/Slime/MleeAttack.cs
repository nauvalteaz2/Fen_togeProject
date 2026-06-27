using UnityEngine;

public class MleeAttack : MonoBehaviour
{
    private int damage;
    private Transform target;
    float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        findTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void findTarget()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (gameObject.CompareTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
    }

    public void OnMeleeHit()
    {
        if (target == null) return;

        if (gameObject.CompareTag("Player"))
        {
            // player hit enemy
            playerData player = GetComponent<playerData>();
            enemyData enemy = target.GetComponent<enemyData>();
            if (enemy != null)
                enemy.TakeDamage(player.currentSkill.skillDamage);
            Debug.Log("Damage masuk ke Player sebesar: " + damage);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            // enemy hit player
            playerData player = target.GetComponent<playerData>();
            enemyData enemy = GetComponent<enemyData>();
            if (player != null)
            {
                int damage = enemy.currentSkill.skillDamage;
                player.TakeDamage(damage);
                Debug.Log("Damage masuk ke Player sebesar: " + damage);
            }
        }
    }
}
