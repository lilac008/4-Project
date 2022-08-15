using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Bullet HandGun(�� obj)       - Trail Renderer (material:default-line, Time:0.3, MVD :0 ��), Rigidbody, Sphere Collider (radius 0.3, isTrigger ) �߰�
/// Bullet SubMachineGun(�� obj) - Trail Renderer (Time:0.1, MVD :0 ��) Rigidbody, Sphere Collider (radius 0.3, isTrigger ) �߰�
/// Bullet Case (�̿� prefab)    - Transform.Scale(.5/.5/.5), Rigidbody, Box Collider(.45/.3/.3) �߰�
/// 1) Bullet script �߰� �� �� ����.  
/// 2) Bullet tag ����
/// 3) Prefab�� ��� ���� 





public class Bullet : MonoBehaviour
{
    public int damage;                 /// HandGun:20, SubMachineGun:10, Bullet Case:0  (���:MissileBoss:12)
    public bool isMelee;               /// Enemy A,B Ȱ��ȭ
    public bool isRock;                /// Bullet script���� Floor tag�� �浹�Ͽ� ������� ���� �����ϱ� ���� flag  /  BossRock script���� �̸� ��� �� BossRock���� isRock Ȱ��ȭ







    void OnCollisionEnter(Collision c) 
    {
        if (!isRock && c.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3); 
        }
    }


    void OnTriggerEnter(Collider t)                     ///13
    {
        if (!isMelee && t.gameObject.tag == "Wall")     ///19  !isMelee(���� �������� �÷��̾� ���ݽ� �������ݹ����� �ı��Ǵ� �� ����) 
        {
            Destroy(gameObject);
        }
    }







}
