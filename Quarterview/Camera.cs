using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;     ///��ǥ : Player�� drag�ؼ� ���´�.  
    public Vector3 offset;       ///������ : camera position ���� �״�� �ִ´�.


    void Update()
    {
        transform.position = target.position + offset;  /// camera position = target position + offset;
    }







}
