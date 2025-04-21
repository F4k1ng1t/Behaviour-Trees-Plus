using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FriendManager : MonoBehaviour
{
    public bool dismissed = false;
    BoxCollider boxCollider;
    Animator _animator;
    public Transform target;
    public Transform player;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dismissed)
        {
            if(boxCollider.enabled == true)
                boxCollider.enabled = false;
            //transform.forward = -transform.forward;
            transform.position = Vector3.MoveTowards(transform.position, target.position, GuardBT.speed * Time.deltaTime);
            transform.LookAt(target.position);
            _animator.SetBool("Walking", true);
        }
        else
        {
            transform.LookAt(player.position);
        }
    }
}
