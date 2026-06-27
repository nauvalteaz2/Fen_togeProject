using Fungus;
using UnityEngine;

public class DialogueEvents : MonoBehaviour
{
    private Animator playeranim;
    public void OnDialogueEnd()
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        if (pc != null) pc.enabled = true;
    }
    public void OnDialogueStart()
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        if (pc != null){

            Animator playerAnim = pc.GetComponent<Animator>();
            playerAnim.SetBool("IsMoving", false);
            pc.enabled = false; 
        }
    }
    public void walkCutscene() { 
        CutsceneController cutsceneController = FindObjectOfType<CutsceneController>();
        if (cutsceneController != null) cutsceneController.WalkRight(2f);

    }
}
