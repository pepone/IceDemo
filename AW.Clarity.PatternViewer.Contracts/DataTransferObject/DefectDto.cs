using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class DefectDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a DefectDto object
        /// </summary>
        /// <returns>a new instance of the DefectDto object</returns>
        public static DefectDto CreateInstance()
        {
            var dto = new DefectDto();
            dto.DefectTooltipText = new System.Collections.Generic.Dictionary<System.String, System.String>();
            return dto;
        }

        /// <summary>
        /// Factory for a DefectDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the DefectDto object</returns>
        public static DefectDto CreateInstance(Action<DefectDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {
            //var result = "Defect: " + string.Join("; ", 
            var result = string.Join(", ",
                              string.Format(CultureInfo.InvariantCulture, "Rectangle='{0}'", this.Rectangle?.CompositeIdToString()),
                              string.Format(CultureInfo.InvariantCulture, "RotationCounterclockwise='{0}'", this.RotationCounterclockwise),
                              string.Format(CultureInfo.InvariantCulture, "DefectTooltipText='{0}'", this.DefectTooltipText),
                              ""
                          );
            return result;
        }

        #endregion
    }
}
 
