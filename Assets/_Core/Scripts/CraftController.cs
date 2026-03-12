using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftController : MonoBehaviour
{
    public CraftSettings craftSettings;
    public GameObject inventoryContent;

    private List<ICraftable> items = new List<ICraftable>();
    private List<GameObject> selected = new List<GameObject>();

    public void EnterCraftMode()
    {
        selected.Clear();
        items = GetComponentsInChildren<ICraftable>().ToList();
        Debug.Log(items.Count);
        foreach (var item in items)
        {
            var button = ((MonoBehaviour)item)?.gameObject.AddComponent<Button>();
            button.onClick.AddListener(() => { Select(button.gameObject); });
        }
    }

    private void Select(GameObject obj)
    {
        if (selected.Contains(obj))
        {
            selected.Remove(obj);
            obj.GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            selected.Add(obj);
            obj.GetComponentInChildren<Image>().color = new Color(1, 0.5f, 0.5f, 0.7f);
        }

        CheckCombo();
    }

    private void CheckCombo()
    {
        List<string> selectednames = new List<string>();
        foreach (var item in selected)
        {
            var name = item.GetComponent<ICraftable>().Name;
            selectednames.Add(name);
        }

        foreach (var combo in craftSettings.combinations)
        {
            if (combo.sources.SequenceEqual(selectednames))
            {
                Debug.Log("Combo found");
                foreach (var item in selected)
                {
                    Destroy(item);
                }
                var newitem = Instantiate(combo.result, inventoryContent.transform);
            }
        }
    }
}
