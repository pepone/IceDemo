using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{    
    public partial class CreateBreakageRequestDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a InputEventDto object
        /// </summary>
        /// <returns>a new instance of the LineDto object</returns>
        public static CreateBreakageRequestDto CreateInstance()
        {
            var dto = new CreateBreakageRequestDto();
            return dto;
        }

        /// <summary>
        /// Factory for a InputEventDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the InputEventDto object</returns>
        public static CreateBreakageRequestDto CreateInstance(Action<CreateBreakageRequestDto> x)
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
                            string.Format(CultureInfo.InvariantCulture, "BreakageReason='{0}'", this.BreakageReason),
                            string.Format(CultureInfo.InvariantCulture, "BreakageReasonId='{0}'", this.BreakageReasonId),
                            string.Format(CultureInfo.InvariantCulture, "SheetGuid='{0}'", this.SheetGuid),
                            ""
                        );
          return result;
        }
        #endregion
    }
}
 
