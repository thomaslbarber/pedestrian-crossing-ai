using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private const float MIN_SECONDS = 3;
    [SerializeField] private const float MAX_SECONDS = 6;

    private bool spawningVehicle = false;

    [SerializeField] private List<GameObject> vehiclePrefabs;

    private void Update()
    {
        if (!spawningVehicle)
        {
            StartCoroutine(SpawnVehicle());
        }
    }

    IEnumerator SpawnVehicle()
    {
        spawningVehicle = true;
        yield return new WaitForSeconds(Random.Range(MIN_SECONDS, MAX_SECONDS));
        GameObject newVehicle = Instantiate(vehiclePrefabs[Random.Range(0, vehiclePrefabs.Count)], transform);
        spawningVehicle = false;
    }
}
