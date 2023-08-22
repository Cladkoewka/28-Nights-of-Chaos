using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private ShopUI _shopUI;

    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnEnable()
    {
        _enemySpawner.WaveStart.AddListener(OnWaveStarted);
        _enemySpawner.WaveStop.AddListener(OnWaveEnded);
    }

    private void OnDisable()
    {
        _enemySpawner.WaveStart.RemoveListener(OnWaveStarted);
        _enemySpawner.WaveStop.RemoveListener(OnWaveEnded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            _shopUI.ActivateShop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            _shopUI.DeactivateShop();
        }
    }

    private void OnWaveStarted()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnWaveEnded()
    {
        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
