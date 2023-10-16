using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombsDeleted : MonoBehaviour, IPointerClickHandler
{
    public enum bombsColor { Blue, Red, Green, Orange, Purple };
    public bombsColor color;

    GameObject[] bombsForDeleting;
    float yPointFrom;
    float yPointTo;
    CellScript[] cells;
    GameObject cellContainer;
    private void Start()
    {
        yPointFrom = GetComponent<BombMovement>().yPointFrom;
        yPointTo = GetComponent <BombMovement>().yPointTo;
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < cells.Count(); i++)
        {
            if (cells[i].bombColor == color)
            {
                bombsForDeleting.Append(cells[i].bomb);
            }
        }
        //DestroyBombs(bombsForDeleting);
        for(int i = 0; i < bombsForDeleting.Length; i++)
        {
            Debug.Log(bombsForDeleting[i]);
        }
    }


    void DestroyBombs(GameObject[] bombs)
    {
        for (int j = 0; j < bombs.Length; j++) {
            for (int i = 0; i < cells.Length; i++)
            {
                if (gameObject.transform.position.x == cells[i].transform.position.x && gameObject.transform.position.y <= cells[i].transform.position.y + yPointFrom && gameObject.transform.position.y >= cells[i].transform.position.y - yPointTo)
                {
                    cells[i].isFree = true;
                }
            }
            Destroy(bombs[j]);
        }
    }
}

