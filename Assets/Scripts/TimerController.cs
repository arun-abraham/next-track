using UnityEngine;
using UnityEngine.UI;

/*
 * Either get a reference to this component in the game manager or use
 * Send/BroadcastMessage to SetDuration, StartTimer, StopTimer, ResetTimer.
 *
 * On timer expiration, broadcasts TimerExpired message.
 */

public class TimerController : MonoBehaviour {

  private bool isRunning;
  private float duration;
  private float remaining;
  private float startedAt;
  private Text textComponent;

  // Use this for initialization
  void Start () {
    textComponent = GetComponent<Text>();
  }

  // Update is called once per frame
  void Update () {
    if (isRunning) {
      remaining -= Time.deltaTime;
    }
    if (remaining <= 0 && isRunning) {
      isRunning = false;
      remaining = 0;
      BroadcastMessage("TimerExpired");
    }
    updateText();
  }

  public void SetDuration(float newDuration) {
    duration = newDuration;
  }

  public void AddTime(float seconds) {
    remaining += seconds;
  }

  public void StartTimer() {
    isRunning = true;
  }

  public void StopTimer() {
    isRunning = false;
  }

  public void ResetTimer() {
    textComponent.text = duration.ToString();
    remaining = duration;
  }

  void updateText() {
    float time = remaining < 0 ? 0 : remaining;
    textComponent.text = Mathf.Round(time).ToString();
  }
}