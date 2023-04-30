using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IKmanager : MonoBehaviour
{
    public Joint root;
    public Joint end;
    public GameObject body;
    public GameObject target;
    public float threshold = 0.05f;
    public float rate = 5f;
    public int count = 0;
    public TMP_Dropdown targetsList;
    public GameObject stdPos;

    private void Update()
    {
        List<GameObject> targets = new List<GameObject>();
        for(int i = 0; i < targetsList.options.Count; i++){
            targets.Add(GameObject.Find(targetsList.options[i].text));
            targets.Add(stdPos);
        }

        if (targetsList.options.Count > 0)
        {
            try
            {
                target = targets[count];
                if (target.name == "stdPos" && targets.Count == 2) count -= 1;
            } 
            catch(Exception e) 
            {
                print(e.ToString());
                count -= 1;
            }

            float s = end.transform.position.y - target.transform.position.y;
            body.transform.Translate(new Vector3(0, -s, 0) * Time.deltaTime, Space.World);

            if (GetDistance(end.transform.position, target.transform.position) > threshold)
            {
                Joint current = root;

                while (current != null)
                {
                    float distance1 = GetDistance(end.transform.position, target.transform.position);
                    current.Rotate(0.01f);

                    float distance2 = GetDistance(end.transform.position, target.transform.position);
                    current.Rotate(-0.01f);
                    
                    float delta = distance2 - distance1;

                    float slope = delta / 0.01f;

                    current.Rotate(-slope * rate);
                        
                    current = current.GetChild();
                }
            } 
            else
            {
                if (targetsList.options.Count > 1) count = (count + 1) % targets.Count;
            }
        }
    }

    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }
}
