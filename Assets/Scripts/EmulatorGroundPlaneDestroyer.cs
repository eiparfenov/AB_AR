using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorGroundPlaneDestroyer : MonoBehaviour
{
    private bool first = true;
    public void Destroy()
    {
        if (first)
        {
            GameObject egp = transform.Find("/emulator_ground_plane").gameObject;
            if (egp)
            {
                Destroy(egp);
            }
        }
    }
}
