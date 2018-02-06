﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShopSystemEntity;

namespace ShopSystemDAL
{
	/// <summary>
	/// 数据访问类:OrderInfo
	/// </summary>
	public partial class OrderInfoDAL
	{
        private OrderInfoDAL()
        { }
        public static readonly OrderInfoDAL instance = new OrderInfoDAL();
        private readonly DbHelper _db = new DbHelper();
		#region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_OrderInfo");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            return _db.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_OrderInfo(");
            strSql.Append("Id,StockId,BuyNum,VipNumber,VipScore,OrderPrice,OrderRemark,Status,CreateBy,CreateDate,UpdateBy,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@Id,@StockId,@BuyNum,@VipNumber,@VipScore,@OrderPrice,@OrderRemark,@Status,@CreateBy,@CreateDate,@UpdateBy,@UpdateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@StockId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@BuyNum", SqlDbType.Int,4),
					new SqlParameter("@VipNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@VipScore", SqlDbType.Int,4),
					new SqlParameter("@OrderPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrderRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@Status", SqlDbType.VarChar,20),
					new SqlParameter("@CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.BuyNum;
            parameters[3].Value = model.VipNumber;
            parameters[4].Value = model.VipScore;
            parameters[5].Value = model.OrderPrice;
            parameters[6].Value = model.OrderRemark;
            parameters[7].Value = model.Status;
            parameters[8].Value = Guid.NewGuid();
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = Guid.NewGuid();
            parameters[11].Value = model.UpdateDate;

            int rows = _db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_OrderInfo set ");
            strSql.Append("StockId=@StockId,");
            strSql.Append("BuyNum=@BuyNum,");
            strSql.Append("VipNumber=@VipNumber,");
            strSql.Append("VipScore=@VipScore,");
            strSql.Append("OrderPrice=@OrderPrice,");
            strSql.Append("OrderRemark=@OrderRemark,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateBy=@CreateBy,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateBy=@UpdateBy,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@BuyNum", SqlDbType.Int,4),
					new SqlParameter("@VipNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@VipScore", SqlDbType.Int,4),
					new SqlParameter("@OrderPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrderRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@Status", SqlDbType.VarChar,20),
					new SqlParameter("@CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.StockId;
            parameters[1].Value = model.BuyNum;
            parameters[2].Value = model.VipNumber;
            parameters[3].Value = model.VipScore;
            parameters[4].Value = model.OrderPrice;
            parameters[5].Value = model.OrderRemark;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.CreateBy;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.UpdateBy;
            parameters[10].Value = model.UpdateDate;
            parameters[11].Value = model.Id;

            int rows = _db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            int rows = _db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderInfo ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = _db.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetModel(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,StockId,BuyNum,VipNumber,VipScore,OrderPrice,OrderRemark,Status,CreateBy,CreateDate,UpdateBy,UpdateDate from Shop_OrderInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            OrderInfo model = new OrderInfo();
            DataSet ds = _db.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo DataRowToModel(DataRow row)
        {
            OrderInfo model = new OrderInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["StockId"] != null && row["StockId"].ToString() != "")
                {
                    model.StockId = new Guid(row["StockId"].ToString());
                }
                if (row["BuyNum"] != null && row["BuyNum"].ToString() != "")
                {
                    model.BuyNum = int.Parse(row["BuyNum"].ToString());
                }
                if (row["VipNumber"] != null)
                {
                    model.VipNumber = row["VipNumber"].ToString();
                }
                if (row["VipScore"] != null && row["VipScore"].ToString() != "")
                {
                    model.VipScore = int.Parse(row["VipScore"].ToString());
                }
                if (row["OrderPrice"] != null && row["OrderPrice"].ToString() != "")
                {
                    model.OrderPrice = decimal.Parse(row["OrderPrice"].ToString());
                }
                if (row["OrderRemark"] != null)
                {
                    model.OrderRemark = row["OrderRemark"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["CreateBy"] != null && row["CreateBy"].ToString() != "")
                {
                    model.CreateBy = new Guid(row["CreateBy"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateBy"] != null && row["UpdateBy"].ToString() != "")
                {
                    model.UpdateBy = new Guid(row["UpdateBy"].ToString());
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,StockId,BuyNum,VipNumber,VipScore,OrderPrice,OrderRemark,Status,CreateBy,CreateDate,UpdateBy,UpdateDate ");
            strSql.Append(" FROM Shop_OrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return _db.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,StockId,BuyNum,VipNumber,VipScore,OrderPrice,OrderRemark,Status,CreateBy,CreateDate,UpdateBy,UpdateDate ");
            strSql.Append(" FROM Shop_OrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return _db.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Shop_OrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = _db.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Shop_OrderInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return _db.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Shop_OrderInfo";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return _db.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

