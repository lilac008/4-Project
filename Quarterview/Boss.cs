using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;           ///NavMeshAgent


/// Enemy D(����)
/// 1. Animator ���� (���� 13�� ����, Entry - Idle,  AnyState - tDie, tShot, tBigShot, tTaunt - Exit(has Exit Time )), 
/// 2. Enemy D - rigidbody(FreezeR x,z),  boxCollider(center(0,2,0),size(3.7 x 3)),  Nav Mesh Agent(Speed:40,AngularSpeed:0,Acceleration:60),  Tag/Layer Enemy,   Boss script �߰�
/// 3. Enemy D - Mesh Obj - Missile PortA/B 2��(��obj, A(2,2,1), B(-2,2,1))
/// 4. Enemy D - Mesh Obj - BossMeleeArea(��obj/  Box Collider(���ݹ���,center(0,(0.5),0),size(3.5,0.5,3.5),isTrigger,��Ȱ��ȭ, bullet script �߰� �� Damage:20, is MeleeȰ��ȭ), Tag/Layer:EnemyBullet �߰� ) 
///
/// Enemy D script ���� 
/// EnemyType:D, maxH:100, curH:100, target:player�巡��,  MeleeArea:(EmeyD-MeshObj-)MeleeArea �巡��,  Bullet:BossRock(prefab) �巡��,  Missile:BossMissile(prefab) �巡��,  MissilePort A/B:(EmeyD-MeshObj-)MissilePortA/B �巡��, isLook Ȱ��ȭ(player�� ���ϵ���) 








public class Boss : Enemy   ///���
{
    public GameObject missile;
    public Transform missilePortA;
    public Transform missilePortB;
    public bool isLook;

    Vector3 lookVec;                     ///player������ ����
    Vector3 tauntVec;                    ///player������ ����





    void Awake() ///Awake �Լ��� �ڽ� script���� ����???
    {
        ///UnassignedReforenceException : The variable anim of Boss has not been assigned. You probably need to assign the anim variable of the Boss script in the inspector.
        r = GetComponent<Rigidbody>();                              ///Enemy���� ���
        bCollider = GetComponent<BoxCollider>();                    ///Enemy���� ���
        meshs = GetComponentsInChildren<MeshRenderer>().material;   ///Enemy���� ���    
        nav = GetComponent<NavMeshAgent>();                         ///Enemy���� ���
        ani = GetComponentInChildren<Animator>();                   ///Enemy���� ���

        nav.isStopped = true;                                       ///
        StartCoroutine(Think()); 
    }



    void Update() 
    {
        if (isDead)
        {
            StopAllCoroutines();                     ///��� �ڷ�ƾ ����
            return;                                  ///�Ʒ� �ݺ����� ������� �ʵ��� ����������
        }
        if (isLook) ///�ٶ󺸴� ���̸�
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 5f;
            transform.LookAt(target.position + lookVec);    ///Enemy D�� ���� ���� = player��ġ(Enemy script�� target) + lookVec(player�� �����̴� ������ 5�� �ռ���)
        }
        else
            nav.SetDestination(tauntVec);                   ///tauntVec�������� ���󰡶� - �������ݽ� ��ǥ�������� �̵�

        IEnumerator Think() 
        { 
            yield return new WaitForSeconds(0.1f);

            int ranAction = Random.Range(0, 5);
            switch (ranAction)
            {
                case 0:
                case 1:
                    StartCoroutine(MissileShot());              ///�̻��� �߻�����
                    break;
                case 2:
                case 3:
                    StartCoroutine(RockShot());                 ///�� �������� ����
                    break;
                case 4:
                    StartCoroutine(Taunt());                    ///���� ���� ����
                    break;
            }

        }


        IEnumerator MissileShot() ///�̻��ϼ�
        {
            ani.SetTrigger("tShot");                         ///Enemy���� ���
            yield return new WaitForSeconds(0.2f);
            GameObject instantMissileA = Instantiate(missile, missilePortA.position, missilePortA.rotation);
            BossMissile bossMissileA = instantMissileA.GetComponent<BossMissile>();
            bossMissileA.target = target;

            yield return new WaitForSeconds(0.3f);          ///0.5�ʿ��� a,b �ι� 
            GameObject instantMissileB = Instantiate(missile, missilePortB.position, missilePortB.rotation);
            BossMissile bossMissileB = instantMissileB.GetComponent<BossMissile>();
            bossMissileB.target = target;

            yield return new WaitForSeconds(2f);           ///�����ؼ� 2.5�� ���� ��������
            StartCoroutine(Think());
        }

        IEnumerator RockShot()  ///�������⼦
        {
            isLook = false;                                              ///�� �������� �ٶ󺸱� ����
            ani.SetTrigger("tRock");                                     ///Enemy���� ���
            Instantiate(bullet, transform.position, transform.rotation);    
            yield return new WaitForSeconds(3f);

            isLook = true;
            StartCoroutine(Think());
        }

        IEnumerator Taunt()     ///���� �� �������
        {
            tauntVec = target.position + lookVect;            ///���� ������ ��ġ

            isLook = false;                                   ///player�� �ٶ󺸸� �̻��ϴϱ� tauntVec�������θ� �ٶ󺸰�
            nav.isStopped = false;                            ///
            bCollider.enabled = false;                        ///player�� ���� �ʵ��� �浹 ��Ȱ��ȭ
            ani.SetTrigger("tTaunt");

            yield return new WaitForSeconds(1.5f);
            meleeArea.enabled = true;                        ///���ݹ��� Ȱ��ȭ

            yield return new WaitForSeconds(0.5f);
            meleeArea.enabled = false;                       ///���ݹ��� ��Ȱ��ȭ  

            yield return new WaitForSeconds(1f);
            isLook = true;                                   
            nav.isStopped = true;                            ///
            bCollider.enabled = true;                       
            StartCoroutine(Think());
        }





    }


}
