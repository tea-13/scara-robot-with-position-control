using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp : MonoBehaviour
{
    private bool insideArea = false;
    private bool outsideArea = false;
    private bool height = false;

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x; //float.Parse(xCord.text);
        float y = transform.position.y; //float.Parse(yCord.text);
        float z = transform.position.z; //float.Parse(zCord.text);


        height = (y >= -0.4 && y <= 1.4);
        outsideArea = ((Mathf.Pow(x, 2) + Mathf.Pow(z, 2) <= Mathf.Pow(4.5f, 2)) && (x >= -3.01)) || ((Mathf.Pow((x + 1.17f), 2) + Mathf.Pow((z - 1.3f), 2) <= Mathf.Pow(2.75f, 2)) && (x <= -3.01)) || ((Mathf.Pow((x + 1.17f), 2) + Mathf.Pow((z + 1.3f), 2) <= Mathf.Pow(2.75f, 2)) && (x <= -3.01));
        insideArea = ((z >= -1.15 && z <= 1.15) && (x >= -2.9 && x <= -0.936)) || ((Mathf.Pow(x, 2) + Mathf.Pow(z, 2) <= Mathf.Pow(1.5f, 2)) && (x >= -0.936f));
        print(height && outsideArea && !insideArea);
    }
}
