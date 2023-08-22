using UnityEngine;

public abstract class CollectableItem : MonoBehaviour, ICollectable, IRandomable
{
    [SerializeField] protected int _value = 5;
    [SerializeField] protected int _minValue = 1;
    [SerializeField] protected int _maxValue = 10;

    public virtual void Collect()
    {
        AudioManager.Instance.PlayPickupSound();
        Die();
    }

    public void SetRandomValues()
    {
        _value = Random.Range(_minValue, _maxValue);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
