using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int MaxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int CurrentHealth = MaxHealth;

    private Slider healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
    }

    public void TakeDamage(int amount)
    {
        if (!isServer) return;

        CurrentHealth -= amount;
    }

    void OnChangeHealth(int health)
    {
        if (healthBar == null) return;
        Debug.Log("Health bar should've changed");
        if (CurrentHealth > healthBar.maxValue)
            healthBar.value = healthBar.maxValue;
        else if (CurrentHealth < 0)
            healthBar.value = healthBar.minValue;
        else
            healthBar.value = health;
    }
}