using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
  [Header("--- Player Info ---")]
  public static string playerName;
  public static string playerProduct;

  [Header("--- Game Stats ---")]
  public static int phase;
  public static int level;
  public static int gamelvl;

  [Header("--- Phase Items ---")]
  public static int lupas;
  public static int lampada;
  public static int ferramenta;

  static World()
  {
    level = 1;
    phase = 1;
    gamelvl = 1;

    lupas = 0;
    lampada = 0;
    ferramenta = 0;
  }

  public static void ResetGame()
  {
    level = 1;
    phase = 1;
    gamelvl = 1;

    lupas = 0;
    lampada = 0;
    ferramenta = 0;
  }
}
