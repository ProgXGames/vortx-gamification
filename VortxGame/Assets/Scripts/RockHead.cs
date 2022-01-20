using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
  public float speed;
  public float moveTime;

  public bool dirDown = true;
  public float timer;

  private Animator anim;

  private void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    if (dirDown) // Go to right
    {
      transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    else // Go to left
    {
      transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    timer += Time.deltaTime;
    if (timer >= moveTime)
    {
      dirDown = !dirDown;
      timer = 0;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      anim.SetBool("hit", true);
      Invoke("TurnOffAnim", 1.5f);
    }
  }

  void TurnOffAnim()
  {
    anim.SetBool("hit", false);
  }
}
