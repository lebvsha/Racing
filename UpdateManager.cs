using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < MonoCache.AllUpdates.Count; i++)
            MonoCache.AllUpdates[i].Tick();
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < MonoCache.AllFixedUpdates.Count; i++)
            MonoCache.AllFixedUpdates[i].FixedTick();
    }
}
