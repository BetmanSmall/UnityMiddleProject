using System.Collections.Generic;
using UnityEngine;

public class MaterialsChanger : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private Material[] materialsToChange;
    private Dictionary<Renderer, Material[]> defaultMaterials;
    private bool isChange = false;
    private int index = 0;

    private void Start()
    {
        defaultMaterials = new Dictionary<Renderer, Material[]>();
        if (renderers == null || renderers.Length == 0) renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            Renderer iMeshRenderer = renderers[i];
            defaultMaterials.Add(iMeshRenderer, iMeshRenderer.materials.Clone() as Material[]);
        }
    }
    public void ToggleMaterial()
    {
        ChangeMaterial(!isChange);
    }
    private void ChangeMaterial(bool isChange)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            if (isChange)
            {
                renderers[i].material = materialsToChange[index];
            }
            else
            {
                renderers[i].materials = defaultMaterials[renderers[i]];
            }
        }
        if (isChange)
        {
            index++;
            if (index >= materialsToChange.Length) index = 0;
        }
        this.isChange = isChange;
    }
}
