using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject playerObject;

    private CameraSettings _cameraSettings;

    private void Start()
    {
        _cameraSettings = GetComponent<CameraSettings>();
    }

    private void Update()
    {
        FollowByPlayer();
    }

    private void FollowByPlayer()
    {
        Vector3 cameraPosition = new Vector3(0, 0, -10.0f);
        Vector3 playerPosition = playerObject.transform.position;
        cameraPosition.x = Mathf.Clamp(playerPosition.x, _cameraSettings.minXPosition, _cameraSettings.maxXPosition);
        cameraPosition.y = Mathf.Clamp(playerPosition.y, _cameraSettings.minYPosition, _cameraSettings.maxYPosition);
        transform.position = cameraPosition;
    }
}
