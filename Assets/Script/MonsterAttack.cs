using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [Header("攻擊設定")]
    public float dps = 10f;          // 每秒傷害

    // Private
    GateHealth gate;

    /*--------------------------------------------------------------------
     * 進入 Gate：先扣一次血 → 立即自毀
     ------------------------------------------------------------------*/
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Gate")) return;

        gate = other.GetComponent<GateHealth>();
        if (gate) gate.TakeDamage(dps);
        Destroy(gameObject);         // ← 自己立刻銷毀
    }

    /*--------------------------------------------------------------------
     * 假如生成時剛好「出生在」Gate 觸發器內，
     * OnTriggerEnter 可能不會送出；用 OnTriggerStay 補一刀
     ------------------------------------------------------------------*/
    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Gate")) return;

        // 只要還活著就再確保一次傷害與自毀
        if (gate == null) gate = other.GetComponent<GateHealth>();
        if (gate) gate.TakeDamage(dps * Time.deltaTime);
        Destroy(gameObject);
    }
}

