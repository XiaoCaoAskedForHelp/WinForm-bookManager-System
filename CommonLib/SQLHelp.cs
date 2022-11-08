using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;



/// <summary>
///SQLHelp 的摘要说明
/// </summary>
/// 
[Serializable]
public  class SQLHelp  
{

    #region 属性
    private SqlConnection _Connection = null;
    private SqlTransaction _Transaction = null;
    private SqlCommand _Command = null;
    public Exception ex;
    public SqlConnection Connection
    {
        get
        {
            if(_Connection==null)
            {

            }
            return _Connection;
        }
        set
        {
            _Connection = value;
        }
    }
    public SqlCommand Command
    {
        get
        {
            return _Command;
        }
        set
        {
            _Command = value;
        }
    }

    public SqlTransaction Transaction
    {
        get
        {
            return _Transaction;
        }
        set
        {
            _Transaction = value;
        }
    }
    #endregion
    #region 构造函数
    public SQLHelp()
    {
        string connstr = "";
        try
        {
            connstr = GetConnString();
            Connection = new SqlConnection(connstr);
            Connection.Open();
            Load();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public SQLHelp(string connStr)
    {
        try
        {
            Connection = new SqlConnection(connStr);
            Connection.Open();
            Load();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public SQLHelp(SqlConnection conn)
    {
        try
        {
            Connection = conn;
            Connection.Open();
            Load();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    #endregion
    #region 内部方法
    internal void Load()
    {

        if (Command != null) Command.Dispose();
        Command = Connection.CreateCommand();
        Command.CommandText = "set ansi_warnings off";
        Command.ExecuteNonQuery();
    }

    public void Close()
    {
       // this.Dispose(true);
    }

    internal string PrepareSql(string strSql)
    {
        return strSql;
    }
    internal void SetParameters(SqlCommand cmd, params object[] Params)
    {
        cmd.Parameters.Clear();
        for (int i = 0; i < Params.GetLength(0); i++)
        {
            object param = Params[i];
            switch (param.GetType().ToString())
            {
                case "System.Float":
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.Float).Value = (double)param;
                    break;
                case "System.String":
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.NChar, (param as string).Length).Value = param as string;
                    break;
                case "System.Int32":
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.Int).Value = (int)param;
                    break;
                case "System.DateTime":
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.DateTime).Value = (DateTime)param;
                    break;
                case "System.Byte[]":
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.Image).Value = (byte[])param;
                    break;
                case "System.Decimal":
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.Decimal).Value = (Decimal)param;
                    break;
                default:
                    string temp = param.ToString();
                    cmd.Parameters.Add(string.Format("@p{0}", i + 1), SqlDbType.VarChar, temp.Length).Value = temp;
                    break;
            }
        }
    }
    #endregion
    #region 事务处理
    public void BeginTransaction()
    {
        Transaction = Connection.BeginTransaction();
        Command.Transaction = Transaction;
    }
    public void Commit()
    {
        Transaction.Commit();
        Transaction = null;
    }
    public void Rollback()
    {
        Transaction.Rollback();
        Transaction = null;
    }
    #endregion
    #region SQL方法
    public int Count(string strSql, params object[] Params)
    {
        SqlDataReader reader = ExecuteReader(strSql, Params);
        reader.Read();
        string ret = reader[0].ToString().Trim();
        reader.Close();
        return int.Parse(ret);
    }
    public SqlDataReader ExecuteReader(string strSql, params object[] Params)
    {
        strSql = PrepareSql(strSql);
        Command.CommandText = strSql;
        SetParameters(Command, Params);
        return Command.ExecuteReader();
    }
    public int ExecuteNoQuery(string strSql, params object[] Params)
    {
        strSql = PrepareSql(strSql);
        Command.CommandText = strSql;
        SetParameters(Command, Params);
        int ret  = Command.ExecuteNonQuery();
        return ret;
    }
    public object ExecuteScalar(string strSql, params object[] Params)
    {
        strSql = PrepareSql(strSql);
        Command.CommandText = strSql;
        SetParameters(Command, Params);
        return Command.ExecuteScalar();
    }
    public int GetIdentity()
    {
        string strSql = "select  SCOPE_IDENTITY()  as id";
        return (int)ExecuteScalar(strSql);
    }
    public bool ColumnExists(string tableName,string columnName)
    {
        string strSql = "select count(*) from  syscolumns c join sysobjects o on c.id = o.id " +
           " where o.type='u' and  o.name =@p1  and c.name=@p2";
        int i = Count(strSql, tableName, columnName);
        return i > 0 ? true : false;
    }

    public bool TableExists(string tableName)
    {
        string strSql = "select count(*) from  sysobjects o where  o.name =@p1 ";
        int i = Count(strSql, tableName );
        return i > 0 ? true : false;
    }


    public DataTable FillDataTable(string strSql, params object[] Params)
    {
        try
        {
            DataTable dt = new DataTable();
            strSql = PrepareSql(strSql);
            SqlDataAdapter sda = new SqlDataAdapter(strSql, Connection);
            sda.SelectCommand.Transaction = Transaction;
            SetParameters(sda.SelectCommand, Params);
            //Console.WriteLine(strSql);
            sda.Fill(dt);
            sda.Dispose();
            return dt;
        }
        catch(Exception x)
        {
            ex = x;
            return null;
        }
    }

    public SqlDataAdapter FillDataTable1(string strSql, params object[] Params)
    {
        try
        {
            DataTable dt = new DataTable();
            strSql = PrepareSql(strSql);
            SqlDataAdapter sda = new SqlDataAdapter(strSql, Connection);
            sda.SelectCommand.Transaction = Transaction;
            SetParameters(sda.SelectCommand, Params);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            //sda.Fill(dt);
            //Console.WriteLine(dt.ToString());
            //sda.Dispose();
            return sda;
        }
        catch (Exception x)
        {
            ex = x;
            return null;
        }
    }

    public int FillDataSet(DataSet ds, string name, int from, int size, string strSql, params object[] Params)
    {
        strSql = PrepareSql(strSql);
        SqlDataAdapter ada = new SqlDataAdapter(strSql, Connection);
        ada.SelectCommand.Transaction = Transaction;
        SetParameters(ada.SelectCommand, Params);
        return ada.Fill(ds, from, size, name);
    }
    public int FillDataSet(DataSet ds, string strSql, params object[] Params)
    {
        return FillDataSet(ds, ds.Tables.Count.ToString(), 0, 0, strSql, Params);
    }
    #endregion
    /// <summary>
    /// 析构函数
    /// </summary>
    ~SQLHelp()
    {
        try { 
        if (this.Connection !=null)
        {
            this.Connection.Close();
        }
        }
        catch
        {

        }
        //Dispose(false);
    }


    /// <summary>
    /// 获取链接字符串,静态方法
    /// </summary>
    /// <returns></returns>
    public static string GetConnString()
    {
        try
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
        }
        catch
        {
            return "";
        }
    }
  
    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        // Release managed resources.
    //        try
    //        {
    //            if (Command != null)
    //            {
    //                Command.Dispose();
    //            }
    //            if (Connection != null)
    //            {
    //                Connection.Close();
    //                Connection.Dispose();
    //            }
    //            if (Transaction != null)
    //            {
    //                Transaction.Commit();
    //                Transaction.Dispose();
    //            }
    //        }
    //        catch
    //        { }
    //    }
    //    // Release unmanaged resources.
    //    // Set large fields to null.
    //    // Call Dispose on your base class.
    //   // base.Dispose(disposing);
    //}
}




