using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample_HeightDetection : MonoBehaviour {

    public Text height_display;
    public LayerMask targetLayer;

    public LineRenderer vertical_line;
    public LineRenderer horizontal_line;
    private void Update()
    {

        Vector3 origin = transform.position + Vector3.up*5000;
        Vector3 boxcast_size = transform.localScale/2;

        RaycastHit hit;

        if (Physics.BoxCast(origin, boxcast_size, Vector3.down, out hit, new Quaternion(), 6000, targetLayer))
        {

            vertical_line.enabled = true;
            horizontal_line.enabled = true;

            height_display.text = "Height: " + hit.point.y.ToString();


            horizontal_line.SetPosition(0, hit.point);
            Vector3 line_end = hit.point;
            line_end.x = -transform.localScale.x / 2;
            horizontal_line.SetPosition(1, line_end);

            vertical_line.SetPosition(0, line_end);
            line_end.y = 0;
            vertical_line.SetPosition(1, line_end);



        }
        else
        {
            vertical_line.enabled = false;
            horizontal_line.enabled = false;
        }
    }
}
