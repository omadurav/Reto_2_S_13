using DialogueSystemWithText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciTrash : MonoBehaviour
{
    [SerializeField] private DialogueUIController _dialogueUIController;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip _audioClipWinner;

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
                SoundController.instance.PlaySound(_audioClip);
            }
            else
            {
                if (_gameBehavior.TotalItemsInScene == _gameBehavior.CurrentCollected)
                {
                    SoundController.instance.PlaySound(_audioClipWinner);
                    _gameBehavior.Winner = true;
                }
            }
        }
    }
}
