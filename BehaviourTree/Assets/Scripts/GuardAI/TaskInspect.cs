using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInspect : Node
{
    private Animator _animator;
    private Transform _lastTarget;
    private CrateManager _crateManager;

    float cachedTime;
    public TaskInspect(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
    }
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _crateManager = target.GetComponent<CrateManager>();
            _lastTarget = target;
            cachedTime = Time.time;
        }

        
        if (Time.time >= cachedTime + GuardBT.inspectTimer)
        {
            _crateManager.searched = true;
            if (_crateManager.searched)
            {
                ClearData("target");
                _animator.SetBool("Attacking", false);
                _animator.SetBool("Walking", true);

            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
