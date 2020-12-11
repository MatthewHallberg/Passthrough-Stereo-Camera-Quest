using UnityEngine;

public class CamFeed : MonoBehaviour {

    WebCamTexture webcamTexture;
    bool videoStarted;

    void Start() {
        StartWebCam();
    }

    void Update() {
        if (!videoStarted && webcamTexture.width > 100) {
            SetAspectRatio();
        }
    }

    void StartWebCam() {
        //logitech 1920 by 1080
        webcamTexture = new WebCamTexture(GetWebCamDevice(),960,540,30);
        Renderer renderer = GetComponent<Renderer>();
        //renderer.material.SetTexture("_BaseMap", webcamTexture);
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    void SetAspectRatio() {
        Vector3 tempScale = transform.localScale;
        float aspectRatio = (float)webcamTexture.width / (float)webcamTexture.height;
        tempScale.x = aspectRatio;
        transform.localScale = tempScale;
        videoStarted = true;
    }

    string GetWebCamDevice() {
        WebCamDevice[] devices = WebCamTexture.devices;
        foreach (WebCamDevice device in devices) {
            print(device.name);
        }
        return devices[devices.Length - 1].name;
    }
}
