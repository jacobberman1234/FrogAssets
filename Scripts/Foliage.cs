using UnityEngine;

public class Foliage : MonoBehaviour
{
    [SerializeField] private GameObject _grass;
    [SerializeField] private Transform _grassParent;

    public void SpawnGrass(Vector3 position)
    {
        var grass = Instantiate(_grass, position, Quaternion.identity);
        grass.transform.SetParent(_grassParent);
    }
}
