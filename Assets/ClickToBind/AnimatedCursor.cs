using UnityEngine;

public class AnimatedCursor : MonoBehaviour
{
    public Texture2D[] frames; // ������ͧ�硫�������������͹������.
    public float frameRate = 0.1f; // ���ҷ������������ʴ�.
    public Vector2 hotSpot = Vector2.zero; // �ش�ٹ���ҧ�ͧ��������.

    private int currentFrameIndex = 0;
    private float timer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // ������ѵ�ع�����١������������Ŵ�չ����
    }

    void Start()
    {
        // ��駤��������������á.
        if (frames == null || frames.Length == 0)
        {
            Debug.LogError("Frames array is null or empty!");
            this.enabled = false; // �Դ��ҹʤ�Ի���ҡ������������Ѻ�͹����ѹ
            return;
        }
        Cursor.SetCursor(frames[currentFrameIndex], hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        // �������ҵ��������ش����.
        timer += Time.deltaTime;

        // ��Ǩ�ͺ��������Թ frameRate �������.
        if (timer >= frameRate)
        {
            // 价������Ѵ�.
            currentFrameIndex = (currentFrameIndex + 1) % frames.Length;

            // ��駤������������ѧ�������.
            Cursor.SetCursor(frames[currentFrameIndex], hotSpot, CursorMode.Auto);

            // ��駤����������.
            timer = 0f;
        }
    }
}
