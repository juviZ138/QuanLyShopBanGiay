using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class SoLuongDAO
    {
        Modify modify = new Modify();

        public SoLuongDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from soLuong";

            return modify.Table(sql);
        }

        public List<SoLuong> GetList()
        {
            List<SoLuong> listSoLuong = new List<SoLuong>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                SoLuong newSoLuong = new SoLuong
                {
                    MaSP = row["product"].ToString(),
                    MaSize = row["size"].ToString(),
                    soLuong = int.Parse(row["quantity"].ToString()),

                };

                listSoLuong.Add(newSoLuong);
            }

            return listSoLuong;
        }


        public void Add(SoLuong SoLuong)
        {
            string sql = $"INSERT INTO SoLuong VALUES( '{SoLuong.MaSP}','{SoLuong.MaSize}','{SoLuong.soLuong}')";
            modify.Command(sql);
        }

        public void Edit(SoLuong SoLuong, string SoLuongId)
        {
            string sql = $"UPDATE SoLuong SET [product] = '{SoLuong.MaSP}' ,[size] = '{SoLuong.MaSize}',[quantity] = {SoLuong.soLuong}  WHERE product = '{SoLuongId}' and size = '{SoLuong.MaSize}'";
            modify.Command(sql);
        }


        public void Delete(string SoLuongId)
        {
            string sql = $"DELETE FROM SoLuong WHERE id = '{SoLuongId}'";
            modify.Command(sql);
        }
    }
}
