using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Transform SkillPanel;
    [SerializeField] private GameObject SkillButton;
    [SerializeField] private SkillData[] skillDataHolder;
    private playerData skillPlayer;
    public bool battlescene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battlescene = true;
        assignSkillButton();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assignSkillButton()
    {

        skillPlayer = FindObjectOfType<playerData>();

        foreach (SkillData skill in skillPlayer.skillDataHolder)
        {
            GameObject buttonObj =
                Instantiate(SkillButton, SkillPanel);

            SkillButton button =
                buttonObj.GetComponent<SkillButton>();

            button.Setup(skill, skillPlayer);
        }
    }
}
