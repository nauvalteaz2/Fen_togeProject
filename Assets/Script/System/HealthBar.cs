using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image Fill;
    private Transform target;
    private Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        
            if (target != null)
            {
                transform.position = target.position + offset;
                Debug.Log("Target pos: " + target.position + " | HealthBar pos: " + transform.position);
            }
            else
            {
                Debug.LogError("Target is NULL!");
            }
        
    }

    public void Init(Transform followTarget, Vector3 posOffset, int currentHp, int maxHp)
    {
        target = followTarget;
        offset = posOffset;
        transform.position = target.position + offset;
        UpdateHealth(currentHp, maxHp);  // set nilai awal langsung
    }

    public void UpdateHealth(int current, int max)
    {
        Fill.fillAmount = (float)current / max;
        if (current <= 0) {
            current = 0;
        }
        nameText.text = current + " / " + max;  // shows "350 / 500"
    }

}
