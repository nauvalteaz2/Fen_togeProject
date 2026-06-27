using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int health = 500;
    public int baseAttack = 50;
    public Vector3 healthBarOffset;
}
