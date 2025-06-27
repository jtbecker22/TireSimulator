using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject[] carVariants; // Assign car prefabs in Inspector
    public Transform[] waypoints;    // Assign empty GameObjects as waypoints
    public float speed;

    void Start()
    {
        StartCoroutine(SpawnCarRoutine());
    }

    IEnumerator SpawnCarRoutine()
    {
        while (true)
        {
            SpawnRandomCar();
            float waitTime = Random.Range(15f, 45f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnRandomCar()
    {
        if (carVariants.Length == 0 || waypoints.Length == 0) return;

        int randomIndex = Random.Range(0, carVariants.Length);
        GameObject car = Instantiate(carVariants[randomIndex], waypoints[0].position, Quaternion.identity);
        car.AddComponent<CarPathFollower>().Init(waypoints, speed);
    }
}

public class CarPathFollower : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentWaypoint = 0;
    private float speed;

    public void Init(Transform[] waypoints, float speed)
    {
        this.waypoints = waypoints;
        this.speed = speed;
    }

    void Update()
    {
        if (waypoints == null || currentWaypoint >= waypoints.Length) return;

        Transform target = waypoints[currentWaypoint];

        // Make the car face the next waypoint (keep y unchanged to avoid tilting)
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                Destroy(gameObject); // Car "dies" at the end
            }
        }
    }
}