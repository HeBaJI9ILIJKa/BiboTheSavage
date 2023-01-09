using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fallingObjectsPools;

    private FallingObjects[] fallingObjectPrefabs;
    private ObjectPool<FallingObjects>[] pools;
    private Coroutine spawnRandomFallingObject;

    private Vector3 spawnPosition;
    private List<int> allChances;
    private int chancesSum;

    private static Spawner instance;

    public static Spawner GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartSpawning()
    {
        PreparePrefabs();
        EventManager.OnObjectFell.AddListener(ReturnToPool);
        //spawnRandomFallingObject = StartCoroutine(SpawnRandomFallingObject()); //версия без пула
        spawnRandomFallingObject = StartCoroutine(SpawnRandomFallingObjectFromPool());
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnRandomFallingObject);
    }
    
    private void PreparePrefabs()
    {
        fallingObjectPrefabs = Resources.LoadAll<FallingObjects>("Prefabs/FallingObjects");
        spawnPosition = new Vector3(0,0,0);
        GetChances();

        CreatePools();
    }

    private void GetChances()
    {
        allChances = new List<int>();
        chancesSum = 0;
        for (int i = 0; i < fallingObjectPrefabs.Length; i++)
        {
            chancesSum += fallingObjectPrefabs[i].spawnWeight;
            allChances.Add(fallingObjectPrefabs[i].spawnWeight);
        }
    }
    private Vector3 GetRandomSpawnPosition(Vector3 spawnPosition)
    {
        spawnPosition.y = GameParameters.worldDimensions.y + 1; //чуть выше экрана
        spawnPosition.z = 0f;
        spawnPosition.x = (Random.Range(0, (GameParameters.worldDimensions.x - 1) * 20) - (GameParameters.worldDimensions.x - 1) * 10) * 0.1f;

        return spawnPosition;
    }

    //Версия без пула
    #region SpawnWeightRandom - заменён на SpawnRandomFallingObjectFromPool
    private IEnumerator SpawnRandomFallingObject()
    {
        while (GameParameters.gameRunnig)
        {
            SpawnPrefab(GetWeightRandomPrefab(), GetRandomSpawnPosition(spawnPosition));
            yield return new WaitForSeconds(GameParameters.spawnInterval);
        }
    }

    private void SpawnPrefab(FallingObjects prefab, Vector3 position)
    {
        FallingObjects fallingObject = Instantiate(prefab, position, Quaternion.identity) as FallingObjects;
        Rigidbody2D rb2d = fallingObject.GetComponent<Rigidbody2D>();

        rb2d.angularVelocity = Random.Range(50, 200) * ((Random.Range(0, 2) - 0.5f) * 2); // получаем скорость вращения объекта от -200 до 200, исключая диапазон от -50 до 50
    }

    private Object GetRandomPrefab()
    {
        return fallingObjectPrefabs[Random.Range(0, fallingObjectPrefabs.Length)];
    }

    private FallingObjects GetWeightRandomPrefab()
    {
        int value = Random.Range(0, chancesSum);
        int sum = 0;
        
        for (int i = 0; i < allChances.Count; i++)
        {
            sum += allChances[i];
            if(value < sum)
            {
                return fallingObjectPrefabs[i];
            }
        }

        return fallingObjectPrefabs[fallingObjectPrefabs.Length - 1];
    }

    #endregion

    //Версия с пулом
    #region SpawnRandomFallingObjectFromPool
    private void CreatePools()
    {
        pools = new ObjectPool<FallingObjects>[fallingObjectPrefabs.Length];
        for (int i = 0; i < fallingObjectPrefabs.Length; i++)
        {
            fallingObjectPrefabs[i].poolNumber = i;
            pools[i] = new ObjectPool<FallingObjects>(createFunc: () => new FallingObjects(), actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false), actionOnDestroy: (obj) => Destroy(obj), false, defaultCapacity: 15);
            FealPool(pools[i], fallingObjectPrefabs[i], 15);
        }
    }

    private void FealPool(ObjectPool<FallingObjects> pool, FallingObjects prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            FallingObjects fallingObject = Instantiate(prefab) as FallingObjects;
            fallingObject.transform.SetParent(fallingObjectsPools.transform);
            pool.Release(fallingObject);
        }
    }

    private void SpawnPrefabFromPool(ObjectPool<FallingObjects> pool, Vector3 position)
    {
        FallingObjects fallingObject = pool.Get();
        fallingObject.transform.position = position;
        //fallingObject.transform.localScale = new Vector3(1, 1, 1);
        Rigidbody2D rb2d = fallingObject.GetComponent<Rigidbody2D>();

        rb2d.angularVelocity = Random.Range(50, 200) * ((Random.Range(0, 2) - 0.5f) * 2); // получаем скорость вращения объекта от -200 до 200, исключая диапазон от -50 до 50
    }

    private IEnumerator SpawnRandomFallingObjectFromPool()
    {
        while (GameParameters.gameRunnig)
        {
            SpawnPrefabFromPool(GetWeightRandomPrefabFromPool(), GetRandomSpawnPosition(spawnPosition));
            yield return new WaitForSeconds(GameParameters.spawnInterval);
        }
    }
    private ObjectPool<FallingObjects> GetWeightRandomPrefabFromPool()
    {
        int value = Random.Range(0, chancesSum);
        int sum = 0;

        for (int i = 0; i < allChances.Count; i++)
        {
            sum += allChances[i];
            if (value < sum)
            {
                return pools[i];
            }
        }

        return pools[pools.Length - 1];
    }
#endregion

    private void ReturnToPool(FallingObjects fallingObject)
    {
        pools[fallingObject.poolNumber].Release(fallingObject);
    }
}