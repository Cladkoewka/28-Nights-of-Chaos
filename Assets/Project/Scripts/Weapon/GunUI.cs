using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    [SerializeField] private Image _reloadIndicator;
    [SerializeField] private Image _gunImage;
    [SerializeField] private TMP_Text _reloadTimer;
    

    private void Start()
    {
        _reloadIndicator.enabled = false;
        _reloadTimer.enabled = false;
    }

    public void ShowReload(float reloadTime)
    {
        StartCoroutine(Reload(reloadTime));
    }



    private IEnumerator Reload(float reloadTime)
    {
        _reloadIndicator.enabled = true;
        _reloadTimer.enabled = true;
        float timer = reloadTime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            _reloadIndicator.fillAmount = timer / reloadTime;
            _reloadTimer.text = timer.ToString("F1");
            yield return null;
        }
        _reloadIndicator.enabled = false;
        _reloadTimer.enabled = false;
    }

    public void SetImage(Sprite sprite)
    {
        _gunImage.sprite = sprite;
    }
}
