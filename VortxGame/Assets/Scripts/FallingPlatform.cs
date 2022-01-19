using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
  [Header("--- GameObjects ---")]
  private TargetJoint2D joint;
  private SpriteRenderer sr;
  private BoxCollider2D box;

  [Header("--- Falling Time ---")]
  public float fallingTime;

  // Start is called before the first frame update
  void Start()
  {
    joint = GetComponent<TargetJoint2D>();
    box = GetComponent<BoxCollider2D>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      Invoke("Falling", fallingTime); // Chamando método apóx X segundos;
    }
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.layer == 9)
    {
      Destroy(gameObject);
    }
  }

  void Falling()
  {
    joint.enabled = false;
    box.isTrigger = true;
  }
}
