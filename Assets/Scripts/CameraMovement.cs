using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _newCamPosition;
    [SerializeField] Vector3 _distance;
    [SerializeField] GameObject _player;
    
    void Update()
    {
        _newCamPosition = new Vector3(_player.transform.position.x, 0, 0) + _distance;
        transform.position = Vector3.Lerp(transform.position, _newCamPosition,1f*Time.deltaTime);
    }
}
