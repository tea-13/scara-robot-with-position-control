using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    private List<Point> targetPoints = new List<Point>();
    private List<string> targetName = new List<string>();

    public TMP_InputField xCord;
    public TMP_InputField yCord;
    public TMP_InputField zCord;
    public TMP_Dropdown targetsList;

    private bool insideArea = false;
    private bool outsideArea = false;
    private bool height = false;
    private int amount = 0;

    public void createTarget(){
        
        try
        {
            float x = float.Parse(xCord.text);
            float y = float.Parse(yCord.text);
            float z = float.Parse(zCord.text);
            string name = "Target " + amount.ToString();

            height = (y >= -0.4 && y <= 1.4);
            outsideArea = ((Mathf.Pow(x, 2) + Mathf.Pow(z, 2) <= Mathf.Pow(4.5f, 2)) && (x >= -3.01)) || ((Mathf.Pow((x + 1.17f), 2) + Mathf.Pow((z - 1.3f), 2) <= Mathf.Pow(2.75f, 2)) && (x <= -3.01)) || ((Mathf.Pow((x + 1.17f), 2) + Mathf.Pow((z + 1.3f), 2) <= Mathf.Pow(2.75f, 2)) && (x <= -3.01));
            insideArea = ((z >= -1.15 && z <= 1.15) && (x >= -2.9 && x <= -0.936)) || ((Mathf.Pow(x, 2) + Mathf.Pow(z, 2) <= Mathf.Pow(1.5f, 2)) && (x >= -0.936f));
            

            if (height && outsideArea && !insideArea)
            {
                amount += 1;

                GameObject target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                target.name = name;
                target.transform.position = new Vector3(x, y, z);
                target.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                
                targetPoints.Add(new Point(name, target, x, y, z));

                targetsList.options.Add(new TMP_Dropdown.OptionData(){ text = name });

                targetsList.RefreshShownValue();
            }

        } catch(Exception e) {
            print(e.ToString());
        }

    }

    public void deleteTarget() {
        string deletePoint = targetsList.options[targetsList.value].text;

        for (int x = 0; x < targetPoints.Count; x++) {
            if (targetPoints[x].name == deletePoint){
                Destroy(targetPoints[x].target);
                targetsList.options.RemoveAt(x);
                targetPoints.RemoveAt(x);
                targetsList.RefreshShownValue();
            }
        }
    }
}


public class Point
{
    public string name {get;set;}
    public GameObject target {get;set;}
    public float x {get;set;}
    public float y {get;set;}
    public float z {get;set;}

    public Point(string _name, GameObject _target, float _x, float _y, float _z)
    {
        name = _name;
        target = _target;
        x = _x;
        y = _y;
        z = _z;
    }
}