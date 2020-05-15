using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class System_Functions : MonoBehaviour
{

    private Boolean doneCheck;



    public void sleep(float time) {

        StartCoroutine(Sleeping(time));

    }


    public void sleepTillDestroy(float time,GameObject gumExplosion)
    {
        StartCoroutine(SleepAndDestroy(time,gumExplosion));

    }



    private IEnumerator Sleeping(float time)
    {

        //time to sleep for
        yield return new WaitForSeconds(time);
        Debug.Log("Timer Finished");

    }

    private IEnumerator SleepAndDestroy(float time, GameObject gumExplosion)
    {

        //time to sleep for
        yield return new WaitForSeconds(time);
        Debug.Log("Timer Finished");
        Destroy(gumExplosion);
    }



}
