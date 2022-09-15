using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{
    public Image SuspicionBarFill;

    public Image PresidentBar;
    public Image MillonaireBar;
    public Image PriestBar;

    public float currentPresidentBar;
    public float currentMillonaireBar;
    public float currentPriestBar;

    public float maxBar;

    public float lerpSpeed = 3f;

    private void Start()
    {

    }

    private void Update()
    {
        BarFiller();
        ColorChanger();
    }

    private void BarFiller()
    {
        MillonaireBar.fillAmount = Mathf.Lerp(MillonaireBar.fillAmount,currentMillonaireBar / maxBar,lerpSpeed);
        PresidentBar.fillAmount = Mathf.Lerp(PresidentBar.fillAmount, currentPresidentBar / maxBar, lerpSpeed);
        PriestBar.fillAmount = Mathf.Lerp(PriestBar.fillAmount, currentPriestBar / maxBar, lerpSpeed);
    }

    private void ColorChanger()
    {
        Color milColor = Color.Lerp(Color.green, Color.red, (currentMillonaireBar) / maxBar);
        Color presiColor = Color.Lerp(Color.green, Color.red, (currentPresidentBar) / maxBar);
        Color PriestColor = Color.Lerp(Color.green, Color.red, (currentPriestBar) / maxBar);

        MillonaireBar.color = milColor;
        PresidentBar.color = presiColor;
        PriestBar.color = PriestColor;
    }
}
