using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    //Scaling cube with loudness
    public Vector3 minScale;
    public Vector3 maxScale;

    //Making cube jump with loudness
    public Vector3 minJump;
    public Vector3 maxJump;

    //The detector that were created in AudioLoudnessDetection is added to the script. 
    public AudioLoudnessDetection detector;
    //Helping adjust the sensitivity of the microphone
    public float loudnessSensibility;
    public float threshold = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
      //minJump is at the ground and then maxJump is the maximum height the character will jump at highest loudness.
      minJump = new Vector3(0.0f, 0.0f, 0.0f);
      maxJump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the character in positive z-axis over time.
        transform.Translate(0f,0f,0.01f);
        //Detects the loudness from microphone and then multiplies it with the adjustable sensitivity.
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        //If the loudness is under the threshold it's too low and it's neglectable.
        if(loudness < threshold)
            loudness = 0;

        //lerp value from minJump to maxJump
        transform.localPosition = Vector3.Lerp(minJump, maxJump, loudness);
    }
}
