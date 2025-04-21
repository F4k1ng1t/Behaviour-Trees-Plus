using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class TaskStomp : Node
{
    private Transform _transform;
    private Animator _animator;
    private Transform _lastTarget;
    private FireManager _fireManager;

    public TaskStomp(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Fire");
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (target != _lastTarget)
        {
            _fireManager = target.GetComponent<FireManager>();
            _lastTarget = target;
        }
        
        if (!_fireManager.stomped)
        {
            ClearData("target");
            _animator.SetBool("Walking", true);
            _animator.SetBool("Attacking", false);
            Debug.Log("bruh");

            _fireManager.stomped = true;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
