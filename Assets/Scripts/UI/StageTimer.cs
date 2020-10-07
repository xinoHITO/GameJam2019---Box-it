using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class StageTimer : MonoBehaviour
{
    public Text _timerText;
    public float TimeInSeconds { get; set; }
    private float _currentTime;

    public UnityAction OnTimeIsUp { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _currentTime = TimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime -= Time.deltaTime;
        int timeToShow = Mathf.CeilToInt(_currentTime);
        _timerText.text = "" + timeToShow;

        if (timeToShow <= 0)
        {
            if (OnTimeIsUp != null)
            {
                OnTimeIsUp.Invoke();
            }
        }
    }

    public void DisableTimer() {
        _timerText.text = "";
        this.enabled = false;
    }

    public int GetRemainingTime() {
        return Mathf.CeilToInt(_currentTime);
    }
    
}
