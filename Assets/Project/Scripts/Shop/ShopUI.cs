using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _shopWindow;
    [SerializeField] private GameObject _goodsCardPrefab;
    [SerializeField] private GameObject _weaponGroup;
    [SerializeField] private GameObject _miscGroup;
    [SerializeField] private ShopGoodsData[] _weaponGoodsData;
    [SerializeField] private ShopGoodsData[] _miscGoodsData;
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _nextWaveButton;

    private void Start()
    {
        DeactivateShop();
        SetShop();
    }

    public void ActivateShop()
    {
        _shopWindow.SetActive(true);
        _menuButton.SetActive(false);
        _nextWaveButton.SetActive(false);
        UIInteraction.Instance.ShowCursor();
    }

    public void DeactivateShop()
    {
        _shopWindow.SetActive(false);
        _menuButton.SetActive(true);
        _nextWaveButton.SetActive(true);
        UIInteraction.Instance.HideCursor();
    }

    private void SetShop()
    {
        for (int i = 0; i < _weaponGoodsData.Length; i++)
        {
            Goods goodsCard = Instantiate(_goodsCardPrefab, _weaponGroup.transform).GetComponent<Goods>();
            ShopGoodsData goodData = _weaponGoodsData[i];
            FillCard(goodsCard, goodData);
        }
        for (int i = 0; i < _miscGoodsData.Length; i++)
        {
            Goods goodsCard = Instantiate(_goodsCardPrefab, _miscGroup.transform).GetComponent<Goods>();
            ShopGoodsData goodData = _miscGoodsData[i];
            FillCard(goodsCard, goodData);
        }
    }

    private void FillCard(Goods goodsCard, ShopGoodsData goodData)
    {
        goodsCard.SetCard(
            goodData.Sprite,
            goodData.Name,
            goodData.Description,
            goodData.Price,
            goodData.Reusable,
            goodData.Index);
    }
}
