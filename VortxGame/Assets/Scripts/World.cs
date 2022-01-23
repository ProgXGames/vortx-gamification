using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
  [Header("--- Player Info ---")]
  public static string playerName;

  [Header("--- Game Stats ---")]
  public static int phase;
  public static int gamelvl;

  [Header("--- Phase Items ---")]
  public static int lupas;
  public static int lampada;
  public static int ferramenta;

  static World()
  {
    phase = 1;
    gamelvl = 1;
  }
}
