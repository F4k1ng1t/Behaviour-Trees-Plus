using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public bool stomped = false;
    GameObject fire;
    BoxCollider boxCollider;
    bool run = false;
    void Start()
    {
        fire = this.transform.GetChild(0).gameObject;
        boxCollider = fire.transform.parent.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stomped && !run)
        {
            run = true;
            StartCoroutine("Stomp");
        }
            

    }
    IEnumerator Stomp()
    {
        fire.SetActive(false);
        boxCollider.enabled = false;
        yield return new WaitForSeconds(5);
        fire.SetActive(true);
        boxCollider.enabled = true;
        stomped = false;
        run = false;
    }
}
