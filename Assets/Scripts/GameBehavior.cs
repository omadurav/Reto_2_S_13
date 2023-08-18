using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystemWithText;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private DialogueUIController _dialogueUIController;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detectado");
            _dialogueUIController.ShowDialogueUI();
        }
    }
}
