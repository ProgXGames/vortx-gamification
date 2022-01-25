using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
  [Header("--- GameObjects ---")]
  private SpriteRenderer sr;
  private BoxCollider2D bc;
  private GameObject collected;

  [Header("--- Sounds ---")]
  private AudioSource collectedSound;

  [Header("--- Item value ---")]
  public int score;

  // Start is called before the first frame update
  void Start()
  {
    sr = GetComponent<SpriteRenderer>();
    bc = GetComponent<BoxCollider2D>();
    collected = gameObject.transform.GetChild(0).gameObject;
    collectedSound = gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == "Player")
    {
      sr.enabled = false;
      bc.enabled = false;
      collected.SetActive(true);
      collectedSound.Play();

      GameController.instance.totalScore += score;
      GameController.instance.UpdateScoreText();

      Destroy(gameObject, 0.25f); // Destroy gameObject after 0.25 seconds
    }
  }
}
