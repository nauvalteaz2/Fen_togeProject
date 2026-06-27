using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public int skillDamage;
    public int skillCooldown;
    public string skillType;
    public Sprite skillIcon;
    public GameObject projectilePrefab;
}
