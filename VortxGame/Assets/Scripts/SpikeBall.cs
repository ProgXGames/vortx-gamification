using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
  public float speed;
  public bool dirRight;

  void Start()
  {
    
  }

  private void Update()
  {
    if (dirRight)
    {
      transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    else
    {
      transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.layer == 10)
    {
      Destroy(gameObject);
    }
  }
}
