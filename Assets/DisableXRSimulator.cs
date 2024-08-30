using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class DisableXRSimulator : MonoBehaviour
{
    void Start()
    {
        XRDeviceSimulator simulator = FindObjectOfType<XRDeviceSimulator>();
        if (simulator != null)
        {
            simulator.gameObject.SetActive(false);
        }
    }
}
