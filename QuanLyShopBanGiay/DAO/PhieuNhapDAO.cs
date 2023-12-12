using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class PhieuNhapDAO
    {
        Modify modify = new Modify();

        public PhieuNhapDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from PhieuNhap";

            return modify.Table(sql);
        }

        public List<PhieuNhap> GetList()
        {
            List<PhieuNhap> listPhieuNhap = new List<PhieuNhap>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                PhieuNhap newPhieuNhap = new PhieuNhap
                {
                    MaPhieuNhap = row["MaPhieuNhap"].ToString(),
                    MaNhanVien = row["MaNhanVien"].ToString(),
                    date = DateTime.Parse(row["NgayNhap"].ToString()),
                    TongCong = float.Parse(row["TongCong"].ToString()),
                    status = int.Parse(row["status"].ToString()),

                };

                listPhieuNhap.Add(newPhieuNhap);
            }

            return listPhieuNhap;
        }


        public void Add(PhieuNhap PhieuNhap)
        {
            string sql = $"INSERT INTO PhieuNhap VALUES( '{PhieuNhap.MaPhieuNhap}','{PhieuNhap.MaNhanVien}','{PhieuNhap.date}',{PhieuNhap.TongCong},{PhieuNhap.status})";
            modify.Command(sql);
        }

        public void Edit(PhieuNhap PhieuNhap, string PhieuNhapId)
        {
            string sql = $"UPDATE PhieuNhap SET [status] = {PhieuNhap.status}  WHERE id = '{PhieuNhapId}'";
            modify.Command(sql);
        }
    }
}
