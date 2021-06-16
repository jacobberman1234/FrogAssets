using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Foliage))]
public class FoliageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Foliage"))
        {
            Debug.Log("Generated Foliage");
        }
    }

    //public void OnSceneGUI()
    //{
    //    Foliage foliage = (Foliage)target;
    //    if (Event.current.type == EventType.MouseDown  && Event.current.button == 0)
    //    {
    //        Event e = Event.current;
    //        Debug.Log("Clicked");
    //        Ray ray = Camera.current.ScreenPointToRay(e.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            foliage.SpawnGrass(hit.point);
    //        }
    //    }

    
}
