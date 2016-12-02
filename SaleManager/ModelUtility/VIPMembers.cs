using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 超市会员信息表
    /// </summary>
    public class VIPMembers
    {
        //MemberId int identity(100200300,1) primary key,--会员编号
        //MemberName nvarchar(50) not null,--会员姓名
        //Points int default(100) not null,--会员积分
        //PhoneNumber nvarchar(200) not null,--联系电话
        //Address text not null, --联系地址
        //OpenTime datetime default(getdate()) ,--开卡时间
        //Status int not null--状态(1：正常，0：冻结，-1：注销)
        /// <summary>
        /// Status
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 会员积分
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 开卡时间
        /// </summary>
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// 状态
        /// 1：正常
        /// 0：冻结
        /// -1：注销
        /// </summary>
        public int Status { get; set; }
    }
}
