
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject skillBuutton;
    private SkillData skillData;
    private playerData player;
    private string skillName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup(SkillData skill, playerData playerRef)
    {
        iconImage.sprite = skill.skillIcon;
        skillData = skill;
        player = playerRef;
    }

    public void OnSkillButtonClicked()
    {
        player.useSkill(skillData);

    }
}
