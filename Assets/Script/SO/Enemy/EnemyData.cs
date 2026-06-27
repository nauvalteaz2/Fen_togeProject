using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public int attackDamage;
    public GameObject EnemyPrefab;
    public Vector3 healthBarOffset;

}
