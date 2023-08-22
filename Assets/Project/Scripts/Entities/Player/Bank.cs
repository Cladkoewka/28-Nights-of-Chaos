using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bank : MonoBehaviour
{
    public UnityAction<int> OnMoneyChanged;
    public static Bank Instance { get; private set; }

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

    private int _money = 0;

    public int Money
    {
        get { return _money; }
        private set { _money = value; }
    }


    public void AddMoney(int amount)
    {
        if (amount < 0) { return; }

        _money += amount;
        OnMoneyChanged?.Invoke(_money);
    }

    public bool TrySpendMoney(int amount)
    {
        if (amount < 0) { return false;}

        if (_money >= amount)
        {
            _money -= amount;
            OnMoneyChanged?.Invoke(_money);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        OnMoneyChanged?.Invoke(_money);
    }
}
