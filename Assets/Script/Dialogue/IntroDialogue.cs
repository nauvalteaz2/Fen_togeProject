using Fungus;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    private Flowchart flowchart;
    [SerializeField] private string blockName; //flowChart block name

    void Start()
    {
        flowchart = GetComponent<Flowchart>();

        // Cek ke GameManager apakah dialog pembuka sudah pernah dimainkan
        if (GameManager.Instance != null && !GameManager.Instance.checkIntro)
        {
            // Set variabel di GameManager menjadi true agar tidak terulang saat balik ke overworld
            GameManager.Instance.checkIntro = true;

            // Perintahkan Fungus untuk menjalankan dialog
            if (flowchart != null && flowchart.HasBlock(blockName))
            {
                PlayerController pc = FindObjectOfType<PlayerController>();
                if (pc != null) pc.enabled = false;
                flowchart.ExecuteBlock(blockName);
            }
        }
    }
}
