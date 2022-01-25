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
  [SerializeField] GameObject titlePanel;
  [SerializeField] GameObject mainMenu;
  [SerializeField] GameObject mainMenuPanel2;
  [SerializeField] GameObject credits;
  [SerializeField] Slider gameLvlSlider;
  [SerializeField] TextMeshProUGUI gameLvlTxt;
  [SerializeField] TMP_InputField nameField;
  [SerializeField] TMP_InputField productField;
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

  public bool isMainMenuOpen = false;

  [Header("--- Sounds ---")]
  [SerializeField] AudioSource winSound;
  [SerializeField] AudioSource looseSound;
  private bool playedSound = false;

  // Start is called before the first frame update
  void Start()
  {
    instance = this;
    FindObjectOfType<StopWatch>().StartTimer();

    if (SceneManager.GetActiveScene().name == "Home")
    {
      scoreObj.SetActive(false);
      if(World.phase == 1)
      {
        isMainMenuOpen = true;
      }
      else
      {
        isMainMenuOpen = false;
        mainMenu.SetActive(false);
        titlePanel.SetActive(false);
      }
    }
  }

  public void OpenMainMenuSecondPanel()
  {
    mainMenu.SetActive(false);
    mainMenuPanel2.SetActive(true);
  }

  public void StartGame()
  {
    titlePanel.SetActive(false);
    mainMenu.SetActive(false);
    mainMenuPanel2.SetActive(false);
    interactivePanel.SetActive(true);
    isMainMenuOpen = false;
    Instantiate(player);
  }

  public void OpenCredits()
  {
    credits.SetActive(true);
    mainMenu.SetActive(false);
  }

  public void CloseCredits()
  {
    credits.SetActive(false);
    mainMenu.SetActive(true);
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
    if (!playedSound)
    {
      playedSound = true;
      looseSound.Play();
    }
  }

  public void ShowAdvanceLevel()
  {
    FindObjectOfType<StopWatch>().StopTimer();
    advLevel.SetActive(true);
    if (!playedSound)
    {
      playedSound = true;
      winSound.Play();
    }
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
      gameLvlTxt.text = "Horizonte 1 - Aperfeiçoamento operacional, mercados que geram renda atualmente";
    }
    else if (World.gamelvl == 2)
    {
      gameLvlTxt.text = "Horizonte 2 - Expansão adjacente, mercados conhecidos";
    }
    else
    {
      gameLvlTxt.text = "Horizonte 3 - Inovação, mercados desconhecidos";
    }
  }

  public void UpdatePlayerName()
  {
    World.playerName = nameField.text;
  }

  public void UpdateProductName()
  {
    World.playerProduct = productField.text;
  }

  public bool GetIsMainMenuOpen()
  {
    return isMainMenuOpen;
  }
}
