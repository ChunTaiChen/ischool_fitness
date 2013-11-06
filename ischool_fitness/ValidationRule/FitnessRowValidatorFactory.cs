using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;

namespace ischool_fitness.ValidationRule
{
    public class FitnessRowValidatorFactory:IRowValidatorFactory
    {
        #region IRowValidatorFactory 成員

        IRowVaildator IRowValidatorFactory.CreateRowValidator(string typeName, System.Xml.XmlElement validatorDescription)
        {
            switch (typeName.ToUpper())
            {
                case "COUNSELSTUDCHECKSTUDENTNUMBERSTATUSVAL":
                    return new RowValidator.StudCheckStudentNumberStatusVal();
                default:
                    return null;
            }
        }

        #endregion
    }
}
