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
    public partial class FooterInformationDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a FooterInformationDto object
        /// </summary>
        /// <returns>a new instance of the FooterInformationDto object</returns>
        public static FooterInformationDto CreateInstance()
        {
            var dto = new FooterInformationDto();
            return dto;
        }

        /// <summary>
        /// Factory for a FooterInformationDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the FooterInformationDto object</returns>
        public static FooterInformationDto CreateInstance(Action<FooterInformationDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {          
          var result = string.Join(", ",
                            string.Format(CultureInfo.InvariantCulture, "Text='{0}'", this.Text),
                            string.Format(CultureInfo.InvariantCulture, "Type='{0}'", this.Type),
                            ""
                        );
          return result;
        }

        #endregion
    }
}
 
