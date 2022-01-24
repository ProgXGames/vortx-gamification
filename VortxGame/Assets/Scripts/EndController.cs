using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
  [Header("--- End Game Sounds ---")]
  public AudioSource windSound;
  public AudioSource looseSound;

  [Header("--- Answer Images ---")]
  [SerializeField] Image positive1;
  [SerializeField] Image positive2;
  [SerializeField] Image positive3;
  [SerializeField] Image positive4;

  void Start()
  {

  }

  void Update()
  {

  }
}
