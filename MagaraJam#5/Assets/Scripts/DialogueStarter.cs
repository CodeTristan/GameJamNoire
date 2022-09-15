using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public string Context;
    public Dialogue[] dialog;
    public bool dialogFinished = false;

    private DialogueManager manager;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }
    public void TriggerDialog()
    {
        manager.maxDialogCount = dialog.Length;
        manager.dialogCount = 0;
        manager.StartDialog(dialog);
        manager.context = Context;
    }
}
