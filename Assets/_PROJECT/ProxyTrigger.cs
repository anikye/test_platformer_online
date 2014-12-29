using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProxyTrigger : MonoBehaviour
{
    public List<Collider2D> ContractList;
    public List<string> Tags;

    public bool IsContract
    {
        get { return ContractList.Count > 0; }
    }

    void Update()
    {
        for (int i = 0; i < ContractList.Count; i++)
        {
            if (ContractList[i] == null)
            {
                ContractList.RemoveAt(i);
                i--;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Tags.Count > 0)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                if (other.CompareTag(Tags[i]))
                {
                    ContractList.Add(other);
                    break;
                }
            }
        }
        else
        {
            ContractList.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (ContractList.Contains(other))
        {
            ContractList.Remove(other);
        }
    }
}
