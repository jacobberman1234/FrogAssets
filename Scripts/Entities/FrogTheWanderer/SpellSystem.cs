using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{
    [SerializeField] private Transform _spellPoint;
    [SerializeField] private List<Spell> _spellbook = new List<Spell>();
    private Spell _activeSpell;
    private GameObject _activeSpellPrefab;

    private void Start()
    {
        if(_spellbook.Count > 0)
            _activeSpell = _spellbook[0];
        _activeSpellPrefab = Instantiate(_activeSpell.spellPrefab, _spellPoint.position, _spellPoint.rotation);
        _activeSpellPrefab.SetActive(false);
        _activeSpellPrefab.transform.SetParent(_spellPoint);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _activeSpell.Cast();
            if (!_activeSpellPrefab.activeSelf)
               _activeSpellPrefab.SetActive(true);
            _activeSpellPrefab.GetComponent<SpellData>().EnableEmission(true);
        }
    }

    private void CastActiveSpell()
    {

    }
}
