using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private float timeStart;
    [SerializeField] private TMP_Text textSec;

    [SerializeField] private TMP_Text pointsForKill;
    int _points = 0;

    [SerializeField] private GameObject pausePanel;

    private void Awake() => instance = this;

    private void Start()
    {
        Time.timeScale = 1;
        textSec.text = timeStart.ToString("F2");

        pointsForKill.text = _points.ToString() + " POINTS";
    }

    private void Update() => GameTime();

    private void GameTime()
    {
        timeStart += Time.deltaTime;
        textSec.text = timeStart.ToString("F2");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void ExitGame() => Application.Quit();

    public void AddPoint()
    {
        if(_points >= 10)
            Time.timeScale = 0;

        _points++;
        pointsForKill.text = _points.ToString() + " POINTS";
    }
}
