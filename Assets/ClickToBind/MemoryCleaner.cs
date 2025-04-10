using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryCleaner : MonoBehaviour
{
    // เรียกใช้งานเมื่อโหลดสคริปต์
    void Awake()
    {
        // ลงทะเบียนตัวจัดการเหตุการณ์เมื่อฉากกำลังจะถูกโหลด
        SceneManager.sceneLoaded += OnSceneLoading;
    }

    // จะถูกเรียกใช้เมื่อมีการโหลดฉากใหม่
    private void OnSceneLoading(Scene scene, LoadSceneMode mode)
    {
        // จัดการเก็บขยะ
        ClearMemory();
    }


    // เคลียร์หน่วยความจำ
    private void ClearMemory()
    {
        // บังคับให้ตัวเก็บขยะของ .NET ทำงาน
        System.GC.Collect();

        // บังคับให้ Unity ทำการเคลียร์หน่วยความจำที่ไม่จำเป็น
        Resources.UnloadUnusedAssets();
    }

    // เรียกใช้เมื่อออบเจกต์ถูกทำลาย
    void OnDestroy()
    {
        // ยกเลิกการลงทะเบียนตัวจัดการเหตุการณ์เมื่อออบเจกต์ถูกทำลาย
        SceneManager.sceneLoaded -= OnSceneLoading;
    }
}
