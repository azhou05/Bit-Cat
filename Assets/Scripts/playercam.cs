using UnityEngine;


public class playercam : MonoBehaviour {

        private Camera _mainCamera;


    private Bounds _cameraBounds;
    private Vector3 _targetPosition;

    public Transform player;

        private void Awake() => _mainCamera = Camera.main;

    // Update is called once per frame

    private void Start()
    {
        var height = _mainCamera.orthographicSize;
        var width = height * _mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.max.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.max.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
            );
    }

    private void LateUpdate()
{
    // Calculate the desired camera position based on the player
    _targetPosition = player.position + new Vector3(0, 0, -5);

    // Clamp the t arget position to the camera bounds
    _targetPosition = GetCameraBounds(_targetPosition);

    // Move the camera
    transform.position = _targetPosition;
}

private Vector3 GetCameraBounds(Vector3 targetPosition)
{
    return new Vector3(
        Mathf.Clamp(targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
        Mathf.Clamp(targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
        targetPosition.z // preserve the intended Z position
    );
}


}

