using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    private Slider sliderBar;
    public GameObject amount;

    protected void Start()
    {
        sliderBar = GetComponent<Slider>();
    }

    public void FillPrecentage(int precentage)
    {
        if (sliderBar == null) return;
        if (precentage > sliderBar.maxValue)
            sliderBar.value = sliderBar.maxValue;
        else if (precentage < 0)
            sliderBar.value = sliderBar.minValue;
        else
            sliderBar.value = precentage;

        if (amount != null)
            amount.GetComponent<Text>().text = ((int)sliderBar.value).ToString();
    }
}
