using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private Transform _scaler;
    [SerializeField] private Transform _targer;
    

    public void SetTarget(Transform target)
    {
        _targer = target;
    }

    public void UpdateHp(float currentHealth, float maxHealth)
    {
        float xScale = Mathf.Clamp01(currentHealth / maxHealth);
        _scaler.localScale = new Vector3(xScale, _scaler.transform.localScale.y, _scaler.transform.localScale.z);
    }


    private void Update()
    {
        transform.position = _targer.position + Vector3.up * 2.5f;
        transform.rotation = Camera.main.transform.rotation;
    }
}
