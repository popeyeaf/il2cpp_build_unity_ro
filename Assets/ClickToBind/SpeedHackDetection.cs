using UnityEngine;

public class SpeedHackDetection : MonoBehaviour
{
    // ��˹�������ҷ�����˵����ŷ���ش�����ҧ���
    public float threshold = 0.1f;

    // ������ҷ������Ǩ�ͺ
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
            // �Դ�ͻ���पѹ
            Application.Quit();

            // ����� Editor ��������觹��������ش������
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        lastFixedUpdateTime = Time.fixedTime;
    }
}
