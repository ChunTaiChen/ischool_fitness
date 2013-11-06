using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischool_fitness
{
    class Global
    {
        /// <summary>
        /// 所有學生學號與狀態對應的暫存
        /// </summary>
        public static Dictionary<string, int> _AllStudentNumberStatusIDTemp = new Dictionary<string, int>();

        /// <summary>
        /// 當有錯誤訊息
        /// </summary>
        public static StringBuilder _ErrorMessageList = new StringBuilder();

        /// <summary>
        /// 學生狀態資料庫內的對應
        /// </summary>
        public static Dictionary<string, string> _StudentStatusDBDict = new Dictionary<string, string>();
    }
}
