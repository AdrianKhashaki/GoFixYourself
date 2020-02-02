using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float yOffset;
    private Camera camera;
    private float zPos;
    public float extraZoom;
    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float centerX = (player1.transform.position.x + player2.transform.position.x) / 2;
        float centerY = (player1.transform.position.y + player2.transform.position.y) / 2;

        float xDistance = (player1.transform.position.x - player2.transform.position.x);
        float yDistance = (player1.transform.position.y - player2.transform.position.y);
        float currentHeight = camera.orthographicSize;
        float currentWidth = currentHeight * Screen.width / Screen.height;
        if (currentHeight * 2 < yDistance * extraZoom)
        {
            camera.orthographicSize = yDistance * extraZoom;
        }

        transform.position = new Vector3(centerX, centerY + yOffset, zPos);
    }
}
