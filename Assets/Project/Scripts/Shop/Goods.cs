using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Goods : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _button;

    private bool _reusable;
    private int _index;
    private Shop _shop;


    private void Start()
    {
        _shop = FindObjectOfType<Shop>();
    }
    public bool IsBuyAlready { get; private set; } = false;

    public void SetCard(Sprite sprite, string name, string description, int price, bool reusable, int index)
    {
        _image.sprite = sprite;
        _name.text = name;
        _description.text = description;
        _price.text = $"${price}";
        _reusable = reusable;
        _index = index;
    }

    public void TryBuy()
    {
        if (!_reusable)
        {
            if (_shop.TryBuyGun(_index))
            {
                _button.enabled = false;
                _price.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                AudioManager.Instance.PlayBuySound();
            }
        }
        else
        {
            if (_index == 4)
            {
                if (_shop.TryBuyAmmo())
                {
                    AudioManager.Instance.PlayBuySound();
                }
            }
            if (_index == 5)
            {
                if (_shop.TryBuyMedkit())
                {
                    AudioManager.Instance.PlayBuySound();
                }
            }
        }
    }
}
