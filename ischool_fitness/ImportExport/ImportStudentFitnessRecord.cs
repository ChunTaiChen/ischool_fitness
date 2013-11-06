using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using Campus.Import;
using FISCA.UDT;
using System.Xml.Linq;

namespace ischool_fitness.ImportExport
{
    public class ImportStudentFitnessRecord : ImportWizard
    {
        private ImportOption mOption;

        public ImportStudentFitnessRecord()
        {
            this.IsSplit = false;
            this.IsLog = false;
        }
        
        public override ImportAction GetSupportActions()
        {
            return ImportAction.InsertOrUpdate;
        }


        public override string GetValidateRule()
        {
            return Properties.Resources.ImportStudentFitnessRecordVal;
        }

        public override string Import(List<IRowStream> Rows)
        {
            throw new NotImplementedException();
        }

        public override void Prepare(ImportOption Option)
        {
            mOption = Option;         
        }
    }
}
