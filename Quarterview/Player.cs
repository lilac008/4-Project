using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  swap() - equipW 관련
//  Attack() 
//  ReloadOut()
//  Turn()


public class Player : MonoBehaviour
{

    /// Player : 1) x,z rotation 얼림
    ///          2) transform이동 : 물리 충돌 무시하는 경우, 추가로 Rigidbody에서 collision ditection - Continuous로 변경, Floor과 Wall은 모두 static으로 변경
    ///          3) Tag/Layer : Player 추가
    /// Player - Mesh Object / Bullet Pos / Jump Sound(빈obj, Audio Source(AudioClip-다운받은효과음, PlayOnAwake 비활성화) 추가)


    /// World space - Floor,Wall 
    /// 1) static 선언 
    /// 2) rigidbody : gravity 해제, isKinematic (script상으로만 구현하며 scene에서는 비활성) 설정
    /// 3) create - physics material (dynamic/static Friction 0, bounciness 0, friction combine - minimum) 추가 


    /// Throw Grenade
    /// 1) prefab에서 기존 grenade 추가 후 이름 변경
    /// 2) Throw Grenade - 미리 만들어진 Particle (0,0,0) 추가 및 비활성화
    /// 3) Throw Grenade - Rigidbody, Sphere Collider (radius 0.7) 추가
    /// 4) create - Physics Material (DynamicFriction:1 - Static Friction:1 - Bounciness:1), 끌어서 Sphere Collider - Material에 드래그
    /// 5) Grenade - Mesh Obj - Trail Renderer(Width:하향, Time:3, Color-alpha:100, Material:Default-Line) 추가
    /// 6) PlayerBullet tag 추가 (player와 부딛혀 밀리는 것 방지)
    /// 7) prefab에 저장 후 Transform.position(0,0,0)









    float hKey;
    float vKey;
    bool walkKey;                   /// Walk : left shift
    bool sKey;                      /// jump : space    /   Project Setting - Physics - Gravity에서 -9.81에서 -25로 수정
    bool eKey;                      /// Interaction : e
    bool fireKey;                   /// fire1 : mouse 왼쪽
    bool grenadeKey;                /// fire2 : mouse 오른쪽
    bool swap1;                     /// 무기교체 : 1,2,3키
    bool swap2;
    bool swap3;
    bool rKey;                      /// Reload : r


    public float speed;             /// speed : 15
    Vector3 mVec;                   /// 방향
    Vector3 dVec;                   /// 회피 중 방향전환 불가능하도록 설정한 변수

    Animator a;                     /// animator 따로 생성후 자식obj인 mesh obj에 넣는다.
    Rigidbody r;
    MeshRenderer[] meshs;           /// 모든 몸통 부위의 mesh를 가져오기 위해 배열로 가져옴

    bool isJump;                    /// 점프 활성화, 비활성화 : 무한점프 방지
    bool isDodge;                   /// 회피 활성화, 비활성화 : 회피중 방향이동 방지 
    bool isSwap;                    /// 무기교체 활성화, 비활성화 : 교체 시간차를 위해
    bool isReload;
    bool isFireReady = true;        /// 공격 준비
    bool isBorder;
    bool isDamage;
    bool isShop;                            ///쇼핑중 변수
    bool isDead;

    GameObject colliderObj;                         /// isTrigger로 접촉한 obj 인식

    public GameObject[] inactiveWeapons;    /// 손에 든 비활성 무기들 : 무기 3종 Prefab을 여기에 연결 후 비활성화 (준비:Player - righthand - Weapon Points(cylinder형 비활성obj, 4부10분참조) - 무기 3종 prefab 단 후 비활성화)
    public bool[] hasWeapon;                /// 가지고 있는, 소유한 무기들의 bool(활성, 비활성) 상태 여부 : 3 으로 설정 
    public Weapon equipWeapon;              /// 장착한 무기, equipW = weaponsInHand[wIndex].GetComponent<Weapon>(); 
    int equipWIndex = -1;                   /// 장착한 무기 index


    public GameObject[] inactiveGrenades;   /// 몸 주위에 공전하는 비활성 수류탄들 : (G Group(빈obj) - Front/Back/Right/Left(각각 빈obj)에 G prefab 추가 - 하위 mesh obj에 각각 Light, Particle( Emission:(RoT:0, RoD:10) )추가 및 mesh obj - Simulation Space - World   / Orbit script 추가 )
    public GameObject grenadeObj;           /// Throw Grenade prefab끌어서 드래그

    public int hasAmmo;                     ///각각 100, 5500, 100
    public int hasCoin;                     
    public int health;
    public int hasGrenades;
    public int maxAmmo;                     ///각각 999, 99999, 100, 4 
    public int maxCoin;
    public int maxHealth;
    public int maxGrenades;


    float fireDelay;                       /// 공격 딜레이

    public Camera camera;                     ///메인카메라 드래그

    public int score;                      ///16강-3,  50000

    public GameManager gameManager;

    public AudioSource jumpSound;          //             






    void Awake()
    {
        a = GetComponentInChildren<Animator>();              ///자식 obj의 component에서 가져옴(단일)
        r = GetComponent<Rigidbody>();                       ///5
        meshs = GetComponentsInChildren<MeshRenderer>();     ///모든 몸통 부위들(자식 obj)에서 가져옴(복수)

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

    void GetInput() ///키입력 
    {
        hKey = Input.GetAxisRaw("Horizontal")
        vKey = Input.GetAxisRaw("Vertical")
        walkKey = Input.GetButton("Walk");           /// GetButton : 누르고 있는 동안 걷기
        sKey = Input.GetButtonDown("Jump");
        fireKey = Input.GetButton("fire1");          /// GetButton : 누르고 있는 동안 계속 발사, GetButtonDown : 눌렀다 떼야 발사 가능
        grenadeKey = Input.GetButton("fire2");        
        rKey = Input.GetButtonDown("Reload");
        eKey = Input.GetButtonDown("Interation");
        swap1 = Input.GetButtonDown("Swap1");
        swap2 = Input.GetButtonDown("Swap2");
        swap3 = Input.GetButtonDown("Swap3");
    }






    void Move() ///1 이동
    {

        /// 기본속도  
        /// v = new Vector3(hKey, 0, vKey).normalized;
        /// transform.position += v * speed * Time.deltaTime;    // transform 위치 += 방향변수v * 속도 * Time.deltaTime    /    transform : 1) Time.deltaTime 필수   2) 물리 충돌 무시하는 case가 있으므로 추가로 Rigidbody - collision detection을 continuous로 변경.

        /// 걷는 속도 추가
        /// v = new Vector3(hKey, 0, vKey).normalized;
        /// if(lsKey)
        ///     transform.position += v * speed * 0.3f * Time.deltaTime;
        /// else
        ///     transform.position += v * speed * Time.deltaTime;

        /// v = new Vector3(hKey, 0, vKey).normalized;
        /// transform.position += v * speed * (walkKey ? 0.3f : 1f) * Time.deltaTime;

        ///회피 중 방향전환 불가 추가, 4-2
        mVec = new Vector3(hKey, 0, vKey).normalized;
        if (isDodge)
            mVec = dVec;

        /// 무기교체 시 이속0,   /6, 8 10
        if (isSwap || !isReload || !isFireReady || isDead)     /// 무기교체o  장전,발사준비시 x  
            mVec = Vector3.zero;                   /// 방향이동 0
        transform.position += mVec * speed * (walkKey ? 0.3f : 1f) * Time.deltaTime;

        ///  11-2 
        if(!isBorder)
            transform.position += mVec * speed * ()

        ///애니 메이션 추가
        a.SetBool("bRun", mVec != Vector3.zero);   ///(Parameter 1부 24분 참조)
        a.SetBool("bWalk", walkKey);

    }


    void Turn() ///2,11 화면 회전
    {
        transform.LookAt(transform.position + mVec); ///LookAt() : 지정된 방향을 향해 회전시킴

        /// 11 공격시에만 마우스에 의한 화면 회전 (7부 40분)
        if (fireKey && !isDead)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition)     ///ScreenPointToRay : 스크린에서 (마우스 위치)로 빛을 쏘는 함수
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 100))                 ///
            {
                Vector3 rayVec = rayHit.point - transform.position;    ///rayHit이 닿았던 지점 - 이 script 위치(Player)
                rayVec.y = 0;                                          ///
                transform.LookAt(transform.position + rayVec);
            }
        }

    }


    void Jump() ///3 점프 (project Setting - physics - Gravity 필요한만큼 적용)
    {
        if (sKey && mVec == Vector3.zero && !isJump && !isDodge && !isSwap && !isDead) /// spaceKey && 이동방향 0 && !점프중 && !회피중 && !무기교체중 
        {
            r.AddForce(Vector3.up * 15, ForceMode.Impurse)

            ///애니메이션 추가
            a.SetBool("bJump", true); ///3-2 (영상 2부 11분 참조)
            a.SetTrigger("tJump");

            isJump = true;              ///활성화, 비활성화시 바닥에 닿을-물리충돌(OnCollisionEnter())-경우 false로


            jumpSound.Play();
        }
    }

    void Grenade() ///14 
    {
        if (hasGrenades == 0)
            return;

        if (grenadeKey && !isReload && !isSwap && !isDead) 
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition) ///ScreenPointToRay : 스크린에서 (마우스 위치)로 빛을 쏘는 함수
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 100))                 ///
            {
                Vector3 rayVec = rayHit.point - transform.position;    ///rayHit이 닿았던 지점 - 이 script 위치(Player)
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


    void Attack() ///8 공격
    {
        if (equipWeapon == null)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.attackSpeed < fireDelay;    /// true = 무기공속 < fireDelay;  공속 시간동안 연타 금지

        if (fireKey && isFireReady && !isDodge && !isSwap && !isShop && !isDead)
        {
            equipWeapon.Use();
            a.SetTrigger(equipWeapon.type == Weapon.Type.Melee ? "tSwing" : "tShot");  ///9 Weapon script
            fireDelay = 0;                                      ///딜레이를 0으로 돌려서 다음 공격까지 기다림
        }
    }

    void Reload() ///10 재장전
    {
        if (equipWeapon == null)                    ///무기 미장착시 탈출
            return;

        if (equipWeapon.type == Wepon.Type.Melee)   ///근접 무기시 탈출
            return;

        if (hasAmmo == 0)                              ///소유 탄약 0일시 탈출
            return;

        if (rKey && !isJump && !isDodge && !isSwap && isFireReady && !isShop && !isDead)   ///r키,공격준비시간 o 점프,회피,무기교체시 x
        {
            a.SetTrigger("tReload");                            ///애니메이터 호출
            isReload = true;                                      ///장전 활성화
            Invoke("ReloadOut", 3f);                            ///3초 뒤 호출
        }
    }

    void ReloadOut()///10
    {
        int reAmmo = hasAmmo < equipWeapon.maxAmmoInGun ? hasAmmo : equipWeapon.maxAmmoInGun;
        equipWeapon.curAmmoInGun = reAmmo;
        hasAmmo -= reAmmo;
        isReload = false;         ///장전 비활성화

    }



    void Dodge() ///4 회피
    {
        if (sKey && v != Vector3.zero && !isJump && !isDodge && !isSwap && !isDead) /// spaceKey && 이동방향 0 && !점프중 && !회피중 && !무기교체중 
        {
            dVec = mVec;
            speed *= 2;                      /// 회피 중 속도 2배 

            ///애니메이션 추가, Dodge Motion 속도:3
            a.SetTrigger("tDodge");

            isDodge = true;                    ///활성화
            Invoke("DodgeOut", 0.5f);        ///비활성화 - 물리 충돌이 아니므로 시간차로 취소시킴

        }
    }
    void DodgeOut() ///4 회피 끝
    {
        speed *= 0.5f; ///회피 끝날시 속도 원상태로
        isDodge = false;
    }


    void Swap() ///6 무기교체
    {
        if (swap1 && (!hasWeapon[0] || equipWIndex == 0))     /// (  소유한 무기[]가 없거나 || 장착한 무기[]가 이미 있을 경우 ) 
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
            /// [ Weapon equipW; 으로 선언했을 경우 ]      (6부 18분)
            if (equipWeapon != null)
                equipWeapon.gameObject.SetActive(false);

            equipWIndex = wIndex;
            equipWeapon = inactiveWeapons[wIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);

            /// [ GameObject equipW; 으로 선언했을 경우 ]    
            ///
            /// if (equipW != null)                             ///equipW이 null이 아닐경우 - equipW 초기값이 정해지지 않은 상태
            ///     equipW.SetActive(false);                    ///equipW 비활성화
            /// 
            /// equipW = weaponsInHand[wIndex];                 ///equipW에 weaponsInHand[wIndex] 저장
            /// equipW.SetActive(true);                         ///equipW 활성화

            ///Animator 추가 (4부20분참조)
            a.SetTrigger("tSwap");

            isSwap = true;
            invoke("SwapOut", 0.4f);

        }
    }
    void SwapOut() ///6 무기교체 끝
    {
        isSwap = false;
    }



    void Interaction() ///5-2 템 줍기
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
            else if (colliderObj.tag == "Shop")                         ///15강-2) Shop script
            {
                Shop shop = colliderObj.GetComponent<Shop>();           
                shop.Enter(this);                                       /// this = this script = Player script
                isShop = true;                                          ///15강-
            }
        }
    }

    void FreezeRotation()   ///11-2 rigid(물리력)에 의한 자동 회전 막기
    {
        r.angularVelocity = Vector3.zero;   ///angularVelocity(물리회전속도) 0

        ///11-3 탄피, 플레이어 물리 충돌 없애기
        ///1) Layer : 8:Floor, 9:Wall, 10:Player, 11:Player Bullet(2개), 12:BulletCase 설정
        ///2) edit - project setting - Physics - Layer Collision Matrix(layer간 충돌 설정): Bulletcase - Floor, BulletCase 외 전부 해제, PlayerBullet - Player 해제 
        ///
    }
    void StopToWall()   ///11-2
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);                         /// DrawRay(시작위치,쏘는방향,색상),          DrawRay():scene에서 ray를 보여줌
        isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall")); /// border = Raycast(시작위치,쏘는방향,길이,충돌대상)이면 true, Raycast():ray를 쏘아 닿는 obj감지    
    }
    void FixedUpdate()  ///11-2
    {
        FreezeRotation();
        StopToWall();

    }

    void OnCollisionEnter(Collision c)   ///3
    {
        if (c.gameObject.tag == "Floor") ///Floor tag 추가
        {
            a.SetBool("bJump", false);   ///3-2

            isJump = false;               ///3 

        }
        
    }



    void onTriggerEnter(Collider colider)     ///7 접촉 진입
    {
        if (colider.tag == "Item")                        ///7 플레이어가 아이템에 접촉할 경우
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
                    inactiveGrenades[hasGrenade].SetActive(true);               ///수류탄 개수대로 공전체가 활성화
                    hasGrenade += cItem.value;
                    if (hasGrenade > maxGrenades)
                        hasGrenade = maxGrenades;
                    break;
            }
            Destroy(colider.gameObject);
        }
        else if (colider.tag == "EnemyBullet")     ///17   Player가 EnemyBullet tag에 접촉할 경우
        {
            if (!isDamage) 
            {
                Bullet enemyBullet = colider.GetComponent<Bullet>();
                health -= enemyBullet.damage;

                bool isBossAttack = colider.name == "Boss Melee Area";    ///t.name == "Boss Melee Area이면 true

                StartCoroutine(OnDamage(isBossAttack));
            }

            ///플레이어 무적타임과 관계없이 투사체미사일이 파괴되도록 if문 밖으로 빼기
            if (colider.GetComponent<Rigidbody>() != null)    ///19  Missile이 가지고 있는 rigidbody 유무를 조건
            {
                Destroy(colider.gameObject);
            }
        }

    }
    void OnTriggerStay(Collider _colider)      ///5-1 접촉 중
    {
        if(_colider.tag == "Weapon" || _colider.tag == "Shop")    ///15강-2) Shop script            
            colliderObj = _colider.gameObject;   

        Debug.Log(colliderObj.name);            ///출력 확인
    }
    void OnTriggerExit(Collider _collider)      ///5-1 접촉 끝
    {
        if (_collider.tag == "Weapon")
            colliderObj = null;                 ///비우기
        else if (_collider.tag == "Shop")                        ///15강-3) 퇴장함수 + Shop script 
        {
            Shop shop = colliderObj.GetComponent<Shop>();
            shop.Exit();
            colliderObj = null;
            isShop = false;                                  ///15강-
        }
    }


    IEnumerator OnDamage(bool isBossAttack)                  ///17 플레이어 피격  (쿼터뷰 12부 )
    {
        isDamage = true;

        foreach (MeshRenderer mesh in meshs)    ///Player의 Mesh Renderer의 material의 색이 yellow로 변함
        {
            mesh.material.color = Color.yellow;
        }

        if (isBossAttack)                                               ///
            r.AddForce(transform.forward * -25, ForceMode.Impulse);     ///

        if (health <= 0 && !isDead)             ///계속 죽음 방지 : !isDead일 경우에만 onDie() 호출 
            OnDie();

        yield return new WaitForSeconds(1f);    ///1초 무적 - 1초 지나고
        isDamage = false;                       ///1초 무적 - 비활성화

        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }

        if (isBossAttack)                                               ///
            r.velocity = Vector3.zero;                                  ///


    }

    void OnDie() 
    {
        anim.SetTrigger("tDie");    ///Player Animator에 Die(animation) 추가
        isDead = true;
        gameManager.GameOver();
    }







}
