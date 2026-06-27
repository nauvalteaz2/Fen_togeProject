using System.Collections;
using UnityEngine;

public enum TurnState { PlayerTurn, EnemyTurn }

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public TurnState currentTurn;

    [SerializeField] private GameObject skillPanel;

    private playerData player;
    private enemyData enemy;

    void Awake() => Instance = this;

    void Start()
    {
        player = FindObjectOfType<playerData>();
        enemy = FindObjectOfType<enemyData>();
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        currentTurn = TurnState.PlayerTurn;
        skillPanel.SetActive(true);
        Debug.Log("PLAYER TURN");
    }

    public void StartEnemyTurn()
    {
        currentTurn = TurnState.EnemyTurn;
        skillPanel.SetActive(false);
        Debug.Log("ENEMY TURN");
        StartCoroutine(EnemyAttackRoutine());
    }
    public void HideSkillPanel()
    {
        if (skillPanel != null)
        {
            skillPanel.SetActive(false);
        }
    }

    IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(1f);

        // pilih skill random dan jalankan
        EnemySkillData skill = enemy.getRandomSkill();
        if (skill != null)
            enemy.useSkill(skill);  // trigger animasi enemy

        else { 
            if (!CheckBattleEnd())
                StartPlayerTurn();
        } 
    }

    public bool CheckBattleEnd()
    {
        if (enemy.IsDead())
        {
            // simpan enemy yang kalah
            GameManager.Instance.defeatedEnemies.Add(GameManager.Instance.currentEnemyGuid);
            Destroy(enemy.gameObject);
            StartCoroutine(BackToOverworld());
            return true;
        }
        if (player.IsDead())
        {
            Debug.Log("LOSE!");
            return true;
        }
        return false;
    }

    public IEnumerator BackToOverworld()
    {
        yield return new WaitForSeconds(1.5f);  // delay dulu biar keliatan
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}