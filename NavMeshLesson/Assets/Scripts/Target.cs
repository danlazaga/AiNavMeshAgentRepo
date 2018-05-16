using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public NavMeshAgent[] navAgent;

    private void Start()
    {
        navAgent = FindObjectsOfType<NavMeshAgent>();
    }

    void Update()
    {
        int button = 0;
        //Get the point of the hit position when the mouse is
        //being clicked
        if (Input.GetMouseButtonDown(button))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;

                for (int i = 0; i < navAgent.Length; i++)
                {
                    navAgent[i].destination = targetPosition;
                }

                transform.position = targetPosition + new Vector3(0, 5, 0);
            }
        }
    }
}