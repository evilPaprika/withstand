using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Thrist : NetworkBehaviour
{
    public const int MaxThrist = 100;

    [SyncVar(hook = "OnChangeThrist")]
    public int CurrentThrist = MaxThrist;

    public SliderHandler SliderHandler;

    protected void Start()
    {
        if (!isServer)
            return;
        StartCoroutine(ChangeThristLevel());
    }

    private IEnumerator ChangeThristLevel()
    {
        while (true)
        {
            CurrentThrist-=10;
            yield return new WaitForSeconds(2f);
        }
    }

    void OnChangeThrist(int thrist)
    {
        if (!isServer)
            CurrentThrist = thrist;
        if (SliderHandler == null) return;
        SliderHandler.FillPrecentage(MaxThrist / 100 * CurrentThrist);
    }
}