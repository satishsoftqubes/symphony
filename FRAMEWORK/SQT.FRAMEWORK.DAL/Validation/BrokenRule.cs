using System;
using System.Collections.Generic;
using System.Text;

namespace SQT.FRAMEWORK.DAL.Validation
{
    
    public class BrokenRule
    {

        #region Data Members

        string _ruleName = string.Empty;
        string _description = string.Empty;
        string _propertyName = string.Empty;

        #endregion

        #region Constructor

        public BrokenRule(ValidateRuleBase rule)
        {
            _ruleName = rule.RuleName;
            _description = rule.Description;
            _propertyName = rule.PropertyName;

        }

        #endregion

        #region Properties

        public string RuleName
        {
            get { return _ruleName; }            
        }

        public string Description
        {
            get { return _description; }            
        }

        public string PropertyName
        {
            get { return _propertyName; }            
        }

        #endregion
    }
}
