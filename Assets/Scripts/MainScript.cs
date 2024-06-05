//#define DEBUG_MODE

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Flower
{
    public List<int> ValueList;
    // Метод для генерации случайной последовательности
    private List<int> GenerateRandomSequence(int key)
    {
       List<int> sequence = new List<int>();
        sequence.Add(key); // Добавляем key в начало последовательности
        // Создаем список из всех цифр от 1 до 9
        List<int> availableDigits = new List<int>();
        for (int i = 1; i <= 9; i++)
        {
            if (i != key) // Исключаем key из доступных цифр
            {
                availableDigits.Add(i);
            }
        }
        // Создаем объект Random для генерации случайных чисел
        System.Random rand = new  System.Random();
        // Добавляем остальные цифры в случайном порядке
        while (availableDigits.Count > 0)
        {
            int randomIndex = rand.Next(0, availableDigits.Count);
            sequence.Add(availableDigits[randomIndex]);
            availableDigits.RemoveAt(randomIndex);
        }
        return sequence;
    }
    public void SetNullFlower()
    {
        for (int i = 0; i < 9; i++)
        {
            ValueList[i] = 0;
        }
    }
    public void printFlower()
    {
    // используется в DEBUG_MODE
        Debug.Log("Flower :" + string.Join(", ", ValueList));
        Debug.Log("Flower :" + ValueList[0].ToString()+ValueList[1].ToString()+ValueList[2].ToString()+ValueList[3].ToString()+ValueList[4].ToString()+ValueList[5].ToString()+ValueList[6].ToString()+ValueList[7].ToString()+ValueList[8].ToString());

    }

    // public void SetRandomFlower()
    // {
    //     int key = Random.Range(1, 10); // Генерируем случайный ключ от 1 до 9
    //     List<int> randomSequence = GenerateRandomSequence(key);
    //     #if (DEBUG_MODE) 
    //     Debug.Log("Random Sequence with Key " + key + ": " + string.Join(", ", randomSequence));
    //     #endif
    //     ValueList = randomSequence;
    //     //value = ValueList[0];
    // }
    public void SetRandomFlowerByKey(int key)
    {
        List<int> randomSequence = GenerateRandomSequence(key);
        #if (DEBUG_MODE) 
        Debug.Log("Random Sequence with Key " + key + ": " + string.Join(", ", randomSequence));
        #endif
        ValueList = randomSequence;
        //value = ValueList[0];
    }
    public Flower()
    {
        ValueList = new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0};
#if (DEBUG_MODE) 
Debug.Log($"created flower with value {ValueList[0]}");
#endif
    }
}

public struct GameData
{
    public int Money, Seeds1, Seeds2, Seeds3, Seeds4, Seeds5, SellShelfPrice;
    public int[] ArrayGrowShelfs, ArraySellShelfs, ArrayPlantFlowers, ArrayBuyedItems;
    public List<System.String> ListDateTimeString;
    public List<int> ListGrowFlowers1, ListGrowFlowers2, ListGrowFlowers3, ListGrowFlowers4, ListGrowFlowers5, ListGrowFlowers6, ListGrowFlowers7, ListGrowFlowers8, ListGrowFlowers9;
    public List<int> ListSellFlowers1, ListSellFlowers2, ListSellFlowers3, ListSellFlowers4, ListSellFlowers5, ListSellFlowers6, ListSellFlowers7, ListSellFlowers8, ListSellFlowers9;
}

public class SaveManager
{
    private const string dataKey = "GameData";

    public void ClearGameData()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SaveGameData(GameData _gameData)
    {
        string json = JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString(dataKey, json);
        PlayerPrefs.Save();
#if (DEBUG_MODE) 
Debug.Log("Game Data saved");
Debug.Log(json);
#endif
    }
    public GameData LoadGameData()
    {
        string json = PlayerPrefs.GetString(dataKey, "");
#if (DEBUG_MODE) 
Debug.Log("Game Data Loaded");
Debug.Log(json);
#endif
        if (!string.IsNullOrEmpty(json))
        {
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
#if (DEBUG_MODE) 
Debug.Log("Game Data IsNullOrEmpty");
#endif
            return new GameData();
        }
    }
}

public struct GrowShelfObject
{
    public GameObject FlowerObject, FlowerImageObject;
    public GameObject FlowerButtonObject;
    public GameObject PriceObject, PriceTextObject, PriceImageObject;
    public Text PriceTextObjectValue, GrowShelfTimeObjectTextValue, Affinity1TextValue, Affinity2TextValue, Affinity3TextValue, Affinity4TextValue, Affinity6TextValue, Affinity7TextValue, Affinity8TextValue, Affinity9TextValue;
    public GameObject GrowShelfTimeObject;       // отличие от SellShelf
    public GameObject Affinity;
    public GameObject Affinity1, Affinity1Text, Affinity1Image;
    public GameObject Affinity2, Affinity2Text, Affinity2Image;
    public GameObject Affinity3, Affinity3Text, Affinity3Image;
    public GameObject Affinity4, Affinity4Text, Affinity4Image;
    public GameObject Affinity6, Affinity6Text, Affinity6Image;
    public GameObject Affinity7, Affinity7Text, Affinity7Image;
    public GameObject Affinity8, Affinity8Text, Affinity8Image;
    public GameObject Affinity9, Affinity9Text, Affinity9Image;
    //public GameObject ImageShelfObject; // в данной версии не используется
}

public struct GrowSelectedFlowerObject
{
    public GameObject FlowerObject, FlowerImageObject;
    public GameObject PriceObject, PriceTextObject, PriceImageObject;
    public Text PriceTextObjectValue, SellShelfPriceTextValue, SellShelfBonusTextValue, Affinity1TextValue, Affinity2TextValue, Affinity3TextValue, Affinity4TextValue, Affinity6TextValue, Affinity7TextValue, Affinity8TextValue, Affinity9TextValue;
    public GameObject Affinity;
    public GameObject Affinity1, Affinity1Text, Affinity1Image;
    public GameObject Affinity2, Affinity2Text, Affinity2Image;
    public GameObject Affinity3, Affinity3Text, Affinity3Image;
    public GameObject Affinity4, Affinity4Text, Affinity4Image;
    public GameObject Affinity6, Affinity6Text, Affinity6Image;
    public GameObject Affinity7, Affinity7Text, Affinity7Image;
    public GameObject Affinity8, Affinity8Text, Affinity8Image;
    public GameObject Affinity9, Affinity9Text, Affinity9Image;
}

public struct SellShelfObject
{ 
    public GameObject FlowerObject, FlowerImageObject;
    public GameObject FlowerButtonObject;
    public GameObject PriceObject, PriceTextObject, PriceImageObject;
    public Text PriceTextObjectValue, Affinity1TextValue, Affinity2TextValue, Affinity3TextValue, Affinity4TextValue, Affinity6TextValue, Affinity7TextValue, Affinity8TextValue, Affinity9TextValue;
    public Text SellShelfPriceTextValue, SellShelfBonusTextValue;           // отличие от GrowShelf
    public GameObject SellShelfPriceObject, SellShelfPriceText;             // отличие от GrowShelf
    public GameObject SellShelfBonusObject, SellShelfBonusText;             // отличие от GrowShelf
    public GameObject Affinity;
    public GameObject Affinity1, Affinity1Text, Affinity1Image;
    public GameObject Affinity2, Affinity2Text, Affinity2Image;
    public GameObject Affinity3, Affinity3Text, Affinity3Image;
    public GameObject Affinity4, Affinity4Text, Affinity4Image;
    public GameObject Affinity6, Affinity6Text, Affinity6Image;
    public GameObject Affinity7, Affinity7Text, Affinity7Image;
    public GameObject Affinity8, Affinity8Text, Affinity8Image;
    public GameObject Affinity9, Affinity9Text, Affinity9Image;
    public GameObject ImageShelfObject;
}

public struct SellSelectedFlowerObject
{
    public GameObject FlowerObject, FlowerImageObject;
    public GameObject PriceObject, PriceTextObject, PriceImageObject;
    public Text PriceTextObjectValue, Affinity1TextValue, Affinity2TextValue, Affinity3TextValue, Affinity4TextValue, Affinity6TextValue, Affinity7TextValue, Affinity8TextValue, Affinity9TextValue;
    public GameObject Affinity;
    public GameObject Affinity1, Affinity1Text, Affinity1Image;
    public GameObject Affinity2, Affinity2Text, Affinity2Image;
    public GameObject Affinity3, Affinity3Text, Affinity3Image;
    public GameObject Affinity4, Affinity4Text, Affinity4Image;
    public GameObject Affinity6, Affinity6Text, Affinity6Image;
    public GameObject Affinity7, Affinity7Text, Affinity7Image;
    public GameObject Affinity8, Affinity8Text, Affinity8Image;
    public GameObject Affinity9, Affinity9Text, Affinity9Image;
}

public struct BalanseObject 
{
    public GameObject  BalanseImage, BalanseText;
    public Text BalanseTextValue;
}

public struct SeedsObject 
{
    public Text seeds1TextValue, seeds2TextValue, seeds3TextValue, seeds4TextValue, seeds5TextValue;
}

public class MainScript : MonoBehaviour
{
    [HideInInspector]public int[] GrowingFlowersArray = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    [SerializeField] public double TimeToGrowMultiplier = 1.0f;
    public List<System.DateTime> GrowingFlowersDateTimeList = new List<System.DateTime>();

    private GameData MyGameData; 
    [SerializeField] private int balanseInt = 0;  // # переинициализируется дальше в коде (Reset())
    [SerializeField] private int Seeds1 = 20, Seeds2 = 0, Seeds3 = 0, Seeds4 = 0, Seeds5 = 0; // # переинициализируется дальше в коде (Reset())
    private int[] GrowShelfsArray; // = new int[10] {0, 0, 0, 0, 1, 1, 1, 0, 0, 0}; # инициализируется дальше в коде (Reset())
    private int[] SellShelfsArray; // = new int[10] {0, 0, 0, 0, 1, 1, 1, 0, 0, 0}; # инициализируется дальше в коде (Reset())
    [SerializeField] private int[] BuyedItemsArray; // = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; # инициализируется дальше в коде (Reset())
    private int[] ItemsCostArray; // = new int[10] {0, 10, 100, 1, 3, 0, 0, 100, 400, 0}; # инициализируется дальше в коде (Reset())
    private const double MINUTES_TO_GROW = 5f;
    private System.DateTime dateTime;
    private bool isToSell = false;
    private bool isToPlant = false;
    private bool isToBuy = false;
    private bool isToBuyFlower = false;
    private bool isToGrow = false;
    private int boughtFlowerNumber = 0;
    System.Random rand = new System.Random();
    [SerializeField] private List<Sprite> SpriteFlowerList0; // Список спрайтов, из которых будет выбираться новый спрайт
    [SerializeField] private List<Sprite> SpriteFlowerList1, SpriteFlowerList2, SpriteFlowerList3, SpriteFlowerList4, SpriteFlowerList5, SpriteFlowerList6, SpriteFlowerList7, SpriteFlowerList8, SpriteFlowerList9;
    private List<List<Sprite>> spriteList2D = new List<List<Sprite>>();
    [SerializeField] private List<Sprite> SpriteCoinList;
    [SerializeField] private List<Sprite> SpriteBackgroundList;
    [SerializeField] private List<Sprite> SpriteShelfList;
    [SerializeField] private GameObject BalanseGameObject;
    [SerializeField] private GameObject SeedsGameObject;
    [SerializeField] private GameObject BackgroundGameObject, FrontGameObject;
    [SerializeField] private GameObject BackgroundGrow, GrowObject, GrowShelf1, GrowShelf2, GrowShelf3, GrowShelf4, GrowShelf5, GrowShelf6, GrowShelf7, GrowShelf8, GrowShelf9, GrowSelectedFlower, GrowSeeds;
    [SerializeField] private GameObject SellObject, SellShelf1, SellShelf2, SellShelf3, SellShelf4, SellShelf5, SellShelf6, SellShelf7, SellShelf8, SellShelf9, SellSelectedFlower, TotalSellValue; 
    [SerializeField] private GameObject ShopObject;
    [SerializeField] private GameObject MenuObject;
    [SerializeField] private List<AudioClip> SoundClipList;
    private GameObject SelectedObject;
    BalanseObject balanseObject;
    SeedsObject seedsObject;
    GrowShelfObject grow_shelf1Object, grow_shelf2Object, grow_shelf3Object, grow_shelf4Object, grow_shelf5Object, grow_shelf6Object, grow_shelf7Object, grow_shelf8Object, grow_shelf9Object; 
    GrowSelectedFlowerObject growSelectedFlowerObject;
    SellSelectedFlowerObject sellSelectedFlowerObject;
    SellShelfObject sell_shelf1Object, sell_shelf2Object, sell_shelf3Object, sell_shelf4Object, sell_shelf5Object, sell_shelf6Object, sell_shelf7Object, sell_shelf8Object, sell_shelf9Object;
    private AudioSource audioSource;
    private SaveManager saveManager = new SaveManager();

    public void UpdateGrowShelfObjectByFlower(GrowShelfObject _shelfObject, Flower _flowerObject)
    {        
        _shelfObject.PriceTextObjectValue.text = _flowerObject.ValueList[0].ToString();
        _shelfObject.Affinity1TextValue.text = _flowerObject.ValueList[1].ToString();
        _shelfObject.Affinity2TextValue.text = _flowerObject.ValueList[2].ToString();
        _shelfObject.Affinity3TextValue.text = _flowerObject.ValueList[3].ToString();
        _shelfObject.Affinity4TextValue.text = _flowerObject.ValueList[4].ToString();
        _shelfObject.Affinity6TextValue.text = _flowerObject.ValueList[5].ToString();
        _shelfObject.Affinity7TextValue.text = _flowerObject.ValueList[6].ToString();
        _shelfObject.Affinity8TextValue.text = _flowerObject.ValueList[7].ToString();
        _shelfObject.Affinity9TextValue.text = _flowerObject.ValueList[8].ToString();
        //определение отображаемого спрайта цветка по первым четырем цифрам / из количества добавленых спрайтов в список
        _shelfObject.FlowerImageObject.GetComponent<Image>().sprite = spriteList2D 
            [_flowerObject.ValueList[0]] 
            [(_flowerObject.ValueList[1] + _flowerObject.ValueList[2] + _flowerObject.ValueList[3] + _flowerObject.ValueList[4]) % (spriteList2D[_flowerObject.ValueList[0]].Count)];
        // если цветок еще не вырос то спрайт растущего цветка
        if (GrowingFlowersArray[_shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().number] == 1) 
        {
            _shelfObject.FlowerImageObject.GetComponent<Image>().sprite = SpriteFlowerList0[0];
        }
        if (_flowerObject.ValueList[0] == 0) {_shelfObject.FlowerImageObject.SetActive(false);} else {_shelfObject.FlowerImageObject.SetActive(true);}
    }
    public void UpdateSellShelfObjectByFlower(SellShelfObject _shelfObject, Flower _flowerObject)
    {        
        _shelfObject.PriceTextObjectValue.text = _flowerObject.ValueList[0].ToString();
        _shelfObject.Affinity1TextValue.text = _flowerObject.ValueList[1].ToString();
        _shelfObject.Affinity2TextValue.text = _flowerObject.ValueList[2].ToString();
        _shelfObject.Affinity3TextValue.text = _flowerObject.ValueList[3].ToString();
        _shelfObject.Affinity4TextValue.text = _flowerObject.ValueList[4].ToString();
        _shelfObject.Affinity6TextValue.text = _flowerObject.ValueList[5].ToString();
        _shelfObject.Affinity7TextValue.text = _flowerObject.ValueList[6].ToString();
        _shelfObject.Affinity8TextValue.text = _flowerObject.ValueList[7].ToString();
        _shelfObject.Affinity9TextValue.text = _flowerObject.ValueList[8].ToString();
        //определение отображаемого спрайта цветка по первым четырем цифрам / из количества добавленых спрайтов в список
        _shelfObject.FlowerImageObject.GetComponent<Image>().sprite = spriteList2D 
            [_flowerObject.ValueList[0]] 
            [(_flowerObject.ValueList[1] + _flowerObject.ValueList[2] + _flowerObject.ValueList[3] + _flowerObject.ValueList[4]) % (spriteList2D[_flowerObject.ValueList[0]].Count)];
        updateSellShelfSellPrice(_shelfObject);
        if (_flowerObject.ValueList[0] == 0) {_shelfObject.FlowerImageObject.SetActive(false);} else {_shelfObject.FlowerImageObject.SetActive(true);}
    }
    public void HideEmptyGrowColliders(bool _boolValue)
    {
        if (grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf1Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf2Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf3Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf4Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf5Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf6Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf7Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf8Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) grow_shelf9Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;  
    }
    public void HideEmptySellColliders(bool _boolValue)
    {
        if (sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf1Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf2Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf3Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf4Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf5Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf6Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf7Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf8Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        if (sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) sell_shelf9Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;  
    }
    public void TurnAllSellAffinityOn()
    {
        toggleAllSellAffinity(sell_shelf1Object, true);
        toggleAllSellAffinity(sell_shelf2Object, true);
        toggleAllSellAffinity(sell_shelf3Object, true);
        toggleAllSellAffinity(sell_shelf4Object, true);
        toggleAllSellAffinity(sell_shelf5Object, true);
        toggleAllSellAffinity(sell_shelf6Object, true);
        toggleAllSellAffinity(sell_shelf7Object, true);
        toggleAllSellAffinity(sell_shelf8Object, true);
        toggleAllSellAffinity(sell_shelf9Object, true);   
    }
    public void TurnAllSellAffinityOff()
    {
        toggleAllSellAffinity(sell_shelf1Object, false);
        toggleAllSellAffinity(sell_shelf2Object, false);
        toggleAllSellAffinity(sell_shelf3Object, false);
        toggleAllSellAffinity(sell_shelf4Object, false);
        toggleAllSellAffinity(sell_shelf5Object, false);
        toggleAllSellAffinity(sell_shelf6Object, false);
        toggleAllSellAffinity(sell_shelf7Object, false);
        toggleAllSellAffinity(sell_shelf8Object, false);
        toggleAllSellAffinity(sell_shelf9Object, false);
    }
    public void TurnAllBonusOn()
    {
        toggleBonus(sell_shelf1Object, true);
        toggleBonus(sell_shelf2Object, true);
        toggleBonus(sell_shelf3Object, true);
        toggleBonus(sell_shelf4Object, true);
        toggleBonus(sell_shelf5Object, true);
        toggleBonus(sell_shelf6Object, true);
        toggleBonus(sell_shelf7Object, true);
        toggleBonus(sell_shelf8Object, true);
        toggleBonus(sell_shelf9Object, true);
    }
    public void TurnAllBonusOff()
    {
        toggleBonus(sell_shelf1Object, false);
        toggleBonus(sell_shelf2Object, false);
        toggleBonus(sell_shelf3Object, false);
        toggleBonus(sell_shelf4Object, false);
        toggleBonus(sell_shelf5Object, false);
        toggleBonus(sell_shelf6Object, false);
        toggleBonus(sell_shelf7Object, false);
        toggleBonus(sell_shelf8Object, false);
        toggleBonus(sell_shelf9Object, false);
    }
    public void TurnAllSellOn()
    {
        toggleShelfSellValue(sell_shelf1Object, true);
        toggleShelfSellValue(sell_shelf2Object, true);
        toggleShelfSellValue(sell_shelf3Object, true);
        toggleShelfSellValue(sell_shelf4Object, true);
        toggleShelfSellValue(sell_shelf5Object, true);
        toggleShelfSellValue(sell_shelf6Object, true);
        toggleShelfSellValue(sell_shelf7Object, true);
        toggleShelfSellValue(sell_shelf8Object, true);
        toggleShelfSellValue(sell_shelf9Object, true);
    }
    public void TurnAllSellOff()
    {
        toggleShelfSellValue(sell_shelf1Object, false);
        toggleShelfSellValue(sell_shelf2Object, false);
        toggleShelfSellValue(sell_shelf3Object, false);
        toggleShelfSellValue(sell_shelf4Object, false);
        toggleShelfSellValue(sell_shelf5Object, false);
        toggleShelfSellValue(sell_shelf6Object, false);
        toggleShelfSellValue(sell_shelf7Object, false);
        toggleShelfSellValue(sell_shelf8Object, false);
        toggleShelfSellValue(sell_shelf9Object, false);
    }
    public void CalculateAllBonus()
    {
        int bonus = 0;
        //////////////////calculateBonus(sell_shelf1Object);
        if (sell_shelf1Object.Affinity6TextValue.text == sell_shelf2Object.PriceTextObjectValue.text) // 1 - 2 (6)
        {   bonus += int.Parse(sell_shelf2Object.PriceTextObjectValue.text);
            sell_shelf1Object.Affinity6Image.SetActive(true);}
        else {sell_shelf1Object.Affinity6Image.SetActive(false);}

        if (sell_shelf1Object.Affinity9TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 1 - 5 (9)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf1Object.Affinity9Image.SetActive(true);}
        else {sell_shelf1Object.Affinity9Image.SetActive(false);}

        if (sell_shelf1Object.Affinity8TextValue.text == sell_shelf4Object.PriceTextObjectValue.text) // 1 - 4 (8)
        {   bonus += int.Parse(sell_shelf4Object.PriceTextObjectValue.text);
            sell_shelf1Object.Affinity8Image.SetActive(true);}
        else {sell_shelf1Object.Affinity8Image.SetActive(false);}

        sell_shelf1Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf2Object);
        if (sell_shelf2Object.Affinity4TextValue.text == sell_shelf1Object.PriceTextObjectValue.text) // 2 - 1 (4)
        {   bonus += int.Parse(sell_shelf1Object.PriceTextObjectValue.text);
            sell_shelf2Object.Affinity4Image.SetActive(true);}
        else {sell_shelf2Object.Affinity4Image.SetActive(false);}

        if (sell_shelf2Object.Affinity6TextValue.text == sell_shelf3Object.PriceTextObjectValue.text) // 2 - 3 (6)
        {   bonus += int.Parse(sell_shelf3Object.PriceTextObjectValue.text);
            sell_shelf2Object.Affinity6Image.SetActive(true);}
        else {sell_shelf2Object.Affinity6Image.SetActive(false);}

        if (sell_shelf2Object.Affinity9TextValue.text == sell_shelf6Object.PriceTextObjectValue.text) // 2 - 6 (9)
        {   bonus += int.Parse(sell_shelf6Object.PriceTextObjectValue.text);
            sell_shelf2Object.Affinity9Image.SetActive(true);}
        else {sell_shelf2Object.Affinity9Image.SetActive(false);}        

        if (sell_shelf2Object.Affinity8TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 2 - 5 (8)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf2Object.Affinity8Image.SetActive(true);}
        else {sell_shelf2Object.Affinity8Image.SetActive(false);}      

        if (sell_shelf2Object.Affinity7TextValue.text == sell_shelf4Object.PriceTextObjectValue.text) // 2 - 4 (7)
        {   bonus += int.Parse(sell_shelf4Object.PriceTextObjectValue.text);
            sell_shelf2Object.Affinity7Image.SetActive(true);}
        else {sell_shelf2Object.Affinity7Image.SetActive(false);}    

        sell_shelf2Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf3Object);
        if (sell_shelf3Object.Affinity4TextValue.text == sell_shelf2Object.PriceTextObjectValue.text) // 3 - 2 (4)
        {   bonus += int.Parse(sell_shelf2Object.PriceTextObjectValue.text);
            sell_shelf3Object.Affinity4Image.SetActive(true);}
        else {sell_shelf3Object.Affinity4Image.SetActive(false);}

        if (sell_shelf3Object.Affinity8TextValue.text == sell_shelf6Object.PriceTextObjectValue.text) // 3 - 6 (8)
        {   bonus += int.Parse(sell_shelf6Object.PriceTextObjectValue.text);
            sell_shelf3Object.Affinity8Image.SetActive(true);}
        else {sell_shelf3Object.Affinity8Image.SetActive(false);}

        if (sell_shelf3Object.Affinity7TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 3 - 5 (7)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf3Object.Affinity7Image.SetActive(true);}
        else {sell_shelf3Object.Affinity7Image.SetActive(false);}

        sell_shelf3Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf4Object);
        if (sell_shelf4Object.Affinity2TextValue.text == sell_shelf1Object.PriceTextObjectValue.text) // 4 - 1 (2)
        {   bonus += int.Parse(sell_shelf1Object.PriceTextObjectValue.text);
            sell_shelf4Object.Affinity2Image.SetActive(true);}
        else {sell_shelf4Object.Affinity2Image.SetActive(false);}

        if (sell_shelf4Object.Affinity3TextValue.text == sell_shelf2Object.PriceTextObjectValue.text) // 4 - 2 (3)
        {   bonus += int.Parse(sell_shelf2Object.PriceTextObjectValue.text);
            sell_shelf4Object.Affinity3Image.SetActive(true);}
        else {sell_shelf4Object.Affinity3Image.SetActive(false);}

        if (sell_shelf4Object.Affinity6TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 4 - 5 (6)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf4Object.Affinity6Image.SetActive(true);}
        else {sell_shelf4Object.Affinity6Image.SetActive(false);}         

        if (sell_shelf4Object.Affinity9TextValue.text == sell_shelf8Object.PriceTextObjectValue.text) // 4 - 8 (9)
        {   bonus += int.Parse(sell_shelf8Object.PriceTextObjectValue.text);
            sell_shelf4Object.Affinity9Image.SetActive(true);}
        else {sell_shelf4Object.Affinity9Image.SetActive(false);}

        if (sell_shelf4Object.Affinity8TextValue.text == sell_shelf7Object.PriceTextObjectValue.text) // 4 - 7 (8)
        {   bonus += int.Parse(sell_shelf7Object.PriceTextObjectValue.text);
            sell_shelf4Object.Affinity8Image.SetActive(true);}
        else {sell_shelf4Object.Affinity8Image.SetActive(false);}

        sell_shelf4Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf5Object);
        if (sell_shelf5Object.Affinity1TextValue.text == sell_shelf1Object.PriceTextObjectValue.text) // 5 - 1 (1)
        {   bonus += int.Parse(sell_shelf1Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity1Image.SetActive(true);}
        else {sell_shelf5Object.Affinity1Image.SetActive(false);}

        if (sell_shelf5Object.Affinity2TextValue.text == sell_shelf2Object.PriceTextObjectValue.text) // 5 - 2 (2)
        {   bonus += int.Parse(sell_shelf2Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity2Image.SetActive(true);}
        else {sell_shelf5Object.Affinity2Image.SetActive(false);}

        if (sell_shelf5Object.Affinity3TextValue.text == sell_shelf3Object.PriceTextObjectValue.text) // 5 - 3 (3)
        {   bonus += int.Parse(sell_shelf3Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity3Image.SetActive(true);}
        else {sell_shelf5Object.Affinity3Image.SetActive(false);}

        if (sell_shelf5Object.Affinity4TextValue.text == sell_shelf4Object.PriceTextObjectValue.text) // 5 - 4 (4)
        {   bonus += int.Parse(sell_shelf4Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity4Image.SetActive(true);}
        else {sell_shelf5Object.Affinity4Image.SetActive(false);}

        if (sell_shelf5Object.Affinity6TextValue.text == sell_shelf6Object.PriceTextObjectValue.text) // 5 - 6 (6)
        {   bonus += int.Parse(sell_shelf6Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity6Image.SetActive(true);}
        else {sell_shelf5Object.Affinity6Image.SetActive(false);}

        if (sell_shelf5Object.Affinity7TextValue.text == sell_shelf7Object.PriceTextObjectValue.text) // 5 - 7 (7)
        {   bonus += int.Parse(sell_shelf7Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity7Image.SetActive(true);}
        else {sell_shelf5Object.Affinity7Image.SetActive(false);}

        if (sell_shelf5Object.Affinity8TextValue.text == sell_shelf8Object.PriceTextObjectValue.text) // 5 - 8 (8)
        {   bonus += int.Parse(sell_shelf8Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity8Image.SetActive(true);}
        else {sell_shelf5Object.Affinity8Image.SetActive(false);}

        if (sell_shelf5Object.Affinity9TextValue.text == sell_shelf9Object.PriceTextObjectValue.text) // 5 - 8 (8)
        {   bonus += int.Parse(sell_shelf9Object.PriceTextObjectValue.text);
            sell_shelf5Object.Affinity9Image.SetActive(true);}
        else {sell_shelf5Object.Affinity9Image.SetActive(false);}

        sell_shelf5Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf6Object);
        if (sell_shelf6Object.Affinity1TextValue.text == sell_shelf2Object.PriceTextObjectValue.text) // 6 - 2 (1)
        {   bonus += int.Parse(sell_shelf2Object.PriceTextObjectValue.text);
            sell_shelf6Object.Affinity1Image.SetActive(true);}
        else {sell_shelf6Object.Affinity1Image.SetActive(false);}

        if (sell_shelf6Object.Affinity2TextValue.text == sell_shelf3Object.PriceTextObjectValue.text) // 6 - 3 (2)
        {   bonus += int.Parse(sell_shelf3Object.PriceTextObjectValue.text);
            sell_shelf6Object.Affinity2Image.SetActive(true);}
        else {sell_shelf6Object.Affinity2Image.SetActive(false);}

        if (sell_shelf6Object.Affinity8TextValue.text == sell_shelf9Object.PriceTextObjectValue.text) // 6 - 9 (8)
        {   bonus += int.Parse(sell_shelf9Object.PriceTextObjectValue.text);
            sell_shelf6Object.Affinity8Image.SetActive(true);}
        else {sell_shelf6Object.Affinity8Image.SetActive(false);}

        if (sell_shelf6Object.Affinity7TextValue.text == sell_shelf8Object.PriceTextObjectValue.text) // 6 - 8 (7)
        {   bonus += int.Parse(sell_shelf8Object.PriceTextObjectValue.text);
            sell_shelf6Object.Affinity7Image.SetActive(true);}
        else {sell_shelf6Object.Affinity7Image.SetActive(false);}

        if (sell_shelf6Object.Affinity4TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 6 - 5 (4)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf6Object.Affinity4Image.SetActive(true);}
        else {sell_shelf6Object.Affinity4Image.SetActive(false);}

        sell_shelf6Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf7Object);
        if (sell_shelf7Object.Affinity2TextValue.text == sell_shelf4Object.PriceTextObjectValue.text) // 7 - 4 (2)
        {   bonus += int.Parse(sell_shelf4Object.PriceTextObjectValue.text);
            sell_shelf7Object.Affinity2Image.SetActive(true);}
        else {sell_shelf7Object.Affinity2Image.SetActive(false);}

        if (sell_shelf7Object.Affinity3TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 7 - 5 (3)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf7Object.Affinity3Image.SetActive(true);}
        else {sell_shelf7Object.Affinity3Image.SetActive(false);}

        if (sell_shelf7Object.Affinity6TextValue.text == sell_shelf8Object.PriceTextObjectValue.text) // 7 - 8 (6)
        {   bonus += int.Parse(sell_shelf8Object.PriceTextObjectValue.text);
            sell_shelf7Object.Affinity6Image.SetActive(true);}
        else {sell_shelf7Object.Affinity6Image.SetActive(false);}

        sell_shelf7Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf8Object);
        if (sell_shelf8Object.Affinity1TextValue.text == sell_shelf4Object.PriceTextObjectValue.text) // 8 - 4 (1)
        {   bonus += int.Parse(sell_shelf4Object.PriceTextObjectValue.text);
            sell_shelf8Object.Affinity1Image.SetActive(true);}
        else {sell_shelf8Object.Affinity1Image.SetActive(false);}

        if (sell_shelf8Object.Affinity2TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 8 - 5 (2)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf8Object.Affinity2Image.SetActive(true);}
        else {sell_shelf8Object.Affinity2Image.SetActive(false);}      

        if (sell_shelf8Object.Affinity3TextValue.text == sell_shelf6Object.PriceTextObjectValue.text) // 8 - 6 (3)
        {   bonus += int.Parse(sell_shelf6Object.PriceTextObjectValue.text);
            sell_shelf8Object.Affinity3Image.SetActive(true);}
        else {sell_shelf8Object.Affinity3Image.SetActive(false);}      

        if (sell_shelf8Object.Affinity4TextValue.text == sell_shelf7Object.PriceTextObjectValue.text) // 8 - 7 (4)
        {   bonus += int.Parse(sell_shelf7Object.PriceTextObjectValue.text);
            sell_shelf8Object.Affinity4Image.SetActive(true);}
        else {sell_shelf8Object.Affinity4Image.SetActive(false);}

        if (sell_shelf8Object.Affinity6TextValue.text == sell_shelf9Object.PriceTextObjectValue.text) // 8 - 9 (6)
        {   bonus += int.Parse(sell_shelf9Object.PriceTextObjectValue.text);
            sell_shelf8Object.Affinity6Image.SetActive(true);}
        else {sell_shelf8Object.Affinity6Image.SetActive(false);}

        sell_shelf8Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
        bonus = 0;
        //////////////////calculateBonus(sell_shelf9Object);
        if (sell_shelf9Object.Affinity1TextValue.text == sell_shelf5Object.PriceTextObjectValue.text) // 9 - 5 (1)
        {   bonus += int.Parse(sell_shelf5Object.PriceTextObjectValue.text);
            sell_shelf9Object.Affinity1Image.SetActive(true);}
        else {sell_shelf9Object.Affinity1Image.SetActive(false);}

        if (sell_shelf9Object.Affinity2TextValue.text == sell_shelf6Object.PriceTextObjectValue.text) // 9 - 6 (2)
        {   bonus += int.Parse(sell_shelf6Object.PriceTextObjectValue.text);
            sell_shelf9Object.Affinity2Image.SetActive(true);}
        else {sell_shelf9Object.Affinity2Image.SetActive(false);}

        if (sell_shelf9Object.Affinity4TextValue.text == sell_shelf8Object.PriceTextObjectValue.text) // 9 - 8 (4)
        {   bonus += int.Parse(sell_shelf8Object.PriceTextObjectValue.text);
            sell_shelf9Object.Affinity4Image.SetActive(true);}
        else {sell_shelf9Object.Affinity4Image.SetActive(false);}

        sell_shelf9Object.SellShelfBonusTextValue.text = "+" + bonus.ToString();
    }
    public void CalculateTotalSellValue()
    {   
        int totalBonus = 0;
        totalBonus += int.Parse(sell_shelf1Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf2Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf3Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf4Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf5Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf6Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf7Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf8Object.SellShelfBonusTextValue.text.Substring(1));
        totalBonus += int.Parse(sell_shelf9Object.SellShelfBonusTextValue.text.Substring(1));
        int totalSell = totalBonus;
        totalSell += int.Parse(sell_shelf1Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf2Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf3Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf4Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf5Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf6Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf7Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf8Object.SellShelfPriceTextValue.text);
        totalSell += int.Parse(sell_shelf9Object.SellShelfPriceTextValue.text);
        TotalSellValue.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>().text = totalSell.ToString();
        // Определение получаемых семян за продажу
        int Seeds = totalSell / 54;
        TotalSellValue.transform.Find("ImageSeed10").gameObject.SetActive(Seeds >= 4);
        TotalSellValue.transform.Find("ImageSeed9").gameObject.SetActive(Seeds >= 3);
        TotalSellValue.transform.Find("ImageSeed8").gameObject.SetActive(Seeds >= 2);
        TotalSellValue.transform.Find("ImageSeed7").gameObject.SetActive(Seeds >= 1);
        totalSell = totalSell % 54;
        Seeds = totalSell / 18;
        TotalSellValue.transform.Find("ImageSeed6").gameObject.SetActive(Seeds >= 2);
        TotalSellValue.transform.Find("ImageSeed5").gameObject.SetActive(Seeds >= 1);
        totalSell = totalSell % 18;
        Seeds = totalSell / 6;
        TotalSellValue.transform.Find("ImageSeed4").gameObject.SetActive(Seeds >= 2);
        TotalSellValue.transform.Find("ImageSeed3").gameObject.SetActive(Seeds >= 1);        
        totalSell = totalSell % 6;
        Seeds = totalSell / 2;
        TotalSellValue.transform.Find("ImageSeed2").gameObject.SetActive(Seeds >= 2);
        TotalSellValue.transform.Find("ImageSeed1").gameObject.SetActive(Seeds >= 1);   
    }
    public void PressedGrow()
    {
        if ((isToSell == false)&(isToGrow == false)&(isToPlant == false)&(isToBuy == false)&(isToBuyFlower == false))
        {
            if (GrowObject.activeSelf) 
            {
                GrowObject.SetActive(true);
                SellObject.SetActive(false);
                ShopObject.SetActive(false);
                MenuObject.SetActive(false);
            }
            else if (SellObject.activeSelf) 
            {
                GrowObject.SetActive(true);
                GrowObject.GetComponent<Animation>().Play("FromLeft");
                SellObject.GetComponent<Animation>().Play("ToRight");
            }
            else if (ShopObject.activeSelf) 
            {
                GrowObject.SetActive(true);
                GrowObject.GetComponent<Animation>().Play("FromLeft");
                ShopObject.GetComponent<Animation>().Play("ToRight");
            }
            else if (MenuObject.activeSelf) 
            {
                GrowObject.SetActive(true);
                GrowObject.GetComponent<Animation>().Play("FromLeft");
                MenuObject.GetComponent<Animation>().Play("ToRight");
            }
            else 
            {
                GrowObject.SetActive(true);
                SellObject.SetActive(false);
                ShopObject.SetActive(false);
                MenuObject.SetActive(false);
            }   
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
    }
    public void PressedSell()
    {
        if (isToPlant == true) PressedButtonBack();
        if ((isToSell == false) & (isToGrow == false) & (isToPlant == false) & (isToBuy == false) & (isToBuyFlower == false))
        {
            if (GrowObject.activeSelf) 
            {
                SellObject.SetActive(true);
                GrowObject.GetComponent<Animation>().Play("ToLeft");
                SellObject.GetComponent<Animation>().Play("FromRight");
            }
            else if (SellObject.activeSelf) 
            {
                GrowObject.SetActive(false);
                SellObject.SetActive(true);
                ShopObject.SetActive(false);
                MenuObject.SetActive(false);
            }
            else if (ShopObject.activeSelf) 
            {
                SellObject.SetActive(true);
                SellObject.GetComponent<Animation>().Play("FromLeft");
                ShopObject.GetComponent<Animation>().Play("ToRight");
            }
            else if (MenuObject.activeSelf) 
            {
                SellObject.SetActive(true);
                SellObject.GetComponent<Animation>().Play("FromLeft");
                MenuObject.GetComponent<Animation>().Play("ToRight");
            }
            else 
            {
                GrowObject.SetActive(false);
                SellObject.SetActive(true);
                ShopObject.SetActive(false);
                MenuObject.SetActive(false);
            }

            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
    }
    public void PressedShop()
    {
        if (isToPlant == true) PressedButtonBack();
        if ((isToSell == false) & (isToGrow == false) & (isToPlant == false) & (isToBuy == false) & (isToBuyFlower == false))
        {
            if (GrowObject.activeSelf) 
            {
                ShopObject.SetActive(true);
                GrowObject.GetComponent<Animation>().Play("ToLeft");
                SellObject.GetComponent<Animation>().Play("FromRight");
            }
            else if (SellObject.activeSelf) 
            {
                ShopObject.SetActive(true);
                SellObject.GetComponent<Animation>().Play("ToLeft");
                ShopObject.GetComponent<Animation>().Play("FromRight");
            }
            else if (ShopObject.activeSelf) 
            {
                GrowObject.SetActive(false);
                SellObject.SetActive(false);
                ShopObject.SetActive(true);
                MenuObject.SetActive(false);
            }
            else if (MenuObject.activeSelf) 
            {
                ShopObject.SetActive(true);
                ShopObject.GetComponent<Animation>().Play("FromLeft");
                MenuObject.GetComponent<Animation>().Play("ToRight");
            }
            else 
            {
                GrowObject.SetActive(false);
                SellObject.SetActive(false);
                ShopObject.SetActive(true);
                MenuObject.SetActive(false);
            }
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
    }
    public void PressedMenu()
    {
        if (isToPlant == true) PressedButtonBack();
        if ((isToSell == false) & (isToGrow == false) & (isToPlant == false) & (isToBuy == false) & (isToBuyFlower == false))
        {
            if (GrowObject.activeSelf) 
            {
                MenuObject.SetActive(true);
                GrowObject.GetComponent<Animation>().Play("ToLeft");
                MenuObject.GetComponent<Animation>().Play("FromRight");
            }
            else if (SellObject.activeSelf) 
            {
                MenuObject.SetActive(true);
                SellObject.GetComponent<Animation>().Play("ToLeft");
                MenuObject.GetComponent<Animation>().Play("FromRight");
            }
            else if (ShopObject.activeSelf) 
            {
                MenuObject.SetActive(true);
                ShopObject.GetComponent<Animation>().Play("ToLeft");
                MenuObject.GetComponent<Animation>().Play("FromRight");
            }
            else if (MenuObject.activeSelf) 
            {
                GrowObject.SetActive(false);
                SellObject.SetActive(false);
                ShopObject.SetActive(false);
                MenuObject.SetActive(true);
            }
            else 
            {
                GrowObject.SetActive(false);
                SellObject.SetActive(false);
                ShopObject.SetActive(false);
                MenuObject.SetActive(true);
            }
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.white;
        }
    }
    public void PressedButtonSellShelf(int _number)
    {
        balanseInt -= ItemsCostArray[4];
        ItemsCostArray[4] *= 2;
        SellShelfsArray[_number] = 1;
        BuyedItemsArray[4] += 1;
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.SetActive(false);
        updateAllShelf(); 
        toggleAllSellColliders(true);
        isToBuy = false;
        BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.white;
        BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.SetActive(false);
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
        updateShop();
    }
    public void BuyItem(int _number)
    {
#if (DEBUG_MODE) 
Debug.Log($"Buy item number {_number}");
#endif
        if (balanseInt >= ItemsCostArray[_number])
        {
            balanseInt -= ItemsCostArray[_number];
            if (_number == 1)
            {
                GrowShelfsArray[7] = 1;
                GrowShelfsArray[8] = 1;
                GrowShelfsArray[9] = 1;
                BuyedItemsArray[_number] = 1;
            }
            if (_number == 2)
            {
                GrowShelfsArray[1] = 1;
                GrowShelfsArray[2] = 1;
                GrowShelfsArray[3] = 1;
                BuyedItemsArray[_number] = 1;
            }
            if (_number == 3) 
            {
#if (DEBUG_MODE) 
Debug.Log($"BuySeed1");
#endif
            Seeds1 += 1;
            }
            if (_number == 4) buySellShelf();
            if (_number == 7) BuyedItemsArray[_number] = 1;
            if (_number == 8) BuyedItemsArray[_number] = 1;
        }
        updateShop();
        updateBalanse();
    }
    public void BuyFlower(int _number)
    {
#if (DEBUG_MODE) 
Debug.Log($"Buy flower number {_number}");
#endif
        if (balanseInt >= 2)
        {
            isToBuyFlower = true;
            boughtFlowerNumber = _number;
            ShopObject.SetActive(false);
            GrowObject.SetActive(true);
            updateAllShelf();
            toggleAllGrowColliders(false);
            toggleAllGrowButtons(true);
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.yellow;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(false);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(false);
        }
    }
    public static void PressedExit()
    {
        // Завершаем приложение
        Application.Quit();
    }
    public void PressedSellFlowers()
    {
        CalculateTotalSellValue();
        int sellValue = int.Parse(TotalSellValue.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>().text);

        if (sellValue != 0) 
        {
            playAudioClip(SoundClipList[0]);
            if (balanseInt == 0) showTip();
        }

        balanseInt += sellValue;
        Seeds5 += sellValue / 54;
        sellValue = sellValue % 54;
        Seeds4 += sellValue / 18;
        sellValue = sellValue % 18;
        Seeds3 += sellValue / 6;
        sellValue = sellValue % 6;
        Seeds2 += sellValue / 2;
        
        sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();

        updateBalanse();
        updateSeeds();
        updateAllShelf();
        CalculateTotalSellValue();
    }
    public void PressedReset()
    {
        resetDataToDefaults();
        saveManager.ClearGameData();
        updateBalanse();
        updateSeeds();
        updateAllShelf();
        updateShop();
        CalculateTotalSellValue();
    }
    public void SelectSeed1()
    {
         if (Seeds1 > 0) 
        {
            Seeds1 -= 1;
            SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetRandomFlowerByKey(1);
            GrowingFlowersArray[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = 1;
            GrowingFlowersDateTimeList[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = System.DateTime.Now.AddMinutes(getTimeToGrow());
            GrowSeeds.SetActive(false);
            toggleAllGrowColliders(true);
            toggleAllGrowButtons(false);
            updateAllShelf();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            isToPlant = false;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            bool CheckFull = true;
            if (GrowShelfsArray[1] == 1) CheckFull = CheckFull & (grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[2] == 1) CheckFull = CheckFull & (grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[3] == 1) CheckFull = CheckFull & (grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[4] == 1) CheckFull = CheckFull & (grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[5] == 1) CheckFull = CheckFull & (grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[6] == 1) CheckFull = CheckFull & (grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[7] == 1) CheckFull = CheckFull & (grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[8] == 1) CheckFull = CheckFull & (grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[9] == 1) CheckFull = CheckFull & (grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (CheckFull) PressedButtonBack(); else PressedButtonPlantSeed();
        }
    }
    public void SelectSeed2()
    {   
        if (Seeds2 > 0) 
        {
            Seeds2 -= 1;
            SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetRandomFlowerByKey(rand.Next(2, 4));
            GrowingFlowersArray[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = 1;
            GrowingFlowersDateTimeList[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = System.DateTime.Now.AddMinutes(getTimeToGrow());
            GrowSeeds.SetActive(false);
            toggleAllGrowColliders(true);
            updateAllShelf();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            isToPlant = false;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            PressedButtonPlantSeed();
            bool CheckFull = true;
            if (GrowShelfsArray[1] == 1) CheckFull = CheckFull & (grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[2] == 1) CheckFull = CheckFull & (grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[3] == 1) CheckFull = CheckFull & (grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[4] == 1) CheckFull = CheckFull & (grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[5] == 1) CheckFull = CheckFull & (grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[6] == 1) CheckFull = CheckFull & (grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[7] == 1) CheckFull = CheckFull & (grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[8] == 1) CheckFull = CheckFull & (grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[9] == 1) CheckFull = CheckFull & (grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (CheckFull) PressedButtonBack(); else PressedButtonPlantSeed();
        }
    }
    public void SelectSeed3()
    {
        if (Seeds3 > 0) 
        {
        Seeds3 -= 1;
        SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetRandomFlowerByKey(rand.Next(4,6));
        GrowingFlowersArray[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = 1;
        GrowingFlowersDateTimeList[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = System.DateTime.Now.AddMinutes(getTimeToGrow());
        GrowSeeds.SetActive(false);
        toggleAllGrowColliders(true);
        updateAllShelf();
        BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
        BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        isToPlant = false;
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
        PressedButtonPlantSeed();
        bool CheckFull = true;
        if (GrowShelfsArray[1] == 1) CheckFull = CheckFull & (grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[2] == 1) CheckFull = CheckFull & (grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[3] == 1) CheckFull = CheckFull & (grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[4] == 1) CheckFull = CheckFull & (grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[5] == 1) CheckFull = CheckFull & (grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[6] == 1) CheckFull = CheckFull & (grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[7] == 1) CheckFull = CheckFull & (grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[8] == 1) CheckFull = CheckFull & (grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (GrowShelfsArray[9] == 1) CheckFull = CheckFull & (grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
        if (CheckFull) PressedButtonBack(); else PressedButtonPlantSeed();
        }
    }
    public void SelectSeed4()
    {
        if (Seeds4 > 0) 
        {
            Seeds4 -= 1;
            SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetRandomFlowerByKey(rand.Next(6,8));
            GrowingFlowersArray[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = 1;
            GrowingFlowersDateTimeList[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = System.DateTime.Now.AddMinutes(getTimeToGrow());
            GrowSeeds.SetActive(false);
            toggleAllGrowColliders(true);
            updateAllShelf();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            isToPlant = false;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            PressedButtonPlantSeed();
            bool CheckFull = true;
            if (GrowShelfsArray[1] == 1) CheckFull = CheckFull & (grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[2] == 1) CheckFull = CheckFull & (grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[3] == 1) CheckFull = CheckFull & (grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[4] == 1) CheckFull = CheckFull & (grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[5] == 1) CheckFull = CheckFull & (grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[6] == 1) CheckFull = CheckFull & (grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[7] == 1) CheckFull = CheckFull & (grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[8] == 1) CheckFull = CheckFull & (grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[9] == 1) CheckFull = CheckFull & (grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (CheckFull) PressedButtonBack(); else PressedButtonPlantSeed();
        }
    }
    public void SelectSeed5()
    {
        if (Seeds5 > 0) 
        {
            Seeds5 -= 1;
            SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetRandomFlowerByKey(rand.Next(8,10));
            GrowingFlowersArray[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = 1;
            GrowingFlowersDateTimeList[SelectedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().number] = System.DateTime.Now.AddMinutes(getTimeToGrow());
            GrowSeeds.SetActive(false);
            toggleAllGrowColliders(true);
            updateAllShelf();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            isToPlant = false;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            PressedButtonPlantSeed();
            bool CheckFull = true;
            if (GrowShelfsArray[1] == 1) CheckFull = CheckFull & (grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[2] == 1) CheckFull = CheckFull & (grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[3] == 1) CheckFull = CheckFull & (grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[4] == 1) CheckFull = CheckFull & (grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[5] == 1) CheckFull = CheckFull & (grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[6] == 1) CheckFull = CheckFull & (grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[7] == 1) CheckFull = CheckFull & (grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[8] == 1) CheckFull = CheckFull & (grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (GrowShelfsArray[9] == 1) CheckFull = CheckFull & (grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0);
            if (CheckFull) PressedButtonBack(); else PressedButtonPlantSeed();
        }
    }
    public void SelectSeedClose()
    {
        GrowSeeds.SetActive(false);
        toggleAllGrowColliders(true);
        updateAllShelf();
        BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
        BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        isToPlant = false;
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false); 
    }
    public void ButtonFlowerClicked(GameObject _clickedObject)
    {
        if (isToSell == true) 
        {
            _clickedObject.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = SelectedObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            SelectedObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
            GrowObject.SetActive(true);
            SellObject.SetActive(false);
            TotalSellValue.SetActive(true);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            toggleAllSellColliders(true);
            toggleAllSellButtons(false);
            toggleAllGrowColliders(true);
            GrowSelectedFlower.SetActive(false);
            isToSell = false;
            updateAllShelf();
            CalculateTotalSellValue();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
        }
        if (isToGrow == true) 
        {                                                                                                                                           //Sell
            _clickedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = SelectedObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList.ToList();
            SelectedObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
            SellObject.SetActive(true);
            GrowObject.SetActive(false);
            TotalSellValue.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
            toggleAllGrowColliders(true);
            toggleAllGrowButtons(false);
            toggleAllSellColliders(true);
            SellSelectedFlower.SetActive(false);
            isToGrow = false;
            updateAllShelf();
            CalculateTotalSellValue();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
        if (isToPlant == true)
        {
            toggleAllGrowButtons(false);
            SelectedObject = _clickedObject;
            if (((Seeds2+Seeds3+Seeds4+Seeds5)==0)&(Seeds1!=0))
            {
            SelectSeed1();
            }
            else
            {
            selectSeed();
            }
        }
        if (isToBuyFlower == true)
        {
            balanseInt -= 2;
            do
            {
                _clickedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetRandomFlowerByKey(1);
            } while ((_clickedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[1]
                    + _clickedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[2]
                    + _clickedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[3]
                    + _clickedObject.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[4]) % spriteList2D[1].Count != boughtFlowerNumber);
            toggleAllGrowColliders(true);
            toggleAllGrowButtons(false);
            toggleAllSellColliders(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            isToBuyFlower = false;
            updateAllShelf();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }

    }
    public void PressedButtonBack()
    {
        if (isToSell == true)
        {
            GrowObject.SetActive(true);
            SellObject.SetActive(false);
            TotalSellValue.SetActive(true);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            toggleAllSellColliders(true);
            toggleAllSellButtons(false);
            toggleAllGrowColliders(true);
            isToSell = false;
            updateAllShelf();
            CalculateTotalSellValue();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
        if (isToGrow == true)
        {
            GrowObject.SetActive(false);
            SellObject.SetActive(true);
            TotalSellValue.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            toggleAllGrowColliders(true);
            toggleAllGrowButtons(false);
            toggleAllSellColliders(true);
            isToGrow = false;
            updateAllShelf();
            CalculateTotalSellValue();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
        if (isToPlant == true)
        {
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            toggleAllGrowColliders(true);
            toggleAllGrowButtons(false);
            isToPlant = false;
            updateAllShelf();
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
        }
        if (isToBuy == true)
        {
            isToBuy = false;
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonShelf").gameObject.SetActive(false);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);            
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.SetActive(false);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            GrowObject.SetActive(false);
            SellObject.SetActive(false);
            ShopObject.SetActive(true);
            MenuObject.SetActive(false);
        }
        if (isToBuyFlower == true)
        {
            isToBuyFlower = false;
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.white;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            toggleAllGrowColliders(true);
            toggleAllGrowButtons(false);
            toggleAllSellColliders(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);           
            updateAllShelf();
        }
    }
    public void GrowFlowerClicked(GameObject _clickedObject)
    {
        if (_clickedObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] != 0)
        {
            SelectedObject = _clickedObject;
            growSelectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().FlowerData = _clickedObject.GetComponent<GrowFlowerComponent>().FlowerData;
            growSelectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().number = _clickedObject.GetComponent<GrowFlowerComponent>().number;
            GrowSelectedFlower.SetActive(true);
            if (GrowingFlowersArray[_clickedObject.GetComponent<GrowFlowerComponent>().number]!=1) GrowSelectedFlower.transform.Find("ButtonSell").gameObject.SetActive(true); else GrowSelectedFlower.transform.Find("ButtonSell").gameObject.SetActive(false);
#if (DEBUG_MODE) 
Debug.Log("####");
growSelectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().FlowerData.printFlower();
Debug.Log("++++");
_clickedObject.GetComponent<GrowFlowerComponent>().FlowerData.printFlower();
Debug.Log("====");
#endif
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(false);
            GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(false);
            updateGrowSelectedFlower();
            toggleAllGrowColliders(false);
        }

    }
    public void SellFlowerClicked(GameObject _clickedObject)
    {
        if (_clickedObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] != 0)
        {
            SelectedObject = _clickedObject;
            sellSelectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().FlowerData = _clickedObject.GetComponent<SellFlowerComponent>().FlowerData;
            sellSelectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().number = _clickedObject.GetComponent<SellFlowerComponent>().number;
            SellSelectedFlower.SetActive(true);
#if (DEBUG_MODE) 
Debug.Log("####");
sellSelectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().FlowerData.printFlower();
Debug.Log("++++");
_clickedObject.GetComponent<SellFlowerComponent>().FlowerData.printFlower();
Debug.Log("====");
#endif
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(false);
            updateSellSelectedFlower();
            toggleAllSellColliders(false);
        }

    }
    public void MoveFlowerToSell()
    {
        isToSell = true;
        toggleAllGrowColliders(true);
        GrowObject.SetActive(false);
        SellObject.SetActive(true);
        TotalSellValue.SetActive(true);
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(false);
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(true);
        toggleAllSellColliders(false);
        toggleAllSellButtons(true);
        BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.yellow;
        BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
    }
    public void MoveFlowerToGrow()
    {
        isToGrow = true;
        toggleAllSellColliders(true);
        SellObject.SetActive(false);
        GrowObject.SetActive(true);
        TotalSellValue.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(false);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(false);        
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(true);
        toggleAllGrowColliders(false);
        toggleAllGrowButtons(true);
        BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.yellow;
        BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
    }
    public void PressedButtonPlantSeed()
    {
        isToPlant = true;
        toggleAllGrowButtons(true);
        updateAllShelf();
        toggleAllGrowColliders(false);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(false);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(false);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(true);
        BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.yellow;
        BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
        BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
    }
    public void PressedBox()
    {
    if ((SellShelf1.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[1] == 1) & ( SellShelfsArray[1] == 1) & (GrowingFlowersArray[1] != 1))
        {
            SellShelf1.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf1.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf1.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf2.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[2] == 1) & ( SellShelfsArray[2] == 1) & (GrowingFlowersArray[2] != 1))
        {
            SellShelf2.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf2.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf2.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf3.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[3] == 1) & ( SellShelfsArray[3] == 1) & (GrowingFlowersArray[3] != 1))
        {
            SellShelf3.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf3.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf3.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf4.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[4] == 1) & ( SellShelfsArray[4] == 1) & (GrowingFlowersArray[4] != 1))
        {
            SellShelf4.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf4.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf4.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf5.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[5] == 1) & ( SellShelfsArray[5] == 1) & (GrowingFlowersArray[5] != 1))
        {
            SellShelf5.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf5.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf5.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf6.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[6] == 1) & ( SellShelfsArray[6] == 1) & (GrowingFlowersArray[6] != 1))
        {
            SellShelf6.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf6.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf6.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf7.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[7] == 1) & ( SellShelfsArray[7] == 1) & (GrowingFlowersArray[7] != 1))
        {
            SellShelf7.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf7.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf7.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf8.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[8] == 1) & ( SellShelfsArray[8] == 1) & (GrowingFlowersArray[8] != 1))
        {
            SellShelf8.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf8.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf8.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
    if ((SellShelf9.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) & ( GrowShelfsArray[9] == 1) & ( SellShelfsArray[9] == 1) & (GrowingFlowersArray[9] != 1))
        {
            SellShelf9.transform.Find("Flower").gameObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = GrowShelf9.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList.ToList();
            GrowShelf9.transform.Find("Flower").gameObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        }
        updateAllShelf();
        CalculateAllBonus();
        CalculateTotalSellValue();
        toggleAllGrowColliders(true);
        toggleAllSellColliders(true);
        HideEmptyGrowColliders(false);
        HideEmptySellColliders(false);
    }
    public void DeleteGrowFlower()
    {
        SelectedObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        GrowingFlowersArray[SelectedObject.GetComponent<GrowFlowerComponent>().number] = 0;
        GrowSelectedFlower.SetActive(false);
        toggleAllGrowColliders(true);
        updateAllShelf();
        checkGrow();
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
    }
    public void DeleteSellFlower()
    {
        SelectedObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        SellSelectedFlower.SetActive(false);
        toggleAllSellColliders(true);
        updateAllShelf();
        CalculateTotalSellValue();
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
    }
    public void SwipeRight()
    {
        if (SellObject.activeSelf) PressedGrow();
        if (ShopObject.activeSelf) PressedSell();
        if (MenuObject.activeSelf) PressedShop();
    }
    public void SwipeLeft()
    {
        if (ShopObject.activeSelf) PressedMenu();
        if (SellObject.activeSelf) PressedShop();
        if (GrowObject.activeSelf) PressedSell();
    }
    public void ShowInfo()
    {
        PressedGrow();
        FrontGameObject.transform.Find("Info").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(false);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(false);
    }
    public void CloseInfo()
    {
        FrontGameObject.transform.Find("Info").gameObject.SetActive(false);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonPlant").gameObject.SetActive(true);
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBox").gameObject.SetActive(true);
    }
    public void CloseTip()
    {
        FrontGameObject.transform.Find("Tip").gameObject.SetActive(false);
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
        PressedShop();
    }

    private BalanseObject createBalanseObject(GameObject _gameObject)
    {
        BalanseObject _newBalanseObject = new BalanseObject();
        _newBalanseObject.BalanseTextValue = _gameObject.transform.Find("Coin").gameObject.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>();
        return _newBalanseObject;
    }
    private SeedsObject createSeedsObject(GameObject _gameObject)
    {
        SeedsObject _newSeedsObject = new SeedsObject();
        _newSeedsObject.seeds2TextValue = _gameObject.transform.Find("Seed2").gameObject.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>();
        _newSeedsObject.seeds3TextValue = _gameObject.transform.Find("Seed3").gameObject.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>();
        _newSeedsObject.seeds4TextValue = _gameObject.transform.Find("Seed4").gameObject.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>();
        _newSeedsObject.seeds5TextValue = _gameObject.transform.Find("Seed5").gameObject.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>();
        return _newSeedsObject;
    } 
    private GrowShelfObject createGrowShelfObject(GameObject _gameObject)
    {   
        GrowShelfObject _newShelfObject = new GrowShelfObject();
        if (_gameObject != null)
        {
            //_newShelfObject.ImageShelfObject = _gameObject.transform.Find("ImageShelf").gameObject;

            _newShelfObject.GrowShelfTimeObject = _gameObject.transform.Find("Cooldown").gameObject;
            _newShelfObject.GrowShelfTimeObjectTextValue = _newShelfObject.GrowShelfTimeObject.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>();

            _newShelfObject.FlowerButtonObject = _gameObject.transform.Find("ButtonFlower").gameObject;

            _newShelfObject.FlowerObject = _gameObject.transform.Find("Flower").gameObject;
            _newShelfObject.FlowerImageObject = _newShelfObject.FlowerObject.transform.Find("ImageFlower").gameObject;

            _newShelfObject.PriceObject = _newShelfObject.FlowerObject.transform.Find("Price").gameObject;
            _newShelfObject.PriceTextObject = _newShelfObject.PriceObject.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.PriceImageObject = _newShelfObject.PriceObject.transform.Find("Image").gameObject;
            _newShelfObject.PriceTextObjectValue = _newShelfObject.PriceTextObject.GetComponent<Text>();
            _newShelfObject.PriceTextObjectValue.color = Color.black;

            _newShelfObject.Affinity = _newShelfObject.FlowerObject.transform.Find("Affinity").gameObject;

            _newShelfObject.Affinity1 = _newShelfObject.Affinity.transform.Find("Affinity1").gameObject;
            _newShelfObject.Affinity1Text = _newShelfObject.Affinity1.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity1Image = _newShelfObject.Affinity1.transform.Find("Image").gameObject;
            _newShelfObject.Affinity1TextValue = _newShelfObject.Affinity1Text.GetComponent<Text>();
          
            _newShelfObject.Affinity2 = _newShelfObject.Affinity.transform.Find("Affinity2").gameObject;
            _newShelfObject.Affinity2Text = _newShelfObject.Affinity2.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity2Image = _newShelfObject.Affinity2.transform.Find("Image").gameObject;
            _newShelfObject.Affinity2TextValue = _newShelfObject.Affinity2Text.GetComponent<Text>();

            _newShelfObject.Affinity3 = _newShelfObject.Affinity.transform.Find("Affinity3").gameObject;
            _newShelfObject.Affinity3Text = _newShelfObject.Affinity3.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity3Image = _newShelfObject.Affinity3.transform.Find("Image").gameObject;
            _newShelfObject.Affinity3TextValue = _newShelfObject.Affinity3Text.GetComponent<Text>();

            _newShelfObject.Affinity4 = _newShelfObject.Affinity.transform.Find("Affinity4").gameObject;
            _newShelfObject.Affinity4Text = _newShelfObject.Affinity4.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity4Image = _newShelfObject.Affinity4.transform.Find("Image").gameObject;
            _newShelfObject.Affinity4TextValue = _newShelfObject.Affinity4Text.GetComponent<Text>();

            _newShelfObject.Affinity6 = _newShelfObject.Affinity.transform.Find("Affinity6").gameObject;
            _newShelfObject.Affinity6Text = _newShelfObject.Affinity6.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity6Image = _newShelfObject.Affinity6.transform.Find("Image").gameObject;
            _newShelfObject.Affinity6TextValue = _newShelfObject.Affinity6Text.GetComponent<Text>();

            _newShelfObject.Affinity7 = _newShelfObject.Affinity.transform.Find("Affinity7").gameObject;
            _newShelfObject.Affinity7Text = _newShelfObject.Affinity7.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity7Image = _newShelfObject.Affinity7.transform.Find("Image").gameObject;
            _newShelfObject.Affinity7TextValue = _newShelfObject.Affinity7Text.GetComponent<Text>();

            _newShelfObject.Affinity8 = _newShelfObject.Affinity.transform.Find("Affinity8").gameObject;
            _newShelfObject.Affinity8Text = _newShelfObject.Affinity8.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity8Image = _newShelfObject.Affinity8.transform.Find("Image").gameObject;
            _newShelfObject.Affinity8TextValue = _newShelfObject.Affinity8Text.GetComponent<Text>();

            _newShelfObject.Affinity9 = _newShelfObject.Affinity.transform.Find("Affinity9").gameObject;
            _newShelfObject.Affinity9Text = _newShelfObject.Affinity9.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity9Image = _newShelfObject.Affinity9.transform.Find("Image").gameObject;
            _newShelfObject.Affinity9TextValue = _newShelfObject.Affinity9Text.GetComponent<Text>();
        }
        return  _newShelfObject;
    }
    private SellShelfObject createSellShelfObject(GameObject _gameObject)
    {   
        SellShelfObject _newShelfObject = new SellShelfObject();
        if (_gameObject != null)
        {
            _newShelfObject.ImageShelfObject = _gameObject.transform.Find("ImageShelf").gameObject;

            _newShelfObject.SellShelfPriceObject = _gameObject.transform.Find("ShelfSellValue").gameObject;
            _newShelfObject.SellShelfPriceText = _newShelfObject.SellShelfPriceObject.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.SellShelfPriceTextValue = _newShelfObject.SellShelfPriceText.GetComponent<Text>();

            _newShelfObject.SellShelfBonusObject = _gameObject.transform.Find("ShelfBonusValue").gameObject;                          //*** нет у GrowShelfObject
            _newShelfObject.SellShelfBonusText = _newShelfObject.SellShelfBonusObject.transform.Find("Text (Legacy)").gameObject;        //*** нет у GrowShelfObject
            _newShelfObject.SellShelfBonusTextValue = _newShelfObject.SellShelfBonusText.GetComponent<Text>();                     //*** нет у GrowShelfObject

            _newShelfObject.FlowerButtonObject = _gameObject.transform.Find("ButtonFlower").gameObject;

            _newShelfObject.FlowerObject = _gameObject.transform.Find("Flower").gameObject;
            _newShelfObject.FlowerImageObject = _newShelfObject.FlowerObject.transform.Find("ImageFlower").gameObject;

            _newShelfObject.PriceObject = _newShelfObject.FlowerObject.transform.Find("Price").gameObject;
            _newShelfObject.PriceTextObject = _newShelfObject.PriceObject.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.PriceImageObject = _newShelfObject.PriceObject.transform.Find("Image").gameObject;
            _newShelfObject.PriceTextObjectValue = _newShelfObject.PriceTextObject.GetComponent<Text>();
            _newShelfObject.PriceTextObjectValue.color = Color.black;

            _newShelfObject.Affinity = _newShelfObject.FlowerObject.transform.Find("Affinity").gameObject;

            _newShelfObject.Affinity1 = _newShelfObject.Affinity.transform.Find("Affinity1").gameObject;
            _newShelfObject.Affinity1Text = _newShelfObject.Affinity1.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity1Image = _newShelfObject.Affinity1.transform.Find("Image").gameObject;
            _newShelfObject.Affinity1TextValue = _newShelfObject.Affinity1Text.GetComponent<Text>();
          
            _newShelfObject.Affinity2 = _newShelfObject.Affinity.transform.Find("Affinity2").gameObject;
            _newShelfObject.Affinity2Text = _newShelfObject.Affinity2.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity2Image = _newShelfObject.Affinity2.transform.Find("Image").gameObject;
            _newShelfObject.Affinity2TextValue = _newShelfObject.Affinity2Text.GetComponent<Text>();

            _newShelfObject.Affinity3 = _newShelfObject.Affinity.transform.Find("Affinity3").gameObject;
            _newShelfObject.Affinity3Text = _newShelfObject.Affinity3.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity3Image = _newShelfObject.Affinity3.transform.Find("Image").gameObject;
            _newShelfObject.Affinity3TextValue = _newShelfObject.Affinity3Text.GetComponent<Text>();

            _newShelfObject.Affinity4 = _newShelfObject.Affinity.transform.Find("Affinity4").gameObject;
            _newShelfObject.Affinity4Text = _newShelfObject.Affinity4.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity4Image = _newShelfObject.Affinity4.transform.Find("Image").gameObject;
            _newShelfObject.Affinity4TextValue = _newShelfObject.Affinity4Text.GetComponent<Text>();

            _newShelfObject.Affinity6 = _newShelfObject.Affinity.transform.Find("Affinity6").gameObject;
            _newShelfObject.Affinity6Text = _newShelfObject.Affinity6.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity6Image = _newShelfObject.Affinity6.transform.Find("Image").gameObject;
            _newShelfObject.Affinity6TextValue = _newShelfObject.Affinity6Text.GetComponent<Text>();

            _newShelfObject.Affinity7 = _newShelfObject.Affinity.transform.Find("Affinity7").gameObject;
            _newShelfObject.Affinity7Text = _newShelfObject.Affinity7.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity7Image = _newShelfObject.Affinity7.transform.Find("Image").gameObject;
            _newShelfObject.Affinity7TextValue = _newShelfObject.Affinity7Text.GetComponent<Text>();

            _newShelfObject.Affinity8 = _newShelfObject.Affinity.transform.Find("Affinity8").gameObject;
            _newShelfObject.Affinity8Text = _newShelfObject.Affinity8.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity8Image = _newShelfObject.Affinity8.transform.Find("Image").gameObject;
            _newShelfObject.Affinity8TextValue = _newShelfObject.Affinity8Text.GetComponent<Text>();

            _newShelfObject.Affinity9 = _newShelfObject.Affinity.transform.Find("Affinity9").gameObject;
            _newShelfObject.Affinity9Text = _newShelfObject.Affinity9.transform.Find("Text (Legacy)").gameObject;
            _newShelfObject.Affinity9Image = _newShelfObject.Affinity9.transform.Find("Image").gameObject;
            _newShelfObject.Affinity9TextValue = _newShelfObject.Affinity9Text.GetComponent<Text>();
        }
        return  _newShelfObject;
    }
    private GrowSelectedFlowerObject createGrowSelectedFlowerObject(GameObject _gameObject)
    {
        GrowSelectedFlowerObject _newGrowSelectedFlowerObject = new GrowSelectedFlowerObject();
        if (_gameObject != null)
        {
            _newGrowSelectedFlowerObject.FlowerObject = _gameObject.transform.Find("Flower").gameObject;
            _newGrowSelectedFlowerObject.FlowerImageObject = _newGrowSelectedFlowerObject.FlowerObject.transform.Find("ImageFlower").gameObject;

            _newGrowSelectedFlowerObject.PriceObject = _newGrowSelectedFlowerObject.FlowerObject.transform.Find("Price").gameObject;
            _newGrowSelectedFlowerObject.PriceTextObject = _newGrowSelectedFlowerObject.PriceObject.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.PriceImageObject = _newGrowSelectedFlowerObject.PriceObject.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.PriceTextObjectValue = _newGrowSelectedFlowerObject.PriceTextObject.GetComponent<Text>();
            _newGrowSelectedFlowerObject.PriceTextObjectValue.color = Color.black;

            _newGrowSelectedFlowerObject.Affinity = _newGrowSelectedFlowerObject.FlowerObject.transform.Find("Affinity").gameObject;

            _newGrowSelectedFlowerObject.Affinity1 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity1").gameObject;
            _newGrowSelectedFlowerObject.Affinity1Text = _newGrowSelectedFlowerObject.Affinity1.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity1Image = _newGrowSelectedFlowerObject.Affinity1.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity1TextValue = _newGrowSelectedFlowerObject.Affinity1Text.GetComponent<Text>();
          
            _newGrowSelectedFlowerObject.Affinity2 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity2").gameObject;
            _newGrowSelectedFlowerObject.Affinity2Text = _newGrowSelectedFlowerObject.Affinity2.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity2Image = _newGrowSelectedFlowerObject.Affinity2.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity2TextValue = _newGrowSelectedFlowerObject.Affinity2Text.GetComponent<Text>();

            _newGrowSelectedFlowerObject.Affinity3 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity3").gameObject;
            _newGrowSelectedFlowerObject.Affinity3Text = _newGrowSelectedFlowerObject.Affinity3.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity3Image = _newGrowSelectedFlowerObject.Affinity3.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity3TextValue = _newGrowSelectedFlowerObject.Affinity3Text.GetComponent<Text>();

            _newGrowSelectedFlowerObject.Affinity4 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity4").gameObject;
            _newGrowSelectedFlowerObject.Affinity4Text = _newGrowSelectedFlowerObject.Affinity4.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity4Image = _newGrowSelectedFlowerObject.Affinity4.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity4TextValue = _newGrowSelectedFlowerObject.Affinity4Text.GetComponent<Text>();

            _newGrowSelectedFlowerObject.Affinity6 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity6").gameObject;
            _newGrowSelectedFlowerObject.Affinity6Text = _newGrowSelectedFlowerObject.Affinity6.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity6Image = _newGrowSelectedFlowerObject.Affinity6.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity6TextValue = _newGrowSelectedFlowerObject.Affinity6Text.GetComponent<Text>();

            _newGrowSelectedFlowerObject.Affinity7 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity7").gameObject;
            _newGrowSelectedFlowerObject.Affinity7Text = _newGrowSelectedFlowerObject.Affinity7.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity7Image = _newGrowSelectedFlowerObject.Affinity7.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity7TextValue = _newGrowSelectedFlowerObject.Affinity7Text.GetComponent<Text>();

            _newGrowSelectedFlowerObject.Affinity8 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity8").gameObject;
            _newGrowSelectedFlowerObject.Affinity8Text = _newGrowSelectedFlowerObject.Affinity8.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity8Image = _newGrowSelectedFlowerObject.Affinity8.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity8TextValue = _newGrowSelectedFlowerObject.Affinity8Text.GetComponent<Text>();

            _newGrowSelectedFlowerObject.Affinity9 = _newGrowSelectedFlowerObject.Affinity.transform.Find("Affinity9").gameObject;
            _newGrowSelectedFlowerObject.Affinity9Text = _newGrowSelectedFlowerObject.Affinity9.transform.Find("Text (Legacy)").gameObject;
            _newGrowSelectedFlowerObject.Affinity9Image = _newGrowSelectedFlowerObject.Affinity9.transform.Find("Image").gameObject;
            _newGrowSelectedFlowerObject.Affinity9TextValue = _newGrowSelectedFlowerObject.Affinity9Text.GetComponent<Text>();
        }
        return  _newGrowSelectedFlowerObject;
    }
    private SellSelectedFlowerObject createSellSelectedFlowerObject(GameObject _gameObject)
    {
        SellSelectedFlowerObject _newSellSelectedFlowerObject = new SellSelectedFlowerObject();
        if (_gameObject != null)
        {
            _newSellSelectedFlowerObject.FlowerObject = _gameObject.transform.Find("Flower").gameObject;
            _newSellSelectedFlowerObject.FlowerImageObject = _newSellSelectedFlowerObject.FlowerObject.transform.Find("ImageFlower").gameObject;

            _newSellSelectedFlowerObject.PriceObject = _newSellSelectedFlowerObject.FlowerObject.transform.Find("Price").gameObject;
            _newSellSelectedFlowerObject.PriceTextObject = _newSellSelectedFlowerObject.PriceObject.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.PriceImageObject = _newSellSelectedFlowerObject.PriceObject.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.PriceTextObjectValue = _newSellSelectedFlowerObject.PriceTextObject.GetComponent<Text>();
            _newSellSelectedFlowerObject.PriceTextObjectValue.color = Color.black;

            _newSellSelectedFlowerObject.Affinity = _newSellSelectedFlowerObject.FlowerObject.transform.Find("Affinity").gameObject;

            _newSellSelectedFlowerObject.Affinity1 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity1").gameObject;
            _newSellSelectedFlowerObject.Affinity1Text = _newSellSelectedFlowerObject.Affinity1.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity1Image = _newSellSelectedFlowerObject.Affinity1.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity1TextValue = _newSellSelectedFlowerObject.Affinity1Text.GetComponent<Text>();
          
            _newSellSelectedFlowerObject.Affinity2 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity2").gameObject;
            _newSellSelectedFlowerObject.Affinity2Text = _newSellSelectedFlowerObject.Affinity2.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity2Image = _newSellSelectedFlowerObject.Affinity2.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity2TextValue = _newSellSelectedFlowerObject.Affinity2Text.GetComponent<Text>();

            _newSellSelectedFlowerObject.Affinity3 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity3").gameObject;
            _newSellSelectedFlowerObject.Affinity3Text = _newSellSelectedFlowerObject.Affinity3.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity3Image = _newSellSelectedFlowerObject.Affinity3.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity3TextValue = _newSellSelectedFlowerObject.Affinity3Text.GetComponent<Text>();

            _newSellSelectedFlowerObject.Affinity4 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity4").gameObject;
            _newSellSelectedFlowerObject.Affinity4Text = _newSellSelectedFlowerObject.Affinity4.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity4Image = _newSellSelectedFlowerObject.Affinity4.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity4TextValue = _newSellSelectedFlowerObject.Affinity4Text.GetComponent<Text>();

            _newSellSelectedFlowerObject.Affinity6 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity6").gameObject;
            _newSellSelectedFlowerObject.Affinity6Text = _newSellSelectedFlowerObject.Affinity6.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity6Image = _newSellSelectedFlowerObject.Affinity6.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity6TextValue = _newSellSelectedFlowerObject.Affinity6Text.GetComponent<Text>();

            _newSellSelectedFlowerObject.Affinity7 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity7").gameObject;
            _newSellSelectedFlowerObject.Affinity7Text = _newSellSelectedFlowerObject.Affinity7.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity7Image = _newSellSelectedFlowerObject.Affinity7.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity7TextValue = _newSellSelectedFlowerObject.Affinity7Text.GetComponent<Text>();

            _newSellSelectedFlowerObject.Affinity8 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity8").gameObject;
            _newSellSelectedFlowerObject.Affinity8Text = _newSellSelectedFlowerObject.Affinity8.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity8Image = _newSellSelectedFlowerObject.Affinity8.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity8TextValue = _newSellSelectedFlowerObject.Affinity8Text.GetComponent<Text>();

            _newSellSelectedFlowerObject.Affinity9 = _newSellSelectedFlowerObject.Affinity.transform.Find("Affinity9").gameObject;
            _newSellSelectedFlowerObject.Affinity9Text = _newSellSelectedFlowerObject.Affinity9.transform.Find("Text (Legacy)").gameObject;
            _newSellSelectedFlowerObject.Affinity9Image = _newSellSelectedFlowerObject.Affinity9.transform.Find("Image").gameObject;
            _newSellSelectedFlowerObject.Affinity9TextValue = _newSellSelectedFlowerObject.Affinity9Text.GetComponent<Text>();
        }
        return _newSellSelectedFlowerObject;
    }
    private void initialise()
    {   
#if (DEBUG_MODE) 
Debug.Log("initialise");
#endif
        audioSource = GetComponent<AudioSource>();
                
        spriteList2D.Clear();

        spriteList2D.Add(SpriteFlowerList0);
        spriteList2D.Add(SpriteFlowerList1);
        spriteList2D.Add(SpriteFlowerList2);
        spriteList2D.Add(SpriteFlowerList3);
        spriteList2D.Add(SpriteFlowerList4);
        spriteList2D.Add(SpriteFlowerList5);
        spriteList2D.Add(SpriteFlowerList6);
        spriteList2D.Add(SpriteFlowerList7);
        spriteList2D.Add(SpriteFlowerList8);
        spriteList2D.Add(SpriteFlowerList9);

        GrowingFlowersDateTimeList.Clear();
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);
        GrowingFlowersDateTimeList.Add(System.DateTime.Now);

        updateBackgroundSprite();

        balanseObject = createBalanseObject(BalanseGameObject);
        seedsObject = createSeedsObject(SeedsGameObject);

        grow_shelf1Object = createGrowShelfObject(GrowShelf1);
        grow_shelf2Object = createGrowShelfObject(GrowShelf2);
        grow_shelf3Object = createGrowShelfObject(GrowShelf3);
        grow_shelf4Object = createGrowShelfObject(GrowShelf4);
        grow_shelf5Object = createGrowShelfObject(GrowShelf5);
        grow_shelf6Object = createGrowShelfObject(GrowShelf6);
        grow_shelf7Object = createGrowShelfObject(GrowShelf7);
        grow_shelf8Object = createGrowShelfObject(GrowShelf8);
        grow_shelf9Object = createGrowShelfObject(GrowShelf9);

        growSelectedFlowerObject = createGrowSelectedFlowerObject(GrowSelectedFlower);
        sellSelectedFlowerObject = createSellSelectedFlowerObject(SellSelectedFlower);

        GrowSelectedFlower.SetActive(false);
        SellSelectedFlower.SetActive(false);

        sell_shelf1Object = createSellShelfObject(SellShelf1);
        sell_shelf2Object = createSellShelfObject(SellShelf2);
        sell_shelf3Object = createSellShelfObject(SellShelf3);
        sell_shelf4Object = createSellShelfObject(SellShelf4);
        sell_shelf5Object = createSellShelfObject(SellShelf5);
        sell_shelf6Object = createSellShelfObject(SellShelf6);
        sell_shelf7Object = createSellShelfObject(SellShelf7);
        sell_shelf8Object = createSellShelfObject(SellShelf8);
        sell_shelf9Object = createSellShelfObject(SellShelf9);

        SellShelf1.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf2.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf3.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf4.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf5.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf6.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf7.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf8.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];
        SellShelf9.transform.Find("ImageShelf").gameObject.GetComponent<Image>().sprite = SpriteShelfList[0];

        setReadyGrowShelf(grow_shelf1Object, 1);
        setReadyGrowShelf(grow_shelf2Object, 2);
        setReadyGrowShelf(grow_shelf3Object, 3);
        setReadyGrowShelf(grow_shelf4Object, 4);
        setReadyGrowShelf(grow_shelf5Object, 5);
        setReadyGrowShelf(grow_shelf6Object, 6);
        setReadyGrowShelf(grow_shelf7Object, 7);
        setReadyGrowShelf(grow_shelf8Object, 8);
        setReadyGrowShelf(grow_shelf9Object, 9);

        setReadyGrowSelectedFlower(growSelectedFlowerObject);
        setReadySellSelectedFlower(sellSelectedFlowerObject);

        setReadySellShelf(sell_shelf1Object);
        setReadySellShelf(sell_shelf2Object);
        setReadySellShelf(sell_shelf3Object);
        setReadySellShelf(sell_shelf4Object);
        setReadySellShelf(sell_shelf5Object);
        setReadySellShelf(sell_shelf6Object);
        setReadySellShelf(sell_shelf7Object);
        setReadySellShelf(sell_shelf8Object);
        setReadySellShelf(sell_shelf9Object);

        setAllAffinityCoinsToDefault();
    }
    private void resetDataToDefaults()
    {
        balanseInt = 0;
        GrowShelfsArray = new int[10] {0, 0, 0, 0, 1, 1, 1, 0, 0, 0};
        SellShelfsArray = new int[10] {0, 0, 0, 0, 1, 1, 1, 0, 0, 0};
        BuyedItemsArray = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        ItemsCostArray = new int[10] {0, 10, 100, 1, 3, 0, 0, 100, 400, 0};
        ItemsCostArray[4] = ItemsCostArray[4];
        Seeds1 = 20;
        Seeds2 = Seeds3 = Seeds4 = Seeds5 = 0;
        grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();
        grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.SetNullFlower();

        sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
        sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();

        GrowingFlowersDateTimeList[1]= System.DateTime.Now;
        GrowingFlowersDateTimeList[2]= System.DateTime.Now;
        GrowingFlowersDateTimeList[3]= System.DateTime.Now;
        GrowingFlowersDateTimeList[4]= System.DateTime.Now;
        GrowingFlowersDateTimeList[5]= System.DateTime.Now;
        GrowingFlowersDateTimeList[6]= System.DateTime.Now;
        GrowingFlowersDateTimeList[7]= System.DateTime.Now;
        GrowingFlowersDateTimeList[8]= System.DateTime.Now;
        GrowingFlowersDateTimeList[9]= System.DateTime.Now;
    }
    private void setReadySellShelf(SellShelfObject _shelfObject)
    {
        _shelfObject.FlowerObject.AddComponent<SellFlowerComponent>();
        _shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData = new Flower();
        _shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().ShelfData = _shelfObject;
        UpdateSellShelfObjectByFlower(_shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().ShelfData,  _shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData);
        toggleAllSellAffinity(_shelfObject, false);
    }
    private void setReadyGrowShelf(GrowShelfObject _shelfObject, int _number)
    {
        _shelfObject.FlowerObject.AddComponent<GrowFlowerComponent>();
        _shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData = new Flower();
        _shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().ShelfData = _shelfObject;
        _shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().number = _number;
        UpdateGrowShelfObjectByFlower(_shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().ShelfData,  _shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData);
        toggleAllGrowAffinity(_shelfObject, false);
    }
    private void setReadyGrowSelectedFlower(GrowSelectedFlowerObject _selectedFlowerObject)
    {
        _selectedFlowerObject.FlowerObject.AddComponent<GrowSelectedFlowerComponent>();
        _selectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().FlowerData =  new Flower();
        _selectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().selectedFlowerData = _selectedFlowerObject;
        _selectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().FlowerData.SetNullFlower();
    } 
    private void setReadySellSelectedFlower(SellSelectedFlowerObject _selectedFlowerObject)
    {
        _selectedFlowerObject.FlowerObject.AddComponent<SellSelectedFlowerComponent>();
        _selectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().FlowerData =  new Flower();
        _selectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().selectedFlowerData = _selectedFlowerObject;
        _selectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().FlowerData.SetNullFlower();
    } 
    private void setAffinityCoins(SellShelfObject _shelfObject, Sprite _coinSprite)
    {
        _shelfObject.Affinity1Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity2Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity3Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity4Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity6Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity7Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity8Image.GetComponent<Image>().sprite = _coinSprite;
        _shelfObject.Affinity9Image.GetComponent<Image>().sprite = _coinSprite;
    }
    private void setAllAffinityCoinsToDefault()
    {
        setAffinityCoins(sell_shelf1Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf2Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf3Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf4Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf5Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf6Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf7Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf8Object, SpriteCoinList[0]);
        setAffinityCoins(sell_shelf9Object, SpriteCoinList[0]);
    }
    private void updateSellShelfSellPrice(SellShelfObject _shelfObject)
    {
        _shelfObject.SellShelfPriceTextValue.text = _shelfObject.PriceTextObjectValue.text;
    }
    private void updateGrowSelectedFlower()
    {       
        Flower FlowerObject = growSelectedFlowerObject.FlowerObject.GetComponent<GrowSelectedFlowerComponent>().FlowerData;
        growSelectedFlowerObject.PriceTextObjectValue.text = FlowerObject.ValueList[0].ToString();
        growSelectedFlowerObject.Affinity1TextValue.text = FlowerObject.ValueList[1].ToString();
        growSelectedFlowerObject.Affinity2TextValue.text = FlowerObject.ValueList[2].ToString();
        growSelectedFlowerObject.Affinity3TextValue.text = FlowerObject.ValueList[3].ToString();
        growSelectedFlowerObject.Affinity4TextValue.text = FlowerObject.ValueList[4].ToString();
        growSelectedFlowerObject.Affinity6TextValue.text = FlowerObject.ValueList[5].ToString();
        growSelectedFlowerObject.Affinity7TextValue.text = FlowerObject.ValueList[6].ToString();
        growSelectedFlowerObject.Affinity8TextValue.text = FlowerObject.ValueList[7].ToString();
        growSelectedFlowerObject.Affinity9TextValue.text = FlowerObject.ValueList[8].ToString();
        //определение отображаемого спрайта цветка по первым четырем цифрам / из количества добавленых спрайтов в список
        growSelectedFlowerObject.FlowerImageObject.GetComponent<Image>().sprite = spriteList2D 
            [FlowerObject.ValueList[0]] 
            [(FlowerObject.ValueList[1] + FlowerObject.ValueList[2] + FlowerObject.ValueList[3] + FlowerObject.ValueList[4]) % (spriteList2D[FlowerObject.ValueList[0]].Count)];
    }
    private void updateSellSelectedFlower()
    {                                                                     
        Flower FlowerObject = sellSelectedFlowerObject.FlowerObject.GetComponent<SellSelectedFlowerComponent>().FlowerData;
        sellSelectedFlowerObject.PriceTextObjectValue.text = FlowerObject.ValueList[0].ToString();
        sellSelectedFlowerObject.Affinity1TextValue.text = FlowerObject.ValueList[1].ToString();
        sellSelectedFlowerObject.Affinity2TextValue.text = FlowerObject.ValueList[2].ToString();
        sellSelectedFlowerObject.Affinity3TextValue.text = FlowerObject.ValueList[3].ToString();
        sellSelectedFlowerObject.Affinity4TextValue.text = FlowerObject.ValueList[4].ToString();
        sellSelectedFlowerObject.Affinity6TextValue.text = FlowerObject.ValueList[5].ToString();
        sellSelectedFlowerObject.Affinity7TextValue.text = FlowerObject.ValueList[6].ToString();
        sellSelectedFlowerObject.Affinity8TextValue.text = FlowerObject.ValueList[7].ToString();
        sellSelectedFlowerObject.Affinity9TextValue.text = FlowerObject.ValueList[8].ToString();
        //определение отображаемого спрайта цветка по первым четырем цифрам / из количества добавленых спрайтов в список
        sellSelectedFlowerObject.FlowerImageObject.GetComponent<Image>().sprite = spriteList2D 
            [FlowerObject.ValueList[0]] 
            [(FlowerObject.ValueList[1] + FlowerObject.ValueList[2] + FlowerObject.ValueList[3] + FlowerObject.ValueList[4]) % (spriteList2D[FlowerObject.ValueList[0]].Count)];
    }
    private void updateSellShelf(SellShelfObject _shelfObject)
    {
        UpdateSellShelfObjectByFlower(_shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().ShelfData,  _shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData);
        if (_shelfObject.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList[0] == 0) 
        {
            _shelfObject.FlowerImageObject.SetActive(false);
        } 
        else 
        {
            _shelfObject.FlowerImageObject.SetActive(true);
        }
    }
    private void updateGrowShelf(GrowShelfObject _shelfObject)
    {
        UpdateGrowShelfObjectByFlower(_shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().ShelfData, _shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData);
        if (_shelfObject.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList[0] == 0) 
        {
            _shelfObject.FlowerImageObject.SetActive(false);
        } 
        else 
        {
            _shelfObject.FlowerImageObject.SetActive(true);
        }
    }
    private void updateAllShelf()
    {
        GrowShelf1.SetActive(GrowShelfsArray[1] == 1);
        GrowShelf2.SetActive(GrowShelfsArray[2] == 1);
        GrowShelf3.SetActive(GrowShelfsArray[3] == 1);
        GrowShelf4.SetActive(GrowShelfsArray[4] == 1);
        GrowShelf5.SetActive(GrowShelfsArray[5] == 1);
        GrowShelf6.SetActive(GrowShelfsArray[6] == 1);
        GrowShelf7.SetActive(GrowShelfsArray[7] == 1);
        GrowShelf8.SetActive(GrowShelfsArray[8] == 1);
        GrowShelf9.SetActive(GrowShelfsArray[9] == 1);

        updateGrowShelf(grow_shelf1Object);
        updateGrowShelf(grow_shelf2Object);
        updateGrowShelf(grow_shelf3Object);
        updateGrowShelf(grow_shelf4Object);
        updateGrowShelf(grow_shelf5Object);
        updateGrowShelf(grow_shelf6Object);
        updateGrowShelf(grow_shelf7Object);
        updateGrowShelf(grow_shelf8Object);
        updateGrowShelf(grow_shelf9Object);
    
        SellShelf1.SetActive(SellShelfsArray[1] == 1);
        SellShelf2.SetActive(SellShelfsArray[2] == 1);
        SellShelf3.SetActive(SellShelfsArray[3] == 1);
        SellShelf4.SetActive(SellShelfsArray[4] == 1);
        SellShelf5.SetActive(SellShelfsArray[5] == 1);
        SellShelf6.SetActive(SellShelfsArray[6] == 1);
        SellShelf7.SetActive(SellShelfsArray[7] == 1);
        SellShelf8.SetActive(SellShelfsArray[8] == 1);
        SellShelf9.SetActive(SellShelfsArray[9] == 1);

        updateSellShelf(sell_shelf1Object);
        updateSellShelf(sell_shelf2Object);
        updateSellShelf(sell_shelf3Object);
        updateSellShelf(sell_shelf4Object);
        updateSellShelf(sell_shelf5Object);
        updateSellShelf(sell_shelf6Object);
        updateSellShelf(sell_shelf7Object);
        updateSellShelf(sell_shelf8Object);
        updateSellShelf(sell_shelf9Object);
    
        TurnAllSellAffinityOff();
        CalculateAllBonus();
        TurnAllBonusOn();
        TurnAllSellOn();
        updateBalanse();
        updateSeeds();

        HideEmptyGrowColliders(false);
        HideEmptySellColliders(false);
    }
    private void updateBalanse()
    {
        balanseObject.BalanseTextValue.text = balanseInt.ToString();
        MyGameData.Money = balanseInt;
    }
    private void updateSeeds()
    {
        seedsObject.seeds2TextValue.text = Seeds2.ToString();
        seedsObject.seeds3TextValue.text = Seeds3.ToString();
        seedsObject.seeds4TextValue.text = Seeds4.ToString();
        seedsObject.seeds5TextValue.text = Seeds5.ToString();

        MyGameData.Seeds1 = Seeds1;
        MyGameData.Seeds2 = Seeds2;
        MyGameData.Seeds3 = Seeds3;
        MyGameData.Seeds4 = Seeds4;
        MyGameData.Seeds5 = Seeds5;
    }
    private void updateShop()
    {
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("BackgroundGrow").gameObject.transform.Find("Layer1Image_1").gameObject.SetActive(BuyedItemsArray[1] == 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-1-1").gameObject.SetActive(BuyedItemsArray[1] != 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-1-1").gameObject.transform.Find("Price").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = ItemsCostArray[1].ToString();

        GrowObject.transform.Find("Canvas").gameObject.transform.Find("BackgroundGrow").gameObject.transform.Find("Layer1Image_2").gameObject.SetActive(BuyedItemsArray[2] == 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-2-1").gameObject.SetActive(BuyedItemsArray[2] != 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-2-1").gameObject.transform.Find("Price").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = ItemsCostArray[2].ToString();

        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-1-2").gameObject.SetActive(BuyedItemsArray[3] != 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-1-2").gameObject.transform.Find("Price").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = ItemsCostArray[3].ToString();
        
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-2-2").gameObject.SetActive(BuyedItemsArray[4] < 6);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-2-2").gameObject.transform.Find("Price").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = ItemsCostArray[4].ToString();
        
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("BackgroundGrow").gameObject.transform.Find("Plant2").gameObject.SetActive(BuyedItemsArray[7] == 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-1-4").gameObject.SetActive(BuyedItemsArray[7] != 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-1-4").gameObject.transform.Find("Price").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = ItemsCostArray[7].ToString();

        GrowObject.transform.Find("Canvas").gameObject.transform.Find("BackgroundGrow").gameObject.transform.Find("Plant1").gameObject.SetActive(BuyedItemsArray[8] == 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-2-4").gameObject.SetActive(BuyedItemsArray[8] != 1);
        ShopObject.transform.Find("Canvas").gameObject.transform.Find("Tab2").gameObject.transform.Find("Buy2-2-4").gameObject.transform.Find("Price").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = ItemsCostArray[8].ToString();
    }
    private void updateBackgroundSprite()
    {
        int currentHour = System.DateTime.Now.Hour;
        // Проверяем, находится ли время суток в диапазоне дня (6:00 - 18:00)
        if (currentHour >= 6 && currentHour < 18)
        {
            BackgroundGrow.transform.GetComponent<Image>().sprite = SpriteBackgroundList[1];
        } // Иначе находится ли время суток в диапазоне вечера (18:00 - 22:00)
        else if (currentHour >= 18 && currentHour < 22)
        {
            BackgroundGrow.transform.GetComponent<Image>().sprite = SpriteBackgroundList[3];
        }
        else // Иначе считаем, что наступила ночь
        {
            BackgroundGrow.transform.GetComponent<Image>().sprite = SpriteBackgroundList[2];
        }
        BackgroundGrow.transform.GetComponent<Image>().enabled = true;
    }
    private void toggleAllSellButtons(bool _boolValue)
    {
        if (sell_shelf1Object.PriceTextObjectValue.text == "0") sell_shelf1Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf1Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf2Object.PriceTextObjectValue.text == "0") sell_shelf2Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf2Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf3Object.PriceTextObjectValue.text == "0") sell_shelf3Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf3Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf4Object.PriceTextObjectValue.text == "0") sell_shelf4Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf4Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf5Object.PriceTextObjectValue.text == "0") sell_shelf5Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf5Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf6Object.PriceTextObjectValue.text == "0") sell_shelf6Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf6Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf7Object.PriceTextObjectValue.text == "0") sell_shelf7Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf7Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf8Object.PriceTextObjectValue.text == "0") sell_shelf8Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf8Object.FlowerButtonObject.SetActive(false);
        if (sell_shelf9Object.PriceTextObjectValue.text == "0") sell_shelf9Object.FlowerButtonObject.SetActive(_boolValue); else sell_shelf9Object.FlowerButtonObject.SetActive(false);
    }
    private void toggleAllSellColliders(bool _boolValue)
    {
        sell_shelf1Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf2Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf3Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf4Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf5Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf6Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf7Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf8Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        sell_shelf9Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
    }
    private void toggleBonus(SellShelfObject _shelfObject, bool _boolValue)
    {
        if ((_shelfObject.SellShelfBonusTextValue.text != "0") & (_shelfObject.SellShelfBonusTextValue.text != "+0")) _shelfObject.SellShelfBonusObject.SetActive(_boolValue);
        else _shelfObject.SellShelfBonusObject.SetActive(false);
    }  
    private void toggleAllSellAffinity(SellShelfObject _shelfObject, bool _boolValue)
    {
        if (_shelfObject.PriceTextObjectValue.text == "0") 
        {
            _shelfObject.PriceObject.SetActive(false);
            _shelfObject.Affinity.SetActive(false);
        } 
        else 
        {
            _shelfObject.PriceObject.SetActive(_boolValue);
            _shelfObject.Affinity.SetActive(_boolValue);
        }
    }
    private void toggleAllGrowAffinity(GrowShelfObject _shelfObject, bool _boolValue)
    {
        if (_shelfObject.PriceTextObjectValue.text == "0") 
        {
            _shelfObject.PriceObject.SetActive(false);
            _shelfObject.Affinity.SetActive(false);
        } 
        else 
        {
            _shelfObject.PriceObject.SetActive(_boolValue);
            _shelfObject.Affinity.SetActive(_boolValue);
        }
    }
    private void toggleShelfSellValue(SellShelfObject _shelfObject, bool _boolValue)
    {   
        if (_shelfObject.SellShelfPriceTextValue.text != "0" ) _shelfObject.SellShelfPriceObject.SetActive(_boolValue);
        else _shelfObject.SellShelfPriceObject.SetActive(false);
    }
    private void toggleAllGrowButtons(bool _boolValue)
    {
        if (grow_shelf1Object.PriceTextObjectValue.text == "0") grow_shelf1Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf1Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf2Object.PriceTextObjectValue.text == "0") grow_shelf2Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf2Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf3Object.PriceTextObjectValue.text == "0") grow_shelf3Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf3Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf4Object.PriceTextObjectValue.text == "0") grow_shelf4Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf4Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf5Object.PriceTextObjectValue.text == "0") grow_shelf5Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf5Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf6Object.PriceTextObjectValue.text == "0") grow_shelf6Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf6Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf7Object.PriceTextObjectValue.text == "0") grow_shelf7Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf7Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf8Object.PriceTextObjectValue.text == "0") grow_shelf8Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf8Object.FlowerButtonObject.SetActive(false);
        if (grow_shelf9Object.PriceTextObjectValue.text == "0") grow_shelf9Object.FlowerButtonObject.SetActive(_boolValue); else grow_shelf9Object.FlowerButtonObject.SetActive(false);
    }
    private void toggleAllGrowColliders(bool _boolValue)
    {
        grow_shelf1Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf2Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf3Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf4Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf5Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf6Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf7Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf8Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
        grow_shelf9Object.FlowerObject.GetComponent<BoxCollider2D>().enabled = _boolValue;
    }
    private void buySellShelf()
    {
        if (balanseInt >= ItemsCostArray[4])
        {
            isToBuy = true;
            GrowObject.SetActive(false);
            SellObject.SetActive(true);
            ShopObject.SetActive(false);
            MenuObject.SetActive(false);
            BackgroundGameObject.transform.Find("ButtonGrowLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonSellLayer").GetComponent<Image>().color = Color.yellow;
            BackgroundGameObject.transform.Find("ButtonShopLayer").GetComponent<Image>().color = Color.gray;
            BackgroundGameObject.transform.Find("ButtonMenuLayer").GetComponent<Image>().color = Color.gray;
            toggleAllSellColliders(false);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.SetActive(true);

            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf1").gameObject.SetActive(SellShelfsArray[1] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf2").gameObject.SetActive(SellShelfsArray[2] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf3").gameObject.SetActive(SellShelfsArray[3] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf4").gameObject.SetActive(SellShelfsArray[4] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf5").gameObject.SetActive(SellShelfsArray[5] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf6").gameObject.SetActive(SellShelfsArray[6] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf7").gameObject.SetActive(SellShelfsArray[7] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf8").gameObject.SetActive(SellShelfsArray[8] == 0);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSellShelf").gameObject.transform.Find("ButtonSellShelf9").gameObject.SetActive(SellShelfsArray[9] == 0);
            
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(false);
            SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(true);
        }
    }
    private System.Collections.IEnumerator callMethodEveryOneSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            checkGrow(); 
        }
    }
    private string getTextGrowTime(System.DateTime _dateTime)
    {
        if (((int)(_dateTime - System.DateTime.Now).TotalSeconds) >= 99)  return (((int)(_dateTime - System.DateTime.Now).TotalSeconds) / 60 + 1).ToString() + "m";
        else return (((int)(_dateTime - System.DateTime.Now).TotalSeconds)).ToString() + "s";
    }
    private double getTimeToGrow()
    {
        return TimeToGrowMultiplier * MINUTES_TO_GROW * (1.0f - 0.2f * BuyedItemsArray[7] - 0.4f * BuyedItemsArray[8]);
    }
    private void checkGrow()
    {
        if (GrowingFlowersArray[1] == 1)
        {   grow_shelf1Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[1], System.DateTime.Now) < 0) {GrowingFlowersArray[1] = 0; updateAllShelf();  grow_shelf1Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf1Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[1]);
        }   else grow_shelf1Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[2] == 1) 
        {   grow_shelf2Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[2], System.DateTime.Now) < 0) {GrowingFlowersArray[2] = 0; updateAllShelf(); grow_shelf2Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf2Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[2]);
        }   else grow_shelf2Object.GrowShelfTimeObject.SetActive(false);;
        if (GrowingFlowersArray[3] == 1) 
        {   grow_shelf3Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[3], System.DateTime.Now) < 0) {GrowingFlowersArray[3] = 0; updateAllShelf(); grow_shelf3Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf3Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[3]);
        }   else grow_shelf3Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[4] == 1) 
        {   grow_shelf4Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[4], System.DateTime.Now) < 0) {GrowingFlowersArray[4] = 0; updateAllShelf(); grow_shelf4Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf4Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[4]);
        }   else grow_shelf4Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[5] == 1) 
        {   grow_shelf5Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[5], System.DateTime.Now) < 0) {GrowingFlowersArray[5] = 0; updateAllShelf(); grow_shelf5Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf5Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[5]);
        }   else grow_shelf5Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[6] == 1) 
        {   grow_shelf6Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[6], System.DateTime.Now) < 0) {GrowingFlowersArray[6] = 0; updateAllShelf(); grow_shelf6Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf6Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[6]);
        }   else grow_shelf6Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[7] == 1) 
        {   grow_shelf7Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[7], System.DateTime.Now) < 0) {GrowingFlowersArray[7] = 0; updateAllShelf(); grow_shelf7Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf7Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[7]);
        }   else grow_shelf7Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[8] == 1) 
        {   grow_shelf8Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[8], System.DateTime.Now) < 0) {GrowingFlowersArray[8] = 0; updateAllShelf(); grow_shelf8Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf8Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[8]);
        }   else grow_shelf8Object.GrowShelfTimeObject.SetActive(false);
        if (GrowingFlowersArray[9] == 1) 
        {   grow_shelf9Object.GrowShelfTimeObject.SetActive(true);
            if (System.DateTime.Compare(GrowingFlowersDateTimeList[9], System.DateTime.Now) < 0) {GrowingFlowersArray[9] = 0; updateAllShelf(); grow_shelf9Object.GrowShelfTimeObject.SetActive(false);} 
            else grow_shelf9Object.GrowShelfTimeObjectTextValue.text = getTextGrowTime(GrowingFlowersDateTimeList[9]);
        }   else grow_shelf9Object.GrowShelfTimeObject.SetActive(false);
    }
    private void selectSeed()
    {
        GrowSeeds.SetActive(true);
        GrowSeeds.transform.Find("ButtonSeed1").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = Seeds1.ToString();
        GrowSeeds.transform.Find("ButtonSeed2").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = Seeds2.ToString();
        GrowSeeds.transform.Find("ButtonSeed3").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = Seeds3.ToString();
        GrowSeeds.transform.Find("ButtonSeed4").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = Seeds4.ToString();
        GrowSeeds.transform.Find("ButtonSeed5").gameObject.transform.Find("Text (Legacy)").GetComponent<Text>().text = Seeds5.ToString();
        GrowObject.transform.Find("Canvas").gameObject.transform.Find("ButtonBack").gameObject.SetActive(false);  
    }
    private void saveAllData()
    {
        MyGameData.Money = balanseInt;
        MyGameData.SellShelfPrice = ItemsCostArray[4]; 
        MyGameData.ArrayGrowShelfs = GrowShelfsArray;
        MyGameData.ArraySellShelfs = SellShelfsArray;
        MyGameData.ArrayPlantFlowers = GrowingFlowersArray;
        MyGameData.ArrayBuyedItems = BuyedItemsArray;

        MyGameData.ListDateTimeString.Clear();
        MyGameData.ListDateTimeString.Add(System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[1].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[2].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[3].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[4].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[5].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[6].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[7].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[8].ToString("yyyy-MM-ddTHH:mm:ss"));
        MyGameData.ListDateTimeString.Add(GrowingFlowersDateTimeList[9].ToString("yyyy-MM-ddTHH:mm:ss"));

        MyGameData.Seeds1 = Seeds1;
        MyGameData.Seeds2 = Seeds2;
        MyGameData.Seeds3 = Seeds3;
        MyGameData.Seeds4 = Seeds4;
        MyGameData.Seeds5 = Seeds5;

        MyGameData.ListGrowFlowers1 = grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers2 = grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers3 = grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers4 = grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers5 = grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers6 = grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers7 = grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers8 = grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListGrowFlowers9 = grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList;

        MyGameData.ListSellFlowers1 = sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers2 = sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers3 = sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers4 = sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers5 = sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers6 = sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers7 = sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers8 = sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
        MyGameData.ListSellFlowers9 = sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList;
    }
    private void loadAllData()
    {
        balanseInt = MyGameData.Money;
        if (MyGameData.SellShelfPrice != 0) ItemsCostArray[4] = MyGameData.SellShelfPrice;
        if (MyGameData.ArrayGrowShelfs != null)
        {
            if (MyGameData.ArrayGrowShelfs.Length > 9)
            {
                GrowShelfsArray[1] = MyGameData.ArrayGrowShelfs[1];
                GrowShelfsArray[2] = MyGameData.ArrayGrowShelfs[2];
                GrowShelfsArray[3] = MyGameData.ArrayGrowShelfs[3];
                GrowShelfsArray[4] = MyGameData.ArrayGrowShelfs[4];
                GrowShelfsArray[5] = MyGameData.ArrayGrowShelfs[5];
                GrowShelfsArray[6] = MyGameData.ArrayGrowShelfs[6];
                GrowShelfsArray[7] = MyGameData.ArrayGrowShelfs[7];
                GrowShelfsArray[8] = MyGameData.ArrayGrowShelfs[8];
                GrowShelfsArray[9] = MyGameData.ArrayGrowShelfs[9];
            }
        }
        if (MyGameData.ArraySellShelfs != null)
        {
            if (MyGameData.ArraySellShelfs.Length > 9)
            {
                SellShelfsArray[1] = MyGameData.ArraySellShelfs[1];
                SellShelfsArray[2] = MyGameData.ArraySellShelfs[2];
                SellShelfsArray[3] = MyGameData.ArraySellShelfs[3];
                SellShelfsArray[4] = MyGameData.ArraySellShelfs[4];
                SellShelfsArray[5] = MyGameData.ArraySellShelfs[5];
                SellShelfsArray[6] = MyGameData.ArraySellShelfs[6];
                SellShelfsArray[7] = MyGameData.ArraySellShelfs[7];
                SellShelfsArray[8] = MyGameData.ArraySellShelfs[8];
                SellShelfsArray[9] = MyGameData.ArraySellShelfs[9];
            }
        }
        if (MyGameData.ArrayPlantFlowers != null)
        {
            if (MyGameData.ArrayPlantFlowers.Length > 9)
            {
                GrowingFlowersArray[1] = MyGameData.ArrayPlantFlowers[1];
                GrowingFlowersArray[2] = MyGameData.ArrayPlantFlowers[2];
                GrowingFlowersArray[3] = MyGameData.ArrayPlantFlowers[3];
                GrowingFlowersArray[4] = MyGameData.ArrayPlantFlowers[4];
                GrowingFlowersArray[5] = MyGameData.ArrayPlantFlowers[5];
                GrowingFlowersArray[6] = MyGameData.ArrayPlantFlowers[6];
                GrowingFlowersArray[7] = MyGameData.ArrayPlantFlowers[7];
                GrowingFlowersArray[8] = MyGameData.ArrayPlantFlowers[8];
                GrowingFlowersArray[9] = MyGameData.ArrayPlantFlowers[9];
            }
        }
        if (MyGameData.ArrayBuyedItems != null)
        {
            if (MyGameData.ArrayBuyedItems.Length > 9)
            {
                BuyedItemsArray[1] = MyGameData.ArrayBuyedItems[1];
                BuyedItemsArray[2] = MyGameData.ArrayBuyedItems[2];
                BuyedItemsArray[3] = MyGameData.ArrayBuyedItems[3];
                BuyedItemsArray[4] = MyGameData.ArrayBuyedItems[4];
                BuyedItemsArray[5] = MyGameData.ArrayBuyedItems[5];
                BuyedItemsArray[6] = MyGameData.ArrayBuyedItems[6];
                BuyedItemsArray[7] = MyGameData.ArrayBuyedItems[7];
                BuyedItemsArray[8] = MyGameData.ArrayBuyedItems[8];
                BuyedItemsArray[9] = MyGameData.ArrayBuyedItems[9];
            }
        }
         if (MyGameData.ListDateTimeString != null)
        {
            if ((MyGameData.ListDateTimeString.Count > 9) & (GrowingFlowersDateTimeList.Count > 9))
            {
                GrowingFlowersDateTimeList[1] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[1], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[2] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[2], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[3] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[3], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[4] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[4], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[5] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[5], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[6] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[6], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[7] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[7], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[8] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[8], "yyyy-MM-ddTHH:mm:ss", null);
                GrowingFlowersDateTimeList[9] = System.DateTime.ParseExact(MyGameData.ListDateTimeString[9], "yyyy-MM-ddTHH:mm:ss", null);
            }
        }
        Seeds1 = MyGameData.Seeds1;
        Seeds2 = MyGameData.Seeds2; 
        Seeds3 = MyGameData.Seeds3; 
        Seeds4 = MyGameData.Seeds4; 
        Seeds5 = MyGameData.Seeds5;
        if (Seeds1 + Seeds2 +  Seeds3 + Seeds4 +  balanseInt == 0) Seeds1 = 20;
        if (MyGameData.ListGrowFlowers1 != null) if (MyGameData.ListGrowFlowers1.Count > 0) grow_shelf1Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers1;
        if (MyGameData.ListGrowFlowers2 != null) if (MyGameData.ListGrowFlowers2.Count > 0) grow_shelf2Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers2;
        if (MyGameData.ListGrowFlowers3 != null) if (MyGameData.ListGrowFlowers3.Count > 0) grow_shelf3Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers3;
        if (MyGameData.ListGrowFlowers4 != null) if (MyGameData.ListGrowFlowers4.Count > 0) grow_shelf4Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers4;
        if (MyGameData.ListGrowFlowers5 != null) if (MyGameData.ListGrowFlowers5.Count > 0) grow_shelf5Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers5;
        if (MyGameData.ListGrowFlowers6 != null) if (MyGameData.ListGrowFlowers6.Count > 0) grow_shelf6Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers6;
        if (MyGameData.ListGrowFlowers7 != null) if (MyGameData.ListGrowFlowers7.Count > 0) grow_shelf7Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers7;
        if (MyGameData.ListGrowFlowers8 != null) if (MyGameData.ListGrowFlowers8.Count > 0) grow_shelf8Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers8;
        if (MyGameData.ListGrowFlowers9 != null) if (MyGameData.ListGrowFlowers9.Count > 0) grow_shelf9Object.FlowerObject.GetComponent<GrowFlowerComponent>().FlowerData.ValueList = MyGameData.ListGrowFlowers9;

        if (MyGameData.ListSellFlowers1 != null) if (MyGameData.ListSellFlowers1.Count > 0) sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers1;
        if (MyGameData.ListSellFlowers2 != null) if (MyGameData.ListSellFlowers2.Count > 0) sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers2;
        if (MyGameData.ListSellFlowers3 != null) if (MyGameData.ListSellFlowers3.Count > 0) sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers3;
        if (MyGameData.ListSellFlowers4 != null) if (MyGameData.ListSellFlowers4.Count > 0) sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers4;
        if (MyGameData.ListSellFlowers5 != null) if (MyGameData.ListSellFlowers5.Count > 0) sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers5;
        if (MyGameData.ListSellFlowers6 != null) if (MyGameData.ListSellFlowers6.Count > 0) sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers6;
        if (MyGameData.ListSellFlowers7 != null) if (MyGameData.ListSellFlowers7.Count > 0) sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers7;
        if (MyGameData.ListSellFlowers8 != null) if (MyGameData.ListSellFlowers8.Count > 0) sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers8;
        if (MyGameData.ListSellFlowers9 != null) if (MyGameData.ListSellFlowers9.Count > 0) sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.ValueList = MyGameData.ListSellFlowers9;
    }
    private void playAudioClip(AudioClip _audioClip)
    {
            audioSource.clip = _audioClip;
            // Проверяем, если аудио не воспроизводится в данный момент
            if (!audioSource.isPlaying)
            {
                // Воспроизводим звук
                audioSource.Play();
            }
    }
    private void showTip()
    {
        FrontGameObject.transform.Find("Tip").gameObject.SetActive(true);
        SellObject.transform.Find("Canvas").gameObject.transform.Find("ButtonSell").gameObject.SetActive(false);
    }
    void Start()
    {   

        initialise();
        MyGameData = new GameData();
        MyGameData = saveManager.LoadGameData();
        resetDataToDefaults();
        loadAllData();
        updateBalanse();
        updateSeeds();
        updateAllShelf();
        CalculateTotalSellValue();
        updateShop();
        checkGrow();
        StartCoroutine(callMethodEveryOneSecond());
        if ((balanseInt == 0) & (Seeds1 == 20)) ShowInfo();
        else PressedGrow();
        
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            if (Screen.width >= 1080) mainCamera.orthographicSize = Screen.height / 2f;
        }
    }
    void OnApplicationFocus(bool _hasFocus)
    {
        if (!_hasFocus)
        {
            saveAllData();
            // Приложение потеряло фокус, сохраняем данные
           saveManager.SaveGameData(MyGameData);
        }
    }
    void OnApplicationQuit()
    {
        saveAllData();
        // Приложение закрывается, сохраняем данные
        saveManager.SaveGameData(MyGameData);
    }
    // void generateTestSampleSell()
    // {
    //     System.Random rand = new  System.Random();
    //     if (rand.Next(0, 10) >= 1) sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf1Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 1) sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf2Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 2) sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf3Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 2) sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf4Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 3) sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf5Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 3) sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf6Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 4) sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf7Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 4) sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf8Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     if (rand.Next(0, 10) >= 5) sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetRandomFlower(); else sell_shelf9Object.FlowerObject.GetComponent<SellFlowerComponent>().FlowerData.SetNullFlower();
    //     updateAllShelf();
    //     CalculateTotalSellValue();
    // }
}
