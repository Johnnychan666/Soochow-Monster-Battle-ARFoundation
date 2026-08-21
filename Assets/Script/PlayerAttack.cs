using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [Header("動畫、攻擊設定")]
    public Animator animator;          // 指到石頭人的 Animator
    public float attackDuration = 0.5f;// 動畫有效時間（秒）

    private bool isAttacking = false;  // 期間內允許擊殺

    // UI 按鈕呼叫
    public void AttackBtnPressed()
    {
        if (isAttacking) return;       // 避免重複啟動
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;
        animator.SetTrigger("Attack"); // 觸發動畫
        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
    }

    // 碰撞時判斷
    private void OnCollisionEnter(Collision other)
    {
        if (isAttacking && other.gameObject.CompareTag("Enemy"))
        {
            // 若用物件池，可改為 SetActive(false)
            Destroy(other.gameObject);
        }
    }
}
