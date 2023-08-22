using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Good", menuName = "Shop Good")]
public class ShopGoodsData : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public string Description;
    public int Price;
    public bool Reusable;
    public int Index;
}
