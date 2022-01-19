using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
  [Header("--- GameObjects ---")]
  private SpriteRenderer sr;
  private CircleCollider2D cc;
  private GameObject collected;

  [Header("--- Item value ---")]
  public int score;

  // Start is called before the first frame update
  void Start()
  {
    sr = GetComponent<SpriteRenderer>();
    cc = GetComponent<CircleCollider2D>();
    collected = gameObject.transform.GetChild(0).gameObject;
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    if(collider.gameObject.tag == "Player")
    {
      sr.enabled = false;
      cc.enabled = false;
      collected.SetActive(true);

      GameController.instance.totalScore += score;
      GameController.instance.UpdateScoreText();

      Destroy(gameObject, 0.25f); // Destroy gameObject after 0.25 seconds
    }
  }
}
