using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class InputEventDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a InputEventDto object
        /// </summary>
        /// <returns>a new instance of the LineDto object</returns>
        public static InputEventDto CreateInstance()
        {
            var dto = new InputEventDto();
            return dto;
        }

        /// <summary>
        /// Factory for a InputEventDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the InputEventDto object</returns>
        public static InputEventDto CreateInstance(Action<InputEventDto> x)
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
                            string.Format("Sheet='{0}'", this.Sheet),                        
                            string.Format("InputType='{0}'", this.InputType),                      
                            string.Format("InputCode='{0}'", this.InputCode),                        
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
 
