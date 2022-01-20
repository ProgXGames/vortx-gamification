using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
  public float speed;
  public float moveTime;

  public bool dirRight = true;
  public float timer;

  void Update()
  {
    if (dirRight) // Go to right
    {
      transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    else // Go to left
    {
      transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    timer += Time.deltaTime;
    if(timer >= moveTime)
    {
      dirRight = !dirRight;
      timer = 0;
    }
  }
}
