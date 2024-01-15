using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject squarePlayer;
    Vector3 diffDistance;

    // Start is called before the first frame update
    void Start()
    {
        diffDistance = this.transform.position - squarePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("Difference of x: " + diffDistance.x);*/
        this.transform.position = squarePlayer.transform.position + diffDistance;
        this.transform.position = new Vector3(this.transform.position.x, 0, -10);
        /*Debug.Log("X position of player: " + squarePlayer.transform.position.x);
        Debug.Log("X position of camera: " + this.transform.position.x);*/
    }
}
