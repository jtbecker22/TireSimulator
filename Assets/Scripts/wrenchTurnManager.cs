using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrenchTurnManager : MonoBehaviour
{

    [SerializeField]
    //public Dictionary<GameObject, bool> LugNuts = new Dictionary<GameObject, bool>();
    public List<GameObject> LugNuts = new List<GameObject>();

    [SerializeField]
    public GameObject currentNut;

    // Start is called before the first frame update
    void Start()
    {

        currentNut = LugNuts[0];
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void enableDisableNut()
    {
        foreach (GameObject i in LugNuts)
        {

            if (currentNut == i)
            {
                currentNut.GetComponent<wrenchTurn>().enabled = true;
            }
            else { i.GetComponent<wrenchTurn>().enabled = false; }

        }
    }
}
