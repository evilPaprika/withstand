using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SliderHandler : NetworkBehaviour
{
//    public const int MaxPoint = 100;
//    [SyncVar(hook = "OnChangePoint")]
//    public int CurrentPoint = MaxPoint;

    private Slider sliderBar;

    protected void Start()
    {
        sliderBar = GetComponent<Slider>();
    }
//
//    public void Increase(int amount)
//    {
//        if (amount < 0) throw new ArgumentException("Argument value should be bigger than zero");
//        CurrentPoint += amount;
//    }
//
//    public void Decrease(int amount)
//    {
//        if (amount < 0) throw new ArgumentException("Argument value should be bigger than zero");
//        CurrentPoint -= amount;
//    }
//
//    public void OnChangePoint(int point)
//    {
//        if (sliderBar == null) return;
//        Debug.Log("Slider bar should've changed");
//        if (CurrentPoint > sliderBar.maxValue)
//            sliderBar.value = sliderBar.maxValue;
//        else if (CurrentPoint < 0)
//            sliderBar.value = sliderBar.minValue;
//        else
//            sliderBar.value = point;
//    }

    public void FillPrecentage(int precentage)
    {
        if (sliderBar == null) return;
        if (precentage > sliderBar.maxValue)
            sliderBar.value = sliderBar.maxValue;
        else if (precentage < 0)
            sliderBar.value = sliderBar.minValue;
        else
        {
            sliderBar.value = precentage;
        }
    }
}
