// 引用 Unity API
using UnityEngine;
using UnityEngine.UI;

namespace Johnny
{
    /// <summary>
    /// 動畫系統：透過按鈕控制動畫
    /// </summary>
    public class AnimationSystem : MonoBehaviour
    {
        // 宣告變數語法：
        // 修飾詞 資料類型 變數名稱 = 預設值；
        // 宣告一個名為 parVictory 變數，類行為字串私人，預設值為「觸發勝利」
        // private 私人：不允許其他類別存取，並且不顯示
        private string parAttack = "觸發攻擊";
        private string parDie = "觸發死亡";
        private Animator ani;

        // SerializeField 序列化欄位，讓變數顯示在面板上並可編輯
        [SerializeField] private Button btnAttack;
        [SerializeField] private Button btnDie;

        // 喚醒事件：播放遊戲後會執行一次
        private void Awake()
        {
            // Debug.Log("哈囉，沃德 :D");

            // 取得此物件身上的 Animator 並存放到變數 ani 裡面
            ani = GetComponent<Animator>();

            // 點下勝利按鈕後執行播放勝利動畫
            // 勝利按鈕的 點擊事件 添加監聽器（方法）
            btnAttack.onClick.AddListener(PlayAttack);
            btnDie.onClick.AddListener(PlayDie);
        }

        // 宣告方法：包含一系列程式式內容的區域，例如：攻擊方法、技能方法等
        private void PlayAttack()
        {
            ani.SetTrigger(parAttack);
        }

        private void PlayDie()
        {
            ani.SetTrigger(parDie);
        }
    }
}
