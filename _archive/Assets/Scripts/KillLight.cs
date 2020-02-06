using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLight : MonoBehaviour
{
    [SerializeField] Component lightComponent;

    private void Start()
    {
        Destroy(lightComponent, .1f);
        print("Hit light out.");
    }
}
