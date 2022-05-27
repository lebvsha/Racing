using System.Collections.Generic;
using UnityEngine;

public class MonoCache : MonoBehaviour
{
    public static List<MonoCache> AllUpdates = new List<MonoCache>(101);
    public static List<MonoCache> AllFixedUpdates = new List<MonoCache>(101);

    private void OnEnable() 
    {
        AllUpdates.Add(this);
        AllFixedUpdates.Add(this);
    }
 
    private void OnDisable() 
    {
        AllUpdates.Remove(this);
        AllFixedUpdates.Remove(this);
    }

    private void OnDestroy() 
    {
        AllUpdates.Remove(this);
        AllFixedUpdates.Remove(this);
    }

    public void Tick() => OnTick();
    public virtual void OnTick() { }

    public void FixedTick() => OnFixedTick();
    public virtual void OnFixedTick() { }

}
