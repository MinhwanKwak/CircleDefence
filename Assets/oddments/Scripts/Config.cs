using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using System.Linq;

[System.Serializable]
public class Config : oddments.SingletonScriptableObject<Config>, oddments.ILoader
{
    public static readonly int Slot_MAX = 3;
    public static readonly int BoostBuffIdx = 20000;
    public static readonly int RouletteIdx = 100000;
    public enum Language
    {
        en,
        ko,
        ja,
        es,
        ch,
    }

    public enum RecordCountKeys
    {
        FacilityAuto,
    }

    public enum FacilityType
    {
        Enter = 1,
        Manufacture,
        Exit,
        Gacha
    }

    public enum RewardType
    {
        Currency = 1,
        Card = 2,
        Manager = 3,
        Item = 4,
        StageClearDoll = 5,
    }

    public enum ItemType
    {
        ADTicket = 0,
        SilverTicket = 50001,
        GoldTicket = 50002,
        DeliveryTicket = 50003,
        nocturnalTicket = 50004,
        diurnalTicket = 50005,
        Mileage = 99999,
    }

    public enum CardType
    {
        ADPack = 100001,
        SilverPack = 100002,
        GoldPack = 100003,
        DeliveryPack = 100004,
        nocturnalPack = 100005,
        diurnalPack = 100006,
        EventADPack = 1100001,
        EventSilverPack = 1100002,
        EventGoldPack = 1100003,
        EventDeliveryPack = 1100004,
        EventNocturnalPack = 1100005,
        EventDiurnalPack = 1100006,
    }

    

    public enum CurrencyID
    {
        StoreMoney = 9999,
        Money = 1,
        Material = 2,
        Cash = 3,
        FeverCoin = 4,
        EventMoney = 101,
        EventMaterial = 102,
        EventFeverCoin = 104,
        GachaCoin = 105,
    }

    public enum ManagerGrade
    {
        Noraml = 1,
        Rare = 2,
        Unique = 3,
    }

    public enum ManagerType
    {
        Distribution = 1,  
        Nocturnal = 2, 
        Driveability = 3,
        EventGacha = 4
    }

    public enum ContentsOpenType
    {
        manager_equip_slot2,
        manager_equip_slot3,
        event_open,
        card_inven,
        review,
        play_start,
        manager,
        booster,
        manager_upgrade,
        shop,
        fever,
        hire,
        exchange,
    }

    public struct RewardItemData
    {
        public int rewardType;
        public int rewardIdx;
        public System.Numerics.BigInteger rewardValue;

        public RewardItemData(int _type, int _idx, System.Numerics.BigInteger _count)
        {
            this.rewardType = _type;
            this.rewardIdx = _idx;
            this.rewardValue = _count;
        }
    }


    [System.Serializable]
    public class ColorDefine
    {
        public string key_string;
        public Color color;
    }

    [HideInInspector]
    [SerializeField]
    private List<ColorDefine> _textColorDefines = new List<ColorDefine>();
    [HideInInspector]
    [SerializeField]
    private List<ColorDefine> _eventTextColorDefines = new List<ColorDefine>();
    private Dictionary<string, Color> _textColorDefinesDic = new Dictionary<string, Color>();
    public List<ColorDefine> TextColorDefines {
        get { 
            return _textColorDefines; 
        }
    }
    public List<ColorDefine> EventTextColorDefines {
        get {
            return _eventTextColorDefines;
        }
    }

    [HideInInspector]
    [SerializeField]
    private List<ColorDefine> _imageColorDefines = new List<ColorDefine>();
    [HideInInspector]
    [SerializeField]
    private List<ColorDefine> _eventImgaeColorDefines = new List<ColorDefine>();
    private Dictionary<string, Color> _imageColorDefinesDic = new Dictionary<string, Color>();
    public List<ColorDefine> ImageColorDefines {
        get {
            return _imageColorDefines;
        }
    }
    public List<ColorDefine> EventImageColorDefines {
        get {
            return _eventImgaeColorDefines;
        }
    }
    public Material SpriteDisableMaterial = null;
    public Material SpriteEnableMaterial = null;

    [SerializeField]
    private SpriteAtlas productAtlas;
    [SerializeField]
    private SpriteAtlas managerAtlas;
    [SerializeField]
    private SpriteAtlas toyAtlas;
    [SerializeField]
    private SpriteAtlas slotAtlas;
    [SerializeField]
    private SpriteAtlas DynamicAtlas;
    [SerializeField]
    private SpriteAtlas DynamicShopAtlas;
    [SerializeField]
    private SpriteAtlas ItemCardAtlas;
    [SerializeField]
    private SpriteAtlas CommonAtlas;

    public Color GetTextColor(string key)
    {
        if(_textColorDefinesDic.ContainsKey(key))
            return _textColorDefinesDic[key];

        return Color.white;
    }

    public Color GetImageColor(string key)
    {
        if(_imageColorDefinesDic.ContainsKey(key))
            return _imageColorDefinesDic[key];

        return Color.white;
    }

    public Color GetManagerGradeBGColor(ManagerGrade grade)
    {
        switch(grade)
        {
            case ManagerGrade.Noraml:
            return GetImageColor("Card_Normal_Bg");
            case ManagerGrade.Rare:
            return GetImageColor("Card_Rare_Bg");
            case ManagerGrade.Unique:
            return GetImageColor("Card_Unique_Bg");            
        }

        return Color.white;
    }

    public Color GetManagerGradeFrameColor(ManagerGrade grade)
    {
        switch(grade)
        {
            case ManagerGrade.Noraml:
            return GetImageColor("Card_Normal_Frame");
            case ManagerGrade.Rare:
            return GetImageColor("Card_Rare_Frame");
            case ManagerGrade.Unique:
            return GetImageColor("Card_Unique_Frame");            
        }

        return Color.white;
    }
    public Sprite GetItemcardImg(string key)
    {
        return ItemCardAtlas.GetSprite(key);
    }

    public Sprite GetCommonImg(string key)
    {
        return CommonAtlas.GetSprite(key);
    }

    public Sprite GetDynamicImg(string key)
    {
        return DynamicAtlas.GetSprite(key);
    }

    public Sprite GetDynamicShop(string key)
    {
        return DynamicShopAtlas.GetSprite(key);
    }

    public Sprite GetProductImg(string key)
    {
        return productAtlas.GetSprite(key);
    }

    public Sprite GetManagerImg(string key)
    {
        return managerAtlas.GetSprite(key);
    }
    
    public Sprite GetToyImg(string key)
    {
        return toyAtlas.GetSprite(key);
    }
    public Sprite GetSlotImg(string key)
	{
        return slotAtlas.GetSprite(key);
    }

    public Sprite GetNotiCardPackImage(int cardidx)
    {
        switch(cardidx)
        {
            case (int)CardType.ADPack:
                return GetDynamicImg("Dynamic_Icon_Cardpack_Ads");
            case (int)CardType.SilverPack:
                return GetDynamicImg("Dynamic_Icon_Cardpack_Silver");
            case (int)CardType.GoldPack:
                return GetDynamicImg("Dynamic_Icon_Cardpack_Gold");
            case (int)CardType.DeliveryPack:
                return GetDynamicImg("Dynamic_Icon_Cardpack_Trade");
            case (int)CardType.diurnalPack:
                return GetDynamicImg("Dynamic_Icon_Cardpack_Sun");
            case (int)CardType.nocturnalPack:
                return GetDynamicImg("Dynamic_Icon_Cardpack_Moon");
        }

        return null;
    }

    public Sprite GetCurrencyImg(CurrencyID id)
    {
        switch(id)
        {
            case CurrencyID.Money:
                return GetDynamicImg("Dynamic_Icon_GameMoney");
            case CurrencyID.Cash:
                return GetDynamicImg("Dynamic_Icon_Gem");
            case CurrencyID.Material:
                return GetDynamicImg("Dynamic_Icon_Material");
            case CurrencyID.GachaCoin:
                return GetDynamicImg("Dynamic_Icon_GachaCoin");
            case CurrencyID.EventMoney:
                return GetDynamicImg("Dynamic_Icon_EventMoney");
            case CurrencyID.EventMaterial:
                return GetDynamicImg("Dynamic_Icon_Material_01");
        }
        return null;
    }

    public void Load()
    {
        _textColorDefinesDic.Clear();
        foreach(var cd in _textColorDefines)
        {
            _textColorDefinesDic.Add(cd.key_string, cd.color);
        }
        foreach(var cd in _eventTextColorDefines)
        {
            _textColorDefinesDic.Add(cd.key_string, cd.color);
        }
        _imageColorDefinesDic.Clear();
        foreach(var cd in _imageColorDefines)
        {
            _imageColorDefinesDic.Add(cd.key_string, cd.color);
        }
        foreach(var cd in _eventImgaeColorDefines)
        {
            _imageColorDefinesDic.Add(cd.key_string, cd.color);
        }
    }

    public string GetManagerTypeConvert(int _key)
    {
        string returnvalue = "";
        switch (_key)
        {

            case (int)Config.ManagerType.Distribution:
                returnvalue = "Dynamic_Icon_Type_Sun";
                break;
            case (int)Config.ManagerType.Nocturnal:
                returnvalue = "Dynamic_Icon_Type_Moon";
                break;
            case (int)Config.ManagerType.Driveability:
                returnvalue = "Dynamic_Icon_Type_Trade";
                break;
        }

        return returnvalue;
    }

    public Sprite GetManagerBottomImg(bool matching)
    {
        if(matching)
            return GetDynamicImg("Dynamic_Bg_ManagerPlace_Match");
        else
            return GetDynamicImg("Dynamic_Bg_ManagerPlace_Notmatch");
    }

}
