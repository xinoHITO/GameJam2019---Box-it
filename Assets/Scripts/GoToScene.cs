using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToScene : MonoBehaviour
{
    [SerializeField]
    private string _sceneName = "Stage 1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeScene() {
        SceneManager.LoadScene(_sceneName);
    }
}
