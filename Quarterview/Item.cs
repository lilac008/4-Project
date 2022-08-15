using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /// Item obj(Hammer, HandGun, SubMachineGun, Grenade, Ammo, Heart, Gold, Sliver, Bronze... etc)
    /// 1) Light : (Type:point, intencity:10, range:4)
    /// 2) Particle : (Renderer - Material:default line,  Emission - RoT:15,  Shape - Rotation(x:-90), ColorOverLifetime(시간에따른색변화):,  SizeOverLifetime :,  LimitVelocityOverLifetime - drag(저항값):1,   Particle - StartLifetime:2 ~~ RandomBetweenTwoConstants:4(2~4까지 랜덤으로 입자생존시간이 결정),StartSpeed:3 ~~ RBTC:5
    /// 3) rigidbody 
    /// 4) sphere collider(물체 중력, 떠 있되 바닥에 착지) : y:1      --> 수정(충돌방지목적) : sphere collider(isTrigger비활성화 상태인)의 ...- MoveUP - Open Prefab - MoveUP(scene상으로 prefab이 열린 상태에서 재설정)  
    /// 5) sphere collider(습득 범위) : radius 5, isTrigger 
    /// 6) 이 script 적용 후 enum 타입 지정 
    /// 7) tag : Weapon 3종, Item  6종  
    /// 8) value :수량 설정 후 전부 prefab에 에셋으로 등록, 좌표 0,0,0




    public enum Type { Coin, Weapon, Ammo, Grenade, Heart }  ///enum : 열거형 데이터타입
    public Type type;
    public int value;                                        ///수량 :  (coin:5,25,100, ammo:30, grenade:1, heart:20,  hammer:0, HandGun:1, SubMachineGun:2)

    Rigidbody r;
    SphereCollider sCollider;

    void Awake() ///12
    {
        r = GetComponent<Rigidbody>();
        sCollider = GetComponent<SphereCollider>();    ///getComponent는 제일 첫번째 component만 가져오므로, sphere collider(isTrigger비활성화 상태인)의 ...- MoveUP - Open Prefab - MoveUP(scene상으로 prefab이 열린 상태에서 재설정)   

    }

    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);  ///자전, transform.Rotate(축 방향 * 속도 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision c)  ///12
    {
        if (c.gameObject.tag == "Floor") 
        {
            r.isKinematic = true;                       /// rigidbody : 활성화
            sCollider.enabled = false;                  /// collider  : 바닥에 떨어지고 난 후 (isTrigger비활성 상태인)collider 비활성화
        }

    }





}
