using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _pickupSound;
    [SerializeField] private AudioSource[] _zombieDeathSounds;
    [SerializeField] private AudioSource _bulletHitEnemySound;
    [SerializeField] private AudioSource _bulletHitWallSound;
    [SerializeField] private AudioSource _FireballHitSound;
    [SerializeField] private AudioSource _emptyMagazineSound;
    [SerializeField] private AudioSource _buySound;
    [SerializeField] private AudioSource _music;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            return;
        }

        Destroy(this.gameObject);
    }

    public void PlayPickupSound()
    {
        _pickupSound.Play();
    }

    public void PlayZombieDeathSound()
    {
        var deathSound = _zombieDeathSounds[Random.Range(0, _zombieDeathSounds.Length)];
        deathSound.pitch = Random.Range(0.8f, 0.9f);
        deathSound.Play();
    }

    public void PlayBulletHitEnemySound()
    {
        _bulletHitEnemySound.pitch = Random.Range(1.1f, 1.2f);
        _bulletHitEnemySound.Play();
    }

    public void PlayBulletHitWallSound()
    {
        _bulletHitWallSound.pitch = Random.Range(0.9f, 1f);
        _bulletHitWallSound.Play();
    }

    public void PlayFireballHitSound()
    {
        _FireballHitSound.pitch = Random.Range(0.95f, 1.1f);
        _FireballHitSound.Play();
    }

    public void PlayEmptyMagazineSound()
    {
        _emptyMagazineSound.Play();
    }

    public void PlayBuySound()
    {
        _buySound.Play();
    }

    public void SetMusic(bool isPlay)
    {
        _music.mute = !isPlay;
    }

    public void SetVolume(float amount)
    {
        AudioListener.volume = Mathf.Clamp01(amount);
    }
}