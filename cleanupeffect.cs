using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanupeffect : MonoBehaviour
{
    //cleans up particle system left over from prefabs
    private float timeleft = 1f;
    

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0f)
        {
            Destroy(this.gameObject);
          }
    }
}
