using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navAgent;
    [SerializeField]
    private bool isArea;
    private float Angle = 45f;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        this.UpdateAsObservable().Where(_ => isArea == true).Subscribe(_ => navAgent.destination = player.transform.position);
        this.UpdateAsObservable().Where(_ => isArea == false).Subscribe(_ => navAgent.destination = this.transform.position);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FanShapeCollider(collision);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isArea = false;
    }

    private void FanShapeCollider(Collider collision)
    {
        Vector3 posDelta = collision.transform.position - transform.position;
        float target_Angle = Vector3.Angle(transform.forward, posDelta);
        if (target_Angle < Angle)
        {
            Debug.Log(posDelta);
            if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit))
            {
                if (hit.collider == collision)
                {
                    isArea = true;
                }
            }
        }
    }
}
