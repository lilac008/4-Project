using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               ///유니티엔진의 UI를 가져옴, public Text talkText; 선언에 사용

/// 쿼터뷰14강

/// [UI]
/// 1. UI (UserInterface 유저상호작용)
/// 2. EventSystem : UI에서 키 입력을 결정해주는 component

/// [Canvas] : 화면상 좌표계, 2D로 바꿔서 작업, Game뷰의 해상도(main camera 크기)와 동일한 크기 -> 16:9로 설정
/// - Rect Transform(화면상 좌표계) : Anchor Presets (shift:UI기준점, Alt:UI위치)
/// - Canvas - Pixel Perfect 활성화(도트 이미지)
/// - Canvas Scaler - UI Scale Mode - Scale with screen size : 어느 해상도에서도 크기가 동일하게 출력이 되도록 
///                                 - Reference Resolution : 해상도, X:1920, Y:1080으로 설정

/// [MenuPanel] : Canvas - UI - Panel 
/// - Image component : UI에서 이미지를 그려주는 component -> 어두운 색상으로 변경
/// 
/// - Title Image (UI-Image) - Source Image : Title Sprite drag
///                          - Set Native Size 설정
/// - Max score Image (UI-Image) - Source Image : Icon Score Mini drag
///                              - Rect Transform : X : -170, Y : -150
/// - Max score Text(UI-Text) - Text component - Text : 999999, Font:쿠키런볼드체, Font Size:130, Alignment:중앙정렬, color:white, Horizontal/Vertical Overflow : Overflow
///                                            - React Transform(W:0, H:0, overflow설정시 영역 부족해도 괜찮음) - Scale(0.5,0.5,0.5 -> 희미한 글씨 압축) 
/// - Start Button(UI-Button) : React Transform : Y : -350, W:400, H:150
///                             Image component - Source Image : PanelA drag 
///                                             - Image Type : Simple, SetNativeSize 설정후 Image Type : Sliced로 변경
///                           - Text(UI-Text) - Rect Transform : scale(0.5,0.5,0.5 -> 희미한 글씨 압축) 
///                                           - Text : Game Start입력, Font:쿠키런볼드체, Font Size:110, H/V Overflow:Overflow         

/// [Game Panel] : Canvas - UI - Panel
/// - Color : A:0 -> 투명화
/// - Score Group (빈obj, Rect Transform(X:20,Y:-20, W:0,H:0, AnchorPreset:alt+shift+좌측상단) - Score Image(UI-Image) : Rect Transform(Anchor Presets:alt+shift+좌측상단 -> 파란색화살표 앵커시 좌표계는 여백으로 설정됨) / Source Image : Icon Score Mini drag
///                                                                                            - Score Text (UI-Text)  : Rect Transform(Anchor Presets:alt+shift+좌측상단 -> 파란색화살표 앵커시 좌표계는 여백으로 설정됨 / W:0,H:0, scale(0.5,0.5,0.5)) / Text:999999, Font:쿠키런볼드체, Font size:100, H/V Overflow:Overflow  
/// - Status Group (score group 복사) : Rect Transform (X:20,Y:20 -> 여백 / 자식obj까지 선택 -> Anchor Presets - alt+shift+우측상단)
///                                   - Heart/Ammo/Coin Image : Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize)
///                                   - Heart/Ammo/Coin Text  : Text(H:100/100, A:-/99, C:1000)
/// - Stage Group  (score group 복사) : Rect Transform (X:-20,Y:-20 -> 여백 / 자식obj까지 선택 -> Anchor Presets - alt+shift+우측상단)   
///                                   - Stage/Time Image : SourceImage:(S:Icon Stage / T:Time Mini)  
///                                   - Stage/Time Text  : Text(S:Stage 1 / T:00:00:00)
/// - Enemy Group  (score group 복사) : Rect Transform (X:-20,Y:20 -> 여백 / 자식 obj까지선택 -> Anchor Presets - alt+shift+우측하단)
///                                   - Enemy A/B/C/D Image : Icon Enemy A/B/C/D
///                                   - Enemy A/B/C/D Text  : Text (A:x0,B:x0,C:x0 / Alignment : 우측정렬)
/// - Equip Group (빈obj) : Rect Transform (Y:20 ->여백, W:0,H:0 / Anchor Presets - alt+shift+중앙하단 / Scale :(0.7,0.7,0.7 -> 전체-자식객체- 숫자키UI크기 조절 가능)) 
///                       - Control L/R Image(UI-Image / Rect T(Anchor Presets-alt+shift+중앙하단), Source Image(Panel B drag), Set Native Size 적용 ) - Weapon L/R Image : Source Image(L:Icon Attack, R:IconWeapon Grenade), Set Native Size 적용
///                                                                                                                                                   - Num L/R Image    : Source Image(L:Icon NumL, R:Icon NumR), Set Native Size 적용 / Rect Transform( X:15, Y:25 / Anchor Presets-alt+shift+좌측상단)
///                       - Equip 1/2/3(UI-Image / Rect T(Anchor Presets-alt+shift+중앙하단), Source Image(Panel B drag), Set Native Size 적용 ) - Weapon1/2/3 Image : Source Image(1:IconWeapon Hammer, 2:IconWeapon HandGun, 3:IconWeapon SubMachineGun), Set Native Size 적용
///                                                                                                                                             - Num1/2/3 Image    : Source Image(Icon Num1/Num2/Num3), Set Native Size 적용 / Rect Transform( X:15, Y:25 / Anchor Presets-alt+shift+좌측상단)
/// - Boss Gruop (빈obj) : Rect Transform(W:0,H:0 / Anchor Presets-alt+shift+중앙상단) 
///                      - Image(Rect Transform(W:600,H:50), Source Image:Guage Back, Image Type:Simple->Set Native Size적용->Image Type:Sliced) - Boss Health Image(RectT(X:-30 / W:600,H:50 / Anchor Presets : shift만 눌러 파란점이 나온상태에서 기준점을 중앙좌측으로 설정 -> Width 위치에서 좌우로 드래그하면 HP가 깍인다), Source Image:Guage Front, color:Red, Image Type:Simple->Set Native Size적용->Image Type:Sliced )
///                                                                                                                                              - Boss Image : RectT(Anchor Presets:중앙좌측) Source Image: Icon Enemy D - Set Native Size
///                                                                                                                                              - Boss Text  : Source Image : Icon Boss - Set Native Size
/// (아래서부터 쿼터뷰 15강)
/// - Item Shop Group : Rect Transform(Y:-1000->canvas밖에 위치 / W:1000, H:500), Image - Source Image : Panel A 
///                   - Item Button A/B/C (source Image : Panel A) - Name Text
///                                                                - Price Text
///                                                                - Item(source Image :Icon Heart/Ammo/WeponGenerade) / Coin Image(source Image : Icon Coin Mini)
///                   - Exit Button - Image  : source Image(Icone Close, Set Native Size)
///                                 - Button : - Transition : Normal / Highlighted(마우스가져다댈때) / Pressed(버튼눌렀을때) / Selected(한번 선택시 고정) / Disable Color
///                                            - OnClick()  : Item Shop-Zone, Shop script의 Exit()함수 연결  
///                   - Portrait Image(source Image : Icone Luna)
///                   - Talk Text
///
/// - Weapon Shop Group (Item Shop Group 복사)
///                   - Exit Button - Image  : source Image(Icone Close, Set Native Size)
///                                 - Button : - Transition : Normal / Highlighted(마우스가져다댈때) / Pressed(버튼눌렀을때) / Selected(한번 선택시 고정) / Disable Color
///                                            - OnClick()  : Weapon Shop-Zone, Shop script의 Exit()함수 연결  







/// 쿼터뷰 15강
/// 
/// [하이어라키뷰에서 만든 상점 obj들]
/// 
/// 1) Item Shop (빈obj) 
/// - Table(3D-Cube)
/// - Goods Group : item prefab들 진열(15강 참고)
/// - Luna (prefab drag) - Mesh Object - Luna Animator controller - IDLE/Hello(Models폴더-Simple NPC-IDLE) : Entry - IDLE / Any State - Hello(Trigger:tHello, has exit time 해제, Transition Duration:0.1) - Exit(has exit time 활성화, Transition Duration:0.1)
/// - Zone(빈obj) : Tag:Shop / Shop script 연결
///               - Particle System(Shpape:Donut, 출입 범위 표시, 15강 참고)
///               - Sphere Collider : is Trigger 활성화
/// - Spawn Pos A/B/C(빈obj) : 15강 참고 
///
/// 
/// 2) Weapon Shop (Item Shop 복사)
/// - Table(3D-Cube)
/// - Goods Group : item prefab들 진열(15강 참고)
/// - Ludo (prefab drag) - Mesh Object - Ludo Animator controller - IDLE/Hello(Models폴더-Simple NPC-IDLE) : Entry - IDLE / Any State - Hello(Trigger:tHello, has exit time 해제, Transition Duration:0.1) - Exit(has exit time 활성화, Transition Duration:0.1)
/// - Zone(빈obj) : Tag:Weapon / Shop script 연결
///               - Particle System(Shpape:Donut, 출입 범위 표시, 15강 참고)
///               - Sphere Collider : is Trigger 활성화
/// - Spawn Pos A/B/C(빈obj) : 15강 참고 








public class Shop : MonoBehaviour
{

    public RectTransform uiGroup;                 /// Game Panel - Item/Weapon Shop Group  drag
    public Animator animator;                     /// Luna/Ludo - Mesh Object  drag    
    Player player;                                /// 플레이어 변수

    public GameObject[] itemObjArray;             /// Luna/Ludo-Zone(Shop script: ItemObjArray   - size:3 설정 후 ItemHeart / ItemAmmo / WeaponGrenade prefab 연결 ) 
    public int[] itemPriceArray;                  /// Luna/Ludo-Zone(Shop script: ItemPriceArray - size:3 설정 후 Luna : 1000/1200/2500 or Ludo : 500/3000/5000 입력 )
    public Transform[] itemPosArray;              /// Luna/Ludo-Zone(Shop script: ItemPosArray   - size:3 설정 후 Luna-Zone-Spawn Pos A/B/C 연결 )
    public Text talkText;                         /// Luna/Ludo-Zone(Shop script: TalkText       - Game Panel - Item / Weapon Shop Group - TalkText 연결 )
    public string[] shopTalkArray;                /// Luna/Ludo-Zone(Shop script: shopTalkArray  - size:2 설정 후  0:소모품/장비는 안전을 지켜주지,  1:돈이 부족해... 다시 확인해봐. 입력)


    /// Item Shop Group   - Exit Button : On Click()함수에  Luna 드래그 후 Shop - Exit() 설정
    /// Weapon Shop Group - Exit Button : On Click()함수에  Ludo 드래그 후 Shop - Exit() 설정
    /// Item Shop Group   - Item Button A/B/C 각각 : On Click()함수에 (Luna-)zone 드래그 후 Shop - Buy(int) - 0/1/2 설정 
    /// Weapon Shop Group - Item Button A/B/C 각각 : On Click()함수에 (Ludo-)zone 드래그 후 Shop - Buy(int) - 0/1/2 설정 



    public void Enter(Player _player) ///15강-1 입장
    {
        player = _player;
        uiGroup.anchoredPosition = Vector3.zero;                ///화면 정중앙에 오도록
    }

    public void Exit()                ///15강-1 퇴장
    {

        animator.SetTrigger("tHello");                         /// animator Trigger 활성화
        uiGroup.anchoredPosition = Vector3.down * 1000;        /// 원래 위치로 내려가도록
    }

    public void Buy(int _int)
    {
        int price = itemPriceArray[_int];

        if (price > player.coin)    /// 금액이 부족하면 return
        {
            
            StopCoroutine(Talk());      /// 이용자가 중복으로 누를 때 대사가 꼬이는걸 방지하기 위해 한 번 정지한다.
            StartCoroutine(Talk());     /// 대사 함수 호출
            return;
        }

        player.coin -= price;                                                                              ///돈이 있으면 금액차감
        Vector3 randomVec = Vector3.right * Random.Range(-3, 3)  +  Vector3.forward * Random.Range(-3, 3); /// 랜덤 위치 변수
        Instantiate(itemObjArray[_int], itemPosArray[_int].position + randomVec,  itemPosArray[_int].rotation);  /// 아이템 생성
    }
    IEnumerator Talk()
    {
        talkText.text = shopTalkArray[1];            
        yield return new WaitForSeconds(2f);    ///2초 정지
        talkText.text = shopTalkArray[0];
    }








}
