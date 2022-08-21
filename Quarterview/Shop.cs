using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               ///유니티 UI를 사용하겠다, public Text talkText; 선언에 사용





/// UI (UserInterface 유저상호작용 : 스크린 좌표계, 2D로 바꾸면 작업하기 편함  /  Rect Transform(스크린 좌표) - Anchor Presets(shift:UI기준점, Alt:UI위치))
/// 
/// Canvas - Menu Panel - Game Panel 
/// 1. Canvas (크기:game화면에서 16:9로 설정(canvas크기는 main camera 크기와 동일), pixel perfect(도트) 활성화,  Canvas Scaler(- UI Scale Mode:ScaleWithScreenSize, Reference Resolution(X:1920, Y:1080 해상도)  )
/// 2. Menu Panel(R click-UI-Panel, Color:Black) - Title Image(R click-UI-Image / Source Image : Title Sprite drag),  Set Native Size 설정) 
///                                              - Max score Image(R click-UI-Image / Source Image : Icon Score Mini drag)
///                                              - Max score Text(R click-UI-Text / Text:999999, Fsize:130, Alignm:중앙, col:white, React Transform(W:0,H:0, Scale(글씨압축):0.5), Font:쿠키런bold,  H/V Overflow:Overflow)
///                                              - Start Button(R click-UI-Button / Source Image: PanelA drag, Image Type:Simple - SetNativeSize - Image Type:Sliced ) - Text (text:Game Start 입력, Font:쿠키런bold, Fsize:110, RectT(scale:0.5,0.5,0.5), H/V Overflow:Overflow)           
/// 3. Game Panel(R click-UI-Panel, Color: A:0)  - [1] Score Group(빈obj, RectT(W:0,H:0, AnchorPreset:alt,shift,좌측상단, PosX:20,PosY:-20) - Score Image(UI-Image / Source Image:Icon Score Mini drag, RectT(AnchorPreset:alt,shift,좌측상단)), Score Text(UI-Text / Text:999999, Font:쿠키런bold, Fsize:100, RectT(W:0,H:0,scale:0.5x3, AnchorPreset:alt,shift,좌측상단), H/V Overflow:Overflow)  
///                                              - Status Group ( [1]복사, StatusGroup(RectT(PosX:20,PosY:-20)) 및 자식obj도 RectT-Anchor-alt,shift,좌측하단, 자식obj의 Image와 Text 선택후 2쌍 복사) - Heart/Ammo/Coin Image(Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize), Heart/Ammo/Coin Text (H:100/100, A:-/99, C:1000)
///                         (이 줄부터 정리안함) - Stage Group( [1]복사, Stage Group(RectT(PosX:-20,PosY:-20)) 및 자식obj도 RectT-Anchor-alt,shift,우측상단 )  -  Stage/Time Image(SourceImage:Icon Stage/Time Mini),  Stage/Time Text(Text:Stage 1/00:00:00, Alignm:우측) 설정후 복사
///                                              - Enemy Group( [1]복사, ) - Enemy A/B/C/D Image/Text 
///                                              - Equip Group - Equip 1/2/3(- Weapon Image/Num Image), ControlR(- Weapon Image/Num Image) 
///                                              - Boss Gruop - Image(SourceImage:, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)) - Boss Health Image(SourceImage:, color:Red, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)), Boss Text, Boss Image
///                                              - [2] Item Shop Group         - Item Button A(On) /B/C(- Text, Text, Image),  Exit Button(-Text삭제  ),  Portrait Image,  Talke Text
///                                              - Weapon Shop Group ([2]복사) - Item Button A/B/C(- Text, Text, Image),  Exit Button(-Text삭제   ),  Portrait Image,  Talk Text 



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
