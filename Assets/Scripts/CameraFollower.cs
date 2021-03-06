using Cinemachine;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject pl1, pl2;
    public float minZpos;
    public float yOffset;
    public float distanceZoomFactor;
    public float zoomBoost;
    public float currentDistance;
    private CinemachineVirtualCamera cam;

    private void Start()
    {
        var camera = Camera.main;
        var brain = (camera == null) ? null : camera.GetComponent<CinemachineBrain>();
        cam = (brain == null) ? null : brain.ActiveVirtualCamera as CinemachineVirtualCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.winningPlayer == null)
        {
            transform.position = GetCameraPosition();
            transform.position = SetCameraZoom();
        }
        else
        {
            transform.position = GameManager.gm.winningPlayer.transform.position;
        }
    }

    public Vector3 GetCameraPosition()
    {
        currentDistance = Vector2.Distance(pl1.transform.position, pl2.transform.position);
        Vector3 direction = pl2.transform.position - pl1.transform.position;
        return pl1.transform.position + (direction)/2;
    }

    private Vector3 SetCameraZoom()
    {
        float zpos = Mathf.Clamp(-currentDistance * distanceZoomFactor + zoomBoost, minZpos, 2);
        return new Vector3(transform.position.x, transform.position.y+yOffset, zpos);
    }
}
