using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{
  [Header("Time General Variables")]
  float currentTime;
  bool stopWatchOn = false;
  bool isPaused = false;
  TimeSpan time;

  [Header("StopWatch exhibition")]
  [SerializeField] TextMeshProUGUI currentTimeTxt;

  // Start is called before the first frame update
  void Start()
  {
    currentTime = 0;
  }

  // Update is called once per frame
  void Update()
  {
    if (stopWatchOn)
    {
      currentTime += Time.deltaTime;
    }
    time = TimeSpan.FromSeconds(currentTime);
    currentTimeTxt.text = time.ToString(@"mm\:ss\.fff");
  }

  public void StartTimer()
  {
    if (isPaused)
    {
      isPaused = false;
    }
    stopWatchOn = true;
  }

  public void StopTimer()
  {
    stopWatchOn = false;
    isPaused = true;
  }

  public TimeSpan GetCurrentTime()
  {
    return time;
  }

  public void ResetStopWatch(bool stillRunning = true)
  {
    stopWatchOn = stillRunning;
    isPaused = false;
    currentTime = 0;
  }
}
