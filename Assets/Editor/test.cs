using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Header("ギズモの長さ")]
    [SerializeField, Range(0, 100)] private float _sight_range;
    [Header("ギズモの角度")]
    [SerializeField, Range(0, 360)] private float _sight_angle;
    [Header("ギズモに割り当てるマテリアル")]
    [SerializeField] private Material mat;
    private GameObject _gizmo;
    private FanGizmos.FanGizmo _fanGizmo;

    // Start is called before the first frame update
    void Start()
    {
        _fanGizmo = new FanGizmos.FanGizmo();
        _gizmo = _fanGizmo.CreateGizmo(this.gameObject, Vector3.zero, Vector3.zero, mat);
    }

    // Update is called once per frame
    void Update()
    {
        _fanGizmo.RefreshGizmo(ref _gizmo, this.gameObject, _sight_angle, _sight_range);
    }
}
