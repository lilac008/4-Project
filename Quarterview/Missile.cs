using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// Missile (Transform:P/R(0,0,0))   (���� 12�� 34�� ����, z��(blue) ���� ����)
/// 1) Missile - Mesh obj(Transform P(0,0,0), R(0,-90,0)) - Missile script �߰� 
/// 2) Missile - Effect(��obj, �����κ���ġ, Transform.P(0,3,-1)) - Particle System (Renderer:Default-Line, Effect(startLifetime:0.6,startSpeed:15,startSize:0.7), Emission(RoT:30), Shape(Angle:13, Radius:0.5, Rotation(0,180,0)), ColorOverLifetime(alpha:100), sizeOverLifetime:������) �߰�
/// 3) Missile - Rigidbody(useGravity ����),  Box Collider(�ǰݹ���, center(0,3,0), size(2,2,2), isTrigger, Bullet script(damage:15), Tag/Layer:EnemyBullet �� Prefab ���
/// 4) Open prefab(Tranform(0,0,0), )
/// 








public class Missile : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.right * 30 * Time.deltaTime);  ///����
    }

}