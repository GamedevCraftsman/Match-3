using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class GroupingAndDeleting : MonoBehaviour, IPointerClickHandler
{
    public enum bombsColor { Blue, Red, Green, Orange, Purple, Nothing };
    public bombsColor color;

    List<GameObject> bombsForDelete = new List<GameObject>();
    int clickedCellIndex = -1;
    CellScript[] cells;
    GameObject cellContainer;
    private void Start()
    {
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].bomb == gameObject)
            {
                clickedCellIndex = i;
                break;
            }
        }
        if (clickedCellIndex - 1 >= 0 && cells[clickedCellIndex - 1].bomb.GetComponent<GroupingAndDeleting>().color == color)
        {
            cells[clickedCellIndex - 1].isFree = true;
            bombsForDelete.Add(cells[clickedCellIndex - 1].bomb);
        }
        if (clickedCellIndex + 1 < cells.Length && cells[clickedCellIndex + 1].bomb.GetComponent<GroupingAndDeleting>().color == color)
        {
            cells[clickedCellIndex + 1].isFree = true;
            bombsForDelete.Add(cells[clickedCellIndex + 1].bomb);

        }
        if (clickedCellIndex + 6 < cells.Length && cells[clickedCellIndex + 6].bomb.GetComponent<GroupingAndDeleting>().color == color)
        {
            cells[clickedCellIndex + 6].isFree = true;
            bombsForDelete.Add(cells[clickedCellIndex + 6].bomb);

        }
        if (clickedCellIndex - 6 >= 0 && cells[clickedCellIndex - 6].bomb.GetComponent<GroupingAndDeleting>().color == color)
        {
            cells[clickedCellIndex - 6].isFree = true;
            bombsForDelete.Add(cells[clickedCellIndex - 6].bomb);
        }

        if (bombsForDelete.Count() >= 1)
        {
            foreach(var bomb in bombsForDelete)
            {
                Destroy(bomb);
                Destroy(gameObject);
                cells[clickedCellIndex].isFree = true;
            }
        }
        bombsForDelete.Clear();
    }
}

