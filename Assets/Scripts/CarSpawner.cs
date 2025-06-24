using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;           // Assign your car prefab
    public Transform[] pathPoints;         // Assign your waypoint path here
    public float carLifetime = 10f;        // Time before the car is destroyed
    public float spawnInterval = 5f;       // Time between spawns
    public float carSpeed = 5f;            // Movement speed of the car

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCar), 0f, spawnInterval);
    }

    void SpawnCar()
    {
        GameObject car = Instantiate(carPrefab, pathPoints[0].position, Quaternion.identity);
        CarMover mover = car.AddComponent<CarMover>();
        mover.Initialize(pathPoints, carSpeed, carLifetime);
    }
}

