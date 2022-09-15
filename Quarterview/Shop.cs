using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               ///����Ƽ UI�� ����ϰڴ�, public Text talkText; ���� ���


/// [UI]
/// 1. UI (UserInterface ������ȣ�ۿ�)
/// 2. EventSystem : UI���� Ű �Է��� �������ִ� component

/// [Canvas] : ȭ��� ��ǥ��, 2D�� �ٲ㼭 �۾�, Game���� �ػ�(main camera ũ��)�� ������ ũ�� -> 16:9�� ����
/// - Rect Transform(ȭ��� ��ǥ��) : Anchor Presets (shift:UI������, Alt:UI��ġ)
/// - Canvas - Pixel Perfect Ȱ��ȭ(��Ʈ �̹���)
/// - Canvas Scaler - UI Scale Mode - Scale with screen size : ��� �ػ󵵿����� ũ�Ⱑ �����ϰ� ����� �ǵ��� 
///                                 - Reference Resolution : �ػ�, X:1920, Y:1080���� ����

/// [MenuPanel] : Canvas - UI - Panel 
/// - Image component : UI���� �̹����� �׷��ִ� component -> ��ο� �������� ����
/// 
/// - Title Image (UI-Image) - Source Image : Title Sprite drag
///                          - Set Native Size ����
/// - Max score Image (UI-Image) - Source Image : Icon Score Mini drag
///                              - Rect Transform : X : -170, Y : -150
/// - Max score Text(UI-Text) - Text component - Text : 999999, Font:��Ű������ü, Font Size:130, Alignment:�߾�����, color:white, Horizontal/Vertical Overflow : Overflow
///                                            - React Transform(W:0, H:0, overflow������ ���� �����ص� ������) - Scale(0.5,0.5,0.5 -> ����� �۾� ����) 
/// - Start Button(UI-Button) : React Transform : Y : -350, W:400, H:150
///                             Image component - Source Image : PanelA drag 
///                                             - Image Type : Simple, SetNativeSize ������ Image Type : Sliced�� ����
///                           - Text(UI-Text) - Rect Transform : scale(0.5,0.5,0.5 -> ����� �۾� ����) 
///                                           - Text : Game Start�Է�, Font:��Ű������ü, Font Size:110, H/V Overflow:Overflow         

/// [Game Panel] : Canvas - UI - Panel
/// - Color : A:0 -> ����ȭ
/// - Score Group (��obj, Rect Transform(X:20,Y:-20, W:0,H:0, AnchorPreset:alt+shift+�������) - Score Image(UI-Image) : Rect Transform(Anchor Presets:alt+shift+������� -> �Ķ���ȭ��ǥ ��Ŀ�� ��ǥ��� �������� ������) / Source Image : Icon Score Mini drag
///                                                                                            - Score Text (UI-Text)  : Rect Transform(Anchor Presets:alt+shift+������� -> �Ķ���ȭ��ǥ ��Ŀ�� ��ǥ��� �������� ������ / W:0,H:0, scale(0.5,0.5,0.5)) / Text:999999, Font:��Ű������ü, Font size:100, H/V Overflow:Overflow  
/// - Status Group (score group ����) : Rect Transform (���� X:20,Y:20 / �ڽ�obj���� ���� -> Anchor Presets - alt+shift+�������)
///                                   - Heart/Ammo/Coin Image : Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize)
///                                   - Heart/Ammo/Coin Text  : Text(H:100/100, A:-/99, C:1000)
/// - Stage Group  (score group ����) : Rect Transform (���� X:-20,Y:-20 / �ڽ�obj���� ���� -> Anchor Presets - alt+shift+�������)   
///                                   - Stage/Time Image : SourceImage:(S:Icon Stage / T:Time Mini)  
///                                   - Stage/Time Text  : Text(S:Stage 1 / T:00:00:00)
/// - Enemy Group  (score group ����) : Rect Transform (���� X:-20,Y:20 / �ڽ� obj�������� -> Anchor Presets - alt+shift+�����ϴ�)
///                                   - Enemy A/B/C/D Image : Icon Enemy A/B/C/D
///                                   - Enemy A/B/C/D Text  :   
/// - Equip Group (��obj) - Control L Image (Rect Transform - Anchor Presets - alt+shift+�߾��ϴ� / Source Image : Panel B, Set Native Size) - Weapon Image : Source Image (Icon Weapon Hammer) 
///                                                                                                                                            - Num Image    : Source Image (Icon Num1)
///                                                                                                                                            
/// 
///                         ControlR(- Weapon Image/Num Image) 
/// - Boss Gruop - Image(SourceImage:, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)) - Boss Health Image(SourceImage:, color:Red, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)), Boss Text, Boss Image
/// - [2] Item Shop Group         - Item Button A(On) /B/C(- Text, Text, Image),  Exit Button(-Text����  ),  Portrait Image,  Talke Text
/// - Weapon Shop Group ([2]����) - Item Button A/B/C(- Text, Text, Image),  Exit Button(-Text����   ),  Portrait Image,  Talk Text 

/// Item Shop   - Table,  Goods Group,  Luna (MeshObj-Animator-Idle,Hello (tHello)),  Zone(��obj - Particle System (Shpape:Donut, ���ͺ� 15�� ����), Shop script) - Spawn Pos A/B/C(��obj)
/// Weapon Shop - Table,  Goods Group,  Ludo (MeshObj- Luna Animation���� �� ��ü ),  Zone(��obj - Shop script) - Spawn Pos A/B/C(��obj)






public class Shop : MonoBehaviour
{

    public RectTransform rectT_UI;                                ///ui ���� ����,  Item / Weapon  Shop Group �巡��
    public Animator anim;                                         /// Luna/Ludo - Mesh Obj �巡��    
    Player player;                                                /// �÷��̾� ����

    public GameObject[] itemObjArr;                               /// ������ prefab �迭, Luna/Ludo - zone (shop script : ItemObjArr - size: 3, ItemHeart/ ItemAmmo / WeaponGrenade prefab ���� ����) 
    public int[] itemPriceArr;                                    /// ������ ���� �迭, Luna/Ludo - zone (shop script : ItemPriceArr - size: 3, Luna1000/1200/2500 or Ludo500/3000/5000 �Է�)
    public Transform[] itemPosArr;                                /// ������ ��ġ �迭, Luna/Ludo - zone (shop script : ItemPosArr - size: 3, (Luna-Zone-)Spawn Pos A/B/C ����)
    public Text talkText;                                         /// Luna/Ludo - zone ( shop script : TalkText - (Item/Weapon Shop Group-)TalkText ���� )
    public string[] shopTalk;                                     /// ������ȭ�� ���� ���� �迭, Luna/Ludo - zone (shop script : shopTalk - size:2, 0:�Ҹ�ǰ/���� ������ ��������, 1:���� ������... �ٽ� Ȯ���غ�.)


    /// Item Shop Group   - Exit Button : On Click()�Լ���  Luna �巡�� �� Shop - Exit() ����
    /// Weapon Shop Group - Exit Button : On Click()�Լ���  Ludo �巡�� �� Shop - Exit() ����
    /// Item Shop Group   - Item Button A/B/C ���� : On Click()�Լ��� (Luna-)zone �巡�� �� Shop - Buy(int) - 0/1/2 ���� 
    /// Weapon Shop Group - Item Button A/B/C ���� : On Click()�Լ��� (Ludo-)zone �巡�� �� Shop - Buy(int) - 0/1/2 ���� 




    public void Enter(Player _player)///15��-1����
    {
        player = _player;
        rectT_UI.anchoredPosition = Vector3.zero;                ///ȭ�� �� �߾ӿ� ������
    }


    public void Exit()                ///15��-1����
    {

        anim.SetTrigger("doHello");
        rectT_UI.anchoredPosition = Vector3.down * 1000;        ///
    }




    public void Buy(int _int)
    {
        int price = itemPriceArr[_int];

        if (price > player.coin)    /// �ݾ��� �����ϸ� return
        {
            
            StopCoroutine(Talk());      /// �̿��ڰ� �ߺ����� ���� �� ��簡 ���̴°� �����ϱ� ���� �� �� �����Ѵ�.
            StartCoroutine(Talk());     /// ��� �Լ� ȣ��
            return;
        }

        player.coin -= price;                                                                              ///���� ������ �ݾ�����
        Vector3 randomVec = Vector3.right * Random.Range(-3, 3)  +  Vector3.forward * Random.Range(-3, 3); /// ���� ��ġ ����
        Instantiate(itemObjArr[_int], itemPosArr[_int].position + randomVec,  itemPosArr[_int].rotation);  /// ������ ����
    }
    IEnumerator Talk()
    {
        talkText.text = shopTalk[1];            
        yield return new WaitForSeconds(2f);    ///2�� ����
        talkText.text = shopTalk[0];
    }








}
