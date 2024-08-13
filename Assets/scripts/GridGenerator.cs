using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject prefab; 
    public int rows = 3;      
    public int columns = 3;   
    public float spacing = 2.0f; 
    
    public GameObject[] childPrefabs; 
    void Start()
    {
        GenerateGrid();
    }

   void GenerateGrid()
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Vector3 position = new Vector3(i * spacing, 0, j * spacing);
            GameObject newPrefab = Instantiate(prefab, position, Quaternion.identity);

            int randomIndex = Random.Range(0, childPrefabs.Length);
            GameObject child = Instantiate(childPrefabs[randomIndex], newPrefab.transform);
            child.transform.localPosition = Vector3.zero;

            if (child.transform.localScale.y > newPrefab.transform.localScale.y)
            {
                Renderer parentRenderer = newPrefab.GetComponent<Renderer>();
                if (parentRenderer != null)
                {
                    Debug.Log("Changing color to red for " + newPrefab.name);
                    parentRenderer.material.color = Color.red;
                    
                }
                else
                {
                    Debug.LogWarning("No Renderer found on " + newPrefab.name);
                }

                Destroy(child);
            }
        }
    }
}
 
}
