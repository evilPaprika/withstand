using UnityEngine.Networking;

public class Indicator : NetworkBehaviour
{
    public int MaxValue = 100;

    [SyncVar(hook = "OnChangeValue")]
    public int CurrentValue;

    public SliderHandler SliderHandler;

    void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void IncreaseLevel(int amount)
    {
        CurrentValue += amount;
        if (CurrentValue > MaxValue)
            CurrentValue = MaxValue;
    }

    public void DecreaseLevel(int amount)
    {
        CurrentValue -= amount;
        if (CurrentValue < 0)
            CurrentValue = 0;
    }

    public virtual void OnChangeValue(int value)
    {
        CurrentValue = value;
        if (SliderHandler == null) return;
        SliderHandler.FillPrecentage((int)(100f / MaxValue * CurrentValue));
    }

    public void SetFull()
    {
        CurrentValue = MaxValue;
    }
}