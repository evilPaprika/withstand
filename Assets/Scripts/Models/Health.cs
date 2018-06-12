using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int MaxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int CurrentHealth = MaxHealth;

    public SliderHandler SliderHandler;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Dead!");
        }
    }

    void OnChangeHealth(int health)
    {
        if (!isServer)
            CurrentHealth = health;
        SliderHandler.FillPrecentage(MaxHealth / 100 * CurrentHealth);
    }
}