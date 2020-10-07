using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSettings : MonoBehaviour
{
    public StageSettingsData _stageData;
    private FinishingPresentation _finishingPresentation;
    private ScoreManager _scoreManager;
    private TrashBar _stageManager;
    private StageTimer _stageTimer;
    private PieceSpawner _pieceSpawner;
    
    void Awake()
    {
        _finishingPresentation = FindObjectOfType<FinishingPresentation>();
        if (_finishingPresentation != null)
        {
            _finishingPresentation.MaxJoyValue = _stageData.MaxJoyValue;
        }

        _scoreManager = FindObjectOfType<ScoreManager>();
        if (_scoreManager != null)
        {
            _scoreManager.ScorePerRemaniningSecond = _stageData.BonusPerRemainingSecond;
        }

        _stageManager = FindObjectOfType<TrashBar>();
        if (_stageManager != null)
        {
            _stageManager.ItemsToWin = _stageData.ItemsToWin;
        }

        _stageTimer = FindObjectOfType<StageTimer>();
        if (_stageTimer != null)
        {
            _stageTimer.TimeInSeconds = _stageData.TimeInSeconds;
        }

        _pieceSpawner = FindObjectOfType<PieceSpawner>();
        if (_pieceSpawner != null)
        {
            _pieceSpawner.PieceDropSpeed = _stageData.DropInterval;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
