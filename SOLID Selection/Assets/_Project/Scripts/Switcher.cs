using UnityEngine;
using System.Collections.Generic;

public class Switcher : MonoBehaviour
{
    public List<GameObject> ChangeableObjects;
    private List<IChangeable> _changeableObjects = new List<IChangeable>();

    private void Start()
    {
        for (int i = 0; i < ChangeableObjects.Count; i++)
        {
            var changeableObject = ChangeableObjects[i].GetComponent<IChangeable>();
            _changeableObjects.Add(changeableObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for (int i = 0; i < _changeableObjects.Count; i++)
            {
                _changeableObjects[i].Next();
            }
        }
    }
}

public interface IChangeable
{
    void Next();
}
