using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects.GamePlay;

public class Monkee : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private Transform target;
    private MonkeeStatus _monkeeStatus;

    public MonkeeStatus MonkeeStatus
    {
        get => _monkeeStatus;
        set
        {
            _monkeeStatus = value;
            switch (value)
            {
                case MonkeeStatus.Waiting:
                    agent.radius = 0.01f;
                    // GoToArea();
                    // WaitPlayer();
                    break;
                // case MonkeeStatus.Boarding:
                //     // Debug.Log("Boarding");
                //     JumpToBuilding();
                //     ChangeMaterialTo(2);
                //     break;
                case MonkeeStatus.Following:
                    // agent.radius = .7f;
                    // var model = transform.GetChild(0);
                    // model.DOLocalJump(Vector3.zero, jumpHeight,1,.4f).OnComplete(() =>
                    // {
                    //     _animationController.SetIdle();
                    // });
                    break;
                // case MonkeeStatus.InLine:
					           //
                //     _navMeshAgent.stoppingDistance = 0;
                //     // GetInLine(ticketLine);
                //     break;
                // case MonkeeStatus.Picked:
                //     // Debug.Log("Picked");
                //     MoveTargetToBoard(boardingPoint);
                //     break;
                default:
                    break;
            }
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (_monkeeStatus)
        {
            case MonkeeStatus.Waiting:
               
                break;
           
            case MonkeeStatus.Following:
                FollowTarget(target.position);
                break;
            
            default:
                break;
        }
    }

    public void FollowTarget(Vector3 targetPosition)
    {
        agent.destination = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger0");
        if(!other.attachedRigidbody)
            return;
        Debug.Log("Trigger1");
        if(!other.attachedRigidbody.TryGetComponent(out Bullet bullet))
            return;
        Debug.Log("Trigger");
        gameObject.SetActive(false);
    }
}

public enum MonkeeStatus
{
    Following,
    Waiting
}
