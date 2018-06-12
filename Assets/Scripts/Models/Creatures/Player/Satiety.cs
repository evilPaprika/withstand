using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Satiety : NetworkBehaviour
{
    public const int MaxSatiety = 100;

    [SyncVar(hook = "OnChangeSatiety")]
    public int CurrentSatiety = MaxSatiety;

    public SliderHandler SliderHandler;

    protected void Start()
    {
        if (!isServer)
            return;
        StartCoroutine(ChangeSatietyLevel());
    }

    private IEnumerator ChangeSatietyLevel()
    {
        while (true)
        {
            CurrentSatiety -= 5;
            yield return new WaitForSeconds(2f);
        }
    }

    void OnChangeSatiety(int satiety)
    {
        if (!isServer)
            CurrentSatiety = satiety;
        if (SliderHandler == null) return;
        SliderHandler.FillPrecentage(MaxSatiety / 100 * CurrentSatiety);
    }
}