using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFriendInDismissRange : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckFriendInDismissRange(Transform transform)
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
        if (Vector3.Distance(_transform.position, target.position) <= GuardBT.inspectRange && target.gameObject.layer == 3)
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
