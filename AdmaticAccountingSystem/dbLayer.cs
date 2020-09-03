using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AdmaticAccountingSystem
{
    public class dbLayer
    {
        public static string DBConnection()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["admaticEntities"];
            string connection = settings.ConnectionString;
            var builder = new EntityConnectionStringBuilder(connection);
            string regularConnectionString = builder.ProviderConnectionString;
            return regularConnectionString;
        }
        public static int MusteriTahsilatEkle(int FirmaID, decimal TahsilatTutar, int HesapID, string Aciklama, string TahsilatTipi, DateTime TahsilatTarihi, DateTime? TahsilatVadeTarihi)
        {
            using (admaticEntities con = new admaticEntities())
            {
                try
                {
                    int result;
                    con.Database.Connection.Open();
                    var command = con.Database.Connection.CreateCommand();
                    command.CommandText = "MusteriTahsilatEkle";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@FirmaID", FirmaID));
                    command.Parameters.Add(new SqlParameter("@TahsilatTutar", TahsilatTutar));
                    command.Parameters.Add(new SqlParameter("@HesapID", HesapID));
                    command.Parameters.Add(new SqlParameter("@Aciklama", Aciklama));
                    command.Parameters.Add(new SqlParameter("@TahsilatTipi", TahsilatTipi));
                    command.Parameters.Add(new SqlParameter("@TahsilatTarihi", TahsilatTarihi));
                    if (TahsilatVadeTarihi.HasValue)
                    {
                        command.Parameters.Add(new SqlParameter("@TahsilatVadeTarihi", TahsilatVadeTarihi.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@TahsilatVadeTarihi", DBNull.Value));
                    }

                    command.CommandTimeout = 600;
                    result = Convert.ToInt32(command.ExecuteScalar());
                    con.Database.Connection.Close();
                    return result;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }

        public static DataSet VadesiGelenMusteri(int FirmaID)
        {
            using (admaticEntities con = new admaticEntities())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(DBConnection());
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "VadesiGelenMusteri";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@FirmaID", FirmaID));
                    command.CommandTimeout = 600;
                    da.SelectCommand = command;
                    DataSet ds = new DataSet();

                    conn.Open();
                    da.Fill(ds);
                    conn.Close();

                    return ds;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static DataSet MusteriTahsilatNakitCekOdeme(int FirmaID)
        {
            using (admaticEntities con = new admaticEntities())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(DBConnection());
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "MusteriTahsilatNakitCekOdeme";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@FirmaID", FirmaID));
                    command.CommandTimeout = 600;
                    da.SelectCommand = command;
                    DataSet ds = new DataSet();

                    conn.Open();
                    da.Fill(ds);
                    conn.Close();

                    return ds;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static DataTable MusterileriGetir()
        {
            using (admaticEntities con = new admaticEntities())
            {
                try
                {
                    DataTable dtTransactions = new DataTable();
                    con.Database.Connection.Open();
                    var command = con.Database.Connection.CreateCommand();
                    command.CommandText = "MusterileriGetir";
                    dtTransactions.Load(command.ExecuteReader());
                    con.Database.Connection.Close();
                    return dtTransactions;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static DataTable FaturalariGetir()
        {
            using (admaticEntities con = new admaticEntities())
            {
                try
                {
                    DataTable dtTransactions = new DataTable();
                    con.Database.Connection.Open();
                    var command = con.Database.Connection.CreateCommand();
                    command.CommandText = "FaturalariGetir";
                    dtTransactions.Load(command.ExecuteReader());
                    con.Database.Connection.Close();
                    return dtTransactions;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
