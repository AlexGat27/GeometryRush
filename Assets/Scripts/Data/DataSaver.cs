using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataSaver : MonoBehaviour
{
    public int currentSprite;
    public float[] progress;

    public void SaveData()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("CurrentSprite", currentSprite);
        if (currentScene != 0)
            PlayerPrefs.SetFloat("Progress" + currentScene, progress[currentScene - 1]);
    }
}
