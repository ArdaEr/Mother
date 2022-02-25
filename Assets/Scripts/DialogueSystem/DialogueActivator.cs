using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueScript dialogueObject;
    public void Interact(CharacterMovement player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Karakter") && collision.TryGetComponent(out CharacterMovement player))
    //    {
    //        player.Interactable = this;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Karakter") && collision.TryGetComponent(out CharacterMovement player))
    //    {
    //        if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
    //        {
    //            player.Interactable = this;
    //        }
    //    }
    //}
}
