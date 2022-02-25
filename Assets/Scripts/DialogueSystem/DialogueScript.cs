using UnityEngine;

[CreateAssetMenu( menuName = "Dialogue/DialogueObject")]
public class DialogueScript : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
