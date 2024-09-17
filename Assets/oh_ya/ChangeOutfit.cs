using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    // そ跑计ノ传借
    public Renderer Rhand_change;
    public Material newRhandMaterial;

    public Renderer Lhand_change;
    public Material newLhandMaterial;

    public Renderer waist_change;
    public Material newWaistMaterial;

    public Renderer R_leg_change;
    public Material newRLegMaterial;

    public Renderer L_leg_change;
    public Material newLLegMaterial;

    // そ跑计ノ埃ン
    public Transform head1Transform; // ヘ夹本更ンlegorun/nurbsCircle2/main/waist/neck/head/head1

    // Prefabノ龟ㄒて穝ン︾/皌ン
    public GameObject newPrefab;       // ︾ Prefab
    public GameObject accessoryPrefab; // 皌ン Prefab
    public GameObject headgearPrefab;  // 繷帛 Prefab

    // そ跑计北穝ン竚
    public Vector3 clothingPosition = new Vector3(0, -0.012f, 0);
    public Vector3 accessoryPosition = new Vector3(0, -0.012f, 0);
    public Vector3 headgearPosition = new Vector3(0, -0.012f, 0);

    // 翴阑秙秸ノよ猭
    public void WhenSelect()
    {
        // 埃 head1Transform ┏┮Τン
        if (head1Transform != null)
        {
            foreach (Transform child in head1Transform)
            {
                Destroy(child.gameObject);
            }
        }

        // 传も借
        if (Rhand_change != null && newRhandMaterial != null)
        {
            Rhand_change.material = newRhandMaterial;
        }

        // 传オも借
        if (Lhand_change != null && newLhandMaterial != null)
        {
            Lhand_change.material = newLhandMaterial;
        }

        // 传竬场借
        if (waist_change != null && newWaistMaterial != null)
        {
            waist_change.material = newWaistMaterial;
        }

        // 传籐借
        if (R_leg_change != null && newRLegMaterial != null)
        {
            R_leg_change.material = newRLegMaterial;
        }

        // 传オ籐借
        if (L_leg_change != null && newLLegMaterial != null)
        {
            L_leg_change.material = newLLegMaterial;
        }

        // 龟ㄒて本更穝︾ン
        if (newPrefab != null && head1Transform != null)
        {
            GameObject newObject = Instantiate(newPrefab, head1Transform);
            newObject.transform.localPosition = clothingPosition;  // ㄏノそ跑计ㄓ北︾竚
        }

        // 龟ㄒて本更皌ンン
        if (accessoryPrefab != null && head1Transform != null)
        {
            GameObject newAccessory = Instantiate(accessoryPrefab, head1Transform);
            newAccessory.transform.localPosition = accessoryPosition; // ㄏノそ跑计ㄓ北皌ン竚
        }

        // 龟ㄒて本更繷帛ン
        if (headgearPrefab != null && head1Transform != null)
        {
            GameObject newHeadgear = Instantiate(headgearPrefab, head1Transform);
            newHeadgear.transform.localPosition = headgearPosition; // ㄏノそ跑计ㄓ北繷帛竚
        }
    }
}
