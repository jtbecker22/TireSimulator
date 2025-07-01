using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        transform.LookAt(target);

        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.x = 0;
        currentEuler.z = 0;

        currentEuler.y += 180f;

        transform.rotation = Quaternion.Euler(currentEuler);
    }
   
}
