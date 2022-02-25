using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    private TypeWriterEffect typewritereffect;
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private DialogueScript testdialogue;

    public bool IsOpen { get; private set; }
    private void Start()
    {
        typewritereffect = GetComponent<TypeWriterEffect>();
        IsOpen = false;
        ShowDialogue(testdialogue);
    }

    public void ShowDialogue(DialogueScript dialogueObject)
    {
        StartCoroutine(StepThroughDialogue(dialogueObject)); 
    }

    private IEnumerator StepThroughDialogue(DialogueScript dialogueObject)
    {
        yield return new WaitForSeconds(1);
        dialogueBox.SetActive(true);
        foreach (string d in dialogueObject.Dialogue)
        {
            yield return typewritereffect.Run(d, textLabel);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return new WaitForSeconds(1);
        }
        CloseDialogueBox();
        
    }

    public void CloseDialogueBox()
    {
        BanditMovement bandit = new BanditMovement();
        bandit.Hareket();
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
    private void Update()
    {

        //if (Time.realtimeSinceStartup > 2)
        //{
        //    ShowDialogue(testdialogue);
        //    IsOpen = true;
        //}
    }
}
