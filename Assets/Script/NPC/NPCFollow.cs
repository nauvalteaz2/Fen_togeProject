using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private string playerTag = "Player"; // Tag untuk mendeteksi Player di scene
    private Transform playerTarget;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3.5f;       // Kecepatan jalan NPC
    [SerializeField] private float stoppingDistance = 5.0f; // Jarak minimal agar NPC tidak menabrak/menumpuk dengan Player

    private Animator npcAnimator;
    private SpriteRenderer spriteRenderer;
    private bool isFollowing = true;

    void Start()
    {
        // Mengambil komponen Animator yang menempel pada NPC ini
        npcAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Mencari Player secara dinamis di dalam scene saat game dimulai
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
        else
        {
            Debug.LogWarning($"NPCFollow_14: Objek dengan Tag '{playerTag}' tidak ditemukan di scene!");
        }
    }

    void Update()
    {
        // Validasi: Jika Player tidak ada atau fitur follow sedang dimatikan (misal saat cutscene/dialog)
        if (playerTarget == null || !isFollowing)
        {
            UpdateAnimation(Vector2.zero); // Set ke animasi Idle
            return;
        }

        // Hitung jarak saat ini antara NPC dan Player
        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);

        // Jika jaraknya lebih besar dari stoppingDistance, NPC akan berjalan mendekat
        if (distanceToPlayer > stoppingDistance)
        {
            // Hitung arah pergerakan
            Vector2 direction = ((Vector2)playerTarget.position - (Vector2)transform.position).normalized;

            // Gerakkan posisi NPC menuju posisi Player
            Vector2 newPosition = Vector2.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.deltaTime);
            transform.position = newPosition;

            // Perbarui parameter animasi berjalan berdasarkan arah gerak
            UpdateAnimation(direction);
        }
        else
        {
            // Jika sudah dekat, hentikan animasi berjalan (kembali ke Idle)
            UpdateAnimation(Vector2.zero);
        }
    }

    /// <summary>
    /// Fungsi untuk mengatur parameter Animator NPC agar visualnya sesuai dengan arah jalan.
    /// Sangat mudah dimengerti dan disesuaikan oleh Game Designer/Animator di tim.
    /// </summary>
    private void UpdateAnimation(Vector2 moveDir)
    {
        if (npcAnimator == null) return;

        // Cek apakah NPC sedang bergerak atau diam
        bool isMoving = moveDir.sqrMagnitude > 0f;
        npcAnimator.SetBool("IsMoving", isMoving);
        Debug.Log(isMoving);

        // KOREKSI FLIP: Hanya cek koordinat X (Horizontal) untuk membalik sprite
        if (moveDir.x > 0f)
        {
            spriteRenderer.flipX = true;  // Menghadap Kanan jika arah minus
        }
        else if (moveDir.x < 0f)
        {
            spriteRenderer.flipX = false; // Menghadap Kiri jika arah plus
        }
    }

    /// <summary>
    /// Fungsi publik API yang bisa dipanggil oleh script lain (seperti DialogueEvents kamu) 
    /// untuk menghentikan atau mengaktifkan fitur follow ini secara instan.
    /// </summary>
    public void SetFollowing(bool state)
    {
        isFollowing = state;
        if (!state)
        {
            UpdateAnimation(Vector2.zero); // Langsung ubah ke Idle jika dihentikan
        }
    }
}
