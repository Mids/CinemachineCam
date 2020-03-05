using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player = default;
    public Transform StartPosition = default;
    public Transform FarAwayPosition = default;
    public CinemachineVirtualCameraBase StartVcam;
    public CinemachineVirtualCameraBase FarAwayVcam;

    public Animator MainCam;

    private bool isFar = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && Input.GetKey(KeyCode.Space))
        {
            if (isFar)
            {
                isFar = false;

                Player.transform.position = StartPosition.position;
                MainCam.SetTrigger("MoveToStart");
                StartVcam.Follow = Player.transform;
                FarAwayVcam.Follow = default;
            }
            else
            {
                isFar = true;
                Player.transform.position = FarAwayPosition.position;
                MainCam.SetTrigger("MoveToFarAway");
                StartVcam.Follow = default;
                FarAwayVcam.Follow = Player.transform;
            }
        }
    }
}
