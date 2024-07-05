using System;
using System.Collections;
using System.Collections.Generic;

using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class TextRowDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a TextRowDto object
        /// </summary>
        /// <returns>a new instance of the TextRowDto object</returns>
        public static TextRowDto CreateInstance()
        {
            var dto = new TextRowDto();
            dto.Columns = new List<TextColumnDto>();
                        
            return dto;
        }

        /// <summary>
        /// Factory for a TextRowDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the TextRowDto object</returns>
        public static TextRowDto CreateInstance(Action<TextRowDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion

        #region override ToString()
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
