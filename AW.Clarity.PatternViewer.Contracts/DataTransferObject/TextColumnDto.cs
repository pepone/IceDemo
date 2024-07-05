using System;
using System.Collections;
using System.Collections.Generic;

using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class TextColumnDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a TextColumnDto object
        /// </summary>
        /// <returns>a new instance of the TextColumnDto object</returns>
        public static TextColumnDto CreateInstance()
        {
            var dto = new TextColumnDto();
            dto.ShowTitle = true;
            dto.Title = "";
            dto.Text = "";

            return dto;
        }

        /// <summary>
        /// Factory for a TextColumnDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the TextColumnDto object</returns>
        public static TextColumnDto CreateInstance(Action<TextColumnDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion

        #region override ToString()
        public override string ToString()
        {
            if (this.ShowTitle)
            {
                return $"'{this.Title}' : '{this.Text}'";
            }
            else
            {
                return $"'({this.Title})' : '{this.Text}'";
            }
        }

        #endregion
    }
}
