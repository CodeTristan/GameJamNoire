using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{
    public GameObject SusBar;

    public Image SuspicionBarFill;
    public Image PresidentBar;
    public Image MillonaireBar;
    public Image PriestBar;

    public float currentPresidentBar;
    public float currentMillonaireBar;
    public float currentPriestBar;
    public float currentSuspicionBar;

    public float maxBar;

    public float lerpSpeed = 3f;
    public float BarWaitTime;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private void BarFiller()
    {
        MillonaireBar.fillAmount = Mathf.Lerp(MillonaireBar.fillAmount,currentMillonaireBar / maxBar,lerpSpeed);
        PresidentBar.fillAmount = Mathf.Lerp(PresidentBar.fillAmount, currentPresidentBar / maxBar, lerpSpeed);
        PriestBar.fillAmount = Mathf.Lerp(PriestBar.fillAmount, currentPriestBar / maxBar, lerpSpeed);
        SuspicionBarFill.fillAmount = Mathf.Lerp(SuspicionBarFill.fillAmount, currentSuspicionBar / maxBar, lerpSpeed);
    }

    private void ColorChanger()
    {
        Color milColor = Color.Lerp(Color.green, Color.red, (currentMillonaireBar) / maxBar);
        Color presiColor = Color.Lerp(Color.green, Color.red, (currentPresidentBar) / maxBar);
        Color PriestColor = Color.Lerp(Color.green, Color.red, (currentPriestBar) / maxBar);
        Color susColor = Color.Lerp(Color.green, Color.red, (currentSuspicionBar) / maxBar);

        MillonaireBar.color = milColor;
        PresidentBar.color = presiColor;
        PriestBar.color = PriestColor;
        SuspicionBarFill.color = susColor;
    }

    public IEnumerator SusBarFill()
    {
        SusBar.SetActive(true);
        BarFiller();
        ColorChanger();
        yield return new WaitForSeconds(0.35f);
        BarFiller();
        ColorChanger();
        yield return new WaitForSeconds(BarWaitTime);
        SusBar.SetActive(false);
    }
}
