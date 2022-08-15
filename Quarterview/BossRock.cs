using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Boss Rock 
/// 1. Rigidbody(Mass:10, AngularDrag(ȸ������):0, FreezeRotation(y,z ���)),  SphereCollider(Radius:4), SphereCollider(isTrigger, Wall tag�� �ε��� ������� �뵵),  BossRock script �� �Ʒ� ���� �߰�,  Tag/Layer:EnemyBullet �߰� �� prefabȭ 




public class BossRock : Bullet  ///���
{

    /// 
    float angularPower = 2;
    float scaleValue = 0.1f;

    Rigidbody r;

    ///�б�
    bool isShoot;

    /// Bullet���� ���
    ///public bool isRock;                /// Bullet script���� Floor tag�� �浹�Ͽ� ������� ���� �����ϱ� ���� flag  /  BossRock script���� �̸� ��� �� BossRock���� isRock Ȱ��ȭ




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
