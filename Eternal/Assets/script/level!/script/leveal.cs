using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveal : MonoBehaviour
{

    [SerializeField] float Leftside = 3.5f;
    [SerializeField] float rightside = 3.5f;
    [SerializeField] float internalleft;
    [SerializeField] float internalRight;



    private void Update()
    {
        internalleft = Leftside;
        internalRight = rightside;

    }
}
