using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public int currentSprite;
    public float[] progress;

    void Start()
    {
        currentSprite = PlayerPrefs.GetInt("CurrentSprite");
        for (int i = 0; i < progress.Length; i++)
        {
            progress[i] = PlayerPrefs.GetFloat("Progress" + i + 1);
        }
    }
}
