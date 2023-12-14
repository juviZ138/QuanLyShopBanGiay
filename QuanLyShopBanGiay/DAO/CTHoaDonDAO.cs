using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class CTHoaDonDAO
    {
        Modify modify = new Modify();

        public CTHoaDonDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from bill_details";

            return modify.Table(sql);
        }

        public List<CTHoaDon> GetList()
        {
            List<CTHoaDon> listCTHoaDon = new List<CTHoaDon>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                CTHoaDon newCTHoaDon = new CTHoaDon
                {
                    MaHoaDon = row["bill_id"].ToString(),
                    MaSP = row["product_id"].ToString(),
                    MaSize = row["size_id"].ToString(),
                    soLuong = int.Parse(row["quantity"].ToString()),
                    GiaBan = float.Parse(row["price"].ToString()),

                };

                listCTHoaDon.Add(newCTHoaDon);
            }

            return listCTHoaDon;
        }


        public void Add(CTHoaDon CTHoaDon)
        {
            string sql = $"INSERT INTO bill_details VALUES( '{CTHoaDon.MaHoaDon}','{CTHoaDon.MaSP}','{CTHoaDon.MaSize}',{CTHoaDon.GiaBan},{CTHoaDon.soLuong})";
            modify.Command(sql);
        }
    }
}
