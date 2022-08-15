using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Weapon : MonoBehaviour
{

    /// Player - Right Hand - Weapon Point - 무기 3종(Hammer, HandGun, SubMachineGun) 
    /// 1) Weapon script 적용 후 값 입력
    /// 2) Melee / Range Tag 적용
    /// 3) Box Collider(공격범위(center 2.5, size x 3.5, y 3, z 2), isTrigger ) 지정, Box Collider 비활성화. 
    /// 4) (무기3종) - Mesh Obj - Effect(빈 obj) - Trail Renderer(Material:Default-Line, Time:0.5, Min Vertex Distance(최소정점거리;잔상꺾임):1.5 ) 추가 & 비활성화. 
    /// 5) Player - Bullet Pos(빈obj, Transform:발사위치 설정)
    ///    Player - Weapon Point - Gun - Case Pos(빈 obj, scene에서 Local로 변경, Transform:배출위치 설정)
    ///  




    public enum Type { Melee, Range };
    public Type type;
    public int damage;                      /// 공격력 : 25
    public float attackSpeed;               /// 공속 : 0.4 
    public BoxCollider meleeArea;           /// 근접공격범위 : 자기 자신(무기 3종)을 드래그.
    public TrailRenderer trailEffect;       /// 공격잔상 : (무기3종-mesh obj-)Effect를 드래그.

    public Transform bulletPos;             /// Bullet Pos 드래그,  (Player - Bullet Pos)
    public Transform bulletCasePos;         /// Case Pos 드래그,    (Player - Weapon Point - Gun - Case Pos) 
    public GameObject bullet;               /// prefab  (Bullet HandGun / Bullet SubMachineGun) 
    public GameObject bulletCase;           /// prefab   탄피

    public int maxAmmoInGun;                /// HandGun:7, SubMachineGun:30 
    public int curAmmoInGun;                /// HandGun:7, SubMachineGun:30 처음 무기 득템시 쓸 수 있는 량



    public void Use() ///9 Melee/Range tag에 해당하는 무기 사용시 
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");         /// 새로 시작하기 위해 지금 동작하는 co-routine 정지
            StartCoroutine("Swing");        ///9 co-routine 시작
        }
        else if (type == Type.Range) 
        { 
            StartCoroutine("Shot"); 
        }
    }


    IEnumerator Swing() ///9 co-routine : 반환형을 IEnumerator(열거형class)로 설정. yield return으로 반환, yield break로 탈출.
    {
        /// yield return null;                        ///1프레임 대기

        yield return new WaitForSeconds(0.1f);        ///0.1초 대기 후 
        meleeArea.enabled = true;                     ///boxCollider 활성화 
        trailEffect.enabled = true;                   ///TrailRenderer 활성화
        
        yield return new WaitForSeconds(0.3f);        ///0.3초 뒤 각각 비활성화
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }


    IEnumerator Shot() ///9 
    {
        /// 총알발사
        GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);           ///인스턴스화
        Rigidbody rInstantBullet = instantBullet.GetComponent<Rigidbody>();                               ///인스턴스화된 bullet에 rigidbody 추가
        rInstantBullet.velocity = bulletPos.forward * 50;                                                 ///rigidbody에 속도 적용
        yield return null;

        /// 탄피배출
        GameObject instantBC = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);  
        Rigidbody rInstantBC = instantBC.GetComponent<Rigidbody>();                                      
        Vector3 vecBC = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up + Random.Range(2, 3);  /// Vector3 파란색 반대방향 : forward * -1  (+ 살짝 위로 솟도록 vector3.up) 
        rInstantBC.AddForce(vecBC, ForceMode.Impulse);                                                   /// rigidbody에 가속도 적용
        rInstantBC.AddTorque(Vector3.up * 10, ForceMode.Impulse);                                        /// rigidbody에 회전 적용

    }




}
