using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerInput))]
public class DetectAnyKey : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onPressAnyKey;
    private PlayerInput _playerInput;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.PressedAnyKey || Input.anyKeyDown)
        {
            if (_onPressAnyKey != null)
            {
                _onPressAnyKey.Invoke();
            }            
        }
    }
}
