using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControl : MonoBehaviour
{
    
    void Update()
    {
        
    }

    public void SwitchScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
