using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Bullet HandGun(빈 obj)       - Trail Renderer (material:default-line, Time:0.3, MVD :0 등), Rigidbody, Sphere Collider (radius 0.3, isTrigger ) 추가
/// Bullet SubMachineGun(빈 obj) - Trail Renderer (Time:0.1, MVD :0 등) Rigidbody, Sphere Collider (radius 0.3, isTrigger ) 추가
/// Bullet Case (미완 prefab)    - Transform.Scale(.5/.5/.5), Rigidbody, Box Collider(.45/.3/.3) 추가
/// 1) Bullet script 추가 후 값 설정.  
/// 2) Bullet tag 설정
/// 3) Prefab에 모두 저장 





public class Bullet : MonoBehaviour
{
    public int damage;                 /// HandGun:20, SubMachineGun:10, Bullet Case:0  (상속:MissileBoss:12)
    public bool isMelee;               /// Enemy A,B 활성화
    public bool isRock;                /// Bullet script에서 Floor tag와 충돌하여 사라지는 것을 방지하기 위한 flag  /  BossRock script에서 이를 상속 후 BossRock에서 isRock 활성화







    void OnCollisionEnter(Collision c) 
    {
        if (!isRock && c.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3); 
        }
    }


    void OnTriggerEnter(Collider t)                     ///13
    {
        if (!isMelee && t.gameObject.tag == "Wall")     ///19  !isMelee(몹이 벽에닿은 플레이어 공격시 근접공격범위가 파괴되는 걸 방지) 
        {
            Destroy(gameObject);
        }
    }







}
