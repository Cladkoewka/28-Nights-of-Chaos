using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _menuButton;

    private void Start()
    {
        CloseMenu();
    }

    public void SetVolume(float volume)
    {
        AudioManager.Instance.SetVolume(volume);
    }

    public void SetMusic(bool isMusic)
    {
        AudioManager.Instance.SetMusic(isMusic);
    }

    public void GoToMainMenu()
    {
        TimeManager.Instance.PlayTime();
        SceneManager.LoadScene(0);
    }

    public void OpenMenu()
    {
        UIInteraction.Instance.ShowCursor();
        TimeManager.Instance.StopTime();
        _menuWindow.SetActive(true);
        _menuButton.SetActive(false);
    }

    public void CloseMenu()
    {
        UIInteraction.Instance.HideCursor();
        TimeManager.Instance.PlayTime();
        _menuWindow.SetActive(false);
        _menuButton.SetActive(true);

    }
}
