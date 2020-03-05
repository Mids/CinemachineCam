using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator MainCam;
    public GameObject Player = default;
    public Transform StartPosition = default;
    public Transform FarAwayPosition = default;
    public CinemachineVirtualCameraBase StartVcam;
    public CinemachineVirtualCameraBase FarAwayVcam;

    private bool _isFar = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKeyDown && Input.GetKey(KeyCode.Space))
        {
            if (_isFar)
            {
                _isFar = false;

                // Move to start position
                Player.transform.position = StartPosition.position;
                MainCam.SetTrigger("MoveToStart");
                StartVcam.Follow = Player.transform;
                FarAwayVcam.Follow = default;
            }
            else
            {
                _isFar = true;

                // Move to far away position
                Player.transform.position = FarAwayPosition.position;
                MainCam.SetTrigger("MoveToFarAway");
                StartVcam.Follow = default;
                FarAwayVcam.Follow = Player.transform;
            }
        }
    }
}