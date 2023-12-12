using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class SizeDAO
    {
        Modify modify = new Modify();

        public SizeDAO()
        {

        }


        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from size";

            return modify.Table(sql);
        }

        public List<SizeProduct> GetList()
        {
            List<SizeProduct> listSize = new List<SizeProduct>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                SizeProduct newSize = new SizeProduct
                {
                    SizeId = row["id"].ToString(),
                    SizeName = row["name"].ToString(),
                    status = int.Parse(row["status"].ToString()),

                };

                listSize.Add(newSize);
            }

            return listSize;
        }


        public void Add(SizeProduct Size)
        {
            string sql = $"INSERT INTO size VALUES('{Size.SizeId}','{Size.SizeName}','{Size.status}')";
            modify.Command(sql);
        }

        public void Edit(SizeProduct Size, string SizeId)
        {
            string sql = $"UPDATE size SET [id] = '{Size.SizeId}' ,[name] = '{Size.SizeName}',[status] = {Size.status}  WHERE id = '{SizeId}'";
            modify.Command(sql);
        }


        public void Delete(string SizeId)
        {
            string sql = $"DELETE FROM size WHERE id = '{SizeId}'";
            modify.Command(sql);
        }
    }

 }
