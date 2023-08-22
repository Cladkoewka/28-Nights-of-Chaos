using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCountText;

    private void UpdatePlayerMoneyAmount(int moneyAmount)
    {
        _moneyCountText.text = $"${moneyAmount}";
    }

    private void Start()
    {
        Bank.Instance.OnMoneyChanged += UpdatePlayerMoneyAmount;
    }

    private void OnDisable()
    {
        Bank.Instance.OnMoneyChanged -= UpdatePlayerMoneyAmount;
    }
}
