using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class JoyBar : MonoBehaviour
{
    public Image _progressBar;
    private bool _inProgressBarAnimation = false;
    private float _lastLerpTime;

    public int TargetScore { get; set; }
    public int Origin { get; set; }
    public int MaxJoy { get; set; }

    public UnityAction OnFinishedFillingBar { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (_inProgressBarAnimation)
        {
            float scor = Mathf.Lerp(Origin, TargetScore, Time.timeSinceLevelLoad - _lastLerpTime);

            if (Mathf.Abs(scor - TargetScore) < 0.5f)
            {
                scor = TargetScore;
                _inProgressBarAnimation = false;
                if (OnFinishedFillingBar != null)
                {
                    OnFinishedFillingBar.Invoke();
                }
            }
            _progressBar.fillAmount = scor / MaxJoy;

        }
    }
    public void SetNewTarget(int origin, int newScore, int maxJoy)
    {
        Origin = origin;
        TargetScore = newScore;
        MaxJoy = maxJoy;
        _inProgressBarAnimation = true;
        _lastLerpTime = Time.timeSinceLevelLoad;

    }

}
