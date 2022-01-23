using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanbanController : MonoBehaviour
{
  [SerializeField] Slider kanbanSlider;

  float valueAux = 1f;

  void Start()
  {
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
  }
}
