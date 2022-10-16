using UnityEngine;
using UnityEngine.XR;

public class HmdInfoManager : MonoBehaviour
{
    private void Start()
    {
        switch (XRSettings.isDeviceActive)
        {
            case false:
                Debug.Log(("Device not plugged"));
                break;
            case true 
                  when XRSettings.loadedDeviceName is "Mock HMD" or "MockHMDDisplay":
                Debug.Log("Using Mock HMD");
                break;
            default:
                Debug.Log("Plugged headset: " + XRSettings.loadedDeviceName);
                break;
        }
    }
}