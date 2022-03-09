using UnityEngine;
 
public class SpawnAreaManager : MonoBehaviour
{
    [SerializeField] RectTransform[] spawnAreas;

    public Vector2 GetRndSpawnAreaPos()
    {
        var rndArea = Random.Range(0, spawnAreas.Length);
        return GetRndPosFromArea(spawnAreas[rndArea]);
    }

    private void Awake()
    {
        Provider.SpawnManager = this;
    }

    Vector3 GetRndPosFromArea(RectTransform area)
    {
        var x = Random.Range(area.rect.xMin, area.rect.xMax);
        var y = Random.Range(area.rect.yMin, area.rect.yMax);
        return (Vector2)area.transform.position + new Vector2(x, y);
    }
}
