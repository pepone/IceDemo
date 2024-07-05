using System;
using System.Collections;
using System.Collections.Generic;

using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class Rectangle2DDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a Rectangle2DDto object
        /// </summary>
        /// <returns>a new instance of the Rectangle2DDto object</returns>
        public static Rectangle2DDto CreateInstance()
        {
            var dto = new Rectangle2DDto();
            dto.LowerLeft = new Point2DDto();
            dto.LowerRight = new Point2DDto();
            dto.UpperLeft = new Point2DDto();
            return dto;
        }

        /// <summary>
        /// Factory for a Rectangle2DDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the Rectangle2DDto object</returns>
        public static Rectangle2DDto CreateInstance(Action<Rectangle2DDto> x)
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
                              string.Format("LowerLeft='{0}'", this.LowerLeft),
                              string.Format("LowerRight='{0}'", this.LowerRight),
                              string.Format("UpperLeft='{0}'", this.UpperLeft),
                              ""
                          );
            return result;
        }

        #endregion
    }
}

