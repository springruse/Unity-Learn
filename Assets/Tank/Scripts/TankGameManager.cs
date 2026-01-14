using System.Reflection;
using TMPro;
using UnityEngine;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] TMP_Text scoreText;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("1337");
    }

    public void OnGameStart()
    {
        titlePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
