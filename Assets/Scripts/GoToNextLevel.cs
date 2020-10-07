using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(PlayerInput))]
public class GoToNextLevel : MonoBehaviour
{
    private PlayerInput _playerInput;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.PressedAnyKey)
        {
            ChangeToNextLevel();
        }
    }

    public void ChangeToNextLevel() {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.GetSceneByBuildIndex(sceneIndex) != null)
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
        
    }
}
