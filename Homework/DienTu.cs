class DienTu : SanPham
{
    public double ThueBaoHanh { get; private set; }
    public DienTu(string maSP, string tenSP, double giaGocSP, double thueBaoHanh) : base(maSP, tenSP, giaGocSP)
    {
        ThueBaoHanh = thueBaoHanh;
    }

    public override double TinhGiaBan()
    {
        return GiaGocSP + (GiaGocSP * ThueBaoHanh / 100);
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        System.Console.WriteLine($" - Giá bán: {TinhGiaBan()} VND");
    }
}