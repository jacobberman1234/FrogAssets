using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellData : MonoBehaviour
{
    [SerializeField] private Spell _spell;

    private ParticleSystem _particleSystem;
    private ParticleSystem.EmissionModule _emission;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _emission = _particleSystem.emission;
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateSpellOnTimer(_spell.duration));
    }

    private IEnumerator DeactivateSpellOnTimer(float timer)
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(timer);
        Debug.Log("Deactivating");
        EnableEmission(false);
        StopAllCoroutines();
    }

    public void EnableEmission(bool value)
    {
        _emission.enabled = value;
        if(value)
            StartCoroutine(DeactivateSpellOnTimer(_spell.duration));
    }
}
