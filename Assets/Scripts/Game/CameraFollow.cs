using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z); ;
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPlayerOffset = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraPlayerOffset, Time.deltaTime);
    }
}
