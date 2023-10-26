using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEditor;
using System.Data;

public class GroupingAndDeleting : MonoBehaviour, IPointerClickHandler
{
    public enum bombsColor { Blue, Red, Green, Orange, Purple, Nothing };
    public bombsColor color;

    const int offset = 1;
    const int columnSize = 6;
    const int numberOfNeighbors = 1;
    int[] farUpBombsIndexes = { 6, 12, 18, 24, 30 };
    int[] farDownBombsIndexes = { 5, 11, 17, 23, 29, 35 };
    List<GameObject> bombsForDelete = new List<GameObject>();
    int clickedCellIndex = -1;
    CellScript[] cells;
    GameObject cellContainer;
    void Start()
    {
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        FindClickedCellIndex();

        CheckAndAddNeighborToList(-offset);
        CheckAndAddNeighborToList(offset);
        CheckAndAddNeighborToList(-columnSize);
        CheckAndAddNeighborToList(columnSize);

        CheckingTheNumberAndDeleteNeighbors();
    }

    void CheckAndAddNeighborToList(int offset)
    {
        int neighborIndex = clickedCellIndex + offset;

        if (CheckBorders(neighborIndex) && IsNeighborMatchingColor(neighborIndex))
        {
            bombsForDelete.Add(cells[neighborIndex].bomb);
            cells[neighborIndex].isFree = true;
        }
        CheckingFarBombs(neighborIndex);    
    }

    bool CheckBorders(int neighborIndex)
    {
        return (neighborIndex < cells.Length && neighborIndex >= 0);
    }

    bool IsNeighborMatchingColor(int neighborIndex)
    {
        if (cells[neighborIndex].bomb.GetComponent<GroupingAndDeleting>().color == color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckingTheNumberAndDeleteNeighbors()
    {
        if (bombsForDelete.Count() >= numberOfNeighbors)
        {
            DeleteBombsFromList();
        }
        bombsForDelete.Clear();
    }

    void DeleteBombsFromList()
    {
        foreach (var bomb in bombsForDelete)
        {
            Destroy(bomb);
            cells[clickedCellIndex].isFree = true;
            Destroy(gameObject);           
        }
    }

    void FindClickedCellIndex()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].bomb == gameObject)
            {
                clickedCellIndex = i;
                break;
            }
        }
    }

    void CheckingFarBombs(int neighborIndex)
    {
        for (int i = 0; i < farUpBombsIndexes.Length; i++)
        {
            CheckUpBombs(neighborIndex, i);

        }
        for (int j = 0; j < farDownBombsIndexes.Length; j++)
        {
            CheckDownBombs(neighborIndex, j);
        }
    }

    void CheckUpBombs(int neighborIndex, int i)
    {
        if (CheckBorders(neighborIndex) && neighborIndex == clickedCellIndex + offset && neighborIndex == farUpBombsIndexes[i])
        {
            bombsForDelete.Remove(cells[clickedCellIndex + offset].bomb);
            cells[clickedCellIndex + offset].isFree = false;
        }
    }

    void CheckDownBombs(int neighborIndex, int j)
    {
        if (CheckBorders(neighborIndex) && neighborIndex == clickedCellIndex - offset && neighborIndex == farDownBombsIndexes[j])
        {
            bombsForDelete.Remove(cells[clickedCellIndex - offset].bomb);
            cells[clickedCellIndex + offset].isFree = false;
        }
    }
}

