using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class CTPhieuNhapDAO
    {
        Modify modify = new Modify();

        public CTPhieuNhapDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from CTPhieuNhap";

            return modify.Table(sql);
        }

        public List<CTPhieuNhap> GetList()
        {
            List<CTPhieuNhap> listCTPhieuNhap = new List<CTPhieuNhap>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                CTPhieuNhap newCTPhieuNhap = new CTPhieuNhap
                {
                    MaPhieuNhap = row["MaPhieuNhap"].ToString(),
                    MaSP = row["MaSanPham"].ToString(),
                    MaSize = row["MaSize"].ToString(),
                    GiaNhap =  float.Parse(row["GiaNhap"].ToString()),
                    soLuong = int.Parse(row["SoLuong"].ToString()),

                };

                listCTPhieuNhap.Add(newCTPhieuNhap);
            }

            return listCTPhieuNhap;
        }


        public void Add(CTPhieuNhap CTPhieuNhap)
        {
            string sql = $"INSERT INTO CTPhieuNhap VALUES( '{CTPhieuNhap.MaPhieuNhap}','{CTPhieuNhap.MaSP}','{CTPhieuNhap.MaSize}',{CTPhieuNhap.GiaNhap},{CTPhieuNhap.soLuong})";
            modify.Command(sql);
        }

        //public void Edit(CTPhieuNhap CTPhieuNhap, string CTPhieuNhapId)
        //{
        //    string sql = $"UPDATE CTPhieuNhap SET [quanity] = {CTPhieuNhap.soLuong}  WHERE id = '{CTPhieuNhapId}'";
        //    modify.Command(sql);
        //}


        //public void Delete(string CTPhieuNhapId)
        //{
        //    string sql = $"DELETE FROM CTPhieuNhap WHERE id = '{CTPhieuNhapId}'";
        //    modify.Command(sql);
        //}
    }
}
