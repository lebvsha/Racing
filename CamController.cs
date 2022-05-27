using UnityEngine;

public class CamController : MonoCache
{
    [SerializeField] private GameObject _target;
    public override void OnTick()
    {
        Vector3 targetPos = _target.transform.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 1000);
    }
}
