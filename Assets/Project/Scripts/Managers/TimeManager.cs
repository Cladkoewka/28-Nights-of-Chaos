using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void SetTime(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void PlayTime()
    {
        Time.timeScale = 1f;
    }
}
