using Microsoft.Office.Interop.Excel;
using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formThongKe : Form
    {
        HoaDonBUS HoaDonBUS = new HoaDonBUS();
        PhieuNhapBUS PhieuNhapBUS = new PhieuNhapBUS();
        CTHoaDonBUS ctHoaDonBUS = new CTHoaDonBUS();
        CTPhieuNhapBUS ctPhieuNhapBUS = new CTPhieuNhapBUS();
        ProductBUS productBUS = new ProductBUS();
  
        public formThongKe()
        {
            InitializeComponent();
            rad1.Checked = true;
            cbTheoKhoang.SelectedIndex = 0;
            cbThang.SelectedIndex = 0;
            cbNam.SelectedIndex = 0;
            //List<HoaDon> listHD = HoaDonBUS.GetHoaDon();
            //List<PhieuNhap> listPN = PhieuNhapBUS.GetPhieuNhap();
            //ThongKe(listHD, listPN);
            //TopBanChay(listHD);
        }

        public List<HoaDon> getHoaDon(List<HoaDon> listPN, DateTime startDate, DateTime endDate)
        {
            var filteredInvoices = listPN.Where(i => i.date >= startDate && i.date <= endDate).ToList();

            // Hiển thị kết quả

            return listPN;

        }

        public List<PhieuNhap> getPhieuNhap(List<PhieuNhap> listPN, DateTime startDate, DateTime endDate)
        {
            var filteredInvoices = listPN.Where(i => i.date >= startDate && i.date <= endDate).ToList();

            // Hiển thị kết quả

            return listPN;

        }

        public void LoadHoaDon()
        {
            List<HoaDon> listHD = HoaDonBUS.GetHoaDon();
            List<PhieuNhap> listPN = PhieuNhapBUS.GetPhieuNhap();

            if (rad1.Checked)
            {
                if (cbTheoKhoang.SelectedIndex == 0)
                {
                    listHD = getHoaDon(listHD, DateTime.Now.AddDays(-1), DateTime.Now);
                    listPN = getPhieuNhap(listPN, DateTime.Now.AddDays(-1), DateTime.Now);
                }

                if (cbTheoKhoang.SelectedIndex == 1)
                {
                    listHD = getHoaDon(listHD, DateTime.Now.AddDays(-7), DateTime.Now);
                    listPN = getPhieuNhap(listPN, DateTime.Now.AddDays(-7), DateTime.Now);

                }

                if (cbTheoKhoang.SelectedIndex == 2)
                {
                    listPN = getPhieuNhap(listPN, DateTime.Now.AddMonths(-1), DateTime.Now);
                    listHD = getHoaDon(listHD, DateTime.Now.AddMonths(-1), DateTime.Now);
                }

                if (cbTheoKhoang.SelectedIndex == 3)
                {
                    listHD = getHoaDon(listHD, DateTime.Now.AddMonths(-6), DateTime.Now);
                    listPN = getPhieuNhap(listPN, DateTime.Now.AddMonths(-6), DateTime.Now);
                }
           
                if (cbTheoKhoang.SelectedIndex == 4)
                {
                    listHD = getHoaDon(listHD, DateTime.Now.AddYears(-1), DateTime.Now);
                    listPN = getPhieuNhap(listPN, DateTime.Now.AddYears(-1), DateTime.Now);
                }
                ThongKe(listHD, listPN);
                TopBanChay(listHD);
            }
            else
            {

                listHD = listHD.Where(i => i.date.Month == int.Parse(cbThang.Text) && i.date.Year <= int.Parse(cbNam.Text)).ToList();
                listPN = listPN.Where(i => i.date.Month == int.Parse(cbThang.Text) && i.date.Year <= int.Parse(cbNam.Text)).ToList();

                // Hiển thị kết quả
                ThongKe(listHD, listPN);
                TopBanChay(listHD);

            }
            
        }


        public void ThongKe(List<HoaDon> hd, List<PhieuNhap> pn)
        {
            float DoanhThu = 0;
            int soLuongProduct = 0;
            HashSet<string> uniqueCustomerCodes = new HashSet<string>();


            foreach ( HoaDon hoaDon in hd)
            {
                uniqueCustomerCodes.Add(hoaDon.MaKhachHang);
                DoanhThu += hoaDon.TongCong;
                List<CTHoaDon> listCTHD = ctHoaDonBUS.GetCTHoaDon(hoaDon.MaHoaDon);
                
                foreach (CTHoaDon ct in listCTHD)
                {
                    soLuongProduct += ct.soLuong;
                }

            }

            txtKH.Text = uniqueCustomerCodes.Count.ToString();
            txtDoanhThu.Text = DoanhThu.ToString();
            txtProduct.Text = soLuongProduct.ToString();


            float ChiTieu = 0;
            float soLuongNhap = 0;
            foreach (PhieuNhap hoaDon in pn)
            {
                ChiTieu += hoaDon.TongCong;
                List<CTPhieuNhap> listCTHD = ctPhieuNhapBUS.GetCTPhieuNhap(hoaDon.MaPhieuNhap);

                foreach (CTPhieuNhap ct in listCTHD)
                {
                    soLuongNhap += ct.soLuong;
                }

            }

            txtChiTieu.Text = ChiTieu.ToString();
            txtNhap.Text = soLuongNhap.ToString();

            float LoiNhuan = DoanhThu - ChiTieu;
            txtLoiNhuan.Text = LoiNhuan.ToString();

            
            if(LoiNhuan > 0)
            {
            int  phanTram = (int)Math.Round((DoanhThu / ChiTieu) * 100,2);
                lbLoiNhuan.Text = "Lãi " + phanTram.ToString() + " %";
            }
            else
            {
                int phanTram = (int)Math.Round((ChiTieu/ DoanhThu) * 100, 2);

                lbLoiNhuan.Text = "Lỗ " + phanTram.ToString() + " %";
            }

            if(DoanhThu == 0)
            {
                int phanTram = (int)Math.Round((ChiTieu) * 100, 2);

                lbLoiNhuan.Text = "Lỗ " + phanTram.ToString() + " %";
            }

            if(ChiTieu == 0)
            {
                int phanTram = (int)Math.Round((DoanhThu) * 100, 2);

                lbLoiNhuan.Text = "Lời " + phanTram.ToString() + " %";
            }


        }

        public void TopBanChay(List<HoaDon> hoaDons)
        {
            Dictionary<string, int> productSales = new Dictionary<string, int>();
            ProductBUS productBUS = new ProductBUS();

            foreach (var detail in hoaDons)
            {
                List<CTHoaDon> listCTHD = ctHoaDonBUS.GetCTHoaDon(detail.MaHoaDon);

                foreach (CTHoaDon ct in listCTHD)
                {
                    string key = productBUS.GetProducts().Find(p => p.ProductId == ct.MaSP)?.ProductName;
                    //string key = ct.MaSP;

                    if (productSales.ContainsKey(key))
                    {
                        productSales[key] += ct.soLuong;
                    }
                    else
                    {
                        productSales[key] = ct.soLuong;
                    }
                }
              

            }
            var topProducts = productSales.OrderByDescending(pair => pair.Value)
                                      .Take(5); // Lấy top 3 sản phẩm
            System.Windows.Forms.DataVisualization.Charting.Series series = chart1.Series[0];

            series.Points.Clear();
            foreach (var entry in topProducts)
            {
               series.Points.AddXY(entry.Key, entry.Value);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void rad1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

   


  
}
