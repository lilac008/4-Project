using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Weapon : MonoBehaviour
{

    /// Player - Right Hand - Weapon Point - ���� 3��(Hammer, HandGun, SubMachineGun) 
    /// 1) Weapon script ���� �� �� �Է�
    /// 2) Melee / Range Tag ����
    /// 3) Box Collider(���ݹ���(center 2.5, size x 3.5, y 3, z 2), isTrigger ) ����, Box Collider ��Ȱ��ȭ. 
    /// 4) (����3��) - Mesh Obj - Effect(�� obj) - Trail Renderer(Material:Default-Line, Time:0.5, Min Vertex Distance(�ּ������Ÿ�;�ܻ���):1.5 ) �߰� & ��Ȱ��ȭ. 
    /// 5) Player - Bullet Pos(��obj, Transform:�߻���ġ ����)
    ///    Player - Weapon Point - Gun - Case Pos(�� obj, scene���� Local�� ����, Transform:������ġ ����)
    ///  




    public enum Type { Melee, Range };
    public Type type;
    public int damage;                      /// ���ݷ� : 25
    public float attackSpeed;               /// ���� : 0.4 
    public BoxCollider meleeArea;           /// �������ݹ��� : �ڱ� �ڽ�(���� 3��)�� �巡��.
    public TrailRenderer trailEffect;       /// �����ܻ� : (����3��-mesh obj-)Effect�� �巡��.

    public Transform bulletPos;             /// Bullet Pos �巡��,  (Player - Bullet Pos)
    public Transform bulletCasePos;         /// Case Pos �巡��,    (Player - Weapon Point - Gun - Case Pos) 
    public GameObject bullet;               /// prefab  (Bullet HandGun / Bullet SubMachineGun) 
    public GameObject bulletCase;           /// prefab   ź��

    public int maxAmmoInGun;                /// HandGun:7, SubMachineGun:30 
    public int curAmmoInGun;                /// HandGun:7, SubMachineGun:30 ó�� ���� ���۽� �� �� �ִ� ��



    public void Use() ///9 Melee/Range tag�� �ش��ϴ� ���� ���� 
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");         /// ���� �����ϱ� ���� ���� �����ϴ� co-routine ����
            StartCoroutine("Swing");        ///9 co-routine ����
        }
        else if (type == Type.Range) 
        { 
            StartCoroutine("Shot"); 
        }
    }


    IEnumerator Swing() ///9 co-routine : ��ȯ���� IEnumerator(������class)�� ����. yield return���� ��ȯ, yield break�� Ż��.
    {
        /// yield return null;                        ///1������ ���

        yield return new WaitForSeconds(0.1f);        ///0.1�� ��� �� 
        meleeArea.enabled = true;                     ///boxCollider Ȱ��ȭ 
        trailEffect.enabled = true;                   ///TrailRenderer Ȱ��ȭ
        
        yield return new WaitForSeconds(0.3f);        ///0.3�� �� ���� ��Ȱ��ȭ
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }


    IEnumerator Shot() ///9 
    {
        /// �Ѿ˹߻�
        GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);           ///�ν��Ͻ�ȭ
        Rigidbody rInstantBullet = instantBullet.GetComponent<Rigidbody>();                               ///�ν��Ͻ�ȭ�� bullet�� rigidbody �߰�
        rInstantBullet.velocity = bulletPos.forward * 50;                                                 ///rigidbody�� �ӵ� ����
        yield return null;

        /// ź�ǹ���
        GameObject instantBC = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);  
        Rigidbody rInstantBC = instantBC.GetComponent<Rigidbody>();                                      
        Vector3 vecBC = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up + Random.Range(2, 3);  /// Vector3 �Ķ��� �ݴ���� : forward * -1  (+ ��¦ ���� �ڵ��� vector3.up) 
        rInstantBC.AddForce(vecBC, ForceMode.Impulse);                                                   /// rigidbody�� ���ӵ� ����
        rInstantBC.AddTorque(Vector3.up * 10, ForceMode.Impulse);                                        /// rigidbody�� ȸ�� ����

    }




}
