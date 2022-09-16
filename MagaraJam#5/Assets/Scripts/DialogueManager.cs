using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Dialogue[] currentDialogs;
    private ChoiceMaker choiceMaker;

    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;

    public float typeSpeed;
    public int dialogCount;
    public int maxDialogCount;
    public string context;
    public bool isThereChoice;

    public DialogueStarter firstDialog;
    public DialogueStarter dolapDialog;


    private void Start()
    {
        sentences = new Queue<string>();
        choiceMaker = FindObjectOfType<ChoiceMaker>();
        firstDialog.TriggerDialog();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }
    
    public void StartDialog(Dialogue[] dialog, bool choice)
    {
        Debug.Log(choice);
        isThereChoice = choice;
        currentDialogs = dialog;
        animator.SetBool("isOpen", true);
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        nameText.text = dialog[dialogCount].name;
        sentences.Clear();

        foreach (string sentence in dialog[dialogCount].sentences)
        {
            sentences.Enqueue(sentence);
        }
        if(sentences.Count != 0)
            sentences.Dequeue();

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        if (sentences.Count == 0)
        {
            dialogCount++;
            StartDialog(currentDialogs, isThereChoice);
        }
        else
        {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void EndDialog()
    {
        animator.SetBool("isOpen", false);
        if (isThereChoice == true)
            choiceMaker.OpenChoiceScreen();
        isThereChoice = false;
    }

}
