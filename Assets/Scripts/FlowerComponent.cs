using UnityEngine;

public class SellFlowerComponent : MonoBehaviour
{
    public Flower FlowerData;
    public SellShelfObject ShelfData;
    public int number;
}

public class GrowFlowerComponent : MonoBehaviour
{
    public Flower FlowerData;
    public GrowShelfObject ShelfData;
    public int number;
}

public class GrowSelectedFlowerComponent : MonoBehaviour
{
    public Flower FlowerData;
    public GrowSelectedFlowerObject selectedFlowerData;
    public int number;
}

public class SellSelectedFlowerComponent : MonoBehaviour
{
    public Flower FlowerData;
    public SellSelectedFlowerObject selectedFlowerData;
    public int number;
}
