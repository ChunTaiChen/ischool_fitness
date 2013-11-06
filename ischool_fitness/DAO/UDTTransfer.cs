using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using FISCA.DSAUtil;

namespace ischool_fitness.DAO
{
    /// <summary>
    /// 處理 UDT 資料
    /// </summary>
    public class UDTTransfer
    {
        /// <summary>
        /// 建立使用到的 UDT Table：主要檢查資料庫有沒有建立UDT，沒有建自動建立。
        /// </summary>
        public static void CreateFitnessUDTTable()
        {
            FISCA.UDT.SchemaManager Manager = new SchemaManager(new DSConnection(FISCA.Authentication.DSAServices.DefaultDataSource));

            // 學生體適能
            Manager.SyncSchema(new  UDT_StudentFitnessRecord());
        }

        /// <summary>
        /// 新增學生體適能
        /// </summary>
        /// <param name="DataList"></param>
        public static void UDTStudentFitnessRecordListInsert(List<UDT_StudentFitnessRecord> DataList)
        {
            if (DataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.InsertValues(DataList);
            }
        }

        /// <summary>
        /// 更新學生體適能
        /// </summary>
        /// <param name="DataList"></param>
        public static void UDTStudentFitnessRecordListUpdate(List<UDT_StudentFitnessRecord> DataList)
        {
            if (DataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.UpdateValues(DataList);
            }
        }

        /// <summary>
        /// 依學生ID 取得學生體適能資料
        /// </summary>
        /// <param name="StudentIDList"></param>
        /// <returns></returns>
        public static List<UDT_StudentFitnessRecord> UDTStudentFitnessRecordListSelectByStudentIDList(List<string> StudentIDList)
        {
            List<UDT_StudentFitnessRecord> dataList = new List<UDT_StudentFitnessRecord>();
            if (StudentIDList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                // 當有 Where 條件寫法
                string query = "ref_student_id in(" + string.Join(",", StudentIDList.ToArray()) + ")";
                dataList = accessHelper.Select<UDT_StudentFitnessRecord>(query);
            }
            return dataList;
        }

        /// <summary>
        /// 刪除學生體適能資料
        /// </summary>
        /// <param name="DataList"></param>
        public static void UDTStudentFitnessRecordListDelete(List<UDT_StudentFitnessRecord> DataList)
        {
            if (DataList.Count > 0)
            {
                foreach (UDT_StudentFitnessRecord data in DataList)
                {
                    // Deleted 設成 true 才會真刪除
                    data.Deleted = true;
                }
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.DeletedValues(DataList);
            }
        }
    }
}
