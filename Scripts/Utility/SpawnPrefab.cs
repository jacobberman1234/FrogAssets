using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [Header("Main Options")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _desiredParent;
    [SerializeField] private Vector3 _minRotationOffset;
    [SerializeField] private Vector3 _maxRotationOffset;
    [SerializeField] private Vector3 _minPositionOffset;
    [SerializeField] private Vector3 _maxPositionOffset;
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;


    [ContextMenu("Spawn Prefab Destroy")]
    public void SpawnDestroy()
    {
        GameObject prefab = Instantiate(_prefab);
        prefab.transform.position = transform.position;
        prefab.transform.SetParent(_desiredParent);
        SetTransforms(prefab, _minRotationOffset, _maxRotationOffset,
            _minPositionOffset, _maxPositionOffset, _minScale, _maxScale);
        DestroyImmediate(gameObject);
    }

    [Header("Grass Options")]
    [SerializeField] private int spawnEveryVertex = 3;
    [SerializeField] private int density = 5;
    [SerializeField] private float unitSphereSize = 5;
    [SerializeField] private LayerMask groundMask;

    [ContextMenu("Spawn Grass")]
    public void SpawnGrass()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i += spawnEveryVertex)
        {
            var vertex = transform.TransformPoint(vertices[i]);
            RaycastHit hit;
            for(int j = 0; j < density; ++j)
            {
                var prefab = Instantiate(_prefab);
                var newPos = vertex + Random.insideUnitSphere * unitSphereSize;
                newPos.y = vertex.y;
                prefab.transform.position = newPos;
                Physics.Raycast(prefab.transform.position, -transform.up, out hit, Mathf.Infinity, groundMask);
                if (hit.collider != null)
                {
                    Debug.Log("Hit!");
                    prefab.transform.position = hit.point;
                }
                else
                {
                    Physics.Raycast(prefab.transform.position, transform.up, out hit, Mathf.Infinity, groundMask);
                    if (hit.collider != null)
                    {
                        newPos.y = hit.point.y;
                        prefab.transform.position = newPos;
                    }
                    else
                    {
                        Debug.Log("Couldn't find the collider");
                    }
                }
                SetTransforms(prefab, _minRotationOffset, _maxRotationOffset,
                    _minPositionOffset, _maxPositionOffset, _minScale, _maxScale);
                prefab.transform.SetParent(_desiredParent);
            }
        }
    }

    private void SetTransforms(GameObject prefab,
        Vector3 minRotation, Vector3 maxRotation,
        Vector3 minPosition, Vector3 maxPosition,
        float minScale = 1, float maxScale = 1)
    {
        Vector3 rotationOffset = Helper.RandomVector3(minRotation, maxRotation);
        Vector3 positionOffset = Helper.RandomVector3(minPosition, maxPosition);
        Vector3 randomScale = Vector3.one * Random.Range(minScale, maxScale);
        prefab.transform.localPosition += positionOffset;
        prefab.transform.localEulerAngles += rotationOffset;
        prefab.transform.localScale = randomScale;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
    //    Vector3[] vertices = mesh.vertices;
    //    for(int i = 0; i < vertices.Length; i++)
    //    {
    //        var vertex = transform.TransformPoint(vertices[i]);
    //        for(int j = 0; j < 5; j++)
    //        {
    //            var newPos = vertex + Random.insideUnitSphere * 5;
    //            newPos.y = vertex.y;
    //            Gizmos.DrawWireSphere(newPos, 1);
    //        }
    //    }



    //}

    private void OnSceneGUI()
    {
        Event e = Event.current;
        Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Camera.current);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

    }
}
