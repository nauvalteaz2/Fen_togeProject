using UnityEngine;

[CreateAssetMenu(fileName = "EnemySkillData", menuName = "Scriptable Objects/EnemySkillData")]
public class EnemySkillData : ScriptableObject
{
    public string skillName;
    public int skillDamage;
    public string skillType;
    public Sprite skillIcon;
    public GameObject projectilePrefab;
}
