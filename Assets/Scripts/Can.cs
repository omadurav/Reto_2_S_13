using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    private GameBehavior _gameBehavior;
    void Start()
    {
        _gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_gameBehavior.InMission)
            {
                _gameBehavior.CurrentCollected++;
                Destroy(this.gameObject);
            }

        }
    }
}
