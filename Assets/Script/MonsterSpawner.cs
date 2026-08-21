using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("基本設定")]
    public GameObject monsterPrefab;   // 怪獸 Prefab
    public Transform gate;             // 目標 (拱門)
    public int count = 8;              // 每波幾隻
    public float radius = 8f;          // 出生半徑

    [Header("刷怪頻率")]
    public float interval = 5f;        // 每幾秒刷一波

    void Start()
    {
        // 啟動無限迴圈協程
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnWave();
            yield return new WaitForSeconds(interval);
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 dir = Random.onUnitSphere;
            dir.y = 0;

            // 加一點緩衝，避免怪獸出生在 Gate 的 Trigger 盒子裡
            float safeRadius = radius + 1.0f;      // 1 公尺夠用，可依 Gate Collider 大小再調

            Vector3 pos = gate.position + dir.normalized * safeRadius;


            GameObject m = Instantiate(monsterPrefab, pos, Quaternion.identity);
            // 綁定目標
            MonsterAI ai = m.GetComponent<MonsterAI>();
            if (ai) ai.target = gate;
        }
    }
}

