using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class StepPatternEventDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a InputEventDto object
        /// </summary>
        /// <returns>a new instance of the LineDto object</returns>
        public static StepPatternEventDto CreateInstance()
        {
            var dto = new StepPatternEventDto();
            return dto;
        }

        /// <summary>
        /// Factory for a InputEventDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the InputEventDto object</returns>
        public static StepPatternEventDto CreateInstance(Action<StepPatternEventDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {
          //var result = "Line: " + string.Join("; ", 
          var result = string.Join(", ",
                            string.Format("Pattern='{0}'", this.Pattern),
                            string.Format("PatternDirection='{0}'", this.PatternDirection),
                            ""
                        );
          return result;
        }

        #region CompositeIdToString()
        //prevent circular ToString()
        internal string CompositeIdToString()
        {
            string result = "...";
            return result;
        }
        #endregion
        #endregion
    }
}
 
