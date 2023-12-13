using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class KhachHangDAO
    {
        Modify modify = new Modify();

        public KhachHangDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from customer";

            return modify.Table(sql);
        }

        public List<KhachHang> GetList()
        {
            List<KhachHang> listKhachHang = new List<KhachHang>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                KhachHang newKhachHang = new KhachHang
                {
                    MaKH = row["id"].ToString(),
                    TenKH = row["name"].ToString(),
                    SDT = row["phone"].ToString(),
                    total = float.Parse(row["total"].ToString()),
                    point = int.Parse(row["point"].ToString()),

                };

                listKhachHang.Add(newKhachHang);
            }

            return listKhachHang;
        }


        public void Add(KhachHang KhachHang)
        {
            string sql = $"INSERT INTO customer VALUES( '{KhachHang.MaKH}',N'{KhachHang.TenKH}','{KhachHang.SDT}',{KhachHang.total},{KhachHang.point})";
            modify.Command(sql);
        }

        public void Edit(KhachHang KhachHang, string KhachHangId)
        {
            string sql = $"UPDATE customer SET [id] = '{KhachHang.MaKH}' ,[name] = N'{KhachHang.TenKH}',[phone] = '{KhachHang.SDT}',[total] = {KhachHang.total}, [point] = {KhachHang.point}  WHERE id = '{KhachHangId}'";
            modify.Command(sql);
        }

    }
}
