using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [Header("--- Player Movement ---")]
  public float speed;
  public float jumpForce;
  public bool isJumping;
  public bool doubleJumping;
  private Rigidbody2D rig;

  [Header("--- Player Animations ---")]
  private Animator anim;

  // Start is called before the first frame update
  void Start()
  {
    rig = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
    Jump();
  }

  void Move()
  {
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    transform.position += movement * Time.deltaTime * speed;

    if(Input.GetAxis("Horizontal") > 0f)
    {
      anim.SetBool("walk", true);
      transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    if (Input.GetAxis("Horizontal") < 0f)
    {
      anim.SetBool("walk", true);
      transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    if (Input.GetAxis("Horizontal") == 0f)
    {
      anim.SetBool("walk", false);
    }

  }

  void Jump()
  {
    if (Input.GetButtonDown("Jump"))
    {
      if (!isJumping)
      {
        rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        doubleJumping = true;
        anim.SetBool("jump", true);
      }
      else
      {
        if (doubleJumping)
        {
          rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  
          doubleJumping = false;
        }
      }
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.layer == 8)
    {
      isJumping = false;
      anim.SetBool("jump", false);
    }

    if(collision.gameObject.tag == "Spike")
    {
      anim.SetBool("hit", true);
      Invoke("KillPlayer", 0.4f);
      GameController.instance.ShowGameOver();
    }
  }

  void OnCollisionExit2D(Collision2D collision)
  {
    isJumping = true;
  }

  void KillPlayer()
  {
    Destroy(gameObject);
  }
}
