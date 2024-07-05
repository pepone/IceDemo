using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class Point2DDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a Point2DDto object
        /// </summary>
        /// <returns>a new instance of the Point2DDto object</returns>
        public static Point2DDto CreateInstance()
        {
            var dto = new Point2DDto();
            dto.X = 0;
            dto.Y = 0;
            return dto;
        }

        /// <summary>
        /// Factory for a Point2DDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the Point2DDto object</returns>
        public static Point2DDto CreateInstance(Action<Point2DDto> x)
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
                            string.Format("X='{0}'", this.X),
                            string.Format("Y='{0}'", this.Y),
                            ""
                        );
          return result;
        }

        #endregion
    }
}
 
