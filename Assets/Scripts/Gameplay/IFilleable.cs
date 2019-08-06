using UnityEngine;

public interface IFilleable
{
    void CreateChild(Block block, Pattern pattern, Transform transform);
}
