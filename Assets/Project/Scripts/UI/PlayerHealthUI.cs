using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    private Player _player;

    private void UpdatePlayerHealthBar(float currentHealth, float maxHealth)
    {
        _healthBar.fillAmount = (currentHealth / maxHealth);
    }

    private void OnEnable()
    {
        _player.OnHealthChanged += UpdatePlayerHealthBar;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= UpdatePlayerHealthBar;
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
}
