using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellData : MonoBehaviour
{
    [SerializeField] private Spell _spell;

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
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
        var emission = _particleSystem.emission;
        emission.enabled = value;
        if(value)
            StartCoroutine(DeactivateSpellOnTimer(_spell.duration));
    }
}
