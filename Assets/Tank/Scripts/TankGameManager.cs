using System.Reflection;
using TMPro;
using UnityEngine;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool debug = true;

    static TankGameManager instance;
    public static TankGameManager Instance {
        get 
        {
            if (instance == null) instance = FindFirstObjectByType<TankGameManager>();
            return instance; 
        } 
    }
    public int score { get; set; } = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = (debug) ? 1.0f : 0.0f;
        titlePanel.SetActive(!debug); 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("00000");
    }

    public void OnGameStart()
    {
        print("game started");
        titlePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnGameWin()
    {
        Time.timeScale = 0.0f;
    }
}
