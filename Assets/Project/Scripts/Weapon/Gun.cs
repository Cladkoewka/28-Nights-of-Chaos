using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GunEffects))]
public class Gun : MonoBehaviour
{
    public UnityAction<int, int> OnBulletsAmoountChanged;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletsSpawnPosition;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int _maxBulletsInAmmoCount;
    [SerializeField] private int _startBulletsCount = 120;
    [SerializeField] private GunUI _gunUI;
    [SerializeField] private Sprite _gunImage;
    [SerializeField] private AudioSource _reloadSound;


    public int CurrentBulletsCount { get; private set; }
    public bool IsMagazineEmpty => _isMagazineEmpty;
    public bool IsAlreadyBuy = false;

    private GunEffects _gunEffects;
    private int _currentBulletsInAmmoCount;
    private bool _isMagazineEmpty = false;
    private bool _isRealoading = false;
    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    private void Start()
    {
        _gunEffects = GetComponent<GunEffects>();
        _currentBulletsInAmmoCount = _maxBulletsInAmmoCount;
        CurrentBulletsCount = _startBulletsCount - _maxBulletsInAmmoCount;
        OnBulletsAmoountChanged?.Invoke(_currentBulletsInAmmoCount,CurrentBulletsCount);
    }

    public void Shoot()
    {
        if (_isRealoading) { return; }

        if (_currentBulletsInAmmoCount > 0)
        {
            if (_timer > _timeBetweenShoot)
            {
                _currentBulletsInAmmoCount--;
                _timer = 0;
                GameObject newBullet = Instantiate(_bulletPrefab, _bulletsSpawnPosition.position, _bulletsSpawnPosition.rotation);
                OnBulletsAmoountChanged?.Invoke(_currentBulletsInAmmoCount, CurrentBulletsCount);
                _gunEffects.ShowShotEffect(_bulletsSpawnPosition, _timeBetweenShoot / 2);
            }
        }
        else
        {
            _isMagazineEmpty = true;
        }
    }

    public void TryReload()
    {
        if (!_isRealoading)
        {
            if (CurrentBulletsCount > 0)
            {
                _isRealoading = true;
                _gunUI.ShowReload(_reloadTime);
                StartCoroutine(Reload());
            }
        }
    }

    public bool IsMagazineFull => _currentBulletsInAmmoCount == _maxBulletsInAmmoCount;

    private IEnumerator Reload()
    {
        _reloadSound.Play();
        yield return new WaitForSeconds(_reloadTime);

        if (_currentBulletsInAmmoCount > 0)
        {
            CurrentBulletsCount += _currentBulletsInAmmoCount;
            _currentBulletsInAmmoCount = 0;
        }

        int addedBullets = (CurrentBulletsCount >= _maxBulletsInAmmoCount) ? _maxBulletsInAmmoCount : CurrentBulletsCount % _maxBulletsInAmmoCount;
        CurrentBulletsCount -= addedBullets;
        _currentBulletsInAmmoCount = addedBullets;
        _isMagazineEmpty = false;
        OnBulletsAmoountChanged?.Invoke(_currentBulletsInAmmoCount, CurrentBulletsCount);
        _isRealoading = false;

    }

    public void AddBullets(int bulletsCount)
    {
        if (bulletsCount <= 0) { return; }

        CurrentBulletsCount += bulletsCount;
        OnBulletsAmoountChanged?.Invoke(_currentBulletsInAmmoCount, CurrentBulletsCount);
    }

    public void ChangeImage()
    {
        _gunUI.SetImage(_gunImage);
    }
}
