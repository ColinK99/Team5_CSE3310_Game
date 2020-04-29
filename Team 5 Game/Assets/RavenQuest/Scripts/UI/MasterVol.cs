using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVol : MonoBehaviour
{

    public void updateMaster(float newVolume)
    {
        float volume = AudioListener.volume;
        volume = newVolume;
        AudioListener.volume = newVolume ;
    }
    // Update is called once per frame


}
