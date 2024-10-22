using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Ins { get; set; }

    // Thêm tùy chọn để xác định có muốn giữ đối tượng khi chuyển scene không
    [SerializeField] private bool dontDestroyOnLoad = true;

    protected virtual void Awake() 
    { 
        // Kiểm tra nếu instance đã tồn tại và không phải là instance hiện tại, thì hủy đối tượng này.
        if (Ins != null && Ins != this as T) 
        { 
            Destroy(gameObject); // Hủy đối tượng GameObject chứa instance không cần thiết
        } 
        else 
        { 
            Ins = this as T;
            
            // Chỉ giữ đối tượng nếu biến "dontDestroyOnLoad" được bật
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject); // Đảm bảo đối tượng này không bị hủy khi đổi scene
            }
        }
    }
}
