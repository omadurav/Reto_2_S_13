using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private Image _timer;
    [SerializeField] private TMP_Text _txtPressQ;
    [SerializeField] private TMP_Text _txtTotalItems;
    [SerializeField] private TMP_Text _txtCurrentCollected;
    [SerializeField] private GameObject _panelItemsComplete;
    [SerializeField] private GameObject _panelWinner;
    [SerializeField] private GameObject _panelLoser;
    [SerializeField] private GameObject _panelPause;

    private int _totalItemsInScene;
    private int _currentCollected = 0;
    private bool _isTalking = false;
    private bool inMission = false;
    private bool _timeIsOver = false;
    private bool _winner = false;
    private bool isPaused = false;

    public bool IsTalking { get => _isTalking; set => _isTalking = value; }
    public bool InMission { get => inMission; set => inMission = value; }
    public int TotalItemsInScene { get => _totalItemsInScene; set => _totalItemsInScene = value; }
    public bool TimeIsOver { get => _timeIsOver; set => _timeIsOver = value; }
    public bool Winner { get => _winner; set => _winner = value; }

    public int CurrentCollected
    {
        get { return _currentCollected; }
        set
        {
            _currentCollected = value;
            _txtCurrentCollected.text = $"Elementos recolectados: {_currentCollected}";

            if (_totalItemsInScene == _currentCollected)
            {
                _panelItemsComplete.gameObject.SetActive(true);
                Invoke("DisableMessageOfComplete", 3f);
            }
        }
    }

    private void Start()
    {
        _isTalking = false;
        _totalItemsInScene = GameObject.FindGameObjectsWithTag("Trash").Length;
        _txtTotalItems.text += _totalItemsInScene.ToString();
        _txtCurrentCollected.text = $"Elementos recolectados: {_currentCollected}";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && _isTalking)
        {
            ShowTime();
            _txtPressQ.gameObject.SetActive(false);
            _txtTotalItems.gameObject.SetActive(true);
            _txtCurrentCollected.gameObject.SetActive(true);
            InMission = true;
        }

        if (_winner)
        {
            _panelWinner.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (_timeIsOver)
        {
            _panelLoser.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ShowPressF()
    {
        _txtPressQ.gameObject.SetActive(true);
    }

    private void ShowTime()
    {
        _timer.gameObject.SetActive(true);
    }


    private void DisableMessageOfComplete()
    {
        _panelItemsComplete.gameObject.SetActive(false);
    }

    public void RestartScene()
    {
        _winner = false;
        _timeIsOver = false;
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }

    public void Pause()
    {
        if(isPaused == false)
        {
            Time.timeScale = 0f;
            isPaused = true;
            _panelPause.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
            _panelPause.gameObject.SetActive(false);
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
        isPaused = false;
        Time.timeScale = 1f;
    }


}
