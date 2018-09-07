using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Sample_HeightDetection : MonoBehaviour {

	[FormerlySerializedAs("line_tensity")] public float LineTensity=1.0f;

    [FormerlySerializedAs("height_display")] public Text HeightDisplay;
    public LayerMask targetLayer;

    [FormerlySerializedAs("vertical_line")] public LineRenderer VerticalLine;
    [FormerlySerializedAs("horizontal_line")] public LineRenderer HorizontalLine;
    private void Update()
    {

        Vector3 origin = transform.position + Vector3.up*5000;
        Vector3 boxcastSize = transform.localScale/2;

        RaycastHit hit;

        if (Physics.BoxCast(origin, boxcastSize, Vector3.down, out hit, new Quaternion(), 6000, targetLayer))
        {

            VerticalLine.enabled = true;
            HorizontalLine.enabled = true;

            HeightDisplay.text = "Height: " + hit.point.y.ToString();


            HorizontalLine.SetPosition(0, hit.point);
            Vector3 lineEnd = hit.point;
            
            lineEnd.x = transform.position.x- transform.localScale.x / 2;
            float lineLength = Mathf.Abs(hit.point.x - lineEnd.x);
            HorizontalLine.SetPosition(1, lineEnd);

			HorizontalLine.material.SetTextureScale("_MainTex", new Vector2(lineLength * 2*LineTensity, 1));
            

            VerticalLine.SetPosition(0, lineEnd);
            lineEnd.y = 0;
            VerticalLine.SetPosition(1, lineEnd);

            lineLength = Mathf.Abs(hit.point.y - lineEnd.y);
			VerticalLine.material.SetTextureScale("_MainTex", new Vector2(lineLength * 2* LineTensity, 1));


        }
        else
        {
            VerticalLine.enabled = false;
            HorizontalLine.enabled = false;
        }
    }
}
