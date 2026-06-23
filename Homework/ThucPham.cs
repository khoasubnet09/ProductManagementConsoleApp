class ThucPham : SanPham
{
    public double PhiVanChuyen { get; private set; }

    public ThucPham(string maSP, string tenSP, double giaGocSP, double phiVanCHuyen) : base(maSP, tenSP, giaGocSP)
    {
        PhiVanChuyen = phiVanCHuyen;
    }

    public override double TinhGiaBan()
    {
        return GiaGocSP + PhiVanChuyen;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        System.Console.WriteLine($" - Giá bán: {TinhGiaBan()} VND");
    }
}