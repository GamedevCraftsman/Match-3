using UnityEngine;
using UnityEngine.EventSystems;

public class BombsDeleted : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float yPointFrom;
    [SerializeField] float yPointTo;

    [SerializeField] CellScript[] cells;
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
        for(int i = 0; i < cells.Length; i++)
        {
            if (gameObject.transform.position.x == cells[i].transform.position.x && gameObject.transform.position.y <= cells[i].transform.position.y + yPointFrom && gameObject.transform.position.y >= cells[i].transform.position.y - yPointTo)
            {
                cells[i].isFree = true;
            }
        }
        Destroy(gameObject);
    }
}
