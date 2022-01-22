using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCanon : MonoBehaviour
{
  [Header("--- Ball obj variables ---")]
  [SerializeField] Transform ballSpawn;
  [SerializeField] GameObject ball;

  [Header("--- Cannon variables ---")]
  public float timeToShot;
  public float currentTime = 0f;
  
  void Update()
  {
    currentTime += Time.deltaTime;

    if(currentTime >= timeToShot)
    {
      Instantiate(ball, ballSpawn);
      currentTime = 0;
      Debug.Log("Ae");
    }
  }
}
