using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstical : MonoBehaviour
{
    public Transform box;
    void Start(){
        box.parent = transform;
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(0, 100 *Time.deltaTime, 0);
    }
}
