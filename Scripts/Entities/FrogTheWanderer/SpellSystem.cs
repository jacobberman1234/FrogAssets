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
        InitializeSpell(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<FrogTransformation>().InHumanForm)
        {
            _activeSpell.Cast();
            if (!_activeSpellPrefab.activeSelf)
               _activeSpellPrefab.SetActive(true);
        }

        if(Helper.NumInputToInt() != -1)
        {
            SetActiveSpell(Helper.NumInputToInt()-1);
        }
    }

    private void InitializeSpell(int spellbookIndex)
    {
        if (_spellbook.Count > 0)
            _activeSpell = _spellbook[spellbookIndex];
        _activeSpellPrefab = Instantiate(_activeSpell.spellPrefab, _spellPoint.position, _spellPoint.rotation);
        _activeSpellPrefab.SetActive(false);
        _activeSpellPrefab.transform.SetParent(_spellPoint);
        Debug.Log($"Active spell is now {_activeSpell.name}");
    }
    
    private void SetActiveSpell(int spellbookIndex)
    {
        if (_spellbook.Count <= spellbookIndex) return;
        Destroy(_activeSpellPrefab);
        InitializeSpell(spellbookIndex);
    }
}
