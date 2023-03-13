using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public Transform playerLocation;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y + 2.5f, -10f);
    }
}
