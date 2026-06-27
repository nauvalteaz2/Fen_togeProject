using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    [SerializeField] private Flowchart flowchartUsed;
    [SerializeField] private string blockName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            flowchartUsed.ExecuteBlock(blockName);
        }
    }
}
