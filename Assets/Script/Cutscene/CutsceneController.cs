using Fungus;
using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerController pc;
    [SerializeField] private Flowchart flowchart;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private PlayerController GetPlayer()
    {
        return FindObjectOfType<PlayerController>();  // cari player clone di scene!
    }

    private NPCController GetNPC()
    {
        return FindObjectOfType<NPCController>();  // cari player clone di scene!
    }
    public void WalkRight(float duration)
    {
        StartCoroutine(WalkRoutine(Vector2.right, duration));
    }

    public void WalkLeft(float duration)
    {
        StartCoroutine(WalkRoutine(Vector2.left, duration));
    }

    IEnumerator WalkRoutine(Vector2 direction, float duration)
    {
        PlayerController pc = GetPlayer();
        Rigidbody2D rb = pc.GetComponent<Rigidbody2D>();
        Animator animator = pc.GetComponent<Animator>();

        pc.enabled = false;
        animator.SetBool("IsMoving", true);

        float timer = 0f;
        while (timer < duration)
        {
            rb.MovePosition(rb.position + direction * 3f * Time.fixedDeltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("IsMoving", false);
        flowchart.SendFungusMessage("WalkDone");
    }
}
