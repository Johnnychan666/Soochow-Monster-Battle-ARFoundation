using UnityEngine;
using UnityEngine.UI;

public class GateHealth : MonoBehaviour
{
    public float maxHP = 100;
    public Slider hpBar;          // 放在子物件的 World-Space Canvas
    float hp;

    void Awake() { hp = maxHP; Refresh(); }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        Refresh();
        if (hp <= 0) Die();
    }

    void Refresh()
    {
        if (hpBar) hpBar.value = hp / maxHP;
    }

    void Die()
    {
        // 停止動畫、粒子、Collider 或觸發結算
        GetComponent<Collider>().enabled = false;
        // 也可呼叫 GameManager.ShowGameOver()
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Destroy(other.gameObject);
        }
    }
}
