using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    void Awake()
    {
        // 1. Turn off VSync (Mandatory: VSync overrides targetFrameRate)
        QualitySettings.vSyncCount = 0;

        // 2. Set the custom frame rate cap
        Application.targetFrameRate = 30;
    }
}
