using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  private Animator anim;

  public bool isFireOn = false;
  public float timer;

  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (isFireOn)
    {
      timer += Time.deltaTime;
      if (timer >= 1.5f)
      {
        timer = 0;
        TurnFireOff();
      }
    }
  }

  public void TurnFireOn()
  {
    isFireOn = true;
    anim.SetBool("onFire", true);
  }

  public void TurnFireOff()
  {
    isFireOn = false;
    anim.SetBool("onFire", false);
  }
}
