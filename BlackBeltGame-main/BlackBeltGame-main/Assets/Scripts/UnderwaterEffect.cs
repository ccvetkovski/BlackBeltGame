using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UnderwaterEffect : MonoBehaviour
{
    public Volume waterFx;
    public Volume normalFx;

    private void OnTriggerEnter(Collider other) {
        waterFx.enabled = true;
        normalFx.enabled = false;
        RenderSettings.fog = true;
    }

    private void OnTriggerExit(Collider other) {
        waterFx.enabled = false;
        normalFx.enabled = true;
        RenderSettings.fog = false;
    }
}
