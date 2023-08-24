using DialogueSystemWithText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciTrashN2 : MonoBehaviour
{
    [SerializeField] private DialogueUIController _dialogueUIController;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _dialogueUIController.ShowDialogueUI();
        }
    }
}
