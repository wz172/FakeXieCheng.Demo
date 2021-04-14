using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Models
{
    public enum TripType
    {
        /// <summary>
        /// 酒店+景点
        /// </summary>
        HotelAndAttract,

        /// <summary>
        /// 跟团游
        /// </summary>
        Group,

        /// <summary>
        /// 私家团
        /// </summary>
        PrivateGroup,

        /// <summary>
        /// 自由行
        /// </summary>
        BackPackTour,

        /// <summary>
        /// 半自由行
        /// </summary>
        SemiBackpackTour,

    }
}
