using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyData : MonoBehaviour
{
    //Enemy data
    public EnemyData enemyDataHolder;
    [SerializeField] private GameObject healthBarPrefab;
    public EnemySkillData[] skillDataHolder;
    public EnemySkillData currentSkill;
    //status bar
    private HealthBar healthBar;
    private int maxHealth;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = enemyDataHolder.health;
        currentHealth = enemyDataHolder.health;
        spawnHealthBar();

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void useSkill(EnemySkillData skill)
    {
        currentSkill = skill;
        Debug.Log("Trigger = " + skill.skillName);
        if (gameObject.GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetTrigger(skill.skillName);
        }
        else
        {
            Debug.LogWarning("enemy died");
        }
    }

    public EnemySkillData getRandomSkill()
    {
        if (skillDataHolder.Length == 0)
        {
            Debug.LogWarning("No skills available for " + enemyDataHolder.enemyName);
            return null;
        }
        int randomIndex = Random.Range(0, skillDataHolder.Length);
        return skillDataHolder[randomIndex];
    }

    public void OnAttackEnd()
    {
        TurnManager.Instance.StartPlayerTurn();
    }
   
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        healthBar.UpdateHealth(currentHealth, maxHealth);
        Debug.Log(enemyDataHolder.enemyName + " took " + damage + " damage. Remaining health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log(enemyDataHolder.enemyName + " has died.");
            //die();
        }
    }
    public void spawnHealthBar()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            GameObject hb = Instantiate(healthBarPrefab);
            healthBar = hb.GetComponent<HealthBar>();
            healthBar.Init(transform, enemyDataHolder.healthBarOffset, currentHealth, maxHealth);
        }

    }
    public void UpdateHealth(int current, int max)
    {
        healthBar.UpdateHealth(current, max);
    }
   public bool IsDead()
    {
        return currentHealth <= 0;
    }
}