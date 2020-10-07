using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text _text;
    public int Score { get; set; }
    
    public int ScorePerRemaniningSecond { get; set; }
    private PieceSpawner _pieceSpawner;

    private ComboManager _comboManager;
    private StageTimer _stageTimer;

    // Start is called before the first frame update
    void Start()
    {
        _comboManager = GetComponent<ComboManager>();

        _pieceSpawner = FindObjectOfType<PieceSpawner>();
        _pieceSpawner.OnCreatedNewPiece += OnCreateNewPiece;
    
        
        _stageTimer = FindObjectOfType<StageTimer>();

    }

    private void OnCreateNewPiece(bool wasLastPieceSuccess)
    {
        if (wasLastPieceSuccess)
        {
            IncreaseCombo();
        }
        else
        {
            _comboManager.ResetCombo();
        }
    }

    public int GetTimeBonus() {
        return _stageTimer.GetRemainingTime() * ScorePerRemaniningSecond;
    }

    private void IncreaseCombo() {
        int scoreIncrease =_comboManager.GetNextComboScore();
        IncreaseScore(scoreIncrease);
    }

    public void IncreaseScore(int scoreIncrease) {
        Score += scoreIncrease;
        _text.text = "Score: " + Score;
    }
    
}
