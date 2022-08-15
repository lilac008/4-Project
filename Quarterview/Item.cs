using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /// Item obj(Hammer, HandGun, SubMachineGun, Grenade, Ammo, Heart, Gold, Sliver, Bronze... etc)
    /// 1) Light : (Type:point, intencity:10, range:4)
    /// 2) Particle : (Renderer - Material:default line,  Emission - RoT:15,  Shape - Rotation(x:-90), ColorOverLifetime(�ð�����������ȭ):,  SizeOverLifetime :,  LimitVelocityOverLifetime - drag(���װ�):1,   Particle - StartLifetime:2 ~~ RandomBetweenTwoConstants:4(2~4���� �������� ���ڻ����ð��� ����),StartSpeed:3 ~~ RBTC:5
    /// 3) rigidbody 
    /// 4) sphere collider(��ü �߷�, �� �ֵ� �ٴڿ� ����) : y:1      --> ����(�浹��������) : sphere collider(isTrigger��Ȱ��ȭ ������)�� ...- MoveUP - Open Prefab - MoveUP(scene������ prefab�� ���� ���¿��� �缳��)  
    /// 5) sphere collider(���� ����) : radius 5, isTrigger 
    /// 6) �� script ���� �� enum Ÿ�� ���� 
    /// 7) tag : Weapon 3��, Item  6��  
    /// 8) value :���� ���� �� ���� prefab�� �������� ���, ��ǥ 0,0,0




    public enum Type { Coin, Weapon, Ammo, Grenade, Heart }  ///enum : ������ ������Ÿ��
    public Type type;
    public int value;                                        ///���� :  (coin:5,25,100, ammo:30, grenade:1, heart:20,  hammer:0, HandGun:1, SubMachineGun:2)

    Rigidbody r;
    SphereCollider sCollider;

    void Awake() ///12
    {
        r = GetComponent<Rigidbody>();
        sCollider = GetComponent<SphereCollider>();    ///getComponent�� ���� ù��° component�� �������Ƿ�, sphere collider(isTrigger��Ȱ��ȭ ������)�� ...- MoveUP - Open Prefab - MoveUP(scene������ prefab�� ���� ���¿��� �缳��)   

    }

    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);  ///����, transform.Rotate(�� ���� * �ӵ� * Time.deltaTime);
    }

    void OnCollisionEnter(Collision c)  ///12
    {
        if (c.gameObject.tag == "Floor") 
        {
            r.isKinematic = true;                       /// rigidbody : Ȱ��ȭ
            sCollider.enabled = false;                  /// collider  : �ٴڿ� �������� �� �� (isTrigger��Ȱ�� ������)collider ��Ȱ��ȭ
        }

    }





}
