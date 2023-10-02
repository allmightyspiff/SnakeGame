using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    private Vector3 offset = new Vector3(0, 10, 0);
    private int zoomOut = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Gradually zoom out the camer as the player gets larger
        if (player.GetPoints() > zoomOut * 10) {
            zoomOut *= 2;
            offset.y = zoomOut;
        }
        transform.position  = player.GetPosition() + offset;

    
    }
}
