abstract class SanPham
{
    public string MaSP { get; private set; }
    public string TenSP { get; private set; }
    public double GiaGocSP { get; private set; }

    public SanPham(string maSP, string tenSP, double giaGocSP)
    {
        MaSP = maSP;
        TenSP = tenSP;
        GiaGocSP = giaGocSP;
    }

    public abstract double TinhGiaBan();

    public virtual void HienThiThongTin()
    {
        System.Console.Write($"Mã: {MaSP} - Tên: {TenSP}");
    }
}