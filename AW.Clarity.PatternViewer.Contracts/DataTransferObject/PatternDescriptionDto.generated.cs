using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class PatternDescriptionDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a HeaderInformationDto object
        /// </summary>
        /// <returns>a new instance of the HeaderInformationDto object</returns>
        public static PatternDescriptionDto CreateInstance()
        {
            var dto = new PatternDescriptionDto();
            return dto;
        }

        /// <summary>
        /// Factory for a HeaderInformationDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the HeaderInformationDto object</returns>
        public static PatternDescriptionDto CreateInstance(Action<PatternDescriptionDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {
          //var result = "HeaderInformation: " + string.Join("; ", 
          var result = string.Join(", ",
                            string.Format("Job='{0}'", this.Job),
                            string.Format("Lot='{0}'", this.Lot),
                            string.Format("Pattern='{0}'", this.Pattern),
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
 
