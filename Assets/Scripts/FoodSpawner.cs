using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
  
    private float maxX = 18f;
    private float minX = -18f;
    private float maxZ = 1.5f;
    private float minZ = 38f;   

    private void Start()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        float x = Random.Range(maxX, minX);
        float z = Random.Range(maxZ, minZ);

        Vector3 _spawnPosition = new Vector3(x, 0.5f, z);

        Instantiate(_foodPrefab, _spawnPosition, Quaternion.identity);
    }

    public void SpawnNewFood()
    {
        SpawnFood();
    }
}
