using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;

    [SerializeField] private Slider healthBar;

    void Start()
    {
        HP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = HP;
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        HP = Mathf.Clamp(HP, 0, maxHP);

        healthBar.value = HP;

        Debug.Log($"Player HP: {HP}");

        if (HP <= 0)
        {
            Debug.Log("Player lost!");
            Time.timeScale = 0f;
        }
    }
}
