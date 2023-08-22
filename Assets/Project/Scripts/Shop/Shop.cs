using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;

    [SerializeField] private int[] _gunPrices;
    [SerializeField] private int _ammoPrice;
    [SerializeField] private int _ammoAmount;
    [SerializeField] private int _medkitPrice;
    [SerializeField] private int _medkitAmount;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public bool TryBuyGun(int index)
    {
        if (_guns[index].IsAlreadyBuy) { return false; }

        if (Bank.Instance.TrySpendMoney(_gunPrices[index]))
        {
            _player.ChangeGun(_guns[index]);
            _guns[index].IsAlreadyBuy = true;
            return true;
        }
        return false;
    }

    public bool TryBuyAmmo()
    {
        if (Bank.Instance.TrySpendMoney(_ammoPrice))
        {
            _player.CollectAmmo(_ammoAmount);
            return true;
        }
        return false;
    }

    public bool TryBuyMedkit()
    {
        if (Bank.Instance.TrySpendMoney(_medkitPrice))
        {
            _player.AddHealth(_medkitAmount);
            return true;
        }
        return false;
    }

}
