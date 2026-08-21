using UnityEngine;

public class MonsterSelfDestruct : MonoBehaviour
{
    [Header("自爆條件設定")]
    [Tooltip("要偵測的玩家 Tag，如石頭人用的 Tag")]
    public string playerTag = "Player";

    // 如果你希望在自爆前有特效，可以設置一個預置體：
    [Header("自爆特效 (可選)")]
    public GameObject explosionEffectPrefab;
    [Tooltip("特效生成後多久自動刪除")]
    public float effectLifetime = 2f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Explode();
        }
    }

    // 如果你把 Collider 打成 Trigger，也可以用這個
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // 1. 先產生特效（若有指定）
        if (explosionEffectPrefab != null)
        {
            var fx = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(fx, effectLifetime);
        }
        // 2. 再把自己消滅
        Destroy(gameObject);
    }
}
