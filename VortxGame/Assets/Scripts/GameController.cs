using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
  [Header("--- UI Elements ---")]
  [SerializeField] TextMeshProUGUI totalScoreTxt;
  [SerializeField] GameObject mainMenu;

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

  public void UpdateScoreText()
  {
    totalScoreTxt.text = totalScore.ToString();
  }
}
