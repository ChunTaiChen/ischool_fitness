using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_fitness.DAO
{
    /// <summary>
    /// 學生體適能UDT
    /// </summary>
    [TableName("ischool_student_fitness")]
    public class UDT_StudentFitnessRecord : ActiveRecord
    {
        /// <summary>
        ///  學生系統編號
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public int StudentID { get; set; }

        /// <summary>
        ///  學年度
        /// </summary>
        [Field(Field = "school_year", Indexed = false)]
        public int SchoolYear { get; set; }
     
        /// <summary>
        ///  測驗日期
        /// </summary>
        [Field(Field = "test_date", Indexed = false)]
        public DateTime TestDate { get; set; } 

        /// <summary>
        ///  身高
        /// </summary>
        [Field(Field = "height", Indexed = false)]
        public string Height { get; set; }

        /// <summary>
        ///  體重
        /// </summary>
        [Field(Field = "weight", Indexed = false)]
        public string Weight { get; set; }

        /// <summary>
        ///  坐姿體前彎
        /// </summary>
        [Field(Field = "sit_and_reach", Indexed = false)]
        public string SitAndReach { get; set; }

        /// <summary>
        ///  立定跳遠
        /// </summary>
        [Field(Field = "standing_long_jump", Indexed = false)]
        public string StandingLongJump { get; set; }

        /// <summary>
        ///  仰臥起坐
        /// </summary>
        [Field(Field = "sit_up", Indexed = false)]
        public string SitUp { get; set; }

        /// <summary>
        ///  心肺適能
        /// </summary>
        [Field(Field = "cardiorespiratory", Indexed = false)]
        public string Cardiorespiratory { get; set; }

    }
}
