using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class InGameStage : MonoBehaviour
{

    [SerializeField]
    private List<Transform> LinePaths;

    private ObjectPool<Enemy> objectPool = new ObjectPool<Enemy>();

    [SerializeField]
    private AssetReference EnemyRef;

    [SerializeField]
    private Transform EnemyRoot;

    public void Init()
    {
        objectPool.Init(EnemyRef, EnemyRoot, 100);

    }

}
