using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class PlayerInput : MonoBehaviour
{
    private Player _playerInput;

    public bool PressedLeft { get; set; }
    public bool PressedRight { get; set; }
    public bool PressedDrop { get; set; }
    public bool PressedRestart { get; set; }
    public bool PressedAnyKey { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        PressedLeft = _playerInput.GetButtonDown("MoveLeft");
        PressedRight = _playerInput.GetButtonDown("MoveRight");
        PressedDrop = _playerInput.GetButtonDown("Drop");
        PressedRestart = _playerInput.GetButtonDown("Restart");
        PressedAnyKey = _playerInput.GetAnyButtonDown();
    }
}
