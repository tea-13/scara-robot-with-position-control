using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint child;
    public int number;

    public Joint GetChild() {
        return child;
    }

    public void Rotate(float _angle) {
        transform.Rotate(Vector3.up * _angle);
    }
    
}
