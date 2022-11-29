using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    //[SerializeField] float cameraDistance;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, transform.position.z);
    }
}
