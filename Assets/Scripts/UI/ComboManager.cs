using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboManager : MonoBehaviour
{
    public int _increasePerCombo = 100;
    private int _comboCount;
    public Text _comboText;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        ResetCombo();
    }

    public int GetNextComboScore() {
        _comboCount++;
        if (_comboCount > 1)
        {
            _comboText.text = "Combo x" + _comboCount;
        }
        _animator.SetTrigger("increase");
        return _increasePerCombo * _comboCount;
    }

    public void ResetCombo() {
        _comboCount = 0;
        _comboText.text = "";
    }
}
