using UnityEngine;
using System.Collections.Generic;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private Transform appleParent;
    private readonly int width = 17, height = 10;
    private readonly int spacing = 20;
    private List<Apple> appleList = new List<Apple>();
    public List<Apple> AppleList => appleList; //AppleList 프로퍼티 : 읽기 전용! 외부에서 변경은 못하고 조회만 가능

    private void Awake()
    {
        SpawnApples();
    }

    private void SpawnApples()
    {
        //프리팹 크기를 구해서 간격(spacing)만큼 더해주기
        Vector2 size = applePrefab.GetComponent<RectTransform>().sizeDelta;
        size += new Vector2(spacing, spacing);

        int sum = 0;

        for(int y = 0; y<height; y++){
            for(int x = 0; x<width; x++){
                GameObject clone = Instantiate(applePrefab, appleParent); //생성하는함수(생성할 프리팹, 부모 오브젝트)
                RectTransform rect = clone.GetComponent<RectTransform>();

                float px = (-width * 0.5f + 0.5f + x) * size.x;
                float py = (height * 0.5f - 0.5f - y) * size.y;
                rect.anchoredPosition = new Vector2(px, py);

                Apple apple = clone.GetComponent<Apple>();
                apple.Number = Random.Range(1,10);

                //마지막 사과를 만들때 총합이 10의 배수가 되도록 고려하기
                if(y == height - 1 && x == width - 1)
                {
                    apple.Number = 10 - (sum % 10);
                }
                sum += apple.Number;

                appleList.Add(apple);
            }
        }
        Debug.Log($"AppleSpawner::SpawnApples() : {sum}");
    }

    public void DestroyApple(Apple removeItem)
    {
        //인자로 받아온 사과를 appleList에서 찾아 삭제
        appleList.Remove(removeItem);
        //Destroy로 해당 오브젝트 파괴
        Destroy(removeItem.gameObject);
    }
}
