using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldEnemyInstance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Generates a unique ID in the inspector manually, or automatically via Context Menu
    [SerializeField] private string uniqueId;
    [SerializeField] public EnemyData enemyDataAsset;

    public string UniqueId => uniqueId;
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(uniqueId))
        {
            uniqueId = System.Guid.NewGuid().ToString();
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
    void Start()
    {
        // Check if this specific instance has already been marked as dead
        if (GameManager.Instance.defeatedEnemies.Contains(uniqueId))
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("Generate Unique ID")]
    public void GenerateId()
    {
        uniqueId = System.Guid.NewGuid().ToString();
    }
}
