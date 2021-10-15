using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            string screenshotname;

            int randomNumber = Random.Range(0, 100000);

            screenshotname = "ScreenShot" + randomNumber + ".png";

            ScreenCapture.CaptureScreenshot(screenshotname);
        }
    }

}
