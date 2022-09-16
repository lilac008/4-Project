using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               ///����Ƽ������ UI�� ������, public Text talkText; ���� ���

/// ���ͺ�14��

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
/// - Status Group (score group ����) : Rect Transform (X:20,Y:20 -> ���� / �ڽ�obj���� ���� -> Anchor Presets - alt+shift+�������)
///                                   - Heart/Ammo/Coin Image : Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize)
///                                   - Heart/Ammo/Coin Text  : Text(H:100/100, A:-/99, C:1000)
/// - Stage Group  (score group ����) : Rect Transform (X:-20,Y:-20 -> ���� / �ڽ�obj���� ���� -> Anchor Presets - alt+shift+�������)   
///                                   - Stage/Time Image : SourceImage:(S:Icon Stage / T:Time Mini)  
///                                   - Stage/Time Text  : Text(S:Stage 1 / T:00:00:00)
/// - Enemy Group  (score group ����) : Rect Transform (X:-20,Y:20 -> ���� / �ڽ� obj�������� -> Anchor Presets - alt+shift+�����ϴ�)
///                                   - Enemy A/B/C/D Image : Icon Enemy A/B/C/D
///                                   - Enemy A/B/C/D Text  : Text (A:x0,B:x0,C:x0 / Alignment : ��������)
/// - Equip Group (��obj) : Rect Transform (Y:20 ->����, W:0,H:0 / Anchor Presets - alt+shift+�߾��ϴ� / Scale :(0.7,0.7,0.7 -> ��ü-�ڽİ�ü- ����ŰUIũ�� ���� ����)) 
///                       - Control L/R Image(UI-Image / Rect T(Anchor Presets-alt+shift+�߾��ϴ�), Source Image(Panel B drag), Set Native Size ���� ) - Weapon L/R Image : Source Image(L:Icon Attack, R:IconWeapon Grenade), Set Native Size ����
///                                                                                                                                                   - Num L/R Image    : Source Image(L:Icon NumL, R:Icon NumR), Set Native Size ���� / Rect Transform( X:15, Y:25 / Anchor Presets-alt+shift+�������)
///                       - Equip 1/2/3(UI-Image / Rect T(Anchor Presets-alt+shift+�߾��ϴ�), Source Image(Panel B drag), Set Native Size ���� ) - Weapon1/2/3 Image : Source Image(1:IconWeapon Hammer, 2:IconWeapon HandGun, 3:IconWeapon SubMachineGun), Set Native Size ����
///                                                                                                                                             - Num1/2/3 Image    : Source Image(Icon Num1/Num2/Num3), Set Native Size ���� / Rect Transform( X:15, Y:25 / Anchor Presets-alt+shift+�������)
/// - Boss Gruop (��obj) : Rect Transform(W:0,H:0 / Anchor Presets-alt+shift+�߾ӻ��) 
///                      - Image(Rect Transform(W:600,H:50), Source Image:Guage Back, Image Type:Simple->Set Native Size����->Image Type:Sliced) - Boss Health Image(RectT(X:-30 / W:600,H:50 / Anchor Presets : shift�� ���� �Ķ����� ���»��¿��� �������� �߾��������� ���� -> Width ��ġ���� �¿�� �巡���ϸ� HP�� ���δ�), Source Image:Guage Front, color:Red, Image Type:Simple->Set Native Size����->Image Type:Sliced )
///                                                                                                                                              - Boss Image : RectT(Anchor Presets:�߾�����) Source Image: Icon Enemy D - Set Native Size
///                                                                                                                                              - Boss Text  : Source Image : Icon Boss - Set Native Size
/// (�Ʒ������� ���ͺ� 15��)
/// - Item Shop Group : Rect Transform(Y:-1000->canvas�ۿ� ��ġ / W:1000, H:500), Image - Source Image : Panel A 
///                   - Item Button A/B/C (source Image : Panel A) - Name Text
///                                                                - Price Text
///                                                                - Item(source Image :Icon Heart/Ammo/WeponGenerade) / Coin Image(source Image : Icon Coin Mini)
///                   - Exit Button - Image  : source Image(Icone Close, Set Native Size)
///                                 - Button : - Transition : Normal / Highlighted(���콺�����ٴ) / Pressed(��ư��������) / Selected(�ѹ� ���ý� ����) / Disable Color
///                                            - OnClick()  : Item Shop-Zone, Shop script�� Exit()�Լ� ����  
///                   - Portrait Image(source Image : Icone Luna)
///                   - Talk Text
///
/// - Weapon Shop Group (Item Shop Group ����)
///                   - Exit Button - Image  : source Image(Icone Close, Set Native Size)
///                                 - Button : - Transition : Normal / Highlighted(���콺�����ٴ) / Pressed(��ư��������) / Selected(�ѹ� ���ý� ����) / Disable Color
///                                            - OnClick()  : Weapon Shop-Zone, Shop script�� Exit()�Լ� ����  







/// ���ͺ� 15��
/// 
/// [���̾��Ű�信�� ���� ���� obj��]
/// 
/// 1) Item Shop (��obj) 
/// - Table(3D-Cube)
/// - Goods Group : item prefab�� ����(15�� ����)
/// - Luna (prefab drag) - Mesh Object - Luna Animator controller - IDLE/Hello(Models����-Simple NPC-IDLE) : Entry - IDLE / Any State - Hello(Trigger:tHello, has exit time ����, Transition Duration:0.1) - Exit(has exit time Ȱ��ȭ, Transition Duration:0.1)
/// - Zone(��obj) : Tag:Shop / Shop script ����
///               - Particle System(Shpape:Donut, ���� ���� ǥ��, 15�� ����)
///               - Sphere Collider : is Trigger Ȱ��ȭ
/// - Spawn Pos A/B/C(��obj) : 15�� ���� 
///
/// 
/// 2) Weapon Shop (Item Shop ����)
/// - Table(3D-Cube)
/// - Goods Group : item prefab�� ����(15�� ����)
/// - Ludo (prefab drag) - Mesh Object - Ludo Animator controller - IDLE/Hello(Models����-Simple NPC-IDLE) : Entry - IDLE / Any State - Hello(Trigger:tHello, has exit time ����, Transition Duration:0.1) - Exit(has exit time Ȱ��ȭ, Transition Duration:0.1)
/// - Zone(��obj) : Tag:Weapon / Shop script ����
///               - Particle System(Shpape:Donut, ���� ���� ǥ��, 15�� ����)
///               - Sphere Collider : is Trigger Ȱ��ȭ
/// - Spawn Pos A/B/C(��obj) : 15�� ���� 








public class Shop : MonoBehaviour
{

    public RectTransform uiGroup;                 /// Game Panel - Item/Weapon Shop Group  drag
    public Animator animator;                     /// Luna/Ludo - Mesh Object  drag    
    Player player;                                /// �÷��̾� ����

    public GameObject[] itemObjArray;             /// Luna/Ludo-Zone(Shop script: ItemObjArray   - size:3 ���� �� ItemHeart / ItemAmmo / WeaponGrenade prefab ���� ) 
    public int[] itemPriceArray;                  /// Luna/Ludo-Zone(Shop script: ItemPriceArray - size:3 ���� �� Luna : 1000/1200/2500 or Ludo : 500/3000/5000 �Է� )
    public Transform[] itemPosArray;              /// Luna/Ludo-Zone(Shop script: ItemPosArray   - size:3 ���� �� Luna-Zone-Spawn Pos A/B/C ���� )
    public Text talkText;                         /// Luna/Ludo-Zone(Shop script: TalkText       - Game Panel - Item / Weapon Shop Group - TalkText ���� )
    public string[] shopTalkArray;                /// Luna/Ludo-Zone(Shop script: shopTalkArray  - size:2 ���� ��  0:�Ҹ�ǰ/���� ������ ��������,  1:���� ������... �ٽ� Ȯ���غ�. �Է�)


    /// Item Shop Group   - Exit Button : On Click()�Լ���  Luna �巡�� �� Shop - Exit() ����
    /// Weapon Shop Group - Exit Button : On Click()�Լ���  Ludo �巡�� �� Shop - Exit() ����
    /// Item Shop Group   - Item Button A/B/C ���� : On Click()�Լ��� (Luna-)zone �巡�� �� Shop - Buy(int) - 0/1/2 ���� 
    /// Weapon Shop Group - Item Button A/B/C ���� : On Click()�Լ��� (Ludo-)zone �巡�� �� Shop - Buy(int) - 0/1/2 ���� 



    public void Enter(Player _player) ///15��-1 ����
    {
        player = _player;
        uiGroup.anchoredPosition = Vector3.zero;                ///ȭ�� ���߾ӿ� ������
    }

    public void Exit()                ///15��-1 ����
    {

        animator.SetTrigger("tHello");                         /// animator Trigger Ȱ��ȭ
        uiGroup.anchoredPosition = Vector3.down * 1000;        /// ���� ��ġ�� ����������
    }

    public void Buy(int _int)
    {
        int price = itemPriceArray[_int];

        if (price > player.coin)    /// �ݾ��� �����ϸ� return
        {
            
            StopCoroutine(Talk());      /// �̿��ڰ� �ߺ����� ���� �� ��簡 ���̴°� �����ϱ� ���� �� �� �����Ѵ�.
            StartCoroutine(Talk());     /// ��� �Լ� ȣ��
            return;
        }

        player.coin -= price;                                                                              ///���� ������ �ݾ�����
        Vector3 randomVec = Vector3.right * Random.Range(-3, 3)  +  Vector3.forward * Random.Range(-3, 3); /// ���� ��ġ ����
        Instantiate(itemObjArray[_int], itemPosArray[_int].position + randomVec,  itemPosArray[_int].rotation);  /// ������ ����
    }
    IEnumerator Talk()
    {
        talkText.text = shopTalkArray[1];            
        yield return new WaitForSeconds(2f);    ///2�� ����
        talkText.text = shopTalkArray[0];
    }








}
