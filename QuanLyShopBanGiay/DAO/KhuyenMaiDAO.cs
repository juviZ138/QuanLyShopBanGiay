using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyShopBanGiay.DAO
{
    public class KhuyenMaiDAO
    {
        Modify modify = new Modify();

        public KhuyenMaiDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from KhuyenMai";

            return modify.Table(sql);
        }

        public List<KhuyenMai> GetList()
        {
            List<KhuyenMai> listKhuyenMai = new List<KhuyenMai>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                KhuyenMai newKhuyenMai = new KhuyenMai
                {
                    MaKM = row["id"].ToString(),
                    TenKM = row["name"].ToString(),
                    PhanTramGiam = float.Parse(row["phanTramGiam"].ToString()),
                    value = float.Parse(row["value"].ToString()),
                    status = int.Parse(row["status"].ToString()),

                };

                listKhuyenMai.Add(newKhuyenMai);
            }

            return listKhuyenMai;
        }


        public void Add(KhuyenMai KhuyenMai)
        {
            string sql = $"INSERT INTO KhuyenMai VALUES( '{KhuyenMai.MaKM}',N'{KhuyenMai.TenKM}',{KhuyenMai.PhanTramGiam},{KhuyenMai.value},{KhuyenMai.status})";
            modify.Command(sql);
        }

        public void Edit(KhuyenMai KhuyenMai, string KhuyenMaiId)
        {
            string sql = $"UPDATE KhuyenMai SET [id] = '{KhuyenMai.MaKM}' ,[name] = N'{KhuyenMai.TenKM}',[phanTramGiam] = {KhuyenMai.PhanTramGiam}, [value] = {KhuyenMai.value}, [status] = {KhuyenMai.status} WHERE id = '{KhuyenMaiId}'";
            modify.Command(sql);
        }


        public void Delete(string KhuyenMaiId)
        {
            string sql = $"DELETE FROM KhuyenMai WHERE id = '{KhuyenMaiId}'";
            modify.Command(sql);
        }
    }
}
