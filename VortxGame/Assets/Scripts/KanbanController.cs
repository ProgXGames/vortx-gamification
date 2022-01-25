using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KanbanController : MonoBehaviour
{
  [Header("--- Slider ---")]
  [SerializeField] Slider kanbanSlider;

  [Header("--- Card Elements ---")]
  [SerializeField] TextMeshProUGUI playerProduct;
  [SerializeField] TextMeshProUGUI playerName;

  float valueAux = 1f;

  void Start()
  {
    playerName.text = World.playerName;
    playerProduct.text = World.playerProduct;

    if(World.level == 1)
    {
      kanbanSlider.value = 1f;
      World.level++;
      valueAux = 1.85f;
    }
    else if (World.level == 2)
    {
      kanbanSlider.value = 1.85f;
      World.level++;
      valueAux = 2.7f;
    }
    else if (World.level == 3)
    {
      kanbanSlider.value = 2.7f;
      World.level++;
      valueAux = 3.49f;
    }
    else
    {
      kanbanSlider.value = 3.49f;
      valueAux = 3.49f;
      World.level = 0;
    }

    StartCoroutine(Advance());
  }

  void Update()
  {

  }

  IEnumerator Advance()
  {
    float contador = kanbanSlider.value;

    do
    {
      contador += 0.01f;
      kanbanSlider.value = contador;

      yield return new WaitForSeconds(0.02f);
    } while (contador <= valueAux);

    StartCoroutine(AdvanceForTheNextLevel());
  }

  IEnumerator AdvanceForTheNextLevel()
  {
    if(World.level == 2)
    {
      NextLevel("Dev - Lvl2");
    }
    else if (World.level == 3)
    {
      NextLevel("Dev - Lvl3");
    }
    else
    {
      NextLevel("Dev - Lvl4");
    }

    yield return new WaitForSeconds(2f);
  }

  void NextLevel(string name)
  {
    FindObjectOfType<SceneLoader>().LoadSceneByName(name);
  }
}
