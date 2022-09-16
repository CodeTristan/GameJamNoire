using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceMaker : MonoBehaviour
{
    
    public GameObject choiceScreen;
    public TextMeshProUGUI ChoiceText1;
    public TextMeshProUGUI ChoiceText2;
    public TextMeshProUGUI ChoiceText3;

    public string choiceName;

    private SuspicionBar suspicionBar;

    [Header("Booleans")]
    public bool dolapOpened;
    public bool dolapDestroyed;
    public bool phdDestroyed;
    public bool phdSwapped;
    public bool cesetBullet;
    public bool cesetCrucified;

    [Header("Dolap Dialogues")]
    public DialogueStarter dolapDialog1;
    public DialogueStarter afterDolapDialog1Opened;
    public DialogueStarter afterDolapDialog1Destroyed;
    public DialogueStarter dolapDialogOpened;
    public DialogueStarter dolapDialogDestroyed;
    public DialogueStarter dolapCesetCrucified;

    [Header("Phd Dialogues")]
    public DialogueStarter phdDialog1;
    public DialogueStarter afterPhdDialog1Destroyed;
    public DialogueStarter afterPhdDialog1Swapped;
    public DialogueStarter phdDialogDestroyed;
    public DialogueStarter phdDialogSwapped;

    [Header("Ceset Dialogues")]
    public DialogueStarter cesetDialog1;
    public DialogueStarter afterCesetDialogBullet;
    public DialogueStarter afterCesetDialogCrucified;
    public DialogueStarter cesetDialogBullet;
    public DialogueStarter cesetDialogCrucified;


    private void Awake()
    {
        suspicionBar = FindObjectOfType<SuspicionBar>();
    }
    public void MakeChoice(string choiceName)
    {
        this.choiceName = choiceName;
        if(choiceName == "Dolap")
        {
            ChoiceText1.text = "Dolabı aç";
            ChoiceText2.text = "Dolabı yık";
            ChoiceText3.text = "Dolabı elleme";
            return;
            
        }
        if (choiceName == "Phd")
        {
            ChoiceText1.text = "Doktora plaketini yırt";
            ChoiceText2.text = "Doktora plaketini sahtesiyle değiştir";
            ChoiceText3.text = "Plaketi elleme";
            return;
        }
        if (choiceName == "Ceset")
        {
            ChoiceText1.text = "Mermi kovanlarını değiştir";
            ChoiceText2.text = "Ölüm pozisyonunu değiştir";
            ChoiceText3.text = "Ceseti rahat bırak";
            return;
        }
    }
    public void Choice1()
    {
        if(choiceName == "Dolap") //Dolabı Aç
        {
            if(cesetCrucified)
            {
                dolapCesetCrucified.TriggerDialog();
                choiceScreen.SetActive(false);
                return;
            }
            //Dolap açma sesi
            StartCoroutine(suspicionBar.SusBarFill());
            suspicionBar.currentPriestBar += 5;
            suspicionBar.currentMillonaireBar += 1;
            suspicionBar.currentPresidentBar += 2;
            suspicionBar.currentSuspicionBar += 0;
            dolapOpened = true;
            Destroy(dolapDialog1.gameObject);
            dolapDialogDestroyed.gameObject.SetActive(false);
            afterDolapDialog1Opened.TriggerDialog();
            choiceScreen.SetActive(false);
            return;
        }
        if (choiceName == "Phd") //Phd plaketini yırt
        {
            //Kağıt yırtma sesi
            StartCoroutine(suspicionBar.SusBarFill());
            suspicionBar.currentPriestBar += 3;
            suspicionBar.currentMillonaireBar += 0;
            suspicionBar.currentPresidentBar += 1;
            suspicionBar.currentSuspicionBar += 2;

            phdDestroyed = true;
            Destroy(phdDialog1.gameObject);
            phdDialogSwapped.gameObject.SetActive(false);
            afterPhdDialog1Destroyed.TriggerDialog();
            choiceScreen.SetActive(false);
            return;
        }
        if (choiceName == "Ceset") //Mermi kovanlarını değiştir
        {
            
            StartCoroutine(suspicionBar.SusBarFill());
            suspicionBar.currentPriestBar += 1;
            suspicionBar.currentMillonaireBar += 3;
            suspicionBar.currentPresidentBar += 5;
            suspicionBar.currentSuspicionBar += 8;

            phdDestroyed = true;
            Destroy(phdDialog1.gameObject);
            phdDialogSwapped.gameObject.SetActive(false);
            afterPhdDialog1Destroyed.TriggerDialog();
            choiceScreen.SetActive(false);
            return;
        }

    }
    public void Choice2()
    {
        if (choiceName == "Dolap") //Dolabı yık
        {
            //Dolap kırma sesi
            //Dolap kırılmış resim
            StartCoroutine(suspicionBar.SusBarFill());
            suspicionBar.currentPriestBar += 1;
            suspicionBar.currentMillonaireBar += 3;
            suspicionBar.currentPresidentBar += 0;
            suspicionBar.currentSuspicionBar += 4;
            dolapDestroyed = true;
            Destroy(dolapDialog1.gameObject);
            dolapDialogOpened.gameObject.SetActive(false);
            afterDolapDialog1Destroyed.TriggerDialog();
            choiceScreen.SetActive(false);
            return;
        }
        if (choiceName == "Phd") //Phd plaketini değiştir
        {
            //Kağıt sesi
            StartCoroutine(suspicionBar.SusBarFill());
            suspicionBar.currentPriestBar += 2;
            suspicionBar.currentMillonaireBar += 0;
            suspicionBar.currentPresidentBar += 3;
            suspicionBar.currentSuspicionBar += 1;

            phdSwapped = true;
            Destroy(phdDialog1.gameObject);
            phdDialogDestroyed.gameObject.SetActive(false);
            afterPhdDialog1Swapped.TriggerDialog();
            choiceScreen.SetActive(false);
            return;
        }
        
    }
    public void Choice3()
    {
        choiceScreen.SetActive(false);
    }
    public void OpenChoiceScreen()
    {
        choiceScreen.SetActive(true);
    }
}
