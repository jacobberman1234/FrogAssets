using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell/AOE Spell")]
public class AOESpell : Spell
{
    [Range(0,359)]
    public float degreesArea;

    public override void Cast()
    {
        //Play spell animation
            //Spell animation spawns prefab through animation event
            //Disable particle system at end of animation
        //Do damage to enemies in range
    }
}
