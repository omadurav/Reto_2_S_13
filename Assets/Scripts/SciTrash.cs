using DialogueSystemWithText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciTrash : MonoBehaviour
{
    [SerializeField] private DialogueUIController _dialogueUIController;

    private GameBehavior _gameBehavior;

    private void Start()
    {
        _gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_gameBehavior.IsTalking)
            {
                _dialogueUIController.ShowDialogueUI();
                _gameBehavior.IsTalking = true;
            }
            else
            {
                if (_gameBehavior.TotalItemsInScene == _gameBehavior.CurrentCollected)
                {
                    _gameBehavior.Winner = true;
                }
            }
        }
    }
}
