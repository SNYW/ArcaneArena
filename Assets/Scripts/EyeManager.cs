using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MonoBehaviour
{
    PlayerController playerController;

    public Vector3 idlePosition;
    public Vector3 movePosition;

    private void Awake()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }
    void Update()
    {
    }
}
