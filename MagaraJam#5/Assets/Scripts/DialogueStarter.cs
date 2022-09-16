using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public string Context;
    public bool isThereChoiceAfterwards;
    public Dialogue[] dialog;
    public bool dialogFinished = false;

    private DialogueManager manager;
    private ChoiceMaker choiceMaker;
    private void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();
        choiceMaker = FindObjectOfType<ChoiceMaker>();
    }
    public void TriggerDialog()
    {
        manager.maxDialogCount = dialog.Length;
        manager.dialogCount = 0;
        manager.StartDialog(dialog, isThereChoiceAfterwards);
        manager.context = Context;
    }

    private void OnMouseDown()
    {
        if(Context == "Dolap1")
        {
            TriggerDialog();
            choiceMaker.MakeChoice("Dolap");
            return;
        }
        if (Context == "Dolap2")
        {
            TriggerDialog();
            return;
        }
        if (Context == "Phd")
        {
            TriggerDialog();
            choiceMaker.MakeChoice("Phd");
            return;
        }
        if (Context == "Phd2")
        {
            TriggerDialog();
            return;
        }
        if (Context == "Ceset")
        {
            TriggerDialog();
            choiceMaker.MakeChoice("Ceset");
            return;
        }
    }
}
