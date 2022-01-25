using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndController : MonoBehaviour
{
  [Header("--- End Game Sounds ---")]
  public AudioSource windSound;
  public AudioSource looseSound;

  [Header("--- Positive Answer Images ---")]
  [SerializeField] List<GameObject> positiveImgs;

  [Header("--- Negative Answer Images ---")]
  [SerializeField] List<GameObject> negativeImgs;

  [Header("--- TMPro ---")]
  [SerializeField] TextMeshProUGUI productName;
  [SerializeField] TextMeshProUGUI discTxt;
  [SerializeField] TextMeshProUGUI protTxt;
  [SerializeField] TextMeshProUGUI devTxt;
  [SerializeField] TextMeshProUGUI succTxt;

  [SerializeField] GameObject endGameBtn;

  bool aprov = true;

  void Start()
  {
    productName.text = World.playerProduct;

    // -- 100 itens para serem coletados ao longo de todo o jogo -- //
    StartCoroutine(Result());
  }

  void Update()
  {

  }

  IEnumerator Result()
  {
    int contador = 0;

    do
    {
      yield return new WaitForSeconds(1.5f);

      if (World.gamelvl == 1) // -- H1 -- //
      {
        if(contador == 0)
        {
          if (World.lupas >= 30)
          {
            positiveImgs[contador].SetActive(true);
            windSound.Play();
          }
          else
          {
            negativeImgs[contador].SetActive(true);
            looseSound.Play();
            aprov = false;
            discTxt.text = "A sua etapa de discovery não foi bem realizada e, " +
              "por isso, você criou um produto que não resolvia uma grande dor do usuário.";
          }
        }
        else if (contador == 1)
        {
          if (World.lampada >= 30)
          {
            positiveImgs[contador].SetActive(true);
            windSound.Play();
          }
          else
          {
            negativeImgs[contador].SetActive(true);
            looseSound.Play();
            aprov = false;
            protTxt.text = "A sua etapa de prototipação não foi bem realizada e, " +
              "por isso, a equipe de desenvolvimento produziu um produto desconexo da sua ideia inicial.";
          }
        }
        else
        {
          if (World.ferramenta >= 50)
          {
            positiveImgs[contador].SetActive(true);
            windSound.Play();
          }
          else
          {
            negativeImgs[contador].SetActive(true);
            looseSound.Play();
            aprov = false;
            devTxt.text = "A etapa de desenvolvimento não foi bem realizada e, " +
              "por isso, o novo produto subiu com vários bugs e erros.";
          }
        }
      }
      else if (World.gamelvl == 2) // -- H2 -- //
      {

      }
      else // -- H3 -- //
      {

      }

      contador++;
    } while (contador < 3);

    if (aprov)
    {
      succTxt.text = "Aprovado!";
    }

    endGameBtn.SetActive(true);
  }

  public void EndGame()
  {
    Application.Quit();
  }
}
