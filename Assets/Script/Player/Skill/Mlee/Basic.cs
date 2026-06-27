using UnityEngine;

public class Basic : MonoBehaviour
{
    private Vector3 originalPosition;
    private Transform target;
    [SerializeField] private float offsetFromTarget = 1.5f;

    void Start()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) target = playerObj.transform;
        }
        else if (gameObject.CompareTag("Player"))
        {
            GameObject enemyObj = GameObject.FindGameObjectWithTag("Enemy");
            if (enemyObj != null) target = enemyObj.transform;
        }
    }

    // ANIMATION EVENT 1: Dipanggil di FRAME PERTAMA (Frame 0) animasi attack
    public void TeleportToTarget()
    {
        if (target == null) return;
        HealthBar hb = GetComponentInChildren<HealthBar>();
        if (hb != null) hb.enabled = false;

        // Simpan posisi asli sebelum berpindah
        originalPosition = transform.position;

        // Hitung posisi tepat di depan target
        Vector3 directionToTarget = (target.position - originalPosition).normalized;
        Vector3 attackPosition = target.position - (directionToTarget * offsetFromTarget);

        // Teleport langsung
        transform.position = attackPosition;
    }

    // ANIMATION EVENT 3: Dipanggil di FRAME TERAKHIR animasi attack
    public void ReturnToOriginalPosition()
    {
        // Kembalikan ke posisi awal dengan aman
        HealthBar hb = GetComponentInChildren<HealthBar>();
        if (hb != null) hb.enabled = true;
        transform.position = originalPosition;
    }
}