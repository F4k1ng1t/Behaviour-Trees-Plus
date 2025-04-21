using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class CheckFireInStompRange : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckFireInStompRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }
    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(_transform.position, target.position) <= GuardBT.stompRange && target.gameObject.layer == 7 && target.GetComponent<FireManager>().stomped == false)
        {
            _animator.SetBool("Attacking", false);
            _animator.SetBool("Walking", false);
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }
}
