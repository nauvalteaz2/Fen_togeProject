using UnityEngine;
using UnityEngine.SceneManagement;

public class playerData : MonoBehaviour
{
    //Player data
    public PlayerData playerDataHolder;
    public SkillData[] skillDataHolder;
    [SerializeField]private Animator animation;
    public SkillData currentSkill;
    [SerializeField] private GameObject healthBarPrefab;
    //status bar
    private int maxHealth;
    private HealthBar healthBar;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = playerDataHolder.health;
        animation = GetComponent<Animator>();
        currentHealth = playerDataHolder.health;
        spawnHealthBar();
        LastPosition();

    }
    //player Mechanic
    public void useSkill(SkillData skill)
    {
        currentSkill = skill;
        Debug.Log("Trigger = " + skill.skillName);

        // Matikan panel UI segera setelah skill dipilih
        if (TurnManager.Instance != null)
        {
            TurnManager.Instance.HideSkillPanel();
        }

        animation.SetTrigger(skill.skillName);
    }
    public void OnattackEnd()
    {
        if (!TurnManager.Instance.CheckBattleEnd())
            TurnManager.Instance.StartEnemyTurn();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void spawnHealthBar()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            GameObject hb = Instantiate(healthBarPrefab);
            healthBar = hb.GetComponent<HealthBar>();
            healthBar.Init(transform, playerDataHolder.healthBarOffset, currentHealth, maxHealth);
        }

    }
    public void LastPosition()
    {
        if (SceneManager.GetActiveScene().name != "BattleScene")
        {
            if (GameManager.Instance != null && GameManager.Instance.playerLastPosition != Vector3.zero)
                transform.position = GameManager.Instance.playerLastPosition;
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
