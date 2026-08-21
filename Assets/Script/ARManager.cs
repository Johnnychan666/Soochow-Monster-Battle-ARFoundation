using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

namespace WEI
{
    /// <summary>
    /// 擴增實境管理器
    /// </summary>
    public class ARManager : MonoBehaviour
    {
        [SerializeField, Header("塔防物件")]
        private GameObject goTD;

        private bool isPlaced;
        private ARRaycastManager arRay;

        private void Awake()
        {
            arRay = GetComponent<ARRaycastManager>();
        }

        private void Update()
        {
            if (isPlaced) return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // 獲得滑鼠座標（觸控座標）
                Vector3 mousePosition = Input.mousePosition;
                //Debug.Log($"<color=#ff3>點擊座標：{mousePosition}</color>");
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (arRay.Raycast(mousePosition, hits, TrackableType.Planes))
                {
                    Instantiate(goTD, hits[0].pose.position, Quaternion.identity);
                    isPlaced = true;
                }
            }
        }
    }
}