using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  ///NavMeshAgent


// c.tag  / c.gameObject.tag ����
// startCoroutine()���� yield return�� �ǹ�
// update() - nav.isStopped 
// Targeting() - rayHits.Length



/// TestEnemy(Cube obj) : 1. Rigidbody(Freeze Rotation:x,z), Box Collider, Enemy script ����
///                       2. Layer : 13:Enemy, 14:EnemyDead(Floor, Wall, EnemyDead �� ���� ����) �߰�


/// Enemy A (�Ϲ���)
/// 1. Rigidbody(FreezeRotation x,z Ȱ��ȭ), Box Collider(center(y:1.13),size(2.5,2.5,2.5)), Enemy Script �߰� �� �Ʒ� ����, Tag/Layer : Enemy �߰� �� Project Setting - Physics - LayerCollisionMask(EnemyBullet-Enemy ��Ȱ��ȭ) 
/// 2. Nav Mesh Agent(AngularSpeed(ȸ���ӵ�):360, Acceleration(���ӵ�):30) �߰� / Floor,Wall : Static ����(static�� bake����) / Window - AI - Navigation - Bake - Advanced:Bake  (NavMesh�� NavAgent�� ��θ� �׸��� ���� ����, NavMeshAgent�� navigation�� ����ϴ� AI)
/// 3. Mesh Obj - Animator(Enemy A) �߰�, �ִϸ��̼� Idle(��Ŭ��-SetAsLayerDefaultState), Walk, Attack, Die �߰� (����11�� 12�� ����), bWalk, bAttack, tDie
/// 4. �Ʒ��� Enemy Bullet �߰� �� Enemy A ���� �տ� ��ġ
/// EnemyA/B/C/D ��ġ �ʱ�ȭ �� prefab


/// Enemy B (������) : 1. Enemy A ���� �״�� ����
///                    2. Nav Mesh Agent (speed:20, AngularSpeed:360, Acceleration:50) 


/// Enemy C (���Ÿ�) : 1. Enemy A ���� �״�� ����
///                    2. NavMeshAgent (speed:5, AngularSpeed:480, Acceleration:60) 
///                    3. Enemy Script�� Melee Area�� �����, Animator�� �ִϸ��̼��� ��� ��ü 


/// EnemyBullet(�� obj) : �������ݹ���
///                       1. Box Collider(isTrigger, size:2,2,2, boxCollider ��Ȱ��ȭ) + Tag/Layer:EnemyBullet + Bullet Script �߰�


/// Missile (Transform:P/R(0,0,0))   (���� 12�� 34�� ����, z��(blue) ���� ����)
///                                  1. Missile - Mesh obj(Transform P(0,0,0), R(0,-90,0)) - Missile script �߰� 
///                                  2. Missile - Effect(��obj, �����κ���ġ, Transform.P(0,3,-1)) - Particle System (Renderer:Default-Line, Effect(startLifetime:0.6,startSpeed:15,startSize:0.7), Emission(RoT:30), Shape(Angle:13, Radius:0.5, Rotation(0,180,0)), ColorOverLifetime(alpha:100), sizeOverLifetime:������) �߰�
///                                  3. Missile - Rigidbody(useGravity ����),  Box Collider(�ǰݹ���, center(0,3,0), size(2,2,2), isTrigger, Bullet script(damage:15), Tag/Layer:EnemyBullet �� Prefab ���
///                                  4. Open prefab(Tranform(0,0,0), )







public class Enemy : MonoBehaviour
{

    public enum Type { A, B, C, D };   /// Ÿ�Գ�����
    public Type enemyType;             /// Ÿ�� ������ ���� ����
    public int maxHealth;              /// TestEnemy:200, EnemyA:50, EnemyB:80, EnemyC:200
    public int curHealth;              /// TestEnemy:200, EnemyA:50, EnemyB:80, EnemyC:200
    public int score;                  /// EnemyA:100, B:250, C:500, D:2000
    public Transform target;           /// Player �巡��
    public BoxCollider meleeArea;      /// ���ݹ��� : EnemyA�� EnemyBullet �巡��
    public GameObject bullet;          /// EnemyC�� Missile prefab �巡��
    public GameObject[] coins;         /// EnemyA/B/C/D -> coin prefab 3��
    public bool isChase;
    public bool isAttack;              
    public bool isDead;                /// �׾��� ���� �˱� ���� flag

    public Rigidbody r;
    public BoxCollider bCollider;
    public MeshRenderer[] meshs;
    public NavMeshAgent nav;
    public Animator ani;







    void Awake()
    {
        r = GetComponent<Rigidbody>();
        bCollider = GetComponent<BoxCollider>();
        ///m = GetComponentInChildren<MeshRenderer>().material;     /// InChildren : 16 EnemyA - Mesh Obj - Bone Body - Body�� Mesh Rendere�� ���� 
        meshs = GetComponentsInChildren<MeshRenderer>().material;   ///21���� : GetComponents
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();

        if(enemyType != Type.D)                         ///20����  
            Invoke("ChaseStart", 2);                    ///16-3
    }


    void Update() 
    {

        if (nav.enabled && enemyType != Type.D)      ///20���� &&���� ���� �߰�
        {
            nav.SetDestination(target.position);    ///16 player ����
            nav.isStopped = !isChase;               ///isStopped�� ���� �ƴ��� �����϶�?
        }



    }

    void FixedUpdate()  
    {
        Targeting();
        FreezeVelocity();
    }

    void Targeting()                        ///18 
    {
        if (!isDead && enemyType != Type.D)            ///  (���� �ʾ�����) && (�������� �ƴϸ�,20����)
        {
            float targetRadius = 0f;
            float targetRange = 0f;

            switch (enemyType)
            {
                case Type.A:
                    targetRadius = 1.5f;
                    targetRange = 3f;
                    break;
                case Type.B:
                    targetRadius = 1f;
                    targetRange = 12f;
                    break;
                case Type.C:
                    targetRadius = 0.5f;
                    targetRange = 25f;
                    break;
            }

            /// �迭 - SphereCastAll,       SphereCastAll(������, ��ü������, �������, ����/�Ÿ�, Layer) : ��ü ����� raycasting(��� obj)
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position,
                                                         targetRadius,
                                                         transform.forward,
                                                         targetRange,
                                                         LayerMask.GetMask("Player"));

            if (rayHits.Length > 0 && !isAttack)        /// !isAttack : ���Ӱ��� ����
            {
                StartCoroutine(Attack());
            }

        }
    }



    void ChaseStart()                               ///16-3
    {
        isChase = true;
        ani.SetBool("bWalk", true);

    }

    void FreezeVelocity()   ///16-2 Enemy�� NavAgent�̵��� ������(rigid)�� �������� �ʵ��� ���� �߰� 
    {
        if (isChase)                             ///16-3
        {
            r.velocity = Vector3.zero;           ///�����ӵ� 0
            r.angularVelocity = Vector3.zero;    ///����ȸ���ӵ� 0
        }
    }


    void OnTriggerEnter(Collider c)             ///13
    {
        if (c.tag == "Melee")
        {
            Weapon weapon = c.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            Vector3 reactVec = transform.position - c.transfrom.position;  ///13-2 �˹�? �� ��ġ - �ǰ���ġ

            startCoroutine(OnDamage(reactVec, false));                     ///13-2�˹�

            Debug.Log("Melee:" + curHealth);
        }
        else if (c.tag == "Bullet")
        {
            Bullet bullet = c.GetComponent<Bullet>();
            curHealth -= bullet.damage;
            Vector3 reactVec = transform.position - c.transfrom.position; ///13-2 �˹� 
            Destroy(c.gameObject);

            startCoroutine(OnDamage(reactVec, false));                    ///13-2�˹�

            Debug.Log("Range:" + curHealth);
        }
    }



    public void HitByGrenade(Vector3 explosionPos) ///15
    {
        curHealth -= 100;
        Vector3 reactVec = transform.position - explosionPos;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator Attack() ///18
    { 
        isChase = false;                 ///�Ѿƿ��� ��Ȱ��ȭ
        isAttack = true;                 ///���� Ȱ��ȭ
        ani.SetBool("bAttack", true);    ///���� �ִϸ��̼� Ȱ��ȭ

        switch (enemyType)
        {
            case Type.A: 
                yield return new WaitForSeconds(0.2f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
            case Type.B:
                yield return new WaitForSeconds(0.1f);
                r.AddForce(transform.forward * 20, ForceMode.Impulse); ///����
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f);
                r.velocity = Vector3.zero;                            ///�ӵ�����
                meleeArea.enabled = false;

                yield return new WaitForSeconds(2f);
                break;
            case Type.C:
                yield return new WaitForSeconds(0.5f);
                GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody rbIB = instantBullet.GetComponent<Rigidbody>();
                rbIB.velocity = transform.forward * 20;

                yield return new WaitForSeconds(2f);
                break;
        }

        isChase = true;                 ///�Ѿƿ��� Ȱ��ȭ
        isAttack = false;               ///���� ��Ȱ��ȭ
        ani.SetBool("bAttack", false);  ///���� �ִϸ��̼� ��Ȱ��ȭ
    }


    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)      ///13,  15 bool isGrenade
    {
        foreach (MeshRenderer mesh in meshs)                         ///21����
            mesh.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);                      

        if (curHealth > 0)
        {
            foreach (MeshRenderer mesh in meshs)                    ///21����
                mesh.material.color = Color.white;
        }
        else                             ///ü��<0
        {
            foreach (MeshRenderer mesh in meshs)                    ///21����
                mesh.material.color = Color.gray;


            gameObject.layer = 14;       ///14:EnemyDead �浹���� (edit-ProjectSetting-Physics-LayerCollisionMatrix ���� Enemy Dead�� ��ġ�� �κп��� Floor,Wall,Enemy Dead �� ���� �浹 ����)
            isDead = true;               ///
            isChase = false;             ///16-3 ���� ��Ȱ��ȭ
            nav.enabled = false;         ///16-3 nav ��Ȱ��ȭ
            ani.SetTrigger("tDie");      ///16-3 ��� �ִϸ��̼�

            Player player = target.GetComponent<Player>();                          /// 17��-1
            player.score += score;                                                  /// 
            int ranCoin = Random.Range(0, 3);                                       ///
            Instantiate(coins[ranCoin], transform.position, Quaternion.identity);   ///ȸ������?

            if (isGrenade)
            {
                reactVec = reactVec.normalized;                             
                reactVec += Vector3.up *3;                               ///15 enemy�� ����ź������׼�

                r.freezeRotation = false;                                ///FreezeRotation x,z�� ����
                r.AddForce(reactVec * 5, ForceMode.Impulse);
                r.AddTorque(reactVec * 10, ForceMode.Impulse);           ///ȸ��

            }
            else 
            {
                reactVec = reactVec.normalized;                          ///13-2 �˹�
                reactVec += Vector3.up;                                  ///13-2 �˹�

                r.AddForce(reactVec * 5, ForceMode.Impulse);
            }

            ///if(enemyType != Type.D)                                      ///17��-1 ������ ���ǿ� ���� ����
                Destroy(gameObject, 4);


        }


    }


}
