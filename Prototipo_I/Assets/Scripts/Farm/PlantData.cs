using UnityEngine;

[CreateAssetMenu(fileName = "NewPlant", menuName = "Farm/PlantData")]
public class PlantData : ScriptableObject
{
    public string plantName;
    public GameObject[] growthStages;
    public float[] growthTimes;
    public int harvest;
}
