using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MaterialsChanger : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private Material[] materialsToChange;
    private Dictionary<Renderer, Material[]> defaultMaterials;
    private bool isChange = false;
    private int index = 0;
    private CharacterHealth characterHealth;

    private void Start()
    {
        defaultMaterials = new Dictionary<Renderer, Material[]>();
        if (renderers == null || renderers.Length == 0) renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            Renderer iMeshRenderer = renderers[i];
            defaultMaterials.Add(iMeshRenderer, iMeshRenderer.materials.Clone() as Material[]);
        }
        characterHealth = GetComponent<CharacterHealth>();
        characterHealth.OnDeath.AddListener(() => { Invoke(nameof(SetDissolveMaterial), 5f); });
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
    private void SetDissolveMaterial()
    {
        Material[] materials = SetMaterial(0);
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].DOFloat(1f, "Dissolve", 5f);
        }
    }

    private Material[] SetMaterial(int index)
    {
        Material[] materials = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = materialsToChange[index];
            materials[i] = renderers[i].material;
        }
        return materials;
    }
}
