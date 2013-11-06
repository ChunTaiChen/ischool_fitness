using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Data;
using System.Data;

namespace ischool_fitness
{
    public class Utility
    {
        /// <summary>
        /// 取得學生狀態與資料庫數字對應
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetStudentStatusDBValDict()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add("一般", "1");
            retVal.Add("延修", "2");
            retVal.Add("休學", "4");
            retVal.Add("輟學", "8");
            retVal.Add("畢業或離校", "16");
            retVal.Add("刪除", "256");
            retVal.Add("", "1");
            return retVal;
        }

        /// <summary>
        /// 取得所有學生學號_狀態對應 StudentNumber_Status,id
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, int> GetAllStudenNumberStatusDict()
        {
            Dictionary<string, int> retVal = new Dictionary<string, int>();
            QueryHelper qh = new QueryHelper();
            string strSQL = "select student.student_number,student.status,student.id from student;";
            DataTable dt = qh.Select(strSQL);
            foreach (DataRow dr in dt.Rows)
            {
                string key = dr[0].ToString() + "_" + dr[1].ToString();
                int id = int.Parse(dr[2].ToString());
                if (!retVal.ContainsKey(key))
                    retVal.Add(key, id);
            }

            return retVal;
        }
    }
}
