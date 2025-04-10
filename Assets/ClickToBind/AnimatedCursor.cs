using UnityEngine;

public class AnimatedCursor : MonoBehaviour
{
    public Texture2D[] frames; // อาเรย์ของเท็กซ์เจอร์ที่เป็นเฟรมแอนิเมชั่น.
    public float frameRate = 0.1f; // เวลาที่แต่ละเฟรมจะแสดง.
    public Vector2 hotSpot = Vector2.zero; // จุดศูนย์กลางของเคอร์เซอร์.

    private int currentFrameIndex = 0;
    private float timer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // ทำให้วัตถุนี้ไม่ถูกทำลายเมื่อโหลดซีนใหม่
    }

    void Start()
    {
        // ตั้งค่าเคอร์เซอร์เฟรมแรก.
        if (frames == null || frames.Length == 0)
        {
            Debug.LogError("Frames array is null or empty!");
            this.enabled = false; // ปิดใช้งานสคริปต์หากไม่มีเฟรมสำหรับแอนิเมชัน
            return;
        }
        Cursor.SetCursor(frames[currentFrameIndex], hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        // เพิ่มเวลาตั้งแต่เฟรมสุดท้าย.
        timer += Time.deltaTime;

        // ตรวจสอบว่าเวลาเกิน frameRate หรือไม่.
        if (timer >= frameRate)
        {
            // ไปที่เฟรมถัดไป.
            currentFrameIndex = (currentFrameIndex + 1) % frames.Length;

            // ตั้งค่าเคอร์เซอร์ไปยังเฟรมใหม่.
            Cursor.SetCursor(frames[currentFrameIndex], hotSpot, CursorMode.Auto);

            // ตั้งค่าเวลาใหม่.
            timer = 0f;
        }
    }
}
