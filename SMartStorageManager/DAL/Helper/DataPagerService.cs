using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Helper
{
    public class DataPagerService
    {
        /// <summary>
        /// 实现日志记录的分页查询
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="currentPage">当前需要显示的页码（第几页）</param>
        /// <param name="recordCount">记录的总数</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>符合条件的记录</returns>
        public DataTable QueryLog(int pageSize, int currentPage, out int recordCount, string beginTime, string endTime)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@CurrentPage",currentPage),
                new SqlParameter("@BeginTime",Convert.ToDateTime(beginTime)),
                new SqlParameter("@EndTime",Convert.ToDateTime(endTime))
            };
            DataSet ds = SQLHelper.GetDataSetByProcedure(
                "usp_LogDataPager", param);
            recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }
    }
}
