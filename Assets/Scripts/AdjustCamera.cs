using UnityEngine;

public class AdjustCamera : MonoBehaviour {

    public Transform camFeed;
    public Transform leftCam;
    public Transform rightCam;

    [Header("CAM-Distance")]
    [Range(.5f, .7f)]
    public float CamDistance;

    [Header("X-SHIFT")]
    [Range(-.2f, .2f)]
    public float X;

    [Header("Y-SHIFT")]
    [Range(-.4f, .4f)]
    public float Y;

    [Header("Z-SHIFT")]
    [Range(-.5f, 1.5f)]
    public float Z;

    void Start() {
        LoadValues();
    }

    void OnApplicationQuit() {
        SaveValues();
    }

    void OnValidate() {
        SetValues();
    }

    void SetValues() {
        camFeed.localPosition = new Vector3(X, Y, Z);
        leftCam.localPosition = new Vector3(-CamDistance, 0, 0);
        rightCam.localPosition = new Vector3(CamDistance, 0, 0);
    }

    void LoadValues() {
        if (PlayerPrefs.HasKey("X")) {
            X = PlayerPrefs.GetFloat("X");
            Y = PlayerPrefs.GetFloat("Y");
            Z = PlayerPrefs.GetFloat("Z");
            CamDistance = PlayerPrefs.GetFloat("CamDistance");
        }
        SetValues();
    }

    void SaveValues() {
        PlayerPrefs.SetFloat("X", X);
        PlayerPrefs.SetFloat("Y", Y);
        PlayerPrefs.SetFloat("Z", Z);
        PlayerPrefs.SetFloat("CamDistance", CamDistance);
    }
}
