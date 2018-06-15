using UnityEngine;
using System.Collections;

public class DecreasingIndicator : Indicator
{
    protected void Start()
    {
        if (!isServer)
            return;
        StartCoroutine(DecreaseLevel());
    }

    private IEnumerator DecreaseLevel()
    {
        while (true)
        {
            DecreaseLevel(2);
            yield return new WaitForSeconds(3f);
        }
    }

    void OnEnable()
    {
        Start();
    }
}