using UnityEngine;

public class GolemGroupController : MonoBehaviour
{
    // 把 4 隻石頭人的 Animator 拖進來
    public Animator[] golemAnimators;

    // 給 UI 按鈕呼叫
    public void AttackAll()
    {
        foreach (var anim in golemAnimators)
        {
            if (anim != null)
            {
                anim.ResetTrigger("Idle");   // 視需求清除其他 Trigger
                anim.SetTrigger("Attack");   // 觸發攻擊
            }
        }
    }
}
