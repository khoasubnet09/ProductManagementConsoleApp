using System.Runtime.InteropServices;
using Newtonsoft.Json;
class QuanLySanPham
{
    private List<SanPham> danhSachSanPham = new List<SanPham>();

    public QuanLySanPham()
    {
        ReadDataFromJSON();
    }

    public void ThemSanPham()
    {
        System.Console.WriteLine("Chọn loại sản phẩm: ");
        System.Console.WriteLine("1. Điện tử");
        System.Console.WriteLine("2. Thời trang");
        System.Console.WriteLine("3. Thực phẩm");

        System.Console.Write("Lựa chọn: ");

        int employeeType =  int.Parse(System.Console.ReadLine() ?? "0");

        switch(employeeType)
        {
            case 1:
            ThemSanPhamDienTu();
            break;

            case 2:
            ThemSanPhamThoiTrang();
            break;

            case 3:
            ThemSanPhamThucPham();
            break;

            default:
            System.Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn nhân viên thích hợp!");
            break;
        }
    }

    private void ThemSanPhamDienTu()
    {
        System.Console.Write("Nhập mã sản phẩm: ");
        string maSP = System.Console.ReadLine() ?? "";

        System.Console.Write("Nhập tên sản phẩm: ");
        string tenSP = System.Console.ReadLine() ?? "";

        System.Console.Write("Nhập giá gốc: ");
        double giaGocSP = double.Parse(System.Console.ReadLine() ?? "");

        System.Console.Write("Nhập thuế bảo hành: ");
        double thueBaoHanh = double.Parse(System.Console.ReadLine() ?? "");

        DienTu dt = new DienTu(maSP, tenSP, giaGocSP, thueBaoHanh);

        dt.TinhGiaBan();


        if(KiemTraSanPhamTonTai(maSP))
        {
            System.Console.WriteLine("Mã sản phẩm đã tồn tại. Vui lòng nhập lại mã hợp lệ!");
            return;
        }
        danhSachSanPham.Add(dt);
        LuuDuLieuVaoJSON();
    }

    private void ThemSanPhamThoiTrang()
    {
        System.Console.Write("Nhập mã sản phẩm: ");
        string maSP = System.Console.ReadLine() ?? "";

        System.Console.Write("Nhập tên sản phẩm: ");
        string tenSP = System.Console.ReadLine() ?? "";

        System.Console.Write("Nhập giá gốc: ");
        double giaGocSP = double.Parse(System.Console.ReadLine() ?? "");

        System.Console.Write("Nhập giảm giá (%): ");
        double giamGia = double.Parse(System.Console.ReadLine() ?? "");

        ThoiTrang tt = new ThoiTrang(maSP, tenSP, giaGocSP, giamGia);

        tt.TinhGiaBan();
        
        if(KiemTraSanPhamTonTai(maSP))
        {
            System.Console.WriteLine("Mã sản phẩm đã tồn tại. Vui lòng nhập lại mã hợp lệ!");
            return;
        }
        danhSachSanPham.Add(tt);
        LuuDuLieuVaoJSON();
    }

    private void ThemSanPhamThucPham()
    {
        System.Console.Write("Nhập mã sản phẩm: ");
        string maSP = System.Console.ReadLine() ?? "";

        System.Console.Write("Nhập tên sản phẩm: ");
        string tenSP = System.Console.ReadLine() ?? "";

        System.Console.Write("Nhập giá gốc: ");
        double giaGocSP = double.Parse(System.Console.ReadLine() ?? "");

        System.Console.Write("Nhập phí vận chuyển: ");
        double phiVanChuyen = double.Parse(System.Console.ReadLine() ?? "");

        ThucPham tp = new ThucPham(maSP, tenSP, giaGocSP, phiVanChuyen);

        tp.TinhGiaBan();
        
        if(KiemTraSanPhamTonTai(maSP))
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Mã sản phẩm đã tồn tại. Vui lòng nhập lại mã hợp lệ!");
            System.Console.ResetColor();
            return;
        }
        danhSachSanPham.Add(tp);
        LuuDuLieuVaoJSON();
    }

    private bool KiemTraSanPhamTonTai(string maSP)
    {
        return danhSachSanPham.Any(sp => sp.MaSP == maSP);
    }

    public void HienThiDanhSachSanPham()
    {
        System.Console.WriteLine("Danh sách sản phẩm: ");
        foreach(var ds in danhSachSanPham)
        {
            ds.HienThiThongTin();
        }
    }

    public void TinhTongDoanhThu()
    {
        double tongDoanhThu = 0;
        
        foreach(SanPham sp in danhSachSanPham)
        {
            tongDoanhThu += sp.TinhGiaBan();
        }
        
        System.Console.WriteLine($"Tổng doanh thu dự kiến: {tongDoanhThu} VND");
    }

    public void XoaSanPham()
    {
        System.Console.Write("Nhập mã sản phẩm muốn xóa: ");

        string maSP = System.Console.ReadLine() ?? "";

        SanPham? sp = danhSachSanPham.Find(e => e.MaSP == maSP);

        if(sp != null)
        {
            danhSachSanPham.Remove(sp);
            System.Console.WriteLine($"Remove sản phẩm {sp.TenSP} successfully!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Không tồn tại mã sản phẩm!");
            System.Console.ResetColor();
        }
    }

    private void LuuDuLieuVaoJSON()
    {
        var json = JsonConvert.SerializeObject(danhSachSanPham, Formatting.Indented, 
        new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        File.WriteAllText("SanPham.json", json);
    }

    /* private void ReadDataFromJSON()
    {
        string docDuLieuTuJSON = File.ReadAllText("SanPham.json");

        // Convert JSON to List
        danhSachSanPham = JsonConvert.DeserializeObject<List<SanPham>>(docDuLieuTuJSON,
        new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        }) ?? new List<SanPham>();
    } */

    private void ReadDataFromJSON()
    {
        if(File.Exists("SanPham.json"))
        {
            string docDuLieuTuJSON = File.ReadAllText("SanPham.json");

            danhSachSanPham =
                JsonConvert.DeserializeObject<List<SanPham>>
                (
                    docDuLieuTuJSON,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }
                ) ?? new List<SanPham>();
        }
        else
        {
            danhSachSanPham = new List<SanPham>();
        }
    }
}