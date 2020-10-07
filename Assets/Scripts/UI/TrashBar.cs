using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TrashBar : MonoBehaviour
{
    public Image _stageProgressBar;
    private int _currentItems = 0;
    public int ItemsToWin { get; set; }
    private PieceSpawner _spawner;

    public UnityAction OnTrashIsEmpty { get; set; }

    const float MAX_HEIGHT = 2797;

    // Start is called before the first frame update
    void Start()
    {
        _spawner = FindObjectOfType<PieceSpawner>();
        _spawner.OnCreatedNewPiece += CheckTrashProgress;        
        DecreaseTrashLevel(0);
    }

    private void CheckTrashProgress(bool wasLastPieceSuccess)
    {
        if (wasLastPieceSuccess)
        {
            DecreaseTrashLevel(1);
        }
    }

    public void DecreaseTrashLevel(int increase) {
        _currentItems += increase;
        _currentItems = Mathf.Clamp(_currentItems, 0, ItemsToWin);
    //    _stageProgressBar.fillAmount = 1-(_currentItems*1.0f / ItemsToWin);

        Vector2 size = _stageProgressBar.rectTransform.sizeDelta;
        size.y = 1 - (_currentItems * 1.0f / ItemsToWin);
        size.y *= MAX_HEIGHT;
        _stageProgressBar.rectTransform.sizeDelta = size;
        if (_currentItems >= ItemsToWin)
        {
            if (OnTrashIsEmpty != null)
            {
                OnTrashIsEmpty.Invoke();
            }
        }
    }
}
