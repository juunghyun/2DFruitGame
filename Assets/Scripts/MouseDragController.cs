using UnityEngine;

public class MouseDragController : MonoBehaviour
{
   [SerializeField] private AppleSpawner appleSpawner;
   [SerializeField] private RectTransform dragRectangle;

   private Rect dragRect;
   private Vector2  start = Vector2.zero;
   private Vector2 end = Vector2.zero;

   private void Awake()
   {
    dragRect = new Rect();

    //start, end의 디폴트값이 0, 0이므로 드래그 영역이 화면에 보이지 않도록 설정
    DrawDragRectangle();
   }

   private void Update()
   {
        if (Input.GetMouseButtonDown(0)) //좌클릭
        {
            start = Input.mousePosition;
            dragRect.Set(0,0,0,0);
        }

        if(Input.GetMouseButton(0))
        {
            end = Input.mousePosition;
            DrawDragRectangle();
            CalculateDragRect();
            SelectApples();
        }
        if(Input.GetMouseButtonUp(0))//드래그 종료
        {
            start = end = Vector2.zero; //다시 0,0으로 바꿔서 드래그 범위 안보이도록
            DrawDragRectangle();
        }
   }

   private void DrawDragRectangle()
   {
        dragRectangle.position = (start + end) * 0.5f;
        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
   }

   private void CalculateDragRect()
   {
        if(Input.mousePosition.x<start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }
   }

   private void SelectApples()
   {
        foreach (Apple apple in appleSpawner.AppleList)
        {
            if(dragRect.Contains(apple.Position))
            {
                apple.OnSelected();
            }else
            {
                apple.OnDeselected();
            }
        }
   }

}
