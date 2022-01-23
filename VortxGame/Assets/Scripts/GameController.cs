using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
  [Header("--- UI Elements ---")]
  [SerializeField] TextMeshProUGUI totalScoreTxt;
  [SerializeField] GameObject mainMenu;
  [SerializeField] Slider gameLvlSlider;
  [SerializeField] TextMeshProUGUI gameLvlTxt;
  [SerializeField] TMP_InputField nameField;
  [SerializeField] GameObject gameOver;
  [SerializeField] GameObject advLevel;
  [SerializeField] GameObject scoreObj;
  [SerializeField] GameObject interactivePanel;

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
    FindObjectOfType<StopWatch>().StartTimer();

    if(SceneManager.GetActiveScene().name == "Home")
    {
      scoreObj.SetActive(false);
    }
  }

  public void StartGame()
  {
    mainMenu.SetActive(false);
    interactivePanel.SetActive(true);
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
    FindObjectOfType<StopWatch>().StopTimer();
    advLevel.SetActive(true);
  }

  public void RestartLevel(string level)
  {
    SceneManager.LoadScene(level);
  }

  public void AdvanceLevel(string level)
  {
    if(World.phase == 1)
    {
      World.lupas += totalScore;
    }
    if (World.phase == 2)
    {
      World.lampada += totalScore;
    }
    else
    {
      World.ferramenta += totalScore;
    }

    SceneManager.LoadScene(level);
  }

  public void UpdateGameLevel()
  {
    World.gamelvl = (int)gameLvlSlider.value;

    if(World.gamelvl == 1)
    {
      gameLvlTxt.text = "Horizonte 1";
    }
    else if (World.gamelvl == 2)
    {
      gameLvlTxt.text = "Horizonte 2";
    }
    else
    {
      gameLvlTxt.text = "Horizonte 3";
    }
  }

  public void UpdatePlayerName()
  {
    World.playerName = nameField.text;
  }
}
