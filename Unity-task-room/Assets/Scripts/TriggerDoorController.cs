using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    bool isDoorOpening = false;
    [SerializeField] private Animator doorAnimator = null;
    [SerializeField] private GameObject player;

    private void Update()
    {
        CheckIfPlayerIsInFrontOfDoor();
        CheckIfPlayerIsAwayFromDoor();
    }

    private void CheckIfPlayerIsInFrontOfDoor()
    {
        if(isDoorOpening)
        {
            return;
        }
        Vector3 directionToPlayer = player.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, 4f))
        {
            isDoorOpening = true;
            print("Raycast hit");
            doorAnimator.Play("DoorOpen", 0, 0.0f);
        }
    }

    private void CheckIfPlayerIsAwayFromDoor()
    {
        if (!isDoorOpening)
        {
            return;
        }
        Vector3 directionToPlayer = player.transform.position - transform.position;
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, directionToPlayer, out hit, 4f))
        {
            isDoorOpening = false;
            print("Raycast hit");
            doorAnimator.Play("DoorClose", 0, 0.0f);
        }
    }
}
