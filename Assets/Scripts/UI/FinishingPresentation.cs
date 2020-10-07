using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishingPresentation : MonoBehaviour
{
    public int MaxJoyValue { get; set; }
    public JoyBar _joyBar;
    public Image _progressBar;
    public Text _bonusScoreText;
    public Text _remainingTimeText;
    public Text _arigatouText;

    private ScoreManager _scoreManager;
    private StageTimer _stageTimer;
    private Animator _animator;
    private GameObject _goToNextLevel;

    private int _scoreBeforeTimeBonus = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();

        _stageTimer = FindObjectOfType<StageTimer>();
        
        _animator = GetComponent<Animator>();

        _goToNextLevel = GetComponentInChildren<GoToNextLevel>().gameObject;
        _goToNextLevel.gameObject.SetActive(false);

        _joyBar.OnFinishedFillingBar += StartAnimation;
    }

    public void LoseAnimation() {
        _animator.SetTrigger("lose");
    }

    public void WinAnimation() {
        StartCoroutine(WinAnimationCoroutine());
    }

    private IEnumerator WinAnimationCoroutine() {
        _joyBar.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.5f);
        StartFillingJoyBar();
    }

    private void StartFillingJoyBar()
    {
        _joyBar.SetNewTarget(_scoreBeforeTimeBonus,_scoreManager.Score, MaxJoyValue);
        _scoreBeforeTimeBonus = _scoreManager.Score;
    }

    private void StartAnimation() {
        _animator.SetTrigger("win");
    }

    public void ShowRemainingTime() {
        _remainingTimeText.text = "Remaining time: " + _stageTimer.GetRemainingTime()+" sec";
    }

    public void ShowScore() {
        _bonusScoreText.text = "Time bonus: " + _scoreManager.GetTimeBonus();
    }

    public void ApplyTimeBonusToScore() {
        _scoreManager.IncreaseScore(_scoreManager.GetTimeBonus());
        _joyBar.OnFinishedFillingBar -= StartAnimation;
        _joyBar.OnFinishedFillingBar += ActivateGoToNextLevel;
    }

    private void ActivateGoToNextLevel() {
        _arigatouText.gameObject.SetActive(true);
        _remainingTimeText.gameObject.SetActive(false);
        _bonusScoreText.gameObject.SetActive(false);
        _goToNextLevel.SetActive(true);
    }

}
