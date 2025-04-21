using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public bool searched = false;
    BoxCollider boxCollider;
    void Start()
    {
        boxCollider = this.GetComponent<BoxCollider>();
        int n = Random.Range(0, 100);
        if (n >= 75)
        {
            Debug.Log($"{this.gameObject.name} is interesting!");
        }
        else
        {
            boxCollider.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (searched)
        {
            boxCollider.enabled = false;
        }

    }
}
