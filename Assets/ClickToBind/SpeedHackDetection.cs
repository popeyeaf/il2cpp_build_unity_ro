using UnityEngine;

public class SpeedHackDetection : MonoBehaviour
{
    // กำหนดค่าเวลาที่สมเหตุสมผลที่สุดระหว่างเฟรม
    public float threshold = 0.1f;

    // ค่าเวลาที่จะใช้ตรวจสอบ
    private float lastFixedUpdateTime;

    private void Start()
    {
        lastFixedUpdateTime = Time.fixedTime;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Time.fixedTime - lastFixedUpdateTime - Time.fixedDeltaTime) > threshold)
        {
            Debug.LogWarning("Speed hack detected! Exiting application.");
            // ปิดแอปพลิเคชัน
            Application.Quit();

            // ถ้าเป็น Editor ให้ใช้คำสั่งนี้เพื่อหยุดการเล่น
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        lastFixedUpdateTime = Time.fixedTime;
    }
}
