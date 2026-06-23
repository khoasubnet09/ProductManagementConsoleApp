class ThoiTrang : SanPham
{
    // public Season Season { get; private set; }
    public double GiamGia { get; private set; }

    public ThoiTrang(string maSP, string tenSP, double giaGocSP, double giamGia) : base(maSP, tenSP, giaGocSP)
    {
        // Season = season;
        GiamGia = giamGia;
    }

    /* private double DiscountRate()
    {
        double discountRate = 0;

        switch(Season)
        {
            case Season.Mùa_Xuân:
            discountRate = 0.10;
            break;

            case Season.Mùa_Hè:
            discountRate = 0.20;
            break;

            case Season.Mùa_Thu:
            discountRate = 0.15;
            break;

            case Season.Mùa_Đông:
            discountRate = 0.30;
            break;
        }

        return discountRate;
    } */

    public override double TinhGiaBan()
    {
        // return GiaGocSP - (GiaGocSP * DiscountRate());
        return GiaGocSP - (GiaGocSP * GiamGia / 100);
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        System.Console.WriteLine($" - Giá bán: {TinhGiaBan()} VND");
    }
}