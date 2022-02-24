using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    private TypeWriterEffect typewritereffect;
    [SerializeField] private DialogueScript testDialogue;
    [SerializeField] private GameObject dialogueBox;
    private void Start()
    {
        typewritereffect = GetComponent<TypeWriterEffect>();
        CloseDiaglogueBox();
        ShowDialogue(testDialogue);
        
    }

    public void ShowDialogue(DialogueScript dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueScript dialogueObject)
    {
        //yield return new WaitForSeconds(2);
        foreach (string d in dialogueObject.Dialogue)
        {
            yield return typewritereffect.Run(d, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDiaglogueBox();
    }

    private void CloseDiaglogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
