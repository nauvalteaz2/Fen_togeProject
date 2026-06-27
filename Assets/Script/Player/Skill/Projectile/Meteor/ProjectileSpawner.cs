using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Transform handPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private playerData player;

    void Start()
    {
        player = GetComponent<playerData>();
    }

    // Spawn Projectile if skill was projectile for animation event
    public void OnSpawnProjectile()
    {
        SkillData skill = player.currentSkill;
        if (skill == null || skill.projectilePrefab == null) return;

        GameObject proj = Instantiate(skill.projectilePrefab, handPoint.position, Quaternion.identity);
    }
}
