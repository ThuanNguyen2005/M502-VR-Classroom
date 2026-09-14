using UnityEngine;

public class CongTacDien : MonoBehaviour, IInteractable
{
    [Header("Danh sach bong den trong phong")]
    public Light[] danhSachDenRoiSan;

    [Header("Vat lieu phat sang cua mang den")]
    public Material vatLieuMangDen;
    
    [ColorUsage(true, true)]
    public Color mauKhiBatDen = Color.white * 3f;
    public Color mauKhiTatDen = Color.black;

    [Header("Trang thai hoat dong")]
    public bool dangBatDen = true;

    void Start()
    {
        CapNhatTrangThaiDen();
    }

    public string GetInteractPrompt()
    {
        return dangBatDen ? "[F] Tat he thong den" : "[F] Bat he thong den";
    }

    public void Interact()
    {
        dangBatDen = !dangBatDen;
        CapNhatTrangThaiDen();
    }

    private void CapNhatTrangThaiDen()
    {
        if (danhSachDenRoiSan != null)
        {
            foreach (Light bongDen in danhSachDenRoiSan)
            {
                if (bongDen != null) bongDen.enabled = dangBatDen;
            }
        }

        if (vatLieuMangDen != null)
        {
            if (dangBatDen)
            {
                vatLieuMangDen.EnableKeyword("_EMISSION");
                vatLieuMangDen.SetColor("_EmissionColor", mauKhiBatDen);
            }
            else
            {
                vatLieuMangDen.SetColor("_EmissionColor", mauKhiTatDen);
                vatLieuMangDen.DisableKeyword("_EMISSION");
            }
        }
    }
}