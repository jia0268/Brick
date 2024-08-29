using System.Diagnostics;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    [SerializeField]
    private Material _selectedMaterial;  // 這是按鈕對應的材質

    public void OnColorButtonClicked()
    {
        // 獲取當前選中的物件
        GameObject selectedObject = ToggleObject.SelectedObject;

        // 確保選中了一個物件
        if (selectedObject != null)
        {
            // 嘗試在所有子物件中找到 Renderer 組件
            Renderer[] renderers = selectedObject.GetComponentsInChildren<Renderer>();

            if (renderers.Length > 0)
            {
                foreach (Renderer renderer in renderers)
                {
                    // 獲取並更改所有材質
                    Material[] materials = renderer.materials;
                    for (int i = 0; i < materials.Length; i++)
                    {
                        materials[i] = _selectedMaterial;  // 將所有材質替換為選中的材質
                    }
                    renderer.materials = materials;  // 設置更新後的材質數組
                }
            }
            else
            {
            }
        }
        else
        {
        }
    }
}
