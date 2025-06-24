using UnityEngine;

public class CarMover : MonoBehaviour
{
    private Transform[] pathPoints;
    private float speed;
    private int currentPointIndex = 0;

    public void Initialize(Transform[] points, float moveSpeed, float lifeTime)
    {
        pathPoints = points;
        speed = moveSpeed;
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (pathPoints == null || pathPoints.Length == 0) return;

        Transform targetPoint = pathPoints[currentPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= pathPoints.Length)
            {
                Destroy(gameObject); // Optional: auto-destroy when path ends
            }
        }

        // Optional: Look towards the target
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
        }
    }
}
