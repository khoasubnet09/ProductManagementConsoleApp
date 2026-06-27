using System.Runtime.InteropServices;
using System.Text;

namespace B13
{
    class Program
    {
        static void Main(string[] args)
        {
            /* SanPham sp1 = new DienTu("SP01", "Laptop Asus", 15000000, 0.08);
            sp1.HienThiThongTin();

            SanPham sp2 = new ThoiTrang("SP02", "Ao khoac", 2345000, Season.Mùa_Đông);
            sp2.HienThiThongTin();

            SanPham sp3 = new ThucPham("SP03", "Ao khoac", 179000, 40000);
            sp3.HienThiThongTin(); */

            // Update code online leanring GitHub
            
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            bool isRunning = true;

            QuanLySanPham qlsp = new QuanLySanPham();

            while(isRunning)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("=== Hệ thống quản lý bán hàng ===");
                System.Console.WriteLine("1. Thêm sản phẩm");
                System.Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                System.Console.WriteLine("3. Tính tổng doanh thu");
                System.Console.WriteLine("4. Xóa sản phẩm");
                System.Console.WriteLine("5. Thoát");

                System.Console.Write("Vui lòng chọn chức năng: ");

                // int choice = int.Parse(System.Console.ReadLine() ?? "0");
                if(!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Vui lòng nhập số từ 1 đến 5.");
                    System.Console.ResetColor();
                    continue;
                }

                switch(choice)
                {
                    case 1:
                    qlsp.ThemSanPham();
                    break;

                    case 2:
                    System.Console.WriteLine();
                    qlsp.HienThiDanhSachSanPham();
                    break;

                    case 3:
                    System.Console.WriteLine();
                    qlsp.TinhTongDoanhThu();
                    break;

                    case 4:
                    qlsp.HienThiDanhSachSanPham();
                    qlsp.XoaSanPham();
                    break;

                    case 5:
                    isRunning = false;
                    System.Console.WriteLine("Chương trình kết thúc. Cảm ơn bạn đã sử dụng hệ thống!");
                    break;

                    default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn option khác!");
                    System.Console.ResetColor();
                    break;
                }
            }
        }
    }
}
