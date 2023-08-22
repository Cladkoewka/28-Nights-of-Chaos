using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotSmokeEffect;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private AudioSource _shotSound;

    public void ShowShotEffect(Transform muzzle, float flashTime)
    {
        var effect = Instantiate(_shotSmokeEffect, muzzle.position, Quaternion.identity);
        StartCoroutine(ShowMuzzleFlash(flashTime));
        _shotSound.pitch = Random.Range(1.1f, 1.16f);
        _shotSound.Play();
    }



    private IEnumerator ShowMuzzleFlash(float flashTime)
    {
        _muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime / 2);
        _muzzleFlash.SetActive(false);
    }
}
