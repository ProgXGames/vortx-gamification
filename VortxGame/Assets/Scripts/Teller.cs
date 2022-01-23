using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Teller : MonoBehaviour
{
  [Header("--- Teller Id ---")]
  [Tooltip("Teller main identifier, can not be equal to another one")]
  [Range(1,8)]
  public int id;

  [Header("--- Chat objects ---")]
  [SerializeField] GameObject chatPanel;
  [SerializeField] TextMeshProUGUI textToDisplay;
  public Button chatPanelNextButton;

  [Space(20)]
  [Tooltip("Teller voice")]
  [SerializeField] AudioSource voice;

  [Space(20)]
  [Tooltip("Text display speed on the screen")]
  [Range(0.05f, 0.10f)]
  public float dialogSpeed;

  [Space(20)]
  [TextArea]
  public string[] sentences;
  private int dialogAuxiliar = 0;
  private int index = 0;

  private bool showingDialog = false;

  // Start is called before the first frame update
  void Start()
  {
    if(id > 4)
    {
      StartDialogue();
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && !showingDialog)
    {
      chatPanel.SetActive(true);
      showingDialog = true;
      StartCoroutine(Dialog());
    }
  }

  IEnumerator Dialog()
  {
    voice.Play();
    textToDisplay.text = "";
    chatPanelNextButton.interactable = false;

    foreach (char letter in sentences[index].ToCharArray())
    {
      if(letter == '@')
      {
        textToDisplay.text += World.playerName;
      }
      else
      {
        textToDisplay.text += letter;
      }

      yield return new WaitForSeconds(dialogSpeed);
    }

    chatPanelNextButton.interactable = true;
  }

  public void AdvanceDialog()
  {
    index++;
    dialogAuxiliar++;

    if(index >= sentences.Length)
    {
      chatPanel.SetActive(false);
      index = 0;
      dialogAuxiliar = 0;
      showingDialog = false;
      return;
    }

    StartCoroutine(Dialog());
  }

  void StartDialogue()
  {
    StartCoroutine(Dialog());
  }
}
