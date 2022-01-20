using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
  [Header("--- UI Elements ---")]
  [SerializeField] TextMeshProUGUI totalScoreTxt;
  [SerializeField] GameObject mainMenu;
  [SerializeField] GameObject gameOver;
  [SerializeField] GameObject advLevel;

  [Header("--- Player Total Score ---")]
  public int totalScore;

  [Header("--- Game Controller Instance ---")]
  public static GameController instance;

  public Transform playerRespawnPoint;
  public GameObject player;

  // Start is called before the first frame update
  void Start()
  {
    instance = this;
  }

  public void StartGame()
  {
    mainMenu.SetActive(false);
    Instantiate(player);
  }

  public void ExitGame()
  {
    Application.Quit();
  }

  public void UpdateScoreText()
  {
    totalScoreTxt.text = totalScore.ToString();
  }

  public void ShowGameOver()
  {
    gameOver.SetActive(true);
  }

  public void ShowAdvanceLevel()
  {
    advLevel.SetActive(true);
  }

  public void RestartLevel(string level)
  {
    SceneManager.LoadScene(level);
  }

  public void AdvanceLevel(string level)
  {
    SceneManager.LoadScene(level);
  }
}
