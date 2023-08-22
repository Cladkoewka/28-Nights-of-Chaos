using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBulletsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletsInMagazineCountText;
    [SerializeField] private TMP_Text _thisGunBulletsCountText;

    private Player _player;
    private Gun _currentGun;

    private void UpdatePlayerBulletsAmount(int bulletsInAmmo, int otherBullets)
    {
        _bulletsInMagazineCountText.text = bulletsInAmmo.ToString();
        _thisGunBulletsCountText.text = otherBullets.ToString();
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        UpdateGunReference();
        SubscribeToGunEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromGunEvents();
    }

    private void UpdateGunReference()
    {
        _currentGun = _player.CurrentGun;
    }

    private void SubscribeToGunEvents()
    {
        if (_currentGun != null)
        {
            _currentGun.OnBulletsAmoountChanged += UpdatePlayerBulletsAmount;
        }
    }

    private void UnsubscribeFromGunEvents()
    {
        if (_currentGun != null)
        {
            _currentGun.OnBulletsAmoountChanged -= UpdatePlayerBulletsAmount;
        }
    }

    private void Update()
    {
        if (_currentGun != _player.CurrentGun)
        {
            UnsubscribeFromGunEvents();
            UpdateGunReference();
            SubscribeToGunEvents();
        }
    }
}
