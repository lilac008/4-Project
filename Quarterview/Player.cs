using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  swap() - equipW ����
//  Attack() 
//  ReloadOut()
//  Turn()


public class Player : MonoBehaviour
{

    /// Player : 1) x,z rotation ��
    ///          2) transform�̵� : ���� �浹 �����ϴ� ���, �߰��� Rigidbody���� collision ditection - Continuous�� ����, Floor�� Wall�� ��� static���� ����
    ///          3) Tag/Layer : Player �߰�
    /// Player - Mesh Object / Bullet Pos / Jump Sound(��obj, Audio Source(AudioClip-�ٿ����ȿ����, PlayOnAwake ��Ȱ��ȭ) �߰�)


    /// World space - Floor,Wall 
    /// 1) static ���� 
    /// 2) rigidbody : gravity ����, isKinematic (script�����θ� �����ϸ� scene������ ��Ȱ��) ����
    /// 3) create - physics material (dynamic/static Friction 0, bounciness 0, friction combine - minimum) �߰� 


    /// Throw Grenade
    /// 1) prefab���� ���� grenade �߰� �� �̸� ����
    /// 2) Throw Grenade - �̸� ������� Particle (0,0,0) �߰� �� ��Ȱ��ȭ
    /// 3) Throw Grenade - Rigidbody, Sphere Collider (radius 0.7) �߰�
    /// 4) create - Physics Material (DynamicFriction:1 - Static Friction:1 - Bounciness:1), ��� Sphere Collider - Material�� �巡��
    /// 5) Grenade - Mesh Obj - Trail Renderer(Width:����, Time:3, Color-alpha:100, Material:Default-Line) �߰�
    /// 6) PlayerBullet tag �߰� (player�� �ε��� �и��� �� ����)
    /// 7) prefab�� ���� �� Transform.position(0,0,0)









    float hKey;
    float vKey;
    bool walkKey;                   /// Walk : left shift
    bool sKey;                      /// jump : space    /   Project Setting - Physics - Gravity���� -9.81���� -25�� ����
    bool eKey;                      /// Interaction : e
    bool fireKey;                   /// fire1 : mouse ����
    bool grenadeKey;                /// fire2 : mouse ������
    bool swap1;                     /// ���ⱳü : 1,2,3Ű
    bool swap2;
    bool swap3;
    bool rKey;                      /// Reload : r


    public float speed;             /// speed : 15
    Vector3 mVec;                   /// ����
    Vector3 dVec;                   /// ȸ�� �� ������ȯ �Ұ����ϵ��� ������ ����

    Animator a;                     /// animator ���� ������ �ڽ�obj�� mesh obj�� �ִ´�.
    Rigidbody r;
    MeshRenderer[] meshs;           /// ��� ���� ������ mesh�� �������� ���� �迭�� ������

    bool isJump;                    /// ���� Ȱ��ȭ, ��Ȱ��ȭ : �������� ����
    bool isDodge;                   /// ȸ�� Ȱ��ȭ, ��Ȱ��ȭ : ȸ���� �����̵� ���� 
    bool isSwap;                    /// ���ⱳü Ȱ��ȭ, ��Ȱ��ȭ : ��ü �ð����� ����
    bool isReload;
    bool isFireReady = true;        /// ���� �غ�
    bool isBorder;
    bool isDamage;
    bool isShop;                            ///������ ����
    bool isDead;

    GameObject colliderObj;                         /// isTrigger�� ������ obj �ν�

    public GameObject[] inactiveWeapons;    /// �տ� �� ��Ȱ�� ����� : ���� 3�� Prefab�� ���⿡ ���� �� ��Ȱ��ȭ (�غ�:Player - righthand - Weapon Points(cylinder�� ��Ȱ��obj, 4��10������) - ���� 3�� prefab �� �� ��Ȱ��ȭ)
    public bool[] hasWeapon;                /// ������ �ִ�, ������ ������� bool(Ȱ��, ��Ȱ��) ���� ���� : 3 ���� ���� 
    public Weapon equipWeapon;              /// ������ ����, equipW = weaponsInHand[wIndex].GetComponent<Weapon>(); 
    int equipWIndex = -1;                   /// ������ ���� index


    public GameObject[] inactiveGrenades;   /// �� ������ �����ϴ� ��Ȱ�� ����ź�� : (G Group(��obj) - Front/Back/Right/Left(���� ��obj)�� G prefab �߰� - ���� mesh obj�� ���� Light, Particle( Emission:(RoT:0, RoD:10) )�߰� �� mesh obj - Simulation Space - World   / Orbit script �߰� )
    public GameObject grenadeObj;           /// Throw Grenade prefab��� �巡��

    public int hasAmmo;                     ///���� 100, 5500, 100
    public int hasCoin;                     
    public int health;
    public int hasGrenades;
    public int maxAmmo;                     ///���� 999, 99999, 100, 4 
    public int maxCoin;
    public int maxHealth;
    public int maxGrenades;


    float fireDelay;                       /// ���� ������

    public Camera camera;                     ///����ī�޶� �巡��

    public int score;                      ///16��-3,  50000

    public GameManager gameManager;

    public AudioSource jumpSound;          //             






    void Awake()
    {
        a = GetComponentInChildren<Animator>();              ///�ڽ� obj�� component���� ������(����)
        r = GetComponent<Rigidbody>();                       ///5
        meshs = GetComponentsInChildren<MeshRenderer>();     ///��� ���� ������(�ڽ� obj)���� ������(����)

        //Player.Prefs.SetInt("MaxScore", 112500);

        debug.Log(PlayerPrefs.GetInt("MaxScore"));

    }   

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Attack();
        Reload();
        Dodge();
        Swap();
        Interaction();

    }

    void GetInput() ///Ű�Է� 
    {
        hKey = Input.GetAxisRaw("Horizontal")
        vKey = Input.GetAxisRaw("Vertical")
        walkKey = Input.GetButton("Walk");           /// GetButton : ������ �ִ� ���� �ȱ�
        sKey = Input.GetButtonDown("Jump");
        fireKey = Input.GetButton("fire1");          /// GetButton : ������ �ִ� ���� ��� �߻�, GetButtonDown : ������ ���� �߻� ����
        grenadeKey = Input.GetButton("fire2");        
        rKey = Input.GetButtonDown("Reload");
        eKey = Input.GetButtonDown("Interation");
        swap1 = Input.GetButtonDown("Swap1");
        swap2 = Input.GetButtonDown("Swap2");
        swap3 = Input.GetButtonDown("Swap3");
    }






    void Move() ///1 �̵�
    {

        /// �⺻�ӵ�  
        /// v = new Vector3(hKey, 0, vKey).normalized;
        /// transform.position += v * speed * Time.deltaTime;    // transform ��ġ += ���⺯��v * �ӵ� * Time.deltaTime    /    transform : 1) Time.deltaTime �ʼ�   2) ���� �浹 �����ϴ� case�� �����Ƿ� �߰��� Rigidbody - collision detection�� continuous�� ����.

        /// �ȴ� �ӵ� �߰�
        /// v = new Vector3(hKey, 0, vKey).normalized;
        /// if(lsKey)
        ///     transform.position += v * speed * 0.3f * Time.deltaTime;
        /// else
        ///     transform.position += v * speed * Time.deltaTime;

        /// v = new Vector3(hKey, 0, vKey).normalized;
        /// transform.position += v * speed * (walkKey ? 0.3f : 1f) * Time.deltaTime;

        ///ȸ�� �� ������ȯ �Ұ� �߰�, 4-2
        mVec = new Vector3(hKey, 0, vKey).normalized;
        if (isDodge)
            mVec = dVec;

        /// ���ⱳü �� �̼�0,   /6, 8 10
        if (isSwap || !isReload || !isFireReady || isDead)     /// ���ⱳüo  ����,�߻��غ�� x  
            mVec = Vector3.zero;                   /// �����̵� 0
        transform.position += mVec * speed * (walkKey ? 0.3f : 1f) * Time.deltaTime;

        ///  11-2 
        if(!isBorder)
            transform.position += mVec * speed * ()

        ///�ִ� ���̼� �߰�
        a.SetBool("bRun", mVec != Vector3.zero);   ///(Parameter 1�� 24�� ����)
        a.SetBool("bWalk", walkKey);

    }


    void Turn() ///2,11 ȭ�� ȸ��
    {
        transform.LookAt(transform.position + mVec); ///LookAt() : ������ ������ ���� ȸ����Ŵ

        /// 11 ���ݽÿ��� ���콺�� ���� ȭ�� ȸ�� (7�� 40��)
        if (fireKey && !isDead)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition)     ///ScreenPointToRay : ��ũ������ (���콺 ��ġ)�� ���� ��� �Լ�
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 100))                 ///
            {
                Vector3 rayVec = rayHit.point - transform.position;    ///rayHit�� ��Ҵ� ���� - �� script ��ġ(Player)
                rayVec.y = 0;                                          ///
                transform.LookAt(transform.position + rayVec);
            }
        }

    }


    void Jump() ///3 ���� (project Setting - physics - Gravity �ʿ��Ѹ�ŭ ����)
    {
        if (sKey && mVec == Vector3.zero && !isJump && !isDodge && !isSwap && !isDead) /// spaceKey && �̵����� 0 && !������ && !ȸ���� && !���ⱳü�� 
        {
            r.AddForce(Vector3.up * 15, ForceMode.Impurse)

            ///�ִϸ��̼� �߰�
            a.SetBool("bJump", true); ///3-2 (���� 2�� 11�� ����)
            a.SetTrigger("tJump");

            isJump = true;              ///Ȱ��ȭ, ��Ȱ��ȭ�� �ٴڿ� ����-�����浹(OnCollisionEnter())-��� false��


            jumpSound.Play();
        }
    }

    void Grenade() ///14 
    {
        if (hasGrenades == 0)
            return;

        if (grenadeKey && !isReload && !isSwap && !isDead) 
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition) ///ScreenPointToRay : ��ũ������ (���콺 ��ġ)�� ���� ��� �Լ�
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 100))                 ///
            {
                Vector3 rayVec = rayHit.point - transform.position;    ///rayHit�� ��Ҵ� ���� - �� script ��ġ(Player)
                rayVec.y = 10;                                          ///

                GameObject instantGrenade = Instantiate(grenadeObj, transform.position, transform.rotation);
                Rigidbody rigidGrenade = instantGrenade.GetComponent<Rigidbody>();
                rigidGrenade.AddForce(rayVec, ForceMode.Impulse);
                rigidGrenade.AddTorque(rayVec, Vector3.back*10, ForceMode.Impulse);

                hasGrenades--;
                grenades[hasGrenades].SetActive(false);
            }


        }
    }


    void Attack() ///8 ����
    {
        if (equipWeapon == null)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.attackSpeed < fireDelay;    /// true = ������� < fireDelay;  ���� �ð����� ��Ÿ ����

        if (fireKey && isFireReady && !isDodge && !isSwap && !isShop && !isDead)
        {
            equipWeapon.Use();
            a.SetTrigger(equipWeapon.type == Weapon.Type.Melee ? "tSwing" : "tShot");  ///9 Weapon script
            fireDelay = 0;                                      ///�����̸� 0���� ������ ���� ���ݱ��� ��ٸ�
        }
    }

    void Reload() ///10 ������
    {
        if (equipWeapon == null)                    ///���� �������� Ż��
            return;

        if (equipWeapon.type == Wepon.Type.Melee)   ///���� ����� Ż��
            return;

        if (hasAmmo == 0)                              ///���� ź�� 0�Ͻ� Ż��
            return;

        if (rKey && !isJump && !isDodge && !isSwap && isFireReady && !isShop && !isDead)   ///rŰ,�����غ�ð� o ����,ȸ��,���ⱳü�� x
        {
            a.SetTrigger("tReload");                            ///�ִϸ����� ȣ��
            isReload = true;                                      ///���� Ȱ��ȭ
            Invoke("ReloadOut", 3f);                            ///3�� �� ȣ��
        }
    }

    void ReloadOut()///10
    {
        int reAmmo = hasAmmo < equipWeapon.maxAmmoInGun ? hasAmmo : equipWeapon.maxAmmoInGun;
        equipWeapon.curAmmoInGun = reAmmo;
        hasAmmo -= reAmmo;
        isReload = false;         ///���� ��Ȱ��ȭ

    }



    void Dodge() ///4 ȸ��
    {
        if (sKey && v != Vector3.zero && !isJump && !isDodge && !isSwap && !isDead) /// spaceKey && �̵����� 0 && !������ && !ȸ���� && !���ⱳü�� 
        {
            dVec = mVec;
            speed *= 2;                      /// ȸ�� �� �ӵ� 2�� 

            ///�ִϸ��̼� �߰�, Dodge Motion �ӵ�:3
            a.SetTrigger("tDodge");

            isDodge = true;                    ///Ȱ��ȭ
            Invoke("DodgeOut", 0.5f);        ///��Ȱ��ȭ - ���� �浹�� �ƴϹǷ� �ð����� ��ҽ�Ŵ

        }
    }
    void DodgeOut() ///4 ȸ�� ��
    {
        speed *= 0.5f; ///ȸ�� ������ �ӵ� �����·�
        isDodge = false;
    }


    void Swap() ///6 ���ⱳü
    {
        if (swap1 && (!hasWeapon[0] || equipWIndex == 0))     /// (  ������ ����[]�� ���ų� || ������ ����[]�� �̹� ���� ��� ) 
            return;
        if (swap2 && (!hasWeapon[1] || equipWIndex == 1))
            return;
        if (swap3 && (!hasWeapon[2] || equipWIndex == 2))
            return;

        int wIndex = -1;
        if (swap1) wIndex = 0;
        if (swap2) wIndex = 1;
        if (swap3) wIndex = 2;


        if ((swap1 || swap2 || swap3) && !isJump && !isDodge && !isDead)
        {
            /// [ Weapon equipW; ���� �������� ��� ]      (6�� 18��)
            if (equipWeapon != null)
                equipWeapon.gameObject.SetActive(false);

            equipWIndex = wIndex;
            equipWeapon = inactiveWeapons[wIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);

            /// [ GameObject equipW; ���� �������� ��� ]    
            ///
            /// if (equipW != null)                             ///equipW�� null�� �ƴҰ�� - equipW �ʱⰪ�� �������� ���� ����
            ///     equipW.SetActive(false);                    ///equipW ��Ȱ��ȭ
            /// 
            /// equipW = weaponsInHand[wIndex];                 ///equipW�� weaponsInHand[wIndex] ����
            /// equipW.SetActive(true);                         ///equipW Ȱ��ȭ

            ///Animator �߰� (4��20������)
            a.SetTrigger("tSwap");

            isSwap = true;
            invoke("SwapOut", 0.4f);

        }
    }
    void SwapOut() ///6 ���ⱳü ��
    {
        isSwap = false;
    }



    void Interaction() ///5-2 �� �ݱ�
    {
        if (eKey && colliderObj != null && !isJump && !isDodge && !isDead)
        {
            if (colliderObj.tag == "Weapon")
            {
                Item item = colliderObj.GetComponent<Item>();
                int wIndex = item.value;
                hasWeapon[wIndex] = true;

                Destroy(colliderObj);
            }
            else if (colliderObj.tag == "Shop")                         ///15��-2) Shop script
            {
                Shop shop = colliderObj.GetComponent<Shop>();           
                shop.Enter(this);                                       /// this = this script = Player script
                isShop = true;                                          ///15��-
            }
        }
    }

    void FreezeRotation()   ///11-2 rigid(������)�� ���� �ڵ� ȸ�� ����
    {
        r.angularVelocity = Vector3.zero;   ///angularVelocity(����ȸ���ӵ�) 0

        ///11-3 ź��, �÷��̾� ���� �浹 ���ֱ�
        ///1) Layer : 8:Floor, 9:Wall, 10:Player, 11:Player Bullet(2��), 12:BulletCase ����
        ///2) edit - project setting - Physics - Layer Collision Matrix(layer�� �浹 ����): Bulletcase - Floor, BulletCase �� ���� ����, PlayerBullet - Player ���� 
        ///
    }
    void StopToWall()   ///11-2
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);                         /// DrawRay(������ġ,��¹���,����),          DrawRay():scene���� ray�� ������
        isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall")); /// border = Raycast(������ġ,��¹���,����,�浹���)�̸� true, Raycast():ray�� ��� ��� obj����    
    }
    void FixedUpdate()  ///11-2
    {
        FreezeRotation();
        StopToWall();

    }

    void OnCollisionEnter(Collision c)   ///3
    {
        if (c.gameObject.tag == "Floor") ///Floor tag �߰�
        {
            a.SetBool("bJump", false);   ///3-2

            isJump = false;               ///3 

        }
        
    }



    void onTriggerEnter(Collider colider)     ///7 ���� ����
    {
        if (colider.tag == "Item")                        ///7 �÷��̾ �����ۿ� ������ ���
        {
            Item cItem = colider.GetComponent<Item>();
            switch (item.type)
            {
                case Item.Type.Ammo;
                    hasAmmo += cItem.value;
                    if (hasAmmo > maxAmmo)
                        hasAmmo = maxAmmo;
                    break;
                case Item.Type.Coin;
                    hasCoin += cItem.value;
                    if (hasCoin > maxCoin)
                        hasCoin = maxCoin;
                    break;
                case Item.Type.Heart;
                    health += cItem.value;
                    if (health > maxHealth)
                        health = maxHealth;
                    break;
                case Item.Type.Grenade;
                    inactiveGrenades[hasGrenade].SetActive(true);               ///����ź ������� ����ü�� Ȱ��ȭ
                    hasGrenade += cItem.value;
                    if (hasGrenade > maxGrenades)
                        hasGrenade = maxGrenades;
                    break;
            }
            Destroy(colider.gameObject);
        }
        else if (colider.tag == "EnemyBullet")     ///17   Player�� EnemyBullet tag�� ������ ���
        {
            if (!isDamage) 
            {
                Bullet enemyBullet = colider.GetComponent<Bullet>();
                health -= enemyBullet.damage;

                bool isBossAttack = colider.name == "Boss Melee Area";    ///t.name == "Boss Melee Area�̸� true

                StartCoroutine(OnDamage(isBossAttack));
            }

            ///�÷��̾� ����Ÿ�Ӱ� ������� ����ü�̻����� �ı��ǵ��� if�� ������ ����
            if (colider.GetComponent<Rigidbody>() != null)    ///19  Missile�� ������ �ִ� rigidbody ������ ����
            {
                Destroy(colider.gameObject);
            }
        }

    }
    void OnTriggerStay(Collider _colider)      ///5-1 ���� ��
    {
        if(_colider.tag == "Weapon" || _colider.tag == "Shop")    ///15��-2) Shop script            
            colliderObj = _colider.gameObject;   

        Debug.Log(colliderObj.name);            ///��� Ȯ��
    }
    void OnTriggerExit(Collider _collider)      ///5-1 ���� ��
    {
        if (_collider.tag == "Weapon")
            colliderObj = null;                 ///����
        else if (_collider.tag == "Shop")                        ///15��-3) �����Լ� + Shop script 
        {
            Shop shop = colliderObj.GetComponent<Shop>();
            shop.Exit();
            colliderObj = null;
            isShop = false;                                  ///15��-
        }
    }


    IEnumerator OnDamage(bool isBossAttack)                  ///17 �÷��̾� �ǰ�  (���ͺ� 12�� )
    {
        isDamage = true;

        foreach (MeshRenderer mesh in meshs)    ///Player�� Mesh Renderer�� material�� ���� yellow�� ����
        {
            mesh.material.color = Color.yellow;
        }

        if (isBossAttack)                                               ///
            r.AddForce(transform.forward * -25, ForceMode.Impulse);     ///

        if (health <= 0 && !isDead)             ///��� ���� ���� : !isDead�� ��쿡�� onDie() ȣ�� 
            OnDie();

        yield return new WaitForSeconds(1f);    ///1�� ���� - 1�� ������
        isDamage = false;                       ///1�� ���� - ��Ȱ��ȭ

        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }

        if (isBossAttack)                                               ///
            r.velocity = Vector3.zero;                                  ///


    }

    void OnDie() 
    {
        anim.SetTrigger("tDie");    ///Player Animator�� Die(animation) �߰�
        isDead = true;
        gameManager.GameOver();
    }







}
