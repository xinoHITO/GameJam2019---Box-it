using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
[RequireComponent (typeof(PlayerInput))]
public class RestartScene : MonoBehaviour
{
    private PlayerInput _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.PressedRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
