using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float spd = 2f; //number of full 360 rotations


    private void Update()
    {
        transform.Rotate(0, 0, 360 * spd * Time.deltaTime);    //only want to rotate on the Z-axis!!!
    }
}
