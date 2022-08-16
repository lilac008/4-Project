using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Boss Rock 
/// 1. Rigidbody(Mass:10, AngularDrag(회전저항):0, FreezeRotation(y,z 잠금)),  SphereCollider(Radius:4), SphereCollider(isTrigger, Wall tag에 부딪혀 사라지는 용도),  BossRock script 후 아래 설정 추가,  Tag/Layer:EnemyBullet 추가 후 prefab화 




public class BossRock : Bullet  ///상속
{

    /// 
    float angularPower = 2;
    float scaleValue = 0.1f;

    Rigidbody r;

    ///분기
    bool isShoot;

    /// Bullet에서 상속
    ///public bool isRock;                /// Bullet script에서 Floor tag와 충돌하여 사라지는 것을 방지하기 위한 flag  /  BossRock script에서 이를 상속 후 BossRock에서 isRock 활성화




    void Awake() 
    {
        r = GetComponent<Rigidbody>();
        startCoroutine(GainPowerTimer());
        startCoroutine(GainPower());
    } 

    IEnumerator GainPowerTimer() 
    {
        yield return new WaitForSeconds(2.2f);
        isShoot = true;
    }

    IEnumerator GainPower()
    {
        while (!isShoot) 
        {
            angularPower += 0.02f;
            scaleValue += 0.005f;
            transform.localScale = Vector3.one * scaleValue;
            r.AddTorque(transform.right * angularPower, ForceMode.Acceleration);
            yield return null;
        }


    }








}
