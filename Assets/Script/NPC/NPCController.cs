using Fungus;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private string blockName;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Interact()
    {
        if (flowchart != null && flowchart.HasBlock(blockName))
        {

            flowchart.ExecuteBlock(blockName);
        }
    }

  
}
