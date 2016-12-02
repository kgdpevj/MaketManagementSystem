using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Helper;

namespace BLL
{
    public class DataPagerManager
    {
        private DataPagerService objDataPagerService = new DataPagerService();
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前的页数（第几页）
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount { get; set; }

        public int PageCount
        {
            get
            {
                if(RecordCount != 0)
                {
                    if(RecordCount % PageSize != 0)
                    {
                        return RecordCount / PageSize + 1;
                    }
                    else
                    {
                        return RecordCount / PageSize;
                    }
                }
                else
                {
                    this.CurrentPage = 1;
                    return 0;
                }
            }
        }
        /// <summary>
        /// 实现日志记录的分页查询
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="currentPage">当前需要显示的页码（第几页）</param>
        /// <param name="recordCount">记录的总数</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>符合条件的记录</returns>
        public DataTable QueryLog(string beginTime, string endTime)
        {
            int recordCount = 0;
            DataTable dt = objDataPagerService.QueryLog(PageSize, CurrentPage, out recordCount, beginTime, Convert.ToDateTime(endTime).AddDays(1.0).ToLongDateString());
            this.RecordCount = recordCount;
            return dt;
        }
    }
}
