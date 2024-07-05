using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class HeaderInformationDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a HeaderInformationDto object
        /// </summary>
        /// <returns>a new instance of the HeaderInformationDto object</returns>
        public static HeaderInformationDto CreateInstance()
        {
            var dto = new HeaderInformationDto();
            dto.Rows = new Ice.Optional<List<TextRowDto>>();

            return dto;
        }

        /// <summary>
        /// Factory for a HeaderInformationDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the HeaderInformationDto object</returns>
        public static HeaderInformationDto CreateInstance(Action<HeaderInformationDto> x)
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
                              $"Text='{this.Text}'",
                              $"Type='{this.Type}'",
                              ""
                          );

            if (this.Rows.HasValue)
            {
                foreach (var row in this.Rows.Value)
                {
                    result = string.Join(
                        result, 
                        row.ToString()
                    );
                }
            }
            return result;
        }

        #endregion
    }
}
 
