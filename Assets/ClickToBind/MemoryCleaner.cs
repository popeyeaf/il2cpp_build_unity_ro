using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryCleaner : MonoBehaviour
{
    // ���¡��ҹ�������Ŵʤ�Ի��
    void Awake()
    {
        // ŧ����¹��ǨѴ����˵ء�ó�����ͩҡ���ѧ�ж١��Ŵ
        SceneManager.sceneLoaded += OnSceneLoading;
    }

    // �ж١���¡��������ա����Ŵ�ҡ����
    private void OnSceneLoading(Scene scene, LoadSceneMode mode)
    {
        // �Ѵ����红��
        ClearMemory();
    }


    // ������˹��¤�����
    private void ClearMemory()
    {
        // �ѧ�Ѻ������红�Тͧ .NET �ӧҹ
        System.GC.Collect();

        // �ѧ�Ѻ��� Unity �ӡ��������˹��¤����ӷ��������
        Resources.UnloadUnusedAssets();
    }

    // ���¡��������ͺਡ��١�����
    void OnDestroy()
    {
        // ¡��ԡ���ŧ����¹��ǨѴ����˵ء�ó�������ͺਡ��١�����
        SceneManager.sceneLoaded -= OnSceneLoading;
    }
}
