using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInteraction : MonoBehaviour
{
    public static UIInteraction Instance { get; private set; }

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

    [SerializeField] private GameObject _crosshair;

    public static bool IsCursorOverUI = false;

    public void ShowCursor()
    {
        IsCursorOverUI = true;
        Cursor.visible = true;
        _crosshair.SetActive(false);
    }

    public void HideCursor()
    {
        IsCursorOverUI = false;
        Cursor.visible = false;
        _crosshair.SetActive(true);
    }

}
