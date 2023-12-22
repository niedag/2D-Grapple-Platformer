using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    // Update is called once per frame
    private void Update() //we want the camera to follow the player
    {
        //transform of the camera and add the Player component to the Camera
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
