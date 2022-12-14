using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Manager_Hotel.ClassLoin
{
    class Modify
    {
        public Modify()
        {
        }
        SqlCommand sqlCommand;
        SqlConnection connection;
        SqlDataAdapter sqlDataAdapter=new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader dataReader; // doc dL trong ban

        public List<TaiKhoan> TaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while(dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)) ) ;
                }
                sqlConnection.Close();
            }
            return taiKhoans;
        }
        public void Command(string squery) // dùng để đăng ký tài khoản
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(squery, sqlConnection);
                sqlCommand.ExecuteNonQuery(); // thực thi câu truy vấn
                sqlConnection.Close();
            }
        }
        public void loaddataTable(DataGridView BangNV,String query)
        {
            sqlCommand = connection.CreateCommand();//load dữ liệu lên ,tạo xử lý kết nối
            sqlCommand.CommandText = query;//liên kết from nhân viên
            sqlDataAdapter.SelectCommand = sqlCommand;
            table.Clear();
            sqlDataAdapter.Fill(table);
            BangNV.DataSource = table;
            //sqlCommand.ExecuteNonQuery(); // thực thi câu truy vấn

        }
        //Dùng hiển thị trên data gird view : thêm , xóa ,sửa
        public void conTable(String queryTable,String query, DataGridView Bang)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = query;
                sqlCommand.ExecuteNonQuery();
                loaddataTable(Bang, queryTable);
                sqlConnection.Close();
            }
        }


        public void OpenConnection()
        {
            connection=Connection.GetSqlConnection();
            connection.Open();
        }
    }
    
  
}
