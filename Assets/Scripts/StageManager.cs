using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StageManager : MonoBehaviour
{

    private PieceSpawner _spawner;
    private StageTimer _stageTimer;
    private TrashBar _trashBar;

    private FinishingPresentation _finishingPresentation;

    // Start is called before the first frame update
    void Start()
    {

        _stageTimer = FindObjectOfType<StageTimer>();
        _stageTimer.OnTimeIsUp += LoseStage;

        _trashBar = FindObjectOfType<TrashBar>();
        _trashBar.OnTrashIsEmpty += WinStage;

        _finishingPresentation = FindObjectOfType<FinishingPresentation>();

        _spawner = FindObjectOfType<PieceSpawner>();
    }

    private void EndStage() {
        _stageTimer.DisableTimer();
        _spawner.DestroySpawner();
    }

    private void WinStage()
    {
        EndStage();
        _finishingPresentation.WinAnimation();
    }

    private void LoseStage()
    {
        EndStage();
        _finishingPresentation.LoseAnimation();
    }

}
