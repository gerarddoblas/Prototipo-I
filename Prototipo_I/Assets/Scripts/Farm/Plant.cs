using UnityEngine;
using UnityEngine.Events;
public class Plant
{
    private string name;
    public string Name { get => name; }

    private int numStages;
    private int currentStage;

    public bool IsGrown => currentStage >= numStages;

    private float timeToGrow;
    //public float TimeToGrow { get => timeToGrow; }

    public float currentTime => Mathf.Max(timeToGrow - DayNightCycle.Instance.DayTime, 0f);

    private UnityEvent<float> MyEvent = new UnityEvent<float>();

    public Plant(string name, int numStages, float timeToGrow)
    {
        this.name = name;
        this.numStages = numStages;
        this.timeToGrow = timeToGrow;
        this.currentStage = 0;
    }

    public void Create()
    {
        MyEvent.AddListener(Grow);

        DayNightCycle.Instance.SubscribeTimedEvent(MyEvent, DayNightCycle.Instance.DayTime + timeToGrow);
    }

    private void Grow(float time)
    {
        currentStage++;
        if (IsGrown)
        {
            Debug.Log("Crecio");
            //UwU
        } else
        {
            Debug.Log("No Crecio");
            DayNightCycle.Instance.SubscribeTimedEvent(MyEvent, DayNightCycle.Instance.DayTime + timeToGrow);
        }
        //Update visual
    }
}