using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

  [Header("--- Player Health ---")]
  public bool hasHealth = false;
  public int health = 10;
  [SerializeField] Slider healthBar;

  [Header("--- Sounds ---")]
  private AudioSource hitSound;

  // Start is called before the first frame update
  void Start()
  {
    rig = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    
    hitSound = gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

    if (hasHealth)
    {
      if(World.gamelvl == 1)
      {
        healthBar.maxValue = 10;
        health = 10;
      }
      if (World.gamelvl == 2)
      {
        healthBar.maxValue = 7;
        health = 7;
      }
      else
      {
        healthBar.maxValue = 5;
        health = 5;
      }
      healthBar.value = health;
    }
  }

  // Update is called once per frame
  void Update()
  {
    Move();
    Jump();

    if (hasHealth)
    {
      healthBar.value = health;

      if(health <= 0)
      {
        Invoke("KillPlayer", 0.4f);
        GameController.instance.ShowGameOver();
      }
    }
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
      hitSound.Play();
      PlayerDamage(10);

      if(health <= 0)
      {
        Invoke("KillPlayer", 0.4f);
        GameController.instance.ShowGameOver();
      }
      else
      {
        Invoke("TurnOffHitAnimation", 0.4f);
      }
    }

    if(collision.gameObject.tag == "Saw")
    {
      anim.SetBool("hit", true);
      hitSound.Play();
      PlayerDamage(6);

      if (health <= 0)
      {
        Invoke("KillPlayer", 0.4f);
        GameController.instance.ShowGameOver();
      }
      else
      {
        Invoke("TurnOffHitAnimation", 0.4f);
      }
    }

    if(collision.gameObject.tag == "RockHead")
    {
      anim.SetBool("hit", true);
      hitSound.Play();
      PlayerDamage(8);

      if (health <= 0)
      {
        Invoke("KillPlayer", 0.4f);
        GameController.instance.ShowGameOver();
      }
      else
      {
        Invoke("TurnOffHitAnimation", 0.4f);
      }
    }
  }

  void OnCollisionExit2D(Collision2D collision)
  {
    isJumping = true;

    if(collision.gameObject.tag == "Fire")
    {
      isJumping = false;
    }
  }

  void KillPlayer()
  {
    Destroy(gameObject);
  }

  void TurnOffHitAnimation()
  {
    anim.SetBool("hit", false);
  }

  public void PlayerDamage(int damage)
  {
    health -= damage;
  }
}
