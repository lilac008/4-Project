using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;     ///목표 : Player를 drag해서 놓는다.  
    public Vector3 offset;       ///보정값 : camera position 값을 그대로 넣는다.


    void Update()
    {
        transform.position = target.position + offset;  /// camera position = target position + offset;
    }







}
