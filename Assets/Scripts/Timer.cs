using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image uiFill;
    [SerializeField] private TMP_Text uiText;
    private GameBehavior _gameBehavior;

    public int duration;

    private int remainingDuration;

    private void Start()
    {
        _gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _gameBehavior.IsTalking)
        {
            Being(duration);
        }
    }

    private void Being(int seconds)
    {
        remainingDuration = seconds;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";

            //interpolacion inversa
            uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        _gameBehavior.TimeIsOver = true;
    }
}

