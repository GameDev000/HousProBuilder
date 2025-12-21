using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;

    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject gameOverPanel;


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
            HP = 0;
            Debug.Log("Player lost!");

            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}
