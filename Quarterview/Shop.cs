using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               ///유니티 UI를 사용하겠다, public Text talkText; 선언에 사용


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
/// - Status Group (score group 복사) : Rect Transform (여백 X:20,Y:20 / 자식obj까지 선택 -> Anchor Presets - alt+shift+우측상단)
///                                   - Heart/Ammo/Coin Image : Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize)
///                                   - Heart/Ammo/Coin Text  : Text(H:100/100, A:-/99, C:1000)
/// - Stage Group  (score group 복사) : Rect Transform (여백 X:-20,Y:-20 / 자식obj까지 선택 -> Anchor Presets - alt+shift+우측상단)   
///                                   - Stage/Time Image : SourceImage:(S:Icon Stage / T:Time Mini)  
///                                   - Stage/Time Text  : Text(S:Stage 1 / T:00:00:00)
/// - Enemy Group  (score group 복사) : Rect Transform (여백 X:-20,Y:20 / 자식 obj까지선택 -> Anchor Presets - alt+shift+우측하단)
///                                   - Enemy A/B/C/D Image : Icon Enemy A/B/C/D
///                                   - Enemy A/B/C/D Text  :   
/// - Equip Group (빈obj) - Control L Image (Rect Transform - Anchor Presets - alt+shift+중앙하단 / Source Image : Panel B, Set Native Size) - Weapon Image : Source Image (Icon Weapon Hammer) 
///                                                                                                                                            - Num Image    : Source Image (Icon Num1)
///                                                                                                                                            
/// 
///                         ControlR(- Weapon Image/Num Image) 
/// - Boss Gruop - Image(SourceImage:, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)) - Boss Health Image(SourceImage:, color:Red, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)), Boss Text, Boss Image
/// - [2] Item Shop Group         - Item Button A(On) /B/C(- Text, Text, Image),  Exit Button(-Text삭제  ),  Portrait Image,  Talke Text
/// - Weapon Shop Group ([2]복사) - Item Button A/B/C(- Text, Text, Image),  Exit Button(-Text삭제   ),  Portrait Image,  Talk Text 

/// Item Shop   - Table,  Goods Group,  Luna (MeshObj-Animator-Idle,Hello (tHello)),  Zone(빈obj - Particle System (Shpape:Donut, 쿼터뷰 15부 참고), Shop script) - Spawn Pos A/B/C(빈obj)
/// Weapon Shop - Table,  Goods Group,  Ludo (MeshObj- Luna Animation복사 후 교체 ),  Zone(빈obj - Shop script) - Spawn Pos A/B/C(빈obj)






public class Shop : MonoBehaviour
{

    public RectTransform rectT_UI;                                ///ui 담을 변수,  Item / Weapon  Shop Group 드래그
    public Animator anim;                                         /// Luna/Ludo - Mesh Obj 드래그    
    Player player;                                                /// 플레이어 변수

    public GameObject[] itemObjArr;                               /// 아이템 prefab 배열, Luna/Ludo - zone (shop script : ItemObjArr - size: 3, ItemHeart/ ItemAmmo / WeaponGrenade prefab 각각 연결) 
    public int[] itemPriceArr;                                    /// 아이템 가격 배열, Luna/Ludo - zone (shop script : ItemPriceArr - size: 3, Luna1000/1200/2500 or Ludo500/3000/5000 입력)
    public Transform[] itemPosArr;                                /// 아이템 위치 배열, Luna/Ludo - zone (shop script : ItemPosArr - size: 3, (Luna-Zone-)Spawn Pos A/B/C 연결)
    public Text talkText;                                         /// Luna/Ludo - zone ( shop script : TalkText - (Item/Weapon Shop Group-)TalkText 연결 )
    public string[] shopTalk;                                     /// 상점대화로 넣을 변수 배열, Luna/Ludo - zone (shop script : shopTalk - size:2, 0:소모품/장비는 안전을 지켜주지, 1:돈이 부족해... 다시 확인해봐.)


    /// Item Shop Group   - Exit Button : On Click()함수에  Luna 드래그 후 Shop - Exit() 설정
    /// Weapon Shop Group - Exit Button : On Click()함수에  Ludo 드래그 후 Shop - Exit() 설정
    /// Item Shop Group   - Item Button A/B/C 각각 : On Click()함수에 (Luna-)zone 드래그 후 Shop - Buy(int) - 0/1/2 설정 
    /// Weapon Shop Group - Item Button A/B/C 각각 : On Click()함수에 (Ludo-)zone 드래그 후 Shop - Buy(int) - 0/1/2 설정 




    public void Enter(Player _player)///15강-1입장
    {
        player = _player;
        rectT_UI.anchoredPosition = Vector3.zero;                ///화면 정 중앙에 오도록
    }


    public void Exit()                ///15강-1퇴장
    {

        anim.SetTrigger("doHello");
        rectT_UI.anchoredPosition = Vector3.down * 1000;        ///
    }




    public void Buy(int _int)
    {
        int price = itemPriceArr[_int];

        if (price > player.coin)    /// 금액이 부족하면 return
        {
            
            StopCoroutine(Talk());      /// 이용자가 중복으로 누를 때 대사가 꼬이는걸 방지하기 위해 한 번 정지한다.
            StartCoroutine(Talk());     /// 대사 함수 호출
            return;
        }

        player.coin -= price;                                                                              ///돈이 있으면 금액차감
        Vector3 randomVec = Vector3.right * Random.Range(-3, 3)  +  Vector3.forward * Random.Range(-3, 3); /// 랜덤 위치 변수
        Instantiate(itemObjArr[_int], itemPosArr[_int].position + randomVec,  itemPosArr[_int].rotation);  /// 아이템 생성
    }
    IEnumerator Talk()
    {
        talkText.text = shopTalk[1];            
        yield return new WaitForSeconds(2f);    ///2초 정지
        talkText.text = shopTalk[0];
    }








}
