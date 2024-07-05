using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class LineDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a LineDto object
        /// </summary>
        /// <returns>a new instance of the LineDto object</returns>
        public static LineDto CreateInstance()
        {
            var dto = new LineDto();
            dto.StartX = new DecimalDto();
            dto.StartY = new DecimalDto();
            dto.EndX = new DecimalDto();
            dto.EndY = new DecimalDto();
            dto.Radius = new DecimalDto();
            dto.SegmentNumber = -1;
            return dto;
        }

        /// <summary>
        /// Factory for a LineDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the LineDto object</returns>
        public static LineDto CreateInstance(Action<LineDto> x)
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
                            string.Format("StartX='{0}'", this.StartX),                        
                            string.Format("StartY='{0}'", this.StartY),                        
                            string.Format("EndX='{0}'", this.EndX),                        
                            string.Format("EndY='{0}'", this.EndY),
                            string.Format("SegmentNumber='{0}'", this.SegmentNumber),
                            string.Format("Radius='{0}'", this.Radius),                        
                            string.Format("LineType='{0}'", this.LineType),                        
                            string.Format("TriangleAtCenter='{0}'", this.TriangleAtCenter),                        
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
 
