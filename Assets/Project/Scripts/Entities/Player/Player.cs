using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : Entity
{
    public UnityAction<float, float> OnHealthChanged;

    [SerializeField] private Gun _currentGun;

    public Gun CurrentGun { get { return _currentGun; } }

    private void Update()
    {
        if (!UIInteraction.IsCursorOverUI)
        {
            if (!_currentGun.IsMagazineEmpty)
            {
                if (Input.GetMouseButton(0))
                {
                    _currentGun.Shoot();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AudioManager.Instance.PlayEmptyMagazineSound();
                    _currentGun.TryReload();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_currentGun.IsMagazineFull) { return; }
            _currentGun.TryReload();
        }
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        OnHealthChanged?.Invoke(Health, _maxHealth);
    }

    public void CollectAmmo(int ammoValue)
    {
        _currentGun.AddBullets(ammoValue);
    }

    public void AddHealth(float healthAmount)
    {
        if (healthAmount < 0) { return; }

        Health += healthAmount;

        if (Health > _maxHealth) 
        {
            Health = _maxHealth;
        }
        OnHealthChanged?.Invoke(Health, _maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectable>() != null)
        {
            other.gameObject.GetComponent<ICollectable>().Collect();
        }
    }

    public void ChangeGun(Gun gun)
    {
        _currentGun.gameObject.SetActive(false);
        _currentGun = gun;
        _currentGun.gameObject.SetActive(true);
        _currentGun.ChangeImage();

    }

    public void ChangeGunPositin(Transform newPosition)
    {
        _currentGun.transform.position = newPosition.position;
        _currentGun.transform.rotation = newPosition.rotation;
    }
}
