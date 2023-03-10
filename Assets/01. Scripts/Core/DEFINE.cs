using Cinemachine;
using UnityEngine;

public static class DEFINE
{
    public const float HitEffectDuration = 0.15f;
    public const float TimeDelayScale = 0.15f;
    public const float CamShakePower = 6f;
    public const float CamShakeFreq = 2f;

    private static CinemachineVirtualCamera cmMainCam = null;
    public static CinemachineVirtualCamera CmMainCam {
        get {
            if(cmMainCam == null)
                cmMainCam = GameObject.Find("CmMainCam").GetComponent<CinemachineVirtualCamera>();

            return cmMainCam;
        }
    }

}
