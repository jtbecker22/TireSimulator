using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSnap : MonoBehaviour
{

    Transform parentTransform;

    [SerializeField]
    private List<GameObject> LugNuts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nut"))
        {
            parentTransform = other.gameObject.transform.parent;
            LugNuts[0].gameObject.SetActive(true);
            LugNuts[1].gameObject.SetActive(true);
            LugNuts[2].gameObject.SetActive(true);
            LugNuts[3].gameObject.SetActive(true);
            LugNuts[4].gameObject.SetActive(true);
            LugNuts[5].gameObject.SetActive(true);
            parentTransform.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
