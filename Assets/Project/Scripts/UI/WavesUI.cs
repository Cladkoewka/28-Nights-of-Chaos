using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _waveText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _remainingEnemiesText;
    [SerializeField] private Button _nextWaveButton;

    private EnemySpawner _enemySpawner;
    private ShopUI _shopUI;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _shopUI = FindObjectOfType<ShopUI>();
        HideButton();
    }


    private void OnEnable()
    {
        _enemySpawner.RemainingEnemiesChanged.AddListener(OnRemainingEnemiesChanged);
        _enemySpawner.WaveStarted.AddListener(OnWaveStarted);
        _enemySpawner.WaveEnded.AddListener(OnWaveEnded);
    }

    private void OnDisable()
    {
        _enemySpawner.RemainingEnemiesChanged.RemoveListener(OnRemainingEnemiesChanged);
        _enemySpawner.WaveStarted.RemoveListener(OnWaveStarted);
        _enemySpawner.WaveEnded.RemoveListener(OnWaveEnded);
    }

    private void OnRemainingEnemiesChanged(int remainingEnemies, int waveEnemies)
    {
        _remainingEnemiesText.text = $"{remainingEnemies}/{waveEnemies}";
    }

    private void OnWaveStarted(int wave)
    {
        _shopUI.DeactivateShop();
        _timerText.gameObject.SetActive(false);
        _waveText.gameObject.SetActive(true);  
        _waveText.text = $"Wave {wave + 1}";
        HideButton();
    }

    private void OnWaveEnded(float timeToNextWave)
    {
        _timerText.gameObject.SetActive(true);
        _waveText.gameObject.SetActive(false);
        ShowButton();
        StartCoroutine(NextWaveTimer(timeToNextWave));
    }

    private void ShowButton()
    {
        _remainingEnemiesText.gameObject.SetActive(false);
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        _remainingEnemiesText.gameObject.SetActive(true);
        _nextWaveButton.gameObject.SetActive(false);
    }

    private IEnumerator NextWaveTimer(float time)
    {
        float timer = time;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            _timerText.text = timer.ToString("F1");
            yield return null;
        }
    }
}
