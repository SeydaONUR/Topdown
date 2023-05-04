using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D boundCamera;
    public float halfWeight, halfHeight;
   // public Vector2 minPosition;
   // public Vector2 maxPoisition;
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWeight= halfHeight *Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (player!= null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x,boundCamera.bounds.min.x + halfWeight,boundCamera.bounds.max.x - halfWeight),
                Mathf.Clamp(player.position.y,boundCamera.bounds.min.y + halfHeight,boundCamera.bounds.max.y - halfHeight),
                transform.position.z);

        }
    }
}
