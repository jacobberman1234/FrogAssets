using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public new string name;
    public AnimationClip spellAnimationClip;
    public GameObject spellPrefab;
    public float duration;
    public float damage;
    public int range;

    public abstract void Cast();
}
