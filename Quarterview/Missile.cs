using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// Missile (Transform:P/R(0,0,0))   (영상 12부 34분 참조, z축(blue) 각도 참조)
/// 1) Missile - Mesh obj(Transform P(0,0,0), R(0,-90,0)) - Missile script 추가 
/// 2) Missile - Effect(빈obj, 꼬리부분위치, Transform.P(0,3,-1)) - Particle System (Renderer:Default-Line, Effect(startLifetime:0.6,startSpeed:15,startSize:0.7), Emission(RoT:30), Shape(Angle:13, Radius:0.5, Rotation(0,180,0)), ColorOverLifetime(alpha:100), sizeOverLifetime:역방향) 추가
/// 3) Missile - Rigidbody(useGravity 해제),  Box Collider(피격범위, center(0,3,0), size(2,2,2), isTrigger, Bullet script(damage:15), Tag/Layer:EnemyBullet 후 Prefab 등록
/// 4) Open prefab(Tranform(0,0,0), )
/// 








public class Missile : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.right * 30 * Time.deltaTime);  ///자전
    }

}