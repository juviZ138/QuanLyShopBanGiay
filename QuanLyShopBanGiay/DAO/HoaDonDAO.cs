using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class HoaDonDAO
    {
        Modify modify = new Modify();

        public HoaDonDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from bill";

            return modify.Table(sql);
        }

        public List<HoaDon> GetList()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                HoaDon newHoaDon = new HoaDon
                {
                    MaHoaDon = row["id"].ToString(),
                    MaNhanVien = row["user_id"].ToString(),
                    MaKhachHang = row["customer_id"].ToString(),
                    date = DateTime.Parse(row["date"].ToString()),
                    MaKhuyenMai = row["promo_id"].ToString(),
                    TongCong = float.Parse(row["total"].ToString()),
                    status = int.Parse(row["status"].ToString()),

                };

                listHoaDon.Add(newHoaDon);
            }

            return listHoaDon;
        }


        public void Add(HoaDon HoaDon)
        {
            string sql = $"INSERT INTO bill VALUES( '{HoaDon.MaHoaDon}','{HoaDon.MaNhanVien}','{HoaDon.MaKhachHang}','{HoaDon.date}','{HoaDon.MaKhuyenMai}',{HoaDon.TongCong},{HoaDon.status})";
            modify.Command(sql);
        }

        public void Edit(HoaDon HoaDon, string HoaDonId)
        {
            string sql = $"UPDATE bill SET [status] = {HoaDon.status}  WHERE id = '{HoaDonId}'";
            modify.Command(sql);
        }
    }
}
