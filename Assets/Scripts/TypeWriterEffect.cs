using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(routine: TypeText(textToType,textLabel));
        
    }
   
    [SerializeField]private float tspeed = 100f;


    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        
        //yield return new WaitForSeconds(2);
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * tspeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }

        textLabel.text = textToType;

    }
}
