using UnityEngine;

public class AttackAllButton : MonoBehaviour
{
    // 綁到 UI 按鈕 OnClick
    public void AttackAllGolems()
    {
        // 找到所有場上有 PlayerAttack 的物件
        var all = FindObjectsOfType<PlayerAttack>();
        foreach (var p in all)
        {
            p.AttackBtnPressed();   // 一個一個叫他去執行攻擊協程
        }
    }
}
