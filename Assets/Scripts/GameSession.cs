using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.1f,2f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int points;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI displayScore;
    [SerializeField] bool isAutoPlay;

    public void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }
    public void updatePoints()
    {
        points += pointsPerBlock;
        displayScore.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void resetGame()
    {
        Destroy(gameObject);
    }
    public bool GetIsAutoplay()
    {
        return isAutoPlay;
    }
}
